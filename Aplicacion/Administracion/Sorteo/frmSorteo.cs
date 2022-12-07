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

namespace Aplicacion.Administracion.Sorteo
{
    public partial class frmSorteo : Form
    {

        /// <summary>
        /// Atributos del modelo de negocios.
        /// </summary>
        private BussinesSorteo miSorteo;

        /// <summary>
        /// Carga los criterios de búsqueda.
        /// </summary>
        private CargaCritriosSorteo miCargaSorteo;

        /// <summary>
        /// Carga los criterios de búsqueda de sorteo por fecha o por rango de fechas.
        /// </summary>
        private CargaCriterioFechaSorteo miCargaFechaSorteo;

        /// <summary>
        /// Carga los criterios de tiquete múltiple.
        /// </summary>
        private CargaCriterioTiqueteMultiple miCargaTiqueteMultiple;

        /// <summary>
        /// Carga los criterios de aplica venta.
        /// </summary>
        private CargarCriteriosAplicaventa miCargaAplicaventa;

        /// <summary>
        /// Carga los criterios de aplica hora.
        /// </summary>
        private CargaCriterioHora miCargaHora;

        /// <summary>
        /// Carga Filtro de búsqueda de nombre y patrocinador de sorteo;
        /// </summary>
        private CargarCriterioCategoria mifiltroSortoContengaIgual;

        /// <summary>
        /// Carga el primer criterio de búsqueda de sorteo.
        /// </summary>
        private CargaCriterioSorteo miCargaPrimariasorteo;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesTipoSorteo miTipoSorteo;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesCategoria miCategoria;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesMarca miMarca;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesProducto miProducto;

        /// <summary>
        /// Obtiene la fecha de  hoy del sistema
        /// </summary>
        private DateTime hoy;

        /// <summary>
        /// Obtiene las marcas de un sorteo.
        /// </summary>
        private List<Marca> marcas;

        /// <summary>
        /// Obtiene la lista de categorías.
        /// </summary>
        private List<Categoria> categoria;

        /// <summary>
        /// Obtiene la lista producto.
        /// </summary>
        private List<Producto> producto;

        /// <summary>
        /// Probador de Mensaje de error
        /// </summary>
        private ErrorProvider er;

        /// <summary>
        /// Representa un atabla de datos en memoria
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Determina el estado de un contador
        /// </summary>
        private int contador = 0;

        /// <summary>
        /// Obtiene o establece el valor del registro  a seguir en la base de datos
        /// </summary>
        private int rowSorteo;

        /// <summary>
        /// Obtiene o establece el valor máximo de registros.
        /// </summary>
        private int rowMaxSorteo;

        /// <summary>
        /// Obtiene o establece la cantidad de registros en la base de datos.
        /// </summary>
        private long totalRowSorteo;

        /// <summary>
        /// Obtiene o establece la cantidad de páginas.
        /// </summary>
        private long paginaSorteo;

        /// <summary>
        /// Obtiene o establece los registros de sorteo.
        /// </summary>
        private int currenPageSorteo;

        /// <summary>
        /// Obtiene o establece la condición dela búsqueda.
        /// </summary>
        private int interacion;

        /// <summary>
        /// Obtiene o establece al tipo de búsqueda de sorteo.
        /// </summary>
        private int idTipoSorteo;

        /// <summary>
        /// Obtiene o establece el criterio de búsqueda
        /// </summary>
        private int criterioPaginacion;

        /// <summary>
        /// Obtiene o establece el valor para el criterio de búsqueda
        /// </summary>
        private string codigoMarcaCategoriaProducto;

        /// <summary>
        /// Obtiene el valor de id marca en la consulta
        /// </summary>
        private int idMarcaTex;

        /// <summary>
        /// Obtiene o establece el id de la grilla.
        /// </summary>
        private int iddgv;

        /// <summary>
        /// Obtiene o establece la fecha inicio de la búsqueda.
        /// </summary>
        private DateTime fechaInicio;

        /// <summary>
        /// Obtiene o establece la fecha fin de la búsqueda.
        /// </summary>
        private DateTime fechaFin;

        /// <summary>
        /// Establece las condiciones de lista marca, categoría, producto en la validación.
        /// </summary>
        private bool lstmarca = false;
        private bool lstcategoria = false;
        private bool lstProducto = false;

        /// <summary>
        /// Establece la condición de nombre sorteo en la validación.
        /// </summary>
        private bool nombreSorteo = false;

        /// <summary>
        /// Establece la condición de premio en la validación.
        /// </summary>
        private bool premioSorteo = false;

       /// <summary>
        /// Establece la condición de patrocinador en la validación.
        /// </summary>
        private bool patrocinadorSorteo = false;

        /// <summary>
        /// Establece la condición de valor mínimo en la validación.
        /// </summary>
        private bool valorminimo = false;

        /// <summary>
        /// Establece la condición de concepto sorteo en la validación.
        /// </summary>
        private bool conceptosorteo = false;

        /// <summary>
        /// Establece la condición de valor premio sorteo en la validación.
        /// </summary>
        private bool valorpremiosorteo = false;

        /// <summary>
        /// Establece la condición de dtp fechas en la validación.
        /// </summary>
        private bool dtpfechas = false;

        /// <summary>
        /// Establece la condición dtp fechas sorteo en la validación.
        /// </summary>
        private bool dtpfechasorteo = false;

        /// <summary>
        /// Establece la condición de dtp hora en la validación.
        /// </summary>
        private bool dtphora = false;

        /// <summary>
        /// Establece la condición de frm en la validación al abrir un nuevo formulario.
        /// </summary>
        private bool FormEditOpen = false;

        /// <summary>
        /// Establece la condición de consulta en la validación
        /// </summary>
        private bool Consulta = false;

        public frmSorteo()
        {
            InitializeComponent();
            miSorteo = new BussinesSorteo();
            miCategoria = new BussinesCategoria();
            miMarca = new BussinesMarca();
            miTipoSorteo = new BussinesTipoSorteo();
            miProducto = new BussinesProducto();
            miCargaSorteo = new CargaCritriosSorteo();
            miCargaFechaSorteo = new CargaCriterioFechaSorteo();
            miCargaAplicaventa = new CargarCriteriosAplicaventa();
            miCargaTiqueteMultiple = new CargaCriterioTiqueteMultiple();
            mifiltroSortoContengaIgual = new CargarCriterioCategoria();
            miCargaPrimariasorteo = new CargaCriterioSorteo();
            er = new ErrorProvider();
            miCargaHora = new CargaCriterioHora();
            miTabla = General();
            rowMaxSorteo = 8;


        }

        private void frmSorteo_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CargaComboTipoSorteo();
            cbxBuscarSorteo.DataSource = miCargaSorteo.listaSorteo;
            cbxfecha.DataSource = miCargaFechaSorteo.listafechas;
            cbxCriterioBusquedaContengaSeaIgual.DataSource = mifiltroSortoContengaIgual.Lista2;
            cbxAplicaVenta.DataSource = miCargaAplicaventa.listaAplica;
            cbxTipoTiquete.DataSource = miCargaTiqueteMultiple.listaTiquete;
            cbxCriterioTipo.DataSource = miTipoSorteo.ListaTipoSorteo();
            cbxAplicaHora.DataSource = miCargaHora.listahora;
            cbxCriterioBusquedaSorteo.DataSource = miCargaPrimariasorteo.listaCriteriosSorteo;
            txtConsultaMarcaCategoriaProducto.Enabled = false;
            btnAgregarMarcaCategoriaProducto.Enabled = false;
            dgvseleccionMarcaCategoriaSorteo.AutoGenerateColumns = false;
            this.btnBuscarSorteo.Location = new Point(508, 86);
            gxbseleccionar.Text = "Seleccionar Marca.";
            gbxResultadoSorteo.Text = "Sorteos activos.";           

        }

        private void tsbtnGuardarSorteo_Click(object sender, EventArgs e)
        {
            Revalidar();
            var sorteo = new DTO.Clases.Sorteo();
            var aplicaVenta = (int)cbxAplicaVenta.SelectedValue;
            var tiqueteMultiple = (int)cbxTipoTiquete.SelectedValue;
            var aplicahora = (int)cbxAplicaHora.SelectedValue;
            sorteo.IdTipoSorteo = Convert.ToInt32(this.cbxTipoSorteo.SelectedValue);
            if (!ExisteBd(sorteo.IdTipoSorteo))
            {
                if (nombreSorteo && conceptosorteo && patrocinadorSorteo && premioSorteo
                    && valorminimo && valorpremiosorteo && dtpfechas && dtpfechasorteo)
                {
                    try
                    {

                        sorteo.NombreSorteo = txtNombreSorteo.Text;
                        sorteo.FechaInicioSorteo = dtpFechaInicio.Value;
                        sorteo.FechaFinalSorteo = dtpFechaFinal.Value;
                        sorteo.FechaSorteo = dtpFechaSorteo.Value;
                        sorteo.PatrocinadoresSorteo = txtPatrosinadores.Text;
                        sorteo.PremioSorteo = txtPremioSorteo.Text;
                        sorteo.ValorPremio = Convert.ToDouble(txtValorPremio.Text);
                        sorteo.ValorMinimoCompraSorteo = Convert.ToDouble(txtValorMinimo.Text);
                        sorteo.EstadoSorteo = true;
                        if (aplicaVenta == 1)
                        {
                            sorteo.AplicaVenta = true;
                        }
                        else
                        {
                            sorteo.AplicaVenta = false;
                        }
                        if (tiqueteMultiple == 1)
                        {
                            sorteo.TiqueteMultiple = true;
                        }
                        else
                        {
                            sorteo.TiqueteMultiple = false;
                        }
                        if (aplicahora == 2)
                        {
                            sorteo.HoraInicio = dtpHoraInicio.Value;
                            sorteo.HoraFin = dtpHoraFin.Value;
                            sorteo.AplicaHora = true;
                        }
                        else
                        {
                            sorteo.AplicaHora = false;
                            sorteo.HoraInicio = dtpHoraInicio.Value;
                            sorteo.HoraFin = dtpHoraFin.Value;
                        }

                        sorteo.Concepto = txtConcepto.Text;

                        if (sorteo.IdTipoSorteo == 2)
                        {
                            if (dgvseleccionMarcaCategoriaSorteo.RowCount > 0)
                            {
                                ListaMarca();
                                sorteo.Marcas = marcas;
                                lstmarca = true;
                                er.SetError(dgvseleccionMarcaCategoriaSorteo, null);
                            }
                            else
                            {
                                er.SetError(dgvseleccionMarcaCategoriaSorteo, "Debe seleccionar al menos una marca.");
                                lstmarca = false;
                            }
                        }
                        else
                        {
                            if (sorteo.IdTipoSorteo == 3)
                            {
                                if (dgvseleccionMarcaCategoriaSorteo.RowCount > 0)
                                {
                                    ListaCategoria();
                                    sorteo.Categorias = categoria;
                                    lstcategoria = true;
                                    er.SetError(dgvseleccionMarcaCategoriaSorteo, null);
                                }
                                else
                                {
                                    er.SetError(dgvseleccionMarcaCategoriaSorteo, "Debe seleccionar al menos una categoria.");
                                    lstcategoria = false;
                                }
                            }
                            else
                            {
                                if (sorteo.IdTipoSorteo == 4)
                                {
                                    if (dgvseleccionMarcaCategoriaSorteo.RowCount > 0)
                                    {
                                        ListaProducto();
                                        sorteo.Producto = producto;
                                        lstProducto = true;
                                        er.SetError(dgvseleccionMarcaCategoriaSorteo, null);
                                    }
                                    else
                                    {
                                        er.SetError(dgvseleccionMarcaCategoriaSorteo, "Debe seleccionar al menos un producto");
                                        lstProducto = false;
                                    }
                                }
                                if (sorteo.IdTipoSorteo == 5)
                                {
                                    lstmarca = true;
                                }
                            }
                        }
                        if (lstmarca || lstcategoria || lstProducto)
                        {
                            if (aplicahora == 2)
                            {
                                if (dtphora)
                                {
                                    miSorteo.InsertaSorteo(sorteo);
                                    OptionPane.MessageInformation("Se a ingresado el sorteo con exito");
                                    lstcategoria = false;
                                    lstmarca = false;
                                    lstProducto = false;
                                    LimpiaCampos();
                                    miTabla.Clear();
                                }
                            }
                            else
                            {
                                miSorteo.InsertaSorteo(sorteo);
                                OptionPane.MessageInformation("Se a ingresado el sorteo con exito");
                                lstcategoria = false;
                                lstmarca = false;
                                lstProducto = false;
                                LimpiaCampos();
                                miTabla.Clear();

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError("Debe de seleccionar" + ex.Message);
                    }
                }
            }
        }

        private void tsbtbListaSorteo_Click(object sender, EventArgs e)
        {
            dgvseleccionMarcaCategoriaSorteo.AutoGenerateColumns = false;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 16;
            try
            {
                tsbtnEditaSorteo.Enabled = true;
                tsbtnIngresarGanador.Enabled = true;
                tsbtnEliminarSorteo.Enabled = true;
                gbxResultadoSorteo.Text = "Sorteos activos";
                cbxCriterioBusquedaSorteo.SelectedValue = 1;
                var estado = "Activo";
                dgvSorteo.DataSource = miSorteo.ListaSorteo(estado, rowSorteo, rowMaxSorteo);
                if (dgvSorteo.RowCount != 0)
                {
                    dgvSorteo.Columns["Column3"].Visible = false;
                    dgvSorteo.Columns["Column4"].Visible = false;
                    totalRowSorteo = miSorteo.RowsListarEstadoSorteo(estado);
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros a listar.");
                }
                miTabla.Clear();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al listar sorteos activos" + ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        private void tsbtnSorteosJudados_Click(object sender, EventArgs e)
        {

            dgvseleccionMarcaCategoriaSorteo.AutoGenerateColumns = false;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 17;
            try
            {
                tsbtnEditaSorteo.Enabled = true;
                tsbtnIngresarGanador.Enabled = true;
                tsbtnEliminarSorteo.Enabled = true;
                gbxResultadoSorteo.Text = "Sorteos jugados";
                cbxCriterioBusquedaSorteo.SelectedValue = 1;
                var estado = "Inactivo";
                dgvSorteo.DataSource = miSorteo.ListaSorteo(estado, rowSorteo, rowMaxSorteo);
                if (dgvSorteo.RowCount != 0)
                {
                    dgvSorteo.Columns["Column3"].Visible = false;
                    dgvSorteo.Columns["Column4"].Visible = false;
                    totalRowSorteo = miSorteo.RowsListarEstadoSorteo(estado);
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros a listar.");
                }
                miTabla.Clear();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al listar los sorteos Jugados" + ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        private void tsbtnHistorialSorteo_Click(object sender, EventArgs e)
        {
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 18;
            try
            {
                tsbtnEditaSorteo.Enabled = false;
                tsbtnIngresarGanador.Enabled = false;
                tsbtnEliminarSorteo.Enabled = false;
                gbxResultadoSorteo.Text = "Historial de sorteos";
                cbxCriterioBusquedaSorteo.SelectedValue = 2;
                dgvSorteo.AutoGenerateColumns = false;
                dgvSorteo.DataSource = miSorteo.ListaHistorialSorteo(rowSorteo, rowMaxSorteo);
                if (dgvSorteo.RowCount != 0)
                {
                    dgvSorteo.Columns["Column3"].Visible = false;
                    dgvSorteo.Columns["Column4"].Visible = false;
                    totalRowSorteo = miSorteo.RowsListarHistorialSorteo();
                }
                else
                {
                    OptionPane.MessageInformation("No hay registros a listar.");
                }

                miTabla.Clear();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError("Error al listar historial de sorteos" + ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        private void btnBuscarSorteo_Click(object sender, EventArgs e)
        {
            dgvSorteo.AutoGenerateColumns = false;
            int criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            int buscar = (int)cbxBuscarSorteo.SelectedValue;
            int igualContenga = (int)cbxCriterioBusquedaContengaSeaIgual.SelectedValue;
            int tipo = (int)cbxCriterioTipo.SelectedValue;
            int fecha = (int)cbxfecha.SelectedValue;


            if (buscar == 1 && igualContenga == 1)//consulta por nombre que sea igual.
            {
                if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                {
                    er.SetError(txtBuscarSorteo, null);
                    if (criterio == 1)// consulta  sorteo activos.
                    {
                        ConsultarSorteoNombre(txtBuscarSorteo.Text, false);
                    }
                    else// consulta historial sorteo.
                    {
                        ConsultarSorteoNombre(txtBuscarSorteo.Text, true);
                    }
                }
                else
                {
                    er.SetError(txtBuscarSorteo, "El campo es requerido.");
                }
            }
            else
            {
                if (buscar == 1 && igualContenga == 2)// consulta por nombre que contenga.
                {
                    if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                    {
                        er.SetError(txtBuscarSorteo, null);
                        if (criterio == 1)// sorteosactivos.
                        {
                            ListarSorteoNombre(txtBuscarSorteo.Text, false);
                        }
                        else// historialsorteo.
                        {
                            ListarSorteoNombre(txtBuscarSorteo.Text, true);
                        }
                    }
                    else
                    {
                        er.SetError(txtBuscarSorteo, "El campo es requerido.");
                    }
                }
                else
                {
                    if (buscar == 2 && igualContenga == 1)// consulta por patrocinador que sea igual.
                    {
                        if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                        {
                            er.SetError(txtBuscarSorteo, null);

                            if (criterio == 1)//sorteor activos.
                            {
                                ConsultarSorteoPatrocinador(txtBuscarSorteo.Text, false);
                            }
                            else//historial sorteo.
                            {
                                ConsultarSorteoPatrocinador(txtBuscarSorteo.Text, true);
                            }
                        }
                        else
                        {
                            er.SetError(txtBuscarSorteo, "El campo es requerido.");
                        }
                    }
                    else
                    {
                        if (buscar == 2 && igualContenga == 2)// consultar por patrocinador que contenga.
                        {
                            if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                            {
                                er.SetError(txtBuscarSorteo, null);

                                if (criterio == 1)// sorteos activos.
                                {
                                    listarSorteoPatrocinador(txtBuscarSorteo.Text, false);
                                }
                                else// historial sorteo.
                                {
                                    listarSorteoPatrocinador(txtBuscarSorteo.Text, true);
                                }
                            }
                            else
                            {
                                er.SetError(txtBuscarSorteo, "El campo es requerido.");
                            }
                        }
                        else
                        {
                            if (buscar == 3 && tipo == 2)// consulta por tipo marca.
                            {

                                if (criterio == 1)// sorteos activos.
                                {
                                    if (fecha == 1)// fecha simple.
                                    {
                                        if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                        {
                                            ConsultarSorteoMarcaFechas
                                                (tipo, dtpFechaIni.Value, false);
                                        }
                                        else//checked esta inactivo(deschequado).
                                        {
                                            if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                            {

                                                er.SetError(txtBuscarSorteo, null);

                                                ConsultarSorteoMarcaFechas
                                                    (tipo, idMarcaTex, dtpFechaIni.Value, false);

                                            }
                                            else
                                            {
                                                er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                            }
                                        }
                                    }
                                    else// periodos de fechas
                                    {
                                        CambiaFecha();

                                        if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                        {
                                            ConsultarSorteoMarcaPeriodo
                                                (tipo, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                        }
                                        else//checked esta inactivo(deschequado).
                                        {
                                            if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                            {
                                                er.SetError(txtBuscarSorteo, null);

                                                ConsultarSorteoMarcaPeriodo
                                                    (tipo, idMarcaTex, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                            }
                                            else
                                            {
                                                er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                            }
                                        }
                                    }
                                }
                                else// historial sorteo
                                {
                                    if (fecha == 1)// fecha simple.
                                    {
                                        if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                        {
                                            ConsultarSorteoMarcaFechas
                                                (tipo, dtpFechaIni.Value, true);
                                        }
                                        else//checked esta inactivo(deschequado).
                                        {
                                            if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                            {
                                                er.SetError(txtBuscarSorteo, null);

                                                ConsultarSorteoMarcaFechas
                                                    (tipo, idMarcaTex, dtpFechaIni.Value, true);
                                            }
                                            else
                                            {
                                                er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                            }
                                        }
                                    }
                                    else// periodos de fechas
                                    {
                                        CambiaFecha();

                                        if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                        {
                                            ConsultarSorteoMarcaPeriodo
                                                (tipo, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                        }
                                        else//checked esta inactivo(deschequado).
                                        {
                                            if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                            {
                                                er.SetError(txtBuscarSorteo, null);

                                                ConsultarSorteoMarcaPeriodo
                                                    (tipo, idMarcaTex, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                            }
                                            else
                                            {
                                                er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (buscar == 3 && tipo == 3)// consulta por tipo categoria.
                                {
                                    if (criterio == 1)// sorteos activos.
                                    {
                                        if (fecha == 1)// fecha simple.
                                        {
                                            if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                            {
                                                ConsultarSorteoCategoriaFechas
                                                    (tipo, dtpFechaIni.Value, false);
                                            }
                                            else//checked esta inactivo(deschequado).
                                            {
                                                if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                {
                                                    codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                    er.SetError(txtBuscarSorteo, null);

                                                    ConsultarSorteoCategoriaFechas
                                                        (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, false);
                                                }
                                                else
                                                {
                                                    er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                }
                                            }
                                        }
                                        else// periodos de fechas
                                        {
                                            CambiaFecha();

                                            if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                            {
                                                ConsultarSorteoCategoriaPeriodo
                                                    (tipo, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                            }
                                            else//checked esta inactivo(deschequado).
                                            {
                                                if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                {
                                                    codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                    er.SetError(txtBuscarSorteo, null);

                                                    ConsultarSorteoCategoriaPeriodo
                                                        (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                }
                                                else
                                                {
                                                    er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                }
                                            }
                                        }
                                    }
                                    else// historial sorteo
                                    {
                                        if (fecha == 1)// fecha simple.
                                        {
                                            if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                            {
                                                ConsultarSorteoCategoriaFechas
                                                    (tipo, dtpFechaIni.Value, true);
                                            }
                                            else//checked esta inactivo(deschequado).
                                            {
                                                if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                {
                                                    codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                    er.SetError(txtBuscarSorteo, null);
                                                    ConsultarSorteoCategoriaFechas
                                                        (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, true);
                                                }
                                                else
                                                {
                                                    er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                }
                                            }
                                        }
                                        else// periodos de fechas
                                        {
                                            CambiaFecha();

                                            if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                            {
                                                ConsultarSorteoCategoriaPeriodo
                                                    (tipo, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                            }
                                            else//checked esta inactivo(deschequado).
                                            {
                                                if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                {
                                                    codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                    er.SetError(txtBuscarSorteo, null);

                                                    ConsultarSorteoCategoriaPeriodo
                                                        (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                }
                                                else
                                                {
                                                    er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (buscar == 3 && tipo == 4)// consulta por tipo producto.
                                    {
                                        if (criterio == 1)// sorteos activos.
                                        {
                                            if (fecha == 1)// fecha simple.
                                            {
                                                if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                                {
                                                    ConsultarSorteoProductoFechas
                                                        (tipo, dtpFechaIni.Value, false);
                                                }
                                                else//checked esta inactivo(deschequado).
                                                {
                                                    if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                    {
                                                        codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                        er.SetError(txtBuscarSorteo, null);

                                                        ConsultarSorteoProductoFechas
                                                            (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, false);
                                                    }
                                                    else
                                                    {
                                                        er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                    }
                                                }
                                            }
                                            else// periodos de fechas
                                            {
                                                CambiaFecha();

                                                if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                                {
                                                    ConsultarSorteoProductoPeriodo
                                                        (tipo, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                }
                                                else//checked esta inactivo(deschequado).
                                                {
                                                    if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                    {
                                                        codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                        er.SetError(txtBuscarSorteo, null);

                                                        ConsultarSorteoProductoPeriodo
                                                            (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                    }
                                                    else
                                                    {
                                                        er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                    }
                                                }
                                            }
                                        }
                                        else// historial sorteo
                                        {
                                            if (fecha == 1)// fecha simple.
                                            {
                                                if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                                {
                                                    ConsultarSorteoProductoFechas
                                                        (tipo, dtpFechaIni.Value, true);
                                                }
                                                else//checked esta inactivo(deschequado).
                                                {
                                                    if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                    {
                                                        codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                        er.SetError(txtBuscarSorteo, null);

                                                        ConsultarSorteoProductoFechas
                                                            (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, true);
                                                    }
                                                    else
                                                    {
                                                        er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                    }
                                                }
                                            }
                                            else// periodos de fechas
                                            {
                                                CambiaFecha();

                                                if (chbxListarTodo.Checked)// checked esta activo(chequeado).
                                                {
                                                    ConsultarSorteoProductoPeriodo
                                                        (tipo, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                }
                                                else//checked esta inactivo(deschequado).
                                                {
                                                    if (!String.IsNullOrEmpty(txtBuscarSorteo.Text))
                                                    {
                                                        codigoMarcaCategoriaProducto = txtBuscarSorteo.Text;

                                                        er.SetError(txtBuscarSorteo, null);
                                                        ConsultarSorteoProductoPeriodo
                                                            (tipo, codigoMarcaCategoriaProducto, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                    }
                                                    else
                                                    {
                                                        er.SetError(txtBuscarSorteo, "El campo es requerido.");
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (buscar == 3 && tipo == 5)//consulta factura
                                        {
                                            if (criterio == 1)// sorteos activos
                                            {
                                                if (fecha == 1)// fecha simple
                                                {
                                                    if (chbxListarTodo.Checked)// checked esta activo(cheqeado)
                                                    {
                                                        ConsultarSorteoFacturaFechas
                                                            (tipo, dtpFechaIni.Value, false);
                                                    }
                                                    else //checked esta inactivo(deschequado)
                                                    {
                                                        ConsultarSorteoFacturaFechas
                                                            (tipo, dtpFechaIni.Value, false);
                                                    }
                                                }
                                                else// periodos de fechas
                                                {
                                                    CambiaFecha();

                                                    if (chbxListarTodo.Checked)// checked esta activo(cheqeado)
                                                    {
                                                        ConsultarSorteoFacturaPeriodo
                                                            (tipo, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                    }
                                                    else//checked esta inactivo(deschequado)
                                                    {
                                                        ConsultarSorteoFacturaPeriodo
                                                               (tipo, dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                    }
                                                }
                                            }
                                            else// historial sorteo
                                            {
                                                if (fecha == 1)// fecha simple
                                                {
                                                    if (chbxListarTodo.Checked)// checked esta activo(cheqeado)
                                                    {
                                                        ConsultarSorteoFacturaFechas
                                                            (tipo, dtpFechaIni.Value, true);
                                                    }
                                                    else //checked esta inactivo(deschequado)
                                                    {
                                                        ConsultarSorteoFacturaFechas
                                                            (tipo, dtpFechaIni.Value, true);
                                                    }
                                                }
                                                else// periodos de fechas
                                                {
                                                    CambiaFecha();

                                                    if (chbxListarTodo.Checked)// checked esta activo(cheqeado)
                                                    {
                                                        ConsultarSorteoFacturaPeriodo
                                                            (tipo, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                    }
                                                    else//checked esta inactivo(deschequado)
                                                    {
                                                        ConsultarSorteoFacturaPeriodo
                                                               (tipo, dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (buscar == 4)// consulta fechas
                                            {
                                                if (criterio == 1)// sorteos activos
                                                {
                                                    ConsultarSorteofechas
                                                        (dtpFechaIni.Value, false);
                                                }
                                                else// historial sorteo
                                                {
                                                    ConsultarSorteofechas
                                                        (dtpFechaIni.Value, true);
                                                }
                                            }


                                            else
                                            {
                                                if (buscar == 5)//consulta periodos de fecha
                                                {
                                                    CambiaFecha();

                                                    if (criterio == 1)// sorteos activos
                                                    {
                                                        ConsultarSorteoPeriodo
                                                            (dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                    }
                                                    else//periodos de fecha
                                                    {
                                                        ConsultarSorteoPeriodo
                                                            (dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                    }
                                                }
                                                else
                                                {
                                                    if (buscar == 6)//consulta inicializacion de sorteo
                                                    {
                                                        if (fecha == 1)// fecha simple
                                                        {
                                                            if (criterio == 1)//sorteos activos
                                                            {
                                                                ConsultarSorteoInicializacion
                                                                    (dtpFechaIni.Value, false);
                                                                if (dgvSorteo.RowCount != 0)
                                                                {
                                                                    dgvSorteo.Columns["Column3"].Visible = true;
                                                                    dgvSorteo.Columns["Column4"].Visible = false;
                                                                }
                                                            }
                                                            else// historial sorteo
                                                            {
                                                                ConsultarSorteoInicializacion
                                                                    (dtpFechaIni.Value, true);
                                                                if (dgvSorteo.RowCount != 0)
                                                                {
                                                                    dgvSorteo.Columns["Column3"].Visible = true;
                                                                    dgvSorteo.Columns["Column4"].Visible = false;
                                                                }
                                                            }
                                                        }
                                                        else//periodos de fecha
                                                        {
                                                            CambiaFecha();

                                                            if (criterio == 1)//sorteos activos
                                                            {
                                                                ConsultarSorteoInicializacionPeriodo
                                                                    (dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                                if (dgvSorteo.RowCount != 0)
                                                                {
                                                                    dgvSorteo.Columns["Column3"].Visible = true;
                                                                    dgvSorteo.Columns["Column4"].Visible = false;
                                                                }
                                                            }
                                                            else// historial sorteos
                                                            {
                                                                ConsultarSorteoInicializacionPeriodo
                                                                    (dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                                if (dgvSorteo.RowCount != 0)
                                                                {
                                                                    dgvSorteo.Columns["Column3"].Visible = true;
                                                                    dgvSorteo.Columns["Column4"].Visible = false;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (buscar == 7)// consulta finalizacion de sorteo
                                                        {
                                                            if (fecha == 1)//fecha simple
                                                            {
                                                                if (criterio == 1)//sorteos activos
                                                                {
                                                                    ConsultarSorteoFinalizacion
                                                                        (dtpFechaIni.Value, false);
                                                                    if (dgvSorteo.RowCount != 0)
                                                                    {
                                                                        dgvSorteo.Columns["Column3"].Visible = false;
                                                                        dgvSorteo.Columns["Column4"].Visible = true;
                                                                    }
                                                                }
                                                                else// historial sorteo
                                                                {
                                                                    ConsultarSorteoFinalizacion
                                                                        (dtpFechaIni.Value, true);
                                                                    if (dgvSorteo.RowCount != 0)
                                                                    {
                                                                        dgvSorteo.Columns["Column3"].Visible = false;
                                                                        dgvSorteo.Columns["Column4"].Visible = true;
                                                                    }
                                                                }
                                                            }
                                                            else//periodos de fecha
                                                            {
                                                                CambiaFecha();

                                                                if (criterio == 1)//sorteos activos
                                                                {
                                                                    ConsultarSorteoFinalizacionPeriodo
                                                                        (dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                                    if (dgvSorteo.RowCount != 0)
                                                                    {
                                                                        dgvSorteo.Columns["Column3"].Visible = false;
                                                                        dgvSorteo.Columns["Column4"].Visible = true;
                                                                    }
                                                                }
                                                                else//historial sorteo
                                                                {
                                                                    ConsultarSorteoFinalizacionPeriodo
                                                                        (dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                                    if (dgvSorteo.RowCount != 0)
                                                                    {
                                                                        dgvSorteo.Columns["Column3"].Visible = false;
                                                                        dgvSorteo.Columns["Column4"].Visible = true;
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (buscar == 8)// consulta fechas de sorteo
                                                            {
                                                                if (fecha == 1)// fecha simple
                                                                {
                                                                    if (criterio == 1)// sorteos activos
                                                                    {
                                                                        ConsultarSorteoSorteo
                                                                            (dtpFechaIni.Value, false);
                                                                        if (dgvSorteo.RowCount != 0)
                                                                        {
                                                                            dgvSorteo.Columns["Column3"].Visible = false;
                                                                            dgvSorteo.Columns["Column4"].Visible = false;
                                                                        }
                                                                    }
                                                                    else//historial de sorteos
                                                                    {
                                                                        ConsultarSorteoSorteo
                                                                            (dtpFechaIni.Value, true);
                                                                        if (dgvSorteo.RowCount != 0)
                                                                        {
                                                                            dgvSorteo.Columns["Column3"].Visible = false;
                                                                            dgvSorteo.Columns["Column4"].Visible = false;
                                                                        }
                                                                    }
                                                                }
                                                                else//periodos de fecha
                                                                {
                                                                    CambiaFecha();

                                                                    if (criterio == 1)
                                                                    {
                                                                        ConsultarSorteoSorteoPeriodo
                                                                            (dtpFechaIni.Value, dtpFechaFin.Value, false);
                                                                        if (dgvSorteo.RowCount != 0)
                                                                        {
                                                                            dgvSorteo.Columns["Column3"].Visible = false;
                                                                            dgvSorteo.Columns["Column4"].Visible = false;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        ConsultarSorteoSorteoPeriodo
                                                                            (dtpFechaIni.Value, dtpFechaFin.Value, true);
                                                                        if (dgvSorteo.RowCount != 0)
                                                                        {
                                                                            dgvSorteo.Columns["Column3"].Visible = false;
                                                                            dgvSorteo.Columns["Column4"].Visible = false;
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
                                }
                            }
                        }
                    }
                }
            }
            if (dgvSorteo.RowCount == 0)
            {
                OptionPane.MessageInformation("No se encontraron registros");
            }
        }

        private void btnAgregarMarcaCategoriaProducto_Click(object sender, EventArgs e)
        {
            var critero = (int)cbxTipoSorteo.SelectedValue;
            if (!String.IsNullOrEmpty(txtConsultaMarcaCategoriaProducto.Text))
            {
                er.SetError(txtConsultaMarcaCategoriaProducto, null);

                if (dgvseleccionMarcaCategoriaSorteo.RowCount != 0)
                {
                    if (critero == 3)
                    {
                        var row = ConsultaCategoria(txtConsultaMarcaCategoriaProducto.Text);
                        if (row != null)
                        {
                            miTabla.Rows.Add(row);
                        }
                        dgvseleccionMarcaCategoriaSorteo.DataSource = miTabla;
                        txtConsultaMarcaCategoriaProducto.Text = "";
                    }
                    else
                    {
                        if (critero == 4)
                        {
                            var row_ = ConsultaProducto(txtConsultaMarcaCategoriaProducto.Text);
                            if (row_ != null)
                            {
                                miTabla.Rows.Add(row_);
                            }
                            dgvseleccionMarcaCategoriaSorteo.DataSource = miTabla;
                            txtConsultaMarcaCategoriaProducto.Text = "";
                        }
                    }
                }
                else
                {
                    var row__ = ConsultaCategoriaProductoExistebd(critero);
                    if (row__ != null)
                    {
                        miTabla.Rows.Add(row__);
                    }

                    dgvseleccionMarcaCategoriaSorteo.DataSource = miTabla;
                    txtConsultaMarcaCategoriaProducto.Text = "";
                }
                if (critero == 2)
                {
                    Configuracion.Marcas.frmMarca marca = new Configuracion.Marcas.frmMarca();
                    marca.CargaGrillaMarca();

                    marca.Show();
                }

            }

            else
            {
                er.SetError(txtConsultaMarcaCategoriaProducto, "El campo es requerido.");
            }
        }

        private void btnBuscarMarcaCategoriaProducto_Click(object sender, EventArgs e)
        {
            var criterio = (int)this.cbxTipoSorteo.SelectedValue;
            if (criterio == 2)
            {
                Consulta = false;
                Configuracion.Marcas.frmMarca marca =
                    new Configuracion.Marcas.frmMarca();
                marca.CargaGrillaMarca();
                marca.Extension = true;
                marca.Show();
            }
            else
            {
                if (criterio == 3)
                {
                    Inventario.Categoria.FrmCategoria categoria =
                        new Inventario.Categoria.FrmCategoria();
                    categoria.CargarGridCategorias();
                    categoria.Extencion = true;
                    categoria.Show();

                }
                else
                {
                    if (criterio == 4)
                    {
                        Inventario.Producto.FrmIngresarProducto producto =
                            new Inventario.Producto.FrmIngresarProducto();
                        producto.Show();
                    }

                }
            }
        }

        private void chbxListarTodo_Click(object sender, EventArgs e)
        {
            if (chbxListarTodo.Checked)
            {
                txtBuscarSorteo.Enabled = false;
                btnConsultaMarcaCatgoriaProducto.Enabled = false;

            }
            else
            {
                txtBuscarSorteo.Enabled = true;
                btnConsultaMarcaCatgoriaProducto.Enabled = true;
            }

        }

        private void btnConsultaMarcaCatgoriaProducto_Click(object sender, EventArgs e)
        {
            Consulta = true;
            var tipo = (int)cbxCriterioTipo.SelectedValue;
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
                // mirar consulta factura.
            }
        }

        private void tsbtnInicio_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            //ir inicio
            if (currenPageSorteo > 1)
            {
                var paginaActual = currenPageSorteo;
                for (int i = paginaActual; i > 1; i--)
                {
                    rowSorteo = rowSorteo - rowMaxSorteo;
                    currenPageSorteo--;
                }
                try
                {
                    if (interacion == 1)
                    {
                        if (criterio == 1)
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                        }
                        else
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                    (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                        }
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            if (criterio == 1)
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                            }
                            else
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                            }
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                if (criterio == 1)
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                }
                                else
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                }
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    if (criterio == 1)
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                    }
                                    else
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                    }
                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        if (criterio == 1)
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                        }
                                        else
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                        }
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            if (criterio == 1)
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                            }
                                            else
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                            }
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                if (criterio == 1)
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                }
                                                else
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                }
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    if (criterio == 1)
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                    }
                                                    else
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                    }
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        if (criterio == 1)
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                        }
                                                        else
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (interacion == 10)
                                                        {
                                                            if (criterio == 1)
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                            }
                                                            else
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                        (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (interacion == 11)
                                                            {
                                                                if (criterio == 1)
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                                }
                                                                else
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (interacion == 12)
                                                                {
                                                                    if (criterio == 1)
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                            (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                    else
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                           (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (interacion == 13)
                                                                    {
                                                                        if (criterio == 1)
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                        else
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (interacion == 14)
                                                                        {
                                                                            if (criterio == 1)
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                            else
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (interacion == 15)
                                                                            {
                                                                                if (criterio == 1)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                        (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                       (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (interacion == 16)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ListaSorteo("Activo", rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (interacion == 17)
                                                                                    {
                                                                                        dgvSorteo.DataSource = miSorteo.ListaSorteo("Inactivo", rowSorteo, rowMaxSorteo);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (interacion == 18)
                                                                                        {
                                                                                            dgvSorteo.DataSource = miSorteo.ListaHistorialSorteo(rowSorteo, rowMaxSorteo);
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
                tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
            }
        }

        private void tsbtnAtras_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            //ir atras
            if (currenPageSorteo > 1)
            {
                try
                {
                    rowSorteo = rowSorteo - rowMaxSorteo;
                    if (rowSorteo <= 0)
                        rowSorteo = 0;
                    if (interacion == 1)
                    {
                        if (criterio == 1)
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                        }
                        else
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                    (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                        }
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            if (criterio == 1)
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                            }
                            else
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                            }
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                if (criterio == 1)
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                }
                                else
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                }
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    if (criterio == 1)
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                    }
                                    else
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                    }
                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        if (criterio == 1)
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                        }
                                        else
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                        }
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            if (criterio == 1)
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                            }
                                            else
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                            }
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                if (criterio == 1)
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                }
                                                else
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                }
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    if (criterio == 1)
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                    }
                                                    else
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                    }
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        if (criterio == 1)
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                        }
                                                        else
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (interacion == 10)
                                                        {
                                                            if (criterio == 1)
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                            }
                                                            else
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                        (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (interacion == 11)
                                                            {
                                                                if (criterio == 1)
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                                }
                                                                else
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (interacion == 12)
                                                                {
                                                                    if (criterio == 1)
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                            (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                    else
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                           (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (interacion == 13)
                                                                    {
                                                                        if (criterio == 1)
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                        else
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (interacion == 14)
                                                                        {
                                                                            if (criterio == 1)
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                            else
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (interacion == 15)
                                                                            {
                                                                                if (criterio == 1)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                        (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                       (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (interacion == 16)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ListaSorteo("Activo", rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (interacion == 17)
                                                                                    {
                                                                                        dgvSorteo.DataSource = miSorteo.ListaSorteo("Inactivo", rowSorteo, rowMaxSorteo);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (interacion == 18)
                                                                                        {
                                                                                            dgvSorteo.DataSource = miSorteo.ListaHistorialSorteo(rowSorteo, rowMaxSorteo);
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
                currenPageSorteo--;
                tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
            }
        }

        private void tsbtnSiguiente_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            // siguiente
            if (currenPageSorteo < paginaSorteo)
            {
                rowSorteo = rowSorteo + rowMaxSorteo;
                try
                {
                    if (interacion == 1)
                    {
                        if (criterio == 1)
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                        }
                        else
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                    (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                        }
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            if (criterio == 1)
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                            }
                            else
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                            }
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                if (criterio == 1)
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                }
                                else
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                }
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    if (criterio == 1)
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                    }
                                    else
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                    }
                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        if (criterio == 1)
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                        }
                                        else
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                        }
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            if (criterio == 1)
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                            }
                                            else
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                            }
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                if (criterio == 1)
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                }
                                                else
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                }
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    if (criterio == 1)
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                    }
                                                    else
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                    }
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        if (criterio == 1)
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                        }
                                                        else
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (interacion == 10)
                                                        {
                                                            if (criterio == 1)
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                            }
                                                            else
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                        (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (interacion == 11)
                                                            {
                                                                if (criterio == 1)
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                                }
                                                                else
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (interacion == 12)
                                                                {
                                                                    if (criterio == 1)
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                            (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                    else
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                           (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (interacion == 13)
                                                                    {
                                                                        if (criterio == 1)
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                        else
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (interacion == 14)
                                                                        {
                                                                            if (criterio == 1)
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                            else
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (interacion == 15)
                                                                            {
                                                                                if (criterio == 1)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                        (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                       (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (interacion == 16)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ListaSorteo("Activo", rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (interacion == 17)
                                                                                    {
                                                                                        dgvSorteo.DataSource = miSorteo.ListaSorteo("Inactivo", rowSorteo, rowMaxSorteo);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (interacion == 18)
                                                                                        {
                                                                                            dgvSorteo.DataSource = miSorteo.ListaHistorialSorteo(rowSorteo, rowMaxSorteo);
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
                currenPageSorteo++;
                tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
            }
        }

        private void tsbtnFinal_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            // ir ultima
            if (currenPageSorteo < paginaSorteo)
            {
                var paginaActual = currenPageSorteo;
                for (int i = paginaActual; i < paginaSorteo; i++)
                {
                    rowSorteo = rowSorteo + rowMaxSorteo;
                    currenPageSorteo++;
                }
                try
                {
                    if (interacion == 1)
                    {
                        if (criterio == 1)
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                        }
                        else
                        {
                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                                    (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                        }
                    }
                    else
                    {
                        if (interacion == 2)
                        {
                            if (criterio == 1)
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                            }
                            else
                            {
                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                    (idTipoSorteo, Convert.ToInt32(codigoMarcaCategoriaProducto), fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                            }
                        }
                        else
                        {
                            if (interacion == 3)
                            {
                                if (criterio == 1)
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                }
                                else
                                {
                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                                        (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                }
                            }
                            else
                            {
                                if (interacion == 4)
                                {
                                    if (criterio == 1)
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                    }
                                    else
                                    {
                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                                            (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                    }
                                }
                                else
                                {
                                    if (interacion == 5)
                                    {
                                        if (criterio == 1)
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                        }
                                        else
                                        {
                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                        }
                                    }
                                    else
                                    {
                                        if (interacion == 6)
                                        {
                                            if (criterio == 1)
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                            }
                                            else
                                            {
                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                                                    (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                            }
                                        }
                                        else
                                        {
                                            if (interacion == 7)
                                            {
                                                if (criterio == 1)
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                }
                                                else
                                                {
                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                                                        (idTipoSorteo, fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                }
                                            }
                                            else
                                            {
                                                if (interacion == 8)
                                                {
                                                    if (criterio == 1)
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                    }
                                                    else
                                                    {
                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                            (idTipoSorteo, codigoMarcaCategoriaProducto, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                    }
                                                }
                                                else
                                                {
                                                    if (interacion == 9)
                                                    {
                                                        if (criterio == 1)
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                        }
                                                        else
                                                        {
                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                                                                (idTipoSorteo, fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (interacion == 10)
                                                        {
                                                            if (criterio == 1)
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                            }
                                                            else
                                                            {
                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                        (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (interacion == 11)
                                                            {
                                                                if (criterio == 1)
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, false, rowSorteo, rowMaxSorteo);
                                                                }
                                                                else
                                                                {
                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                                                                        (fechaInicio, true, rowSorteo, rowMaxSorteo);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (interacion == 12)
                                                                {
                                                                    if (criterio == 1)
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                            (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                    else
                                                                    {
                                                                        dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                                                                           (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (interacion == 13)
                                                                    {
                                                                        if (criterio == 1)
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                        else
                                                                        {
                                                                            dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                                                                                (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (interacion == 14)
                                                                        {
                                                                            if (criterio == 1)
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                            else
                                                                            {
                                                                                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                                                                                    (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (interacion == 15)
                                                                            {
                                                                                if (criterio == 1)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                        (fechaInicio, fechaFin, false, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                                                                                       (fechaInicio, fechaFin, true, rowSorteo, rowMaxSorteo);
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (interacion == 16)
                                                                                {
                                                                                    dgvSorteo.DataSource = miSorteo.ListaSorteo("Activo", rowSorteo, rowMaxSorteo);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (interacion == 17)
                                                                                    {
                                                                                        dgvSorteo.DataSource = miSorteo.ListaSorteo("Inactivo", rowSorteo, rowMaxSorteo);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (interacion == 18)
                                                                                        {
                                                                                            dgvSorteo.DataSource = miSorteo.ListaHistorialSorteo(rowSorteo, rowMaxSorteo);
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
                tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
            }
        }

        private void cbxAplicaHora_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var criterio = (int)cbxAplicaHora.SelectedValue;
            if (criterio == 1)
            {
                lblHoraInicio.Enabled = false;
                lblHoraFin.Enabled = false;
                dtpHoraInicio.Enabled = false;
                dtpHoraFin.Enabled = false;
            }
            else
            {
                if (criterio == 2)
                {
                    lblHoraInicio.Enabled = true;
                    lblHoraFin.Enabled = true;
                    dtpHoraInicio.Enabled = true;
                    dtpHoraFin.Enabled = true;
                }
            }
        }

        private void cbxBuscarSorteo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int criterio1 = Convert.ToInt32(this.cbxBuscarSorteo.SelectedValue);

            if (criterio1 < 3)
            {
                dgvSorteo.DataSource = null;
                limpiaObjeto();
                this.cbxCriterioTipo.Visible = false;
                this.cbxfecha.Enabled = false;
                this.dtpFechaFin.Enabled = false;
                this.dtpFechaIni.Enabled = false;
                this.txtBuscarSorteo.Visible = true;
                this.txtBuscarSorteo.Enabled = true;
                this.btnBuscarSorteo.Enabled = true;
                this.cbxCriterioBusquedaContengaSeaIgual.Enabled = true;
                this.cbxCriterioBusquedaContengaSeaIgual.Visible = true;
                this.txtBuscarSorteo.Enabled = true;
                this.chbxListarTodo.Enabled = false;
                this.btnConsultaMarcaCatgoriaProducto.Enabled = false;


            }
            if (criterio1 == 3)
            {
                dgvSorteo.DataSource = null;
                limpiaObjeto();
                this.cbxCriterioTipo.Enabled = true;
                this.cbxCriterioTipo.Visible = true;
                this.chbxListarTodo.Enabled = true;
                this.btnConsultaMarcaCatgoriaProducto.Enabled = true;
                this.cbxCriterioBusquedaContengaSeaIgual.Visible = false;
                this.cbxfecha.Enabled = true;
                this.dtpFechaIni.Enabled = true;
                this.txtBuscarSorteo.Enabled = false;
                this.txtBuscarSorteo.Enabled = false;
                this.dtpFechaFin.Enabled = false;
                this.cbxCriterioBusquedaContengaSeaIgual.Enabled = false;

            }
            if (criterio1 == 4)
            {
                dgvSorteo.DataSource = null;
                limpiaObjeto();
                this.cbxCriterioTipo.Enabled = false;
                this.cbxfecha.Enabled = false;
                this.chbxListarTodo.Enabled = false;
                this.txtBuscarSorteo.Enabled = true;
                this.txtBuscarSorteo.Enabled = false;
                this.btnConsultaMarcaCatgoriaProducto.Enabled = false;
                this.dtpFechaIni.Enabled = true;
                this.dtpFechaFin.Enabled = false;
                this.btnBuscarSorteo.Enabled = true;
                this.cbxCriterioBusquedaContengaSeaIgual.Enabled = false;
                this.chbxListarTodo.Enabled = false;

            }
            if (criterio1 == 5)
            {
                dgvSorteo.DataSource = null;
                limpiaObjeto();
                this.cbxCriterioTipo.Enabled = false;
                this.cbxfecha.Enabled = false;
                this.chbxListarTodo.Enabled = false;
                this.txtBuscarSorteo.Enabled = true;
                this.txtBuscarSorteo.Enabled = false;
                this.btnConsultaMarcaCatgoriaProducto.Enabled = false;
                this.dtpFechaIni.Enabled = true;
                this.dtpFechaFin.Enabled = true;
                this.btnBuscarSorteo.Enabled = true;
                this.cbxCriterioBusquedaContengaSeaIgual.Enabled = false;
                this.chbxListarTodo.Enabled = false;
            }
            if (criterio1 > 5)
            {
                dgvSorteo.DataSource = null;
                limpiaObjeto();
                this.cbxCriterioTipo.Enabled = false;
                this.cbxfecha.Enabled = true;
                this.chbxListarTodo.Enabled = false;
                this.txtBuscarSorteo.Enabled = true;
                this.txtBuscarSorteo.Enabled = false;
                this.btnConsultaMarcaCatgoriaProducto.Enabled = false;
                this.dtpFechaIni.Enabled = true;
                this.dtpFechaFin.Enabled = false;
                this.btnBuscarSorteo.Enabled = true;
                this.cbxCriterioBusquedaContengaSeaIgual.Enabled = false;
                this.chbxListarTodo.Enabled = false;
            }
        }

        private void cbxfecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int criterio1 = (int)cbxfecha.SelectedValue;

            if (criterio1 == 1)
            {
                this.dtpFechaFin.Enabled = false;

            }
            else
            {
                this.dtpFechaFin.Enabled = true;
            }

        }

        private void cbxCriterioTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var tipo = (int)cbxCriterioTipo.SelectedValue;
            if (tipo == 2)
            {
                limpiaObjeto();

                if (chbxListarTodo.Checked)
                {
                    txtBuscarSorteo.Enabled = false;
                    btnConsultaMarcaCatgoriaProducto.Enabled = false;
                }
                else
                {
                    txtBuscarSorteo.Enabled = false;
                    btnConsultaMarcaCatgoriaProducto.Enabled = true;
                }
            }
            else
            {
                if (tipo == 3)
                {
                    limpiaObjeto();

                    if (chbxListarTodo.Checked)
                    {
                        txtBuscarSorteo.Enabled = false;
                        btnConsultaMarcaCatgoriaProducto.Enabled = false;
                    }
                    else
                    {
                        txtBuscarSorteo.Enabled = true;
                        btnConsultaMarcaCatgoriaProducto.Enabled = true;
                    }
                }
                else
                {
                    if (tipo == 4)
                    {
                        limpiaObjeto();

                        if (chbxListarTodo.Checked)
                        {
                            txtBuscarSorteo.Enabled = false;
                            btnConsultaMarcaCatgoriaProducto.Enabled = false;
                        }
                        else
                        {
                            txtBuscarSorteo.Enabled = true;
                            btnConsultaMarcaCatgoriaProducto.Enabled = true;
                        }
                    }
                    else
                    {
                        limpiaObjeto();

                        if (chbxListarTodo.Checked)
                        {
                            txtBuscarSorteo.Enabled = false;
                            btnConsultaMarcaCatgoriaProducto.Enabled = false;
                        }
                        else
                        {
                            txtBuscarSorteo.Enabled = false;
                            btnConsultaMarcaCatgoriaProducto.Enabled = true;
                        }
                    }
                }
            }
        }

        private void cbxTipoSorteo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int Criterio1 = (int)cbxTipoSorteo.SelectedValue;

            if (Criterio1 == 2)
            {
                cbxAplicaVenta.DataSource = miCargaAplicaventa.listaAplica;
                gxbseleccionar.Text = "Seleccionar Marca.";
                cbxTipoTiquete.SelectedValue = 1;
                gxbseleccionar.Enabled = true;
                cbxTipoTiquete.Enabled = true;
                txtConsultaMarcaCategoriaProducto.Enabled = false;
                btnAgregarMarcaCategoriaProducto.Enabled = false;
                miTabla.Clear();

            }
            else
            {
                if (Criterio1 == 3)
                {
                    cbxAplicaVenta.DataSource = miCargaAplicaventa.listaAplica;
                    gxbseleccionar.Text = "Seleccionar Categoria";
                    cbxTipoTiquete.SelectedValue = 1;
                    cbxTipoTiquete.Enabled = true;
                    txtConsultaMarcaCategoriaProducto.Enabled = true;
                    btnAgregarMarcaCategoriaProducto.Enabled = true;
                    gxbseleccionar.Enabled = true;
                    miTabla.Clear();
                }
                else
                {
                    if (Criterio1 == 4)
                    {
                        cbxAplicaVenta.DataSource = miCargaAplicaventa.listaAplica;
                        gxbseleccionar.Text = "Seleccionar Productos";
                        cbxTipoTiquete.SelectedValue = 1;
                        cbxTipoTiquete.Enabled = true;
                        txtConsultaMarcaCategoriaProducto.Enabled = true;
                        btnAgregarMarcaCategoriaProducto.Enabled = true;
                        gxbseleccionar.Enabled = true;
                        miTabla.Clear();
                    }
                    else
                    {
                        if (Criterio1 == 5)
                        {
                            cbxAplicaVenta.DataSource = miCargaAplicaventa.listaAplica2;
                            cbxTipoTiquete.SelectedValue = 2;
                            cbxTipoTiquete.Enabled = false;
                            gxbseleccionar.Enabled = false;
                            txtConsultaMarcaCategoriaProducto.Enabled = true;
                            btnAgregarMarcaCategoriaProducto.Enabled = true;
                            miTabla.Clear();
                        }
                        else
                        {
                            miTabla.Clear();
                        }
                    }
                }
            }


        }

        private void cbxCriterioBusquedaSorteo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var di = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            if (di == 1)
            {
                tsbtnEditaSorteo.Enabled = true;
                tsbtnIngresarGanador.Enabled = true;
                tsbtnEliminarSorteo.Enabled = true;
                gbxResultadoSorteo.Text = "Sorteos activos";
            }
            else
            {
                tsbtnEditaSorteo.Enabled = false;
                tsbtnIngresarGanador.Enabled = false;
                tsbtnEliminarSorteo.Enabled = false;
                gbxResultadoSorteo.Text = "Historial de sorteos";
            }
            while (dgvSorteo.RowCount != 0)
            {
                dgvSorteo.Rows.RemoveAt(0);
            }
        }

        private void txtConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtConcepto, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtConcepto, er, "Formato Incorrecto"))
                {
                    conceptosorteo = true;
                }
                else
                {
                    conceptosorteo = false;
                }
            }
            else
            {
                conceptosorteo = false;
            }

        }

        private void txtValorPremio_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorPremio, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtValorPremio, er, "Formato Incorrecto"))
                {
                    valorpremiosorteo = true;
                }
                else
                {
                    valorpremiosorteo = false;
                }
            }
            else
            {
                valorpremiosorteo = false;
            }
        }

        private void txtPatrosinadores_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtPatrosinadores, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtPatrosinadores, er, "Formato incorrecto"))
                {
                    patrocinadorSorteo = true;
                }
                else
                {
                    patrocinadorSorteo = false;
                }
            }
            else
            {
                patrocinadorSorteo = false;
            }
        }

        private void txtNombreSorteo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreSorteo, er, "El campo e requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombreSorteo, er, "Formato incorrecto"))
                {
                    nombreSorteo = true;
                }
                else
                {
                    nombreSorteo = false;
                }
            }
            else
            {
                nombreSorteo = false;
            }

        }

        private void txtPremioSorteo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtPremioSorteo, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtPremioSorteo, er, "Formato incorrecto"))
                {
                    premioSorteo = true;
                }
                else
                {
                    premioSorteo = false;
                }
            }
            else
            {
                premioSorteo = false;
            }

        }

        private void txtValorMinimo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorMinimo, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtValorMinimo, er, "Formato incorrecto"))
                {
                    valorminimo = true;
                }
                else
                {
                    valorminimo = false;
                }
            }
            else
            {
                valorminimo = false;
            }

        }

        private void dtpFechaFinal_Validating(object sender, CancelEventArgs e)
        {
            var fechaInicio = new DateTime(dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day);
            var fechaFin = new DateTime(dtpFechaFinal.Value.Year, dtpFechaFinal.Value.Month, dtpFechaFinal.Value.Day);
            if (fechaInicio <= fechaFin)
            {
                dtpfechas = true;
                er.SetError(dtpFechaFinal, null);
            }
            else
            {
                er.SetError(dtpFechaFinal, "La fecha de inicio debe ser menor al la fecha final");

                dtpfechas = false;
            }
        }

        private void dtpFechaSorteo_Validating(object sender, CancelEventArgs e)
        {
            var fechaSorteo = new DateTime(dtpFechaSorteo.Value.Year, dtpFechaSorteo.Value.Month, dtpFechaSorteo.Value.Day);
            var fechaFin = new DateTime(dtpFechaFinal.Value.Year, dtpFechaFinal.Value.Month, dtpFechaFinal.Value.Day);

            if (fechaSorteo >= fechaFin)
            {
                dtpfechasorteo = true;
                er.SetError(dtpFechaSorteo, null);
            }
            else
            {
                er.SetError(dtpFechaSorteo, "La fecha de sorteo debe ser igual o mayor a la fecha final");
                dtpfechasorteo = false;
            }
        }

        private void dtpHoraFin_Validating(object sender, CancelEventArgs e)
        {
            var horaInicio = new DateTime(1, 1, 1, dtpHoraInicio.Value.Hour,
                dtpHoraInicio.Value.Minute, dtpHoraInicio.Value.Second);
            var horafin = new DateTime(1, 1, 1, dtpHoraFin.Value.Hour, dtpHoraFin.Value.Minute, dtpHoraFin.Value.Second);

            if (dtpHoraFin.Enabled)
            {
                if (horaInicio != horafin)
                {
                    dtphora = true;
                    er.SetError(dtpHoraFin, null);
                }
                else
                {
                    er.SetError(dtpHoraFin, "La hora de inicio debe ser menor a la hora final");
                    dtphora = false;
                }
            }
            else
            {

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvseleccionMarcaCategoriaSorteo.RowCount != 0)
            {
                this.dgvseleccionMarcaCategoriaSorteo.Rows.RemoveAt(
                    this.dgvseleccionMarcaCategoriaSorteo.CurrentCell.RowIndex);
            }
        }

        private void tsbtnEditaSorteo_Click(object sender, EventArgs e)
        {
            if (this.dgvSorteo.RowCount != 0)
            {
                if (!FormEditOpen)
                {

                    frmEditaSorteo editaSorteo = new frmEditaSorteo();
                    var id = (int)dgvSorteo.CurrentRow.Cells["Column10"].Value;
                    editaSorteo.CargaSorteoEditar(id,false);
                    editaSorteo.Show();
                    FormEditOpen = true;
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay sorteos a modificar seleccione el sorteo a modificar");
            }
        }

        private void tsbtnDetalleSorteo_Click(object sender, EventArgs e)
        {
            if (this.dgvSorteo.RowCount != 0)
            {
                var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
                try
                {
                    frmDetalleSorteo detalleSorteo = new frmDetalleSorteo();
                    var id = (int)this.dgvSorteo.CurrentRow.Cells["Column10"].Value;
                    var tipo = (int)this.dgvSorteo.CurrentRow.Cells["Column11"].Value;
                    if (criterio == 1)
                    {
                        detalleSorteo.Size = new System.Drawing.Size(993, 509);
                        if (tipo == 5)
                        {
                            detalleSorteo.Size = new System.Drawing.Size(993, 335);
                        }
                        detalleSorteo.CargaDetalleSorteo(id, false);
                    }
                    else
                    {
                        detalleSorteo.CargaDetalleSorteo(id, true);
                    }
                    detalleSorteo.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                OptionPane.MessageInformation("No hay sorteos a mostrar su detalle  seleccione el sorteo. ");
            }
        }

        private void tsbtnEliminarSorteo_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
            if (criterio == 1)
            {
                try
                {
                    if (this.dgvSorteo.RowCount != 0)
                    {
                        DialogResult r = MessageBox.Show("Esta seguro que desea eliminar el sorteo", "Eliminar",
                            MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (r == DialogResult.OK)
                        {
                            var id = (int)this.dgvSorteo.CurrentRow.Cells["Column10"].Value;
                            miSorteo.EliminarSorteo(id);

                            dgvSorteo.Rows.RemoveAt(dgvSorteo.CurrentCell.RowIndex);
                            OptionPane.MessageInformation("Se elimino sorteo exitosamente");
                        }

                    }
                    else
                    {
                        OptionPane.MessageInformation("No tiene registros a eliminar");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsbtnSalirSorteo_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbtnConsultaSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbtnIngresarGanador_Click(object sender, EventArgs e)
        {
            hoy = DateTime.Today;

            if (this.dgvSorteo.RowCount != 0)
            {
                var fechaSorteo = (DateTime)dgvSorteo.CurrentRow.Cells["Column5"].Value;

                if (fechaSorteo <= hoy)
                {
                    var estado = (string)dgvSorteo.CurrentRow.Cells["Column9"].Value;
                    if (estado == "Activo")
                    {
                        var criterio = (int)cbxCriterioBusquedaSorteo.SelectedValue;
                        try
                        {
                            if (criterio == 1)
                            {
                                frmGanador ganador = new frmGanador();
                                ganador.idSorteo = (int)this.dgvSorteo.CurrentRow.Cells["Column10"].Value;
                                ganador.Show();
                            }
                            else
                            {
                                OptionPane.MessageInformation("Para ingresar un ganador debe seleccionar un sorteo activo");
                            }
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError("Error al ingresar el ganador" + ex.Message);
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El sorteo debe de estar activo pa ra poder ingresar un ganador");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No se puede ingresar el sorteo ya que esta en juego");
                }
            }
        }

        /// <summary>
        /// Carga combo box de tipos sorteo.
        /// </summary>
        private void CargaComboTipoSorteo()
        {
            try
            {
                cbxTipoSorteo.DataSource = miTipoSorteo.ListaTipoSorteo();
            }
            catch (Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }
        }

        /// <summary>
        /// Transferencia de datos de un formulario externo.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                TransferirMarca m = (TransferirMarca)args.MiMarca;
                iddgv = m.IdMarca;
                if (!Consulta)
                {
                    if (!Existe(2))
                    {
                        var existe = true;
                        foreach (DataRow row in miTabla.Rows)
                        {
                            var id = Convert.ToInt32(row["Codigo"]);

                            if (id == m.IdMarca)
                            {
                                existe = false;
                                break;
                            }
                            else
                            {
                                existe = true;
                            }
                        }
                        if (existe)
                        {
                            var row_ = miTabla.NewRow();
                            row_["Codigo"] = m.IdMarca;
                            row_["Nombre"] = m.NombreMarca;
                            miTabla.Rows.Add(row_);
                        }
                        dgvseleccionMarcaCategoriaSorteo.DataSource = miTabla;
                        txtConsultaMarcaCategoriaProducto.Text = "";
                    }
                    else
                    {
                        OptionPane.MessageInformation("La marca ya  tiene un sorteo asociado.");
                        btnBuscarMarcaCategoriaProducto_Click(null, null);
                    }

                }
                else
                {
                    idMarcaTex = m.IdMarca;
                    txtBuscarSorteo.Text = m.NombreMarca;

                }
            }
            catch
            { }
            try
            {
                DTO.Clases.Categoria c = (DTO.Clases.Categoria)args.MiMarca;
                iddgv = Convert.ToInt32(c.CodigoCategoria);
                if (!Consulta)
                {
                    if (!Existe(3))
                    {
                        var existe = true;
                        foreach (DataRow row in miTabla.Rows)
                        {
                            var id = Convert.ToString(row["Codigo"]);
                            if (id == c.CodigoCategoria)
                            {
                                existe = false;
                                break;
                            }
                            else
                            {
                                existe = true;
                            }
                        }
                        if (existe)
                        {
                            var row_ = miTabla.NewRow();
                            row_["Codigo"] = c.CodigoCategoria;
                            row_["Nombre"] = c.NombreCategoria;
                            miTabla.Rows.Add(row_);

                        }

                        dgvseleccionMarcaCategoriaSorteo.DataSource = miTabla;
                        txtConsultaMarcaCategoriaProducto.Text = "";

                    }
                    else
                    {
                        OptionPane.MessageInformation("La categoria ya tiene un sorteo asociado.");
                        btnBuscarMarcaCategoriaProducto_Click(null, null);
                    }
                }
                else
                {
                    txtBuscarSorteo.Text = c.CodigoCategoria;
                }
            }
            catch
            { }

            try
            {
                Producto p = (Producto)args.MiMarca;
                iddgv = Convert.ToInt32(p.CodigoInternoProducto);
                if (!Consulta)
                {
                    if (!Existe(4))
                    {
                        var existe = true;
                        foreach (DataRow row in miTabla.Rows)
                        {
                            var id = Convert.ToString(row["Codigo"]);
                            if (id == p.CodigoInternoProducto)
                            {
                                existe = false;
                                break;
                            }
                            else
                            {
                                existe = true;
                            }
                        }

                        if (existe)
                        {
                            var row__ = miTabla.NewRow();
                            row__["Codigo"] = p.CodigoInternoProducto;
                            row__["Nombre"] = p.NombreProducto;
                            miTabla.Rows.Add(row__);
                        }
                        else
                        {
                            dgvseleccionMarcaCategoriaSorteo.DataSource = miTabla;
                            txtConsultaMarcaCategoriaProducto.Text = "";
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El Producto ya tiene un sorteo asociado.");
                        btnBuscarMarcaCategoriaProducto_Click(null, null);
                    }
                }
                else
                {
                    txtBuscarSorteo.Text = p.CodigoInternoProducto;
                }

            }

            catch
            {
            }

            try
            {
                FormEditOpen = (bool)args.MiMarca;
            }
            catch
            { }

        }

        /// <summary>
        /// Obtiene las marcas seleccionadas.
        /// </summary>
        private void ListaMarca()
        {
            marcas = new List<Marca>();
            foreach (DataRow row in miTabla.Rows)
            {
                var miMarca = new Marca();
                miMarca.IdMarca = Convert.ToInt32(row["Codigo"]);

                marcas.Add(miMarca);
            }
        }

        /// <summary>
        /// Obtiene las lista de las categorías seleccionadas.
        /// </summary>
        private void ListaCategoria()
        {
            categoria = new List<Categoria>();
            foreach (DataRow row in miTabla.Rows)
            {
                var miCategoria = new Categoria();
                miCategoria.CodigoCategoria = (string)row["Codigo"];

                categoria.Add(miCategoria);
            }
        }

        /// <summary>
        /// Obtiene la lista de los productos seleccionados.
        /// </summary>
        private void ListaProducto()
        {
            producto = new List<Producto>();
            foreach (DataRow row in miTabla.Rows)
            {
                var miProducto = new Producto();
                miProducto.CodigoInternoProducto = (string)row["Codigo"];

                producto.Add(miProducto);
            }
        }

        /// <summary>
        /// Obtiene los datos de categoría.
        /// </summary>
        /// <param name="codigo"> código (categoría) a consultar</param>
        /// <returns></returns>
        public DataRow ConsultaCategoria(string codigo)
        {
            var rows = miTabla.NewRow();
            try
            {
                var consulta = miCategoria.consultaCategoriaCodigo(codigo);
                var existe = true;
                if (consulta.Count > 0)
                {
                    if (dgvseleccionMarcaCategoriaSorteo.RowCount != 0)
                    {
                        foreach (DataGridViewRow row_ in dgvseleccionMarcaCategoriaSorteo.Rows)
                        {
                            var id = Convert.ToString(row_.Cells["Column12"].Value);
                            if (id == txtConsultaMarcaCategoriaProducto.Text)
                            {
                                existe = false;
                                break;
                            }
                            else
                            {
                                existe = true;
                            }
                        }
                        iddgv = Convert.ToInt32(((Categoria)consulta[0]).CodigoCategoria);
                        if (Existe(3))
                        {
                            existe = false;
                            OptionPane.MessageInformation("La categoria ya tiene un sorteo asociado.");
                        }
                        if (existe)
                        {
                            var cattemp = (Categoria)consulta[0];
                            rows["Codigo"] = cattemp.CodigoCategoria;
                            rows["Nombre"] = cattemp.NombreCategoria;
                            return rows;
                        }
                        else
                        {

                            return null;
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("No se encontro la categoria en la base de datos.");
                }
                return null;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Obtiene los datos de producto.
        /// </summary>
        /// <param name="codigo">código(producto) a consultar</param>
        /// <returns></returns>
        public DataRow ConsultaProducto(string codigo)
        {
            var rows = miTabla.NewRow();
            try
            {
                var consulta = miProducto.ConsultaProductoSimple(codigo);
                var existe = true;
                if (consulta.CodigoInternoProducto != "")
                {
                    if (!String.IsNullOrEmpty(consulta.CodigoInternoProducto))
                    {
                        if (dgvseleccionMarcaCategoriaSorteo.RowCount != 0)
                        {
                            foreach (DataGridViewRow row in dgvseleccionMarcaCategoriaSorteo.Rows)
                            {
                                var id = Convert.ToString(row.Cells["Column12"].Value);
                                if (id == txtConsultaMarcaCategoriaProducto.Text)
                                {
                                    existe = false;
                                    break;
                                }
                                else
                                {
                                    existe = true;
                                }
                            }
                            iddgv = Convert.ToInt32(consulta.CodigoInternoProducto);
                            if (Existe(4))
                            {
                                existe = false;
                                OptionPane.MessageInformation("El producto ya tiene un sorteo asociado.");
                            }
                            if (existe)
                            {
                                rows["Codigo"] = consulta.CodigoInternoProducto;
                                rows["Nombre"] = consulta.NombreProducto;
                                return rows;
                            }

                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se encontro el producto en la base de datos.");
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Consulta categoría, producto si existe en la base de datos,
        /// </summary>
        /// <param name="idTipo"> id tipo sorteo(categoría o producto) a consultar</param>
        /// <returns></returns>
        public DataRow ConsultaCategoriaProductoExistebd(int idTipo)
        {
            var rows = miTabla.NewRow();
            try
            {
                if (idTipo == 3)
                {
                    var consulta = miCategoria.consultaCategoriaCodigo(txtConsultaMarcaCategoriaProducto.Text);
                    if (consulta.Count > 0)
                    {
                        iddgv = Convert.ToInt32(((Categoria)consulta[0]).CodigoCategoria);

                        if (!Existe(3))
                        {
                            var cattemp = (Categoria)consulta[0];
                            rows["Codigo"] = cattemp.CodigoCategoria;
                            rows["Nombre"] = cattemp.NombreCategoria;
                            return rows;
                        }
                        else
                        {
                            OptionPane.MessageInformation("la categoria ya tiene un sorteo asociado.");
                            return null;
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se encontro la categoria en la base de datos");
                        return null;
                    }
                }
                else
                {
                    var consulta = miProducto.ConsultaProductoSimple(txtConsultaMarcaCategoriaProducto.Text);
                    if (consulta.CodigoInternoProducto != "")
                    {
                        iddgv = Convert.ToInt32(consulta.CodigoInternoProducto);
                        if (!Existe(4))
                        {
                            rows["Codigo"] = consulta.CodigoInternoProducto;
                            rows["Nombre"] = consulta.NombreProducto;
                            return rows;
                        }
                        else
                        {
                            OptionPane.MessageInformation("El producto ya tiene un sorteo asociado.");
                            return null;
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se encontro el producto en la base de dartos.");
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }

        }

        /// <summary>
        /// Consulta sorteo nombre (sea igual)
        /// </summary>
        /// <param name="nombre">nombre sorteo</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoNombre
            (string nombre, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultaSorteoNombre
                    (nombre, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Lista sorteo nombre (que contenga)
        /// </summary>
        /// <param name="nombre">nombre sorteo</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ListarSorteoNombre
            (string nombre, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ListaSorteoNombre
                    (nombre, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar  sorteo patrocinador (sea igual)
        /// </summary>
        /// <param name="patrocinador">nombre patrocinador</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoPatrocinador
            (string patrocinador, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultaSorteoPatrocinador
                    (patrocinador, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Lista sorteo patrocinador (que contenga)
        /// </summary>
        /// <param name="patrocinador">nombre patrocinador</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void listarSorteoPatrocinador
            (string patrocinador, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ListaSorteoPatrocinador
                    (patrocinador, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar sorteo marca fechas
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(marca)a consultar</param>
        /// <param name="idMarca">id marca a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoMarcaFechas
            (int idTipo, int idMarca, DateTime fechas, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                    (idTipo, idMarca, fechas, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta Sorteo tipo marca fechas
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(marca) a consultar</param>        
        /// <param name="fechas">fecha a consultar</param>
        /// <param name="historial">determina el estado de la consulta</param>
        private void ConsultarSorteoMarcaFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 1;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaFechas
                    (idTipo, fechas, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoMarcaFechas
                    (idTipoSorteo, fechaInicio, historial);

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consulta sorteo marca periodos
        /// </summary>
        /// <param name="idTipo">id tipo sorteo (merca)a consultar</param>
        /// <param name="idMarca">id marca a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoMarcaPeriodo
            (int idTipo, int idMarca, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 2;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                        (idTipo, idMarca, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoMarca
                    (idTipo, idMarca, fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consulta sorteo tipo marca periodo
        /// </summary>
        /// <param name="idTipo">id tipo sorteo (marca) a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoMarcaPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 3;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoMarcaPeriodos
                    (idTipo, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoMarcaPeriodo
                    (idTipoSorteo, fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consultar sorteo categoría fechas
        /// </summary>
        /// <param name="idTipo">id tipo sorteo (categoría) a consultar</param>
        /// <param name="codigoCategoria">código categoría a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoCategoriaFechas
            (int idTipo, string codigoCategoria, DateTime fecha, bool historial)
        {
            interacion = 0;

            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                    (idTipo, codigoCategoria, fecha, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar sorteo tipo categoría fechas
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(categoría) a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoCategoriaFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 4;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaFechas
                    (idTipoSorteo, fechas, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoCategoriaFechas
                    (idTipoSorteo, fechaInicio, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consulta sorteo categoría periodos
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(categoría) a consultar</param>
        /// <param name="codigoCategoria">código categoría a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoCategoriaPeriodo
            (int idTipo, string codigoCategoria, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 5;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                    (idTipo, codigoCategoria, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoCategoria
                    (idTipo, codigoCategoria, fecha1, fecha2, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consulta sorteo tipo categoría periodos
        /// </summary>
        /// <param name="idTipo">id tipo sorteo (categoría) a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>


        private void ConsultarSorteoCategoriaPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 6;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoCategoriaPeriodos
                    (idTipo, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoCategoriaPeriodos
                    (idTipoSorteo, fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consultar sorteo producto fechas
        /// </summary>
        /// <param name="idTipo">id tipo sorteo (producto) a consultar</param>
        /// <param name="codigoInternoProducto">código interno producto a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoProductoFechas
            (int idTipo, string codigoInternoProducto, DateTime fechas, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                    (idTipo, codigoInternoProducto, fechas, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar sorteo tipo producto fechas.
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(producto) a consultar</param>
        /// <param name="fechas">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoProductoFechas
            (int idTipo, DateTime fechas, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 7;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoFechas
                    (idTipo, fechas, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoProductoFechas
                    (idTipoSorteo, fechaInicio, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar sorteo producto periodos
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(producto) a consultar</param>
        /// <param name="codigoInternoProducto">código interno producto a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoProductoPeriodo
            (int idTipo, string codigoInternoProducto, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 8;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                    (idTipo, codigoInternoProducto, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoProducto
                    (idTipo, codigoInternoProducto, fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consultar sorteo tipo producto periodo
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(producto) a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoProductoPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 9;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoProductoPeriodo
                    (idTipo, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoProductoPeriodo
                    (idTipoSorteo, fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consultar sorteo factura fechas
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(factura) a consultar</param>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoFacturaFechas
            (int idTipo, DateTime fecha, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFacturaFechas
                    (idTipo, fecha, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta sorteo factura  periodo
        /// </summary>
        /// <param name="idTipo">id tipo sorteo(factura)a consultar</param>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoFacturaPeriodo
            (int idTipo, DateTime fecha1, DateTime fecha2, bool historial)
        {
            idTipoSorteo = (int)cbxCriterioTipo.SelectedValue;
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 10;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFacturaPeriodo
                    (idTipo, fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoFactura
                    (idTipoSorteo, fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consulta sorteo fecha
        /// </summary>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteofechas
            (DateTime fecha, bool historial)
        {
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 11;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechas
                    (fecha, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoFechas(fecha, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consultar sorteo periodo
        /// </summary>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoPeriodo
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 12;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoPeriodos
                    (fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoPeriodos(fecha1, fecha2, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta inicialización de sorteos
        /// </summary>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoInicializacion
            (DateTime fecha, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarFechaInicio
                    (fecha, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta sorteo inicialización periodo
        /// </summary>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de  la consulta</param>
        private void ConsultarSorteoInicializacionPeriodo
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 13;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaInicioPeriodos
                    (fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoFechaInicio
                    (fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Consulta finalizacion sorteo fechas
        /// </summary>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoFinalizacion
            (DateTime fecha, bool historial)
        {
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinFechas
                    (fecha, historial);
                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Consulta finalización de sorteo
        /// </summary>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoFinalizacionPeriodo
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 14;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaFinPeriodo
                    (fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteoFechaFin
                    (fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        ///  Consulta sorteo fecha sorteo fechas
        /// </summary>
        /// <param name="fecha">fecha a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoSorteo
            (DateTime fecha, bool historial)
        {
            interacion = 0;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteo
                    (fecha, historial);

                tslblConteo.Text = "1/1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }

        }

        /// <summary>
        /// Consultar sorteo fecha sorteo periodos
        /// </summary>
        /// <param name="fecha1">fecha inicio a consultar</param>
        /// <param name="fecha2">fecha fin a consultar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        private void ConsultarSorteoSorteoPeriodo
            (DateTime fecha1, DateTime fecha2, bool historial)
        {
            EstablecerHistorial(historial);
            fechaInicio = dtpFechaIni.Value;
            fechaFin = dtpFechaFin.Value;
            rowSorteo = 0;
            currenPageSorteo = 1;
            interacion = 15;
            try
            {
                dgvSorteo.DataSource = miSorteo.ConsultarSorteoFechaSorteoPeriodo
                    (fecha1, fecha2, historial, rowSorteo, rowMaxSorteo);
                totalRowSorteo = miSorteo.RowListarSorteofechaSorteo
                    (fechaInicio, fechaFin, historial);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginaSorteo = totalRowSorteo / rowMaxSorteo;
            if (totalRowSorteo % rowMaxSorteo != 0)
                paginaSorteo++;
            if (currenPageSorteo > paginaSorteo)
                currenPageSorteo = 0;
            tslblConteo.Text = currenPageSorteo + " / " + paginaSorteo;
        }

        /// <summary>
        /// Valida los campos de sorteo.
        /// </summary>
        private void Revalidar()
        {
            txtNombreSorteo_Validating(null, null);
            txtConcepto_Validating(null, null);
            txtPatrosinadores_Validating(null, null);
            txtPremioSorteo_Validating(null, null);
            txtValorMinimo_Validating(null, null);
            txtValorPremio_Validating(null, null);
            dtpFechaFinal_Validating(null, null);
            dtpFechaSorteo_Validating(null, null);
            dtpHoraFin_Validating(null, null);
        }

        /// <summary>
        /// Limpia los campos de sorteo.
        /// </summary>
        private void LimpiaCampos()
        {
            txtNombreSorteo.Text = "";
            txtConcepto.Text = "";
            txtPatrosinadores.Text = "";
            txtPremioSorteo.Text = "";
            txtValorMinimo.Text = "";
            txtValorPremio.Text = "";
        }

        /// <summary>
        /// Limpia campo del objeto.
        /// </summary>
        private void limpiaObjeto()
        {
            txtBuscarSorteo.Text = "";
            er.SetError(txtBuscarSorteo, null);
        }

        /// <summary>
        /// Cambia de posición de las fechas de menor a mayor.
        /// </summary>
        private void CambiaFecha()
        {
            if (dtpFechaFin.Value < dtpFechaIni.Value)
            {
                var tem = dtpFechaIni.Value;
                dtpFechaIni.Value = dtpFechaFin.Value;
                dtpFechaFin.Value = tem;
            }
        }

        /// <summary>
        /// Establece el valor de la consulta de sorteo.
        /// </summary>
        /// <param name="historial"></param>
        private void EstablecerHistorial(bool historial)
        {
            if (historial)
            {
                criterioPaginacion = 2;
            }
            else
            {
                criterioPaginacion = 1;
            }
        }

        /// <summary>
        /// Existe al buscar o ingresar una marca categoría o producto en la base de datos.
        /// </summary>
        /// <param name="idTipo">id criterion de busqueda</param>
        /// <returns></returns>
        private bool Existe(int idTipo)
        {
            var existe = false;
            try
            {
                if (idTipo == 2)
                {
                    existe = miSorteo.ExisteSorteoMarca(iddgv, dtpFechaInicio.Value, dtpFechaFinal.Value);

                }
                else
                {
                    if (idTipo == 3)
                    {
                        existe = miSorteo.ExisteSorteocategoria(Convert.ToString(iddgv), dtpFechaInicio.Value, dtpFechaFinal.Value);
                    }
                    else
                    {
                        if (idTipo == 4)
                        {
                            existe = miSorteo.ExisteSorteoProducto(Convert.ToString(iddgv), dtpFechaInicio.Value, dtpFechaFinal.Value);
                        }
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
        /// Validación de existe al guardar marca categoría producto
        /// </summary>
        /// <param name="idTipo">id criterio de búsqueda</param>
        /// <param name="codigo"> código marca categoría producto a buscar</param>
        /// <returns></returns>
        private bool Existe(int idTipo, object codigo)
        {
            var existe = false;
            try
            {
                if (idTipo == 2)
                {
                    existe = miSorteo.ExisteSorteoMarca(Convert.ToInt32(codigo), dtpFechaInicio.Value, dtpFechaFinal.Value);
                }
                else
                {
                    if (idTipo == 3)
                    {
                        existe = miSorteo.ExisteSorteocategoria(Convert.ToString(codigo), dtpFechaInicio.Value, dtpFechaFinal.Value);
                    }
                    else
                    {
                        if (idTipo == 4)
                        {
                            existe = miSorteo.ExisteSorteoProducto(Convert.ToString(codigo), dtpFechaInicio.Value, dtpFechaFinal.Value);
                        }
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
        /// Obtiene o establece si existe o no en la base de datos
        /// </summary>
        /// <param name="idTipo">id tipo a consultar</param>
        /// <returns></returns>
        private bool ExisteBd(int idTipo)
        {
            var existeBd = false;
            List<string> list = new List<string>();

            foreach (DataRow row in miTabla.Rows)
            {
                var id = Convert.ToString(row["Codigo"]);
                if (Existe(idTipo, id))
                {
                    list.Add(Convert.ToString(row["Nombre"]));
                    existeBd = true;
                }
            }

            if (list.Count > 0)
            {
                var t = "";
                if (idTipo == 2)
                {
                    t = "Marca(s)";
                }
                else
                {
                    if (idTipo == 3)
                    {
                        t = "Categoria(s)";
                    }
                    else
                    {
                        t = "Producto(s)";
                    }
                }
                string msm = "L@s " + t + " Ya tiene registros asociados en Sorteo.";
                OptionPane.MessageInformation(msm);
            }
            if (idTipo == 5)
            {
                if (ExisteFactura(5))
                {
                    OptionPane.MessageInformation("Ya existe un sorteo por factura en las fechas seleccionadas.");
                    existeBd = true;
                }
                else
                {
                    existeBd = false;
                }

            }
            return existeBd;
        }

        /// <summary>
        /// Obtiene o establece  el existe factura en la bd.
        /// </summary>
        /// <param name="idTipo">id tipo sorteo</param>
        /// <returns></returns>
        private bool ExisteFactura(int idTipo)
        {
            var existe = false;
            try
            {
                existe = miSorteo.ExisteSorteoFactura(idTipo, dtpFechaInicio.Value, dtpFechaFinal.Value);
                return existe;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return existe;
            }
        }

        /// <summary>
        /// Obtiene una tabla específica para varios registros.
        /// </summary>
        /// <returns></returns>
        public DataTable General()
        {
            var generel = new DataTable();
            generel.Columns.Add(new DataColumn("Codigo", typeof(string)));
            generel.Columns.Add(new DataColumn("Nombre", typeof(string)));

            return generel;
        }
    }
}
