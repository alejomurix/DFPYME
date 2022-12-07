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

namespace Aplicacion.Inventario.Cruce
{
    public partial class frmRelacion : Form
    {
        #region Atributos

        /// <summary>
        /// Obtiene o establece el valor si habilita o no Color en el Formulario.
        /// </summary>
        private bool ConfiguracionColor;

        private bool NivelaCero;

        /// <summary>
        /// Obtiene o establece el valor que indica si se mantiene la cifra del inventario en sistema.
        /// </summary>
        private bool InventarioSistema;

        /// <summary>
        /// Obtiene o establece el valor que indica si es el primer corte realizado en el sistema.
        /// </summary>
        private bool FirtsCorte;

        /// <summary>
        /// Representa un objeto para el uso de fecha.
        /// </summary>
        DateTime fechaHoy;

        /// <summary>
        /// Objeto de logica de negocio de inventario.
        /// </summary>
        private BussinesInventario miBussinesInventario;

        /// <summary>
        /// Objeto para estructurar criterios de consulta.
        /// </summary>
        private CriterioRelacion miCriterio;

        /// <summary>
        /// Objeto de logia de negocio de Categoria.
        /// </summary>
        private BussinesCategoria miBussinesCategoria;

        /// <summary>
        /// Objeto para encapsular un origen de datos.
        /// </summary>
        private BindingSource bindigSource;

        /// <summary>
        /// Objeto tipo hilo que me premite realiza ejecuciones asincronas y sincrona.
        /// </summary>
        private Thread miThread;

        /// <summary>
        /// Objeto que representa el panel de opcion a mostrar.
        /// </summary>
        private OptionPane miOption;

        /// <summary>
        /// Obtiene o establece el valor que indica si el cruce se realizo con exito.
        /// </summary>
        private bool Success = false;

        #endregion

        #region Variables Pagina dgvProducto

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int iteracionP = 0;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int rowProducto;

        /// <summary>
        /// Obtiene o establece el numero maximo de registro a cargar.
        /// </summary>
        private int rowMaxProducto;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long totalRowProducto;

        /// <summary>
        /// Obtiene o establece el numero total de paginas que componen la consulta.
        /// </summary>
        private long paginasProducto;

        /// <summary>
        /// Obtiene o establece el numero de la pagina actual.
        /// </summary>
        private int currentPageProducto;

        #endregion

        #region Variables Pagina dgvInventario

        private int rowInventario;

        private int rowMaxInventario;

        private long totalRowInventario;

        private long paginasInventario;

        private int currentPageInventario;

        private int iteracion = 0;

        private DateTime fecha1;

        private DateTime fecha2;

        #endregion

        public frmRelacion()
        {
            InitializeComponent();

            ConfiguracionColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            NivelaCero = Convert.ToBoolean(AppConfiguracion.ValorSeccion("nivelcero"));
            InventarioSistema = Convert.ToBoolean(AppConfiguracion.ValorSeccion("inventariosistema"));

            miBussinesInventario = new BussinesInventario();
            miCriterio = new CriterioRelacion();
            miBussinesCategoria = new BussinesCategoria();
            bindigSource = new BindingSource();

            rowMaxProducto = 10;
            rowMaxInventario = 10;
        }

        private void frmRelacion_Load(object sender, EventArgs e)
        {
            InicializarFechaHoy();
            //cbCriterioCategoria.DataSource = miBussinesCategoria.ListarCategoria();
            this.dgvProductos.AutoGenerateColumns = false;
            this.dgvInventario.AutoGenerateColumns = false;
            cbCriterio.DataSource = miCriterio.lstCriterio;
            cbConsultaInventario.DataSource = miCriterio.lstInventario;
            cbCriterioConsulta.DataSource = miCriterio.lstCriterioConsulta;
            CargarOpcionMedidaColor();
            dgvInventario.DataSource = bindigSource;
        }

        private void frmRelacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F1)
            {
                tsbtnCorteRealizar_Click(null, null);
            }
            else
            {
                if (e.KeyData == Keys.F2)
                    tsbtnCudrarInventario_Click(null, null);
                else
                {
                    if (e.KeyData == Keys.F3)
                    {
                        tsBtnCorteGeneral_Click(null, null);
                    }
                    else
                    {
                        if (e.KeyData == Keys.Escape)
                        {
                            this.Close();
                        }
                    }
                }
            }
        }

        private void tsbtnCorteRealizar_Click(object sender, EventArgs e)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracionP = 1;
            try
            {
                dgvProductos.DataSource = miBussinesInventario.ProductoConCorte
                    (rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesInventario.GetTotalRowProductoConCorte();
                if (dgvProductos.RowCount != 0)
                    cbConsultaInventario.Enabled = true;
                cbConsultaInventario.SelectedValue = 1;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginasProducto = totalRowProducto / rowMaxProducto;
            if (totalRowProducto % rowMaxProducto != 0)
                paginasProducto++;
            if (currentPageProducto > paginasProducto)
                currentPageProducto = 0;
            statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
            dgvProductos_CellClick(null, null);
        }

        private void tsBtnCorteGeneral_Click(object sender, EventArgs e)
        {
            frmCorteGeneral corteGeneral = new frmCorteGeneral();
            corteGeneral.MdiParent = this.MdiParent;
           /* corteGeneral.gbConsulta.Visible = false;
            corteGeneral.gbOrdenar.Visible = true;
            corteGeneral.gbOrdenar.Location = new Point(8, 35);
            corteGeneral.MdiParent = this.MdiParent;
            corteGeneral.CortePendiente = true;*/
            corteGeneral.Show();
           // corteGeneral.MostrarRegistrosSinInventario();
        }

        private void tsbtnCudrarInventario_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Esta seguro de que quiere Cruzar el Inventario?", "Inventario",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta == DialogResult.Yes)
            {
                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                miThread = new Thread(start);
                miThread.Start();
            }
        }

        private void tsBtnResultado_Click(object sender, EventArgs e)
        {
            var corteGeneral = new FrmResumenInventario();
            /*corteGeneral.gbOrdenar.Visible = false;
            corteGeneral.gbConsulta.Visible = true;
            corteGeneral.CortePendiente = false;*/
            corteGeneral.MdiParent = this.MdiParent;
            corteGeneral.Show();
        }

        private void tsBtnHistorial_Click(object sender, EventArgs e)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracionP = 3;
            try
            {
                dgvProductos.DataSource = miBussinesInventario.ConsultaProductoResumenInventario
                    (rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesInventario.GetRowsConsultaProductoResumenInventario();
                if (dgvProductos.RowCount != 0)
                    cbConsultaInventario.Enabled = true;
                cbConsultaInventario.SelectedValue = 2;
                dgvProductos_CellClick(null, null);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginasProducto = totalRowProducto / rowMaxProducto;
            if (totalRowProducto % rowMaxProducto != 0)
                paginasProducto++;
            if (currentPageProducto > paginasProducto)
                currentPageProducto = 0;
            statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        private void tsBtnActualizar_Click(object sender, EventArgs e)
        {
            var frmActualizar = new FrmActualizaDatos();
            frmActualizar.MdiParent = this.MdiParent;
            frmActualizar.Show();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)this.cbCriterio.SelectedValue;
            if (id == 1)
                CriterioConProducto();
            else
                CriterioConCategoria();
            txtCodigo.Text = "";
        }

        private void cbCriterioCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var codigo = (string)this.cbCriterioCategoria.SelectedValue;
            txtCodigo.Text = codigo;
            txtCodigo_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtCodigo.Text))
                {
                    EstructurarConsulta();
                    if (dgvProductos.RowCount != 0)
                        cbConsultaInventario.Enabled = true;
                    cbConsultaInventario.SelectedIndex = 0;
                    cbCriterioConsulta.SelectedIndex = 0;
                    //panelHistorial.Enabled = false;
                }
                else
                    MessageBox.Show("El campo de busqueda es requerido", "Inventario",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            txtCodigo_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var IdConsulta = (int)this.cbConsultaInventario.SelectedValue;
            var codigo = "";
            if (dgvProductos.RowCount != 0)
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            if (IdConsulta == 1)
            {
                ConsultarInvetarioFisico();
            }
            else
            {
                ConsultarHistorialInventario();
            }

            if (dgvInventario.Rows.Count != 0 && ConfiguracionColor)
            {
               // dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
            cbCriterioConsulta.SelectedIndex = 0;
            HabilitarFechas(false, false, false);
        }

        private void dgvProductos_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                dgvProductos_CellClick(null, null);
            }
        }

        private void btnInicioRowProducto_Click(object sender, EventArgs e)
        {
            ///Avanza hasta la primera pagina de los registros.
            if (currentPageProducto > 1)
            {
                var paginaActual = currentPageProducto;
                for (int i = paginaActual; i > 1; i--)
                {
                    rowProducto = rowProducto - rowMaxProducto;
                    currentPageProducto--;
                }
                try
                {
                    if (iteracionP == 1)
                    {
                        dgvProductos.DataSource = miBussinesInventario.ProductoConCorte
                                                            (rowProducto, rowMaxProducto);
                    }
                    else
                    {
                        if (iteracionP == 3)
                        {
                            dgvProductos.DataSource = miBussinesInventario.ConsultaProductoResumenInventario
                                                            (rowProducto, rowMaxProducto);
                        }
                        else
                        {
                            int criterio = (int)this.cbCriterio.SelectedValue;
                            if (criterio == 2)
                            {
                                dgvProductos.DataSource =
                                    miBussinesInventario.ConsultaProductoPorCategoria
                                    (txtCodigo.Text, rowProducto, rowMaxProducto);
                            }
                        }
                    }
                    statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                    dgvProductos_CellClick(null, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnteriorRowProducto_Click(object sender, EventArgs e)
        {
            ///Retrocede a la pagina anterior de la actual.
            if (iteracionP == 1)
            {
                if (currentPageProducto > 1)
                {
                    rowProducto = rowProducto - rowMaxProducto;
                    if (rowProducto <= 0)
                        rowProducto = 0;
                    try
                    {
                    dgvProductos.DataSource = miBussinesInventario.ProductoConCorte
                        (rowProducto, rowMaxProducto);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    dgvProductos_CellClick(null, null);
                    currentPageProducto--;
                    statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                }
            }
            else
            {
                if (iteracionP == 3)
                {
                    if (currentPageProducto > 1)
                    {
                        rowProducto = rowProducto - rowMaxProducto;
                        if (rowProducto <= 0)
                            rowProducto = 0;
                        try
                        {
                            dgvProductos.DataSource = miBussinesInventario.ConsultaProductoResumenInventario
                                (rowProducto, rowMaxProducto);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        dgvProductos_CellClick(null, null);
                        currentPageProducto--;
                        statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                    }
                }
                else
                {
                    int criterio = (int)this.cbCriterio.SelectedValue;
                    if (criterio == 2)
                    {
                        if (currentPageProducto > 1)
                        {
                            rowProducto = rowProducto - rowMaxProducto;
                            if (rowProducto <= 0)
                                rowProducto = 0;
                            try
                            {
                                dgvProductos.DataSource =
                                    miBussinesInventario.ConsultaProductoPorCategoria
                                    (txtCodigo.Text, rowProducto, rowMaxProducto);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                            dgvProductos_CellClick(null, null);
                            currentPageProducto--;
                            statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                        }
                    }
                }
            }
        }

        private void btnSiguienteRowProducto_Click(object sender, EventArgs e)
        {
            ///Avanza a la pagina siguiente de la actual
            if (iteracionP == 1)
            {
                if (currentPageProducto < paginasProducto)
                {
                    rowProducto = rowProducto + rowMaxProducto;
                    try
                    {
                    dgvProductos.DataSource = miBussinesInventario.ProductoConCorte
                        (rowProducto, rowMaxProducto);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    currentPageProducto++;
                    statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                    dgvProductos_CellClick(null, null);
                }
            }
            else
            {
                if (iteracionP == 3)
                {
                    if (currentPageProducto < paginasProducto)
                    {
                        rowProducto = rowProducto + rowMaxProducto;
                        try
                        {
                            dgvProductos.DataSource = miBussinesInventario.ConsultaProductoResumenInventario
                                (rowProducto, rowMaxProducto);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        currentPageProducto++;
                        statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                        dgvProductos_CellClick(null, null);
                    }
                }
                else
                {
                    int criterio = (int)this.cbCriterio.SelectedValue;
                    if (criterio == 2)
                    {
                        if (currentPageProducto < paginasProducto)
                        {
                            rowProducto = rowProducto + rowMaxProducto;
                            try
                            {
                                dgvProductos.DataSource =
                                    miBussinesInventario.ConsultaProductoPorCategoria
                                    (txtCodigo.Text, rowProducto, rowMaxProducto);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                            currentPageProducto++;
                            statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                            dgvProductos_CellClick(null, null);
                        }
                    }
                }
            }
        }

        private void btnFinRowProducto_Click(object sender, EventArgs e)
        {
            ///Avanza hasta la ultima pagina de los registros.
            if (currentPageProducto < paginasProducto)
            {
                var paginaActual = currentPageProducto;
                for (int i = paginaActual; i < paginasProducto; i++)
                {
                    rowProducto = rowProducto + rowMaxProducto;
                    currentPageProducto++;
                }
                try
                {
                    if (iteracionP == 1)
                    {
                        dgvProductos.DataSource = miBussinesInventario.ProductoConCorte
                                                            (rowProducto, rowMaxProducto);
                    }
                    else
                    {
                        if (iteracionP == 3)
                        {
                            dgvProductos.DataSource = miBussinesInventario.ConsultaProductoResumenInventario
                                                            (rowProducto, rowMaxProducto);
                        }
                        else
                        {
                            int criterio = (int)this.cbCriterio.SelectedValue;
                            if (criterio == 2)
                            {
                                dgvProductos.DataSource =
                                    miBussinesInventario.ConsultaProductoPorCategoria
                                    (txtCodigo.Text, rowProducto, rowMaxProducto);
                            }
                        }
                    }
                    statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
                    dgvProductos_CellClick(null, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void cbConsultaInventario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)this.cbConsultaInventario.SelectedValue;
            if (id == 1)
                cbCriterioConsulta.Enabled = false;
            else
                cbCriterioConsulta.Enabled = true;
               // panelHistorial.Enabled = false;
            //else
                //panelHistorial.Enabled = true;
            dgvProductos_CellClick(null, null);
        }

        private void cbCriterioConsulta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var id = (int)this.cbCriterioConsulta.SelectedValue;
            if (id == 0)
            {
                HabilitarFechas(false, false, false);
            }
            else
            {
                if (id == 1)
                {
                    HabilitarFechas(false, false, false);
                    ConsultarUltimoRegistro();
                }
                else
                {
                    if (id == 2)
                    {
                        HabilitarFechas(true, false, true);
                    }
                    else
                    {
                        HabilitarFechas(true, true, true);
                    }
                }
            }
        }

        private void btnBuscaInventario_Click(object sender, EventArgs e)
        {
            int criterio = (int)this.cbCriterioConsulta.SelectedValue;
            if (criterio == 2)
            {
                ConsultaInventarioFecha();
            }
            else
            {
                if (criterio == 3)
                {
                    ConsultaInventarioPeriodoFechas();
                }
            }
        }

        private void btnInicioRowInventario_Click(object sender, EventArgs e)
        {
            ///Avanza hasta la primera pagina de los registros.
            var codigo = "";
            if (dgvProductos.RowCount != 0)
            {
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            }
            if (currentPageInventario > 1)
            {
                var paginaActual = currentPageInventario;
                for (int i = paginaActual; i > 1; i--)
                {
                    rowInventario = rowInventario - rowMaxInventario;
                    currentPageInventario--;
                }
                if (iteracion == 1)
                {
                    try
                    {
                        bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFisico
                            (codigo, rowInventario, rowMaxInventario);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    if (iteracion == 2)
                    {
                        try
                        {
                            bindigSource.DataSource = miBussinesInventario.ConsultarInventarioFisicoNoColor
                                (codigo, rowInventario, rowMaxInventario);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        if (iteracion == 3)
                        {
                            try
                            {
                                bindigSource.DataSource = miBussinesInventario.ResumenInventarioColor
                                    (codigo, rowInventario, rowMaxInventario);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                        else
                        {
                            if (iteracion == 4)
                            {
                                try
                                {
                                    bindigSource.DataSource = miBussinesInventario.ResumenInventarioNoColor
                                        (codigo, rowInventario, rowMaxInventario);
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                            }
                            else
                            {
                                if (iteracion == 5)
                                {
                                    try
                                    {
                                        bindigSource.DataSource = miBussinesInventario.UltimoRegistroInventario
                                            (codigo, ConfiguracionColor, rowInventario, rowMaxInventario);
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                    }
                                }
                                else
                                {
                                    if (iteracion == 6)
                                    {
                                        try
                                        {
                                            bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFecha
                                                (codigo, fecha1, ConfiguracionColor, rowInventario, rowMaxInventario);
                                        }
                                        catch (Exception ex)
                                        {
                                            OptionPane.MessageError(ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        if (iteracion == 7)
                                        {
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodo
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodoNoColor
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
        }

        private void btnAnteriorRowInventario_Click(object sender, EventArgs e)
        {
            ///Retrocede a la pagina anterior de la actual.
            var codigo = "";
            if (dgvProductos.RowCount != 0)
            {
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            }
            if (iteracion == 1)
            {
                if (currentPageInventario > 1)
                {
                    rowInventario = rowInventario - rowMaxInventario;
                    if (rowInventario <= 0)
                        rowInventario = 0;
                    try
                    {
                        bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFisico
                            (codigo, rowInventario, rowMaxInventario);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                    currentPageInventario--;
                    statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                }
            }
            else
            {
                if (iteracion == 2)
                {
                    if (currentPageInventario > 1)
                    {
                        rowInventario = rowInventario - rowMaxInventario;
                        if (rowInventario <= 0)
                            rowInventario = 0;
                        try
                        {
                            bindigSource.DataSource = miBussinesInventario.ConsultarInventarioFisicoNoColor
                                (codigo, rowInventario, rowMaxInventario);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        currentPageInventario--;
                        statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                    }
                }
                else
                {
                    if (iteracion == 3)
                    {
                        if (currentPageInventario > 1)
                        {
                            rowInventario = rowInventario - rowMaxInventario;
                            if (rowInventario <= 0)
                                rowInventario = 0;
                            try
                            {
                                bindigSource.DataSource = miBussinesInventario.ResumenInventarioColor
                                    (codigo, rowInventario, rowMaxInventario);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                            currentPageInventario--;
                            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                        }
                    }
                    else
                    {
                        if (iteracion == 4)
                        {
                            if (currentPageInventario > 1)
                            {
                                rowInventario = rowInventario + rowMaxInventario;
                                if (rowInventario <= 0)
                                    rowInventario = 0;
                                try
                                {
                                    bindigSource.DataSource = miBussinesInventario.ResumenInventarioNoColor
                                        (codigo, rowInventario, rowMaxInventario);
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                                currentPageInventario--;
                                statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                            }
                        }
                        else
                        {
                            if (iteracion == 5)
                            {
                                if (currentPageInventario > 1)
                                {
                                    rowInventario = rowInventario + rowMaxInventario;
                                    if (rowInventario > 23)
                                        rowInventario = 18;
                                    try
                                    {
                                        bindigSource.DataSource = miBussinesInventario.UltimoRegistroInventario
                                            (codigo, ConfiguracionColor, rowInventario, rowMaxInventario);
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                    }
                                    currentPageInventario++;
                                    statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                }
                            }
                            else
                            {
                                if (iteracion == 6)
                                {
                                    if (currentPageInventario > 1)
                                    {
                                        rowInventario = rowInventario - rowMaxInventario;
                                        if (rowInventario <= 0)
                                            rowInventario = 0;
                                        try
                                        {
                                            bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFecha
                                                (codigo, fecha1, ConfiguracionColor, rowInventario, rowMaxInventario);
                                        }
                                        catch (Exception ex)
                                        {
                                            OptionPane.MessageError(ex.Message);
                                        }
                                        currentPageInventario--;
                                        statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                    }
                                }
                                else
                                {
                                    if (iteracion == 7)
                                    {
                                        if (currentPageInventario > 1)
                                        {
                                            rowInventario = rowInventario - rowMaxInventario;
                                            if (rowInventario <= 0)
                                                rowInventario = 0;
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodo
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                            currentPageInventario--;
                                            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                        }
                                    }
                                    else
                                    {
                                        if (currentPageInventario > 1)
                                        {
                                            rowInventario = rowInventario - rowMaxInventario;
                                            if (rowInventario <= 0)
                                                rowInventario = 0;
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodoNoColor
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                            currentPageInventario++;
                                            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnSiguienteRowInventario_Click(object sender, EventArgs e)
        {
            ///Avanza a la pagina siguiente de la actual.
            var codigo = "";
            if (dgvProductos.RowCount != 0)
            {
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            }
            if (iteracion == 1)
            {
                if (currentPageInventario < paginasInventario)
                {
                    rowInventario = rowInventario + rowMaxInventario;
                    if (rowInventario > 23)
                        rowInventario = 18;
                    try
                    {
                        bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFisico
                            (codigo, rowInventario, rowMaxInventario);
                    }
                    catch (Exception ex) 
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    currentPageInventario++;
                    statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                }
            }
            else
            {
                if (iteracion == 2)
                {
                    if (currentPageInventario < paginasInventario)
                    {
                        rowInventario = rowInventario + rowMaxInventario;
                        if (rowInventario > 23)
                            rowInventario = 18;
                        try
                        {
                            bindigSource.DataSource = miBussinesInventario.ConsultarInventarioFisicoNoColor
                                (codigo, rowInventario, rowMaxInventario);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                        currentPageInventario++;
                        statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                    }
                }
                else
                {
                    if (iteracion == 3)
                    {
                        if (currentPageInventario < paginasInventario)
                        {
                            rowInventario = rowInventario + rowMaxInventario;
                            if (rowInventario > 23)
                                rowInventario = 18;
                            try
                            {
                                bindigSource.DataSource = miBussinesInventario.ResumenInventarioColor
                                    (codigo, rowInventario, rowMaxInventario);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                            currentPageInventario++;
                            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                        }
                    }
                    else
                    {
                        if (iteracion == 4)
                        {
                            if (currentPageInventario < paginasInventario)
                            {
                                rowInventario = rowInventario + rowMaxInventario;
                                if (rowInventario > 23)
                                    rowInventario = 18;
                                try
                                {
                                    bindigSource.DataSource = miBussinesInventario.ResumenInventarioNoColor
                                        (codigo, rowInventario, rowMaxInventario);
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                                currentPageInventario++;
                                statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                            }
                        }
                        else
                        {
                            if (iteracion == 5)
                            {
                                if (currentPageInventario < paginasInventario)
                                {
                                    rowInventario = rowInventario + rowMaxInventario;
                                    if (rowInventario > 23)
                                        rowInventario = 18;
                                    try
                                    {
                                        bindigSource.DataSource = miBussinesInventario.UltimoRegistroInventario
                                            (codigo, ConfiguracionColor, rowInventario, rowMaxInventario);
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                    }
                                    currentPageInventario++;
                                    statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                }
                            }
                            else
                            {
                                if (iteracion == 6)
                                {
                                    if (currentPageInventario < paginasInventario)
                                    {
                                        rowInventario = rowInventario + rowMaxInventario;
                                        if (rowInventario > 23)
                                            rowInventario = 18;
                                        try
                                        {
                                            bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFecha
                                                (codigo, fecha1, ConfiguracionColor, rowInventario, rowMaxInventario);
                                        }
                                        catch (Exception ex)
                                        {
                                            OptionPane.MessageError(ex.Message);
                                        }
                                        currentPageInventario++;
                                        statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                    }
                                }
                                else
                                {
                                    if (iteracion == 7)
                                    {
                                        if (currentPageInventario < paginasInventario)
                                        {
                                            rowInventario = rowInventario + rowMaxInventario;
                                            if (rowInventario > 23)
                                                rowInventario = 18;
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodo
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                            currentPageInventario++;
                                            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                        }
                                    }
                                    else
                                    {
                                        if (currentPageInventario < paginasInventario)
                                        {
                                            rowInventario = rowInventario + rowMaxInventario;
                                            if (rowInventario > 23)
                                                rowInventario = 18;
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodoNoColor
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                            currentPageInventario++;
                                            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnFinRowInventario_Click(object sender, EventArgs e)
        {
            ///Avanza hasta la ultima pagina de los registros.
            var codigo = "";
            if (dgvProductos.RowCount != 0)
            {
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            }
            if (currentPageInventario < paginasInventario)
            {
                var paginaActual = currentPageInventario;
                for (int i = paginaActual; i < paginasInventario; i++)
                {
                    rowInventario = rowInventario + rowMaxInventario;
                    currentPageInventario++;
                }
                if (iteracion == 1)
                {
                    try
                    {
                        bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFisico
                            (codigo, rowInventario, rowMaxInventario);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
                else
                {
                    if (iteracion == 2)
                    {
                        try
                        {
                            bindigSource.DataSource = miBussinesInventario.ConsultarInventarioFisicoNoColor
                                (codigo, rowInventario, rowMaxInventario);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                    else
                    {
                        if (iteracion == 3)
                        {
                            try
                            {
                                bindigSource.DataSource = miBussinesInventario.ResumenInventarioColor
                                    (codigo, rowInventario, rowMaxInventario);
                            }
                            catch (Exception ex)
                            {
                                OptionPane.MessageError(ex.Message);
                            }
                        }
                        else
                        {
                            if (iteracion == 4)
                            {
                                try
                                {
                                    bindigSource.DataSource = miBussinesInventario.ResumenInventarioNoColor
                                        (codigo, rowInventario, rowMaxInventario);
                                }
                                catch (Exception ex)
                                {
                                    OptionPane.MessageError(ex.Message);
                                }
                            }
                            else
                            {
                                if (iteracion == 5)
                                {
                                    try
                                    {
                                        bindigSource.DataSource = miBussinesInventario.UltimoRegistroInventario
                                            (codigo, ConfiguracionColor, rowInventario, rowMaxInventario);
                                    }
                                    catch (Exception ex)
                                    {
                                        OptionPane.MessageError(ex.Message);
                                    }
                                }
                                else
                                {
                                    if (iteracion == 6)
                                    {
                                        try
                                        {
                                            bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFecha
                                                (codigo, fecha1, ConfiguracionColor, rowInventario, rowMaxInventario);
                                        }
                                        catch (Exception ex)
                                        {
                                            OptionPane.MessageError(ex.Message);
                                        }
                                    }
                                    else
                                    {
                                        if (iteracion == 7)
                                        {
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodo
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                        }
                                        else
                                        {
                                            try
                                            {
                                                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodoNoColor
                                                    (codigo, fecha1, fecha2, rowInventario, rowMaxInventario);
                                            }
                                            catch (Exception ex)
                                            {
                                                OptionPane.MessageError(ex.Message);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
        }

        /// <summary>
        /// Despliega el proceso en el hilo (Thread).
        /// </summary>
        private void start()
        {
            CruzarInventario();
        }

        /// <summary>
        /// Realiza la operacion en el inventario con ayuda de el hilo (Thread).
        /// </summary>
        private void CruzarInventario()
        {
            try
            {
                FirtsCorte = Convert.ToBoolean(AppConfiguracion.ValorSeccion("firstcorte"));
                miBussinesInventario.CruzarInventario(NivelaCero, InventarioSistema, fechaHoy); //revisar
                if(FirtsCorte)
                    AppConfiguracion.SaveConfiguration("firstcorte", "false");
                Success = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                Success = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de cruce de inventario.
        /// </summary>
        private void FinishProcess()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
            this.Enabled = true;
            if (Success)
                OptionPane.MessageSuccess("Las operaciones se realizaron correctamente.");
        }

        /// <summary>
        /// Inicializa la fecha y la muestra en el formulario.
        /// </summary>
        private void InicializarFechaHoy()
        {
            fechaHoy = DateTime.Today;
            lblFechaActual.Text = fechaHoy.ToLongDateString();
        }

        /// <summary>
        /// Cargar Combo Box con los criterios de Codigo de producto.
        /// </summary>
        private void CriterioConProducto()
        {
            //cbCriterioCodigo.DataSource = miCriterio.lstCodigo;
            //cbCriterioCodigo.Visible = true;
            cbCriterioCategoria.Enabled = false;
            txtCodigo.Enabled = true;
            btnBuscar.Enabled = true;
            txtCodigo.Focus();
        }

        /// <summary>
        /// Cargar el Combo Box con las categorias de producto.
        /// </summary>
        private void CriterioConCategoria()
        {
            cbCriterioCategoria.Enabled = true;
            //cbCriterioCodigo.Visible = false;
            txtCodigo.Enabled = false;
            btnBuscar.Enabled = false;
        }

        /// <summary>
        /// Estructura la consulta del producto de acuerdo con los criterios seleccionados.
        /// </summary>
        private void EstructurarConsulta()
        {
            int criterio = (int)this.cbCriterio.SelectedValue;
            rowProducto = 0;
            currentPageProducto = 1;
            if (criterio == 1 )        //Consulta por codigo de barras o codigo interno.
            {
                try
                {
                dgvProductos.DataSource =
                        miBussinesInventario.ConsultarProducto(txtCodigo.Text);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                statusPaginaProducto.Text = "1 / 1";
            }
            if (criterio == 2)                          //Consulta por categorias.
            {
                try
                {
                dgvProductos.DataSource =
                        miBussinesInventario.ConsultaProductoPorCategoria
                        (txtCodigo.Text, rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesInventario.GetTotalRowProducto(txtCodigo.Text);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                paginasProducto = totalRowProducto / rowMaxProducto;
                if (totalRowProducto % rowMaxProducto != 0)
                    paginasProducto++;
                if (currentPageProducto > paginasProducto)
                    currentPageProducto = 0;
                statusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
            }
            //if (this.dgvProductos.RowCount != 0)
                dgvProductos_CellClick(null, null);
        }

        /// <summary>
        /// Cargar el Combo box con las opciones de Medida y Color segun la configuracion de color
        /// </summary>
        private void CargarOpcionMedidaColor()
        {
            if (ConfiguracionColor)
            {
                //cbCriterioMedidaColor.DataSource = miCriterio.lstMedidaColor;
            }
            else
            {
                //cbCriterioMedidaColor.DataSource = miCriterio.lstMedidaNoColor;
                Color.Visible = false;
                this.dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        /// <summary>
        /// Estructura la consulta del Inventario Fisico.
        /// </summary>
        private void ConsultarInvetarioFisico()
        {
            var codigo = "";
            if (dgvProductos.RowCount != 0)
            {
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            }
            rowInventario = 0;
            currentPageInventario = 1;
            if (ConfiguracionColor)         //Con configuracion true en color.
            {
                try
                {
                    bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFisico
                        (codigo, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetTotalRowCorteInventario(codigo);
                    iteracion = 1;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else                           //Con configuracion false en color.
            {
                try
                {
                    bindigSource.DataSource = miBussinesInventario.ConsultarInventarioFisicoNoColor
                        (codigo, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetRowsInventarioFisicoNoColor(codigo);
                    iteracion = 2;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                currentPageInventario = 0;
            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
        }

        /// <summary>
        /// Estructura la consulta del Historial de Inventario.
        /// </summary>
        private void ConsultarHistorialInventario()
        {
            var codigo = "";
            if (dgvProductos.RowCount != 0)
            {
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            }
            rowInventario = 0;
            currentPageInventario = 1;
            if (ConfiguracionColor)
            {
                try
                {
                    bindigSource.DataSource = miBussinesInventario.ResumenInventarioColor
                        (codigo, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetRowsResumenInventarioColor(codigo);
                    iteracion = 3;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
            {
                try
                {
                    bindigSource.DataSource = miBussinesInventario.ResumenInventarioNoColor
                        (codigo, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetRowsResumenInventarioNoColor(codigo);
                    iteracion = 4;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                currentPageInventario = 0;
            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
        }

        /// <summary>
        /// Establece el valor para habilitar las fechas y el boton de busqueda.
        /// </summary>
        /// <param name="fecha1">Valor para la Fecha uno.</param>
        /// <param name="fecha2">Valor para la Fecha dos.</param>
        /// <param name="boton">Valor para el boton.</param>
        private void HabilitarFechas(bool fecha1, bool fecha2, bool boton)
        {
            this.dtFecha1.Enabled = fecha1;
            this.dtFecha2.Enabled = fecha2;
            this.btnBuscaInventario.Enabled = boton;
        }

        /// <summary>
        /// Carga el GridView con el ultimo registro de la consulta.
        /// </summary>
        private void ConsultarUltimoRegistro()
        {
            rowInventario = 0;
            currentPageInventario = 1;
            var codigo = "";
            if(dgvProductos.RowCount != 0)
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            try
            {
                bindigSource.DataSource =
                    miBussinesInventario.UltimoRegistroInventario
                    (codigo, ConfiguracionColor, rowInventario, rowMaxInventario);
                if (ConfiguracionColor)
                    totalRowInventario = miBussinesInventario.GetRowsUltimoRegistroInventario(codigo);
                iteracion = 5;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            if (ConfiguracionColor)
            {
                paginasInventario = totalRowInventario / rowMaxInventario;
                if (totalRowInventario % rowMaxInventario != 0)
                    paginasInventario++;
                if (currentPageInventario > paginasInventario)
                    paginasInventario = 0;
                statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
            else
                statusPaginaInventario.Text = "1 / 1";
        }

        /// <summary>
        /// Carga el GridView con la consulta por fecha del inventario.
        /// </summary>
        private void ConsultaInventarioFecha()
        {
            rowInventario = 0;
            currentPageInventario = 1;
            fecha1 = dtFecha1.Value;
            var codigo = "";
            if (dgvProductos.RowCount != 0)
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            try
            {
                bindigSource.DataSource = miBussinesInventario.ConsultaInventarioFecha
                    (codigo, dtFecha1.Value, ConfiguracionColor, rowInventario, rowMaxInventario);
                if (ConfiguracionColor)
                    totalRowInventario = miBussinesInventario.GetRowsConsultaInventarioFecha(codigo, dtFecha1.Value);
                iteracion = 6;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            if (ConfiguracionColor)
            {
                paginasInventario = totalRowInventario / rowMaxInventario;
                if (totalRowInventario % rowMaxInventario != 0)
                    paginasInventario++;
                if (currentPageInventario > paginasInventario)
                    paginasInventario = 0;
                statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
            else
                statusPaginaInventario.Text = "1 / 1";
        }

        /// <summary>
        /// Carga el GridView con la consulta por periodo de fechas del inventario.
        /// </summary>
        private void ConsultaInventarioPeriodoFechas()
        {
            rowInventario = 0;
            currentPageInventario = 1;
            fecha1 = dtFecha1.Value;
            fecha2 = dtFecha2.Value;
            var codigo = "";
            if (dgvProductos.RowCount != 0)
                codigo = (string)this.dgvProductos.CurrentRow.Cells[0].Value;
            if (dtFecha1.Value > dtFecha2.Value)
            {
                var temp = dtFecha1.Value;
                dtFecha1.Value = dtFecha2.Value;
                dtFecha2.Value = temp;
            }
            if (ConfiguracionColor)
            {
                try
                {
                    bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodo
                        (codigo, dtFecha1.Value, dtFecha2.Value, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetRowsConsultaInventarioPeriodo
                        (codigo, dtFecha1.Value, dtFecha2.Value);
                    iteracion = 7;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    bindigSource.DataSource = miBussinesInventario.ConsultaInventarioPeriodoNoColor
                        (codigo, dtFecha1.Value, dtFecha2.Value, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetRowsConsultaInventarioPeriodoNoColor
                        (codigo, dtFecha1.Value, dtFecha2.Value);
                    iteracion = 8;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                paginasInventario = 0;
            statusPaginaInventario.Text = currentPageInventario + " / " + paginasInventario;
        }

        private void btnEditarCantidad_Click(object sender, EventArgs e)
        {
            var frmEditarCantidad = new FrmEditarCantInventarioFisico();
            frmEditarCantidad.Id = Convert.ToInt32(this.dgvInventario.CurrentRow.Cells["Id"].Value);//Id 
            frmEditarCantidad.txtCantidad.Text = Convert.ToDouble(this.dgvInventario.CurrentRow.Cells["Fisico"].Value).ToString().Replace(',', '.');
            frmEditarCantidad.ShowDialog();
            this.dgvProductos_CellClick(this.dgvProductos, null);
        }
    }

    /// <summary>
    /// Representa una clase para estructurar criterios.
    /// </summary>
    internal class CriterioRelacion
    {
        /// <summary>
        /// Obtiene o establece las opciones para los criterios de busqueda.
        /// </summary>
        public List<Opcion> lstCriterio { set; get; }

        /// <summary>
        /// Obtiene o establece las opciones para consultas de inventario.
        /// </summary>
        public List<Opcion> lstInventario { set; get; }

        /// <summary>
        /// Obtiene o establece las opciones se seleccion en medida y/o color.
        /// </summary>
        public List<Opcion> lstMedidaColor { set; get; }

        /// <summary>
        /// Obtiene o establece las opciones se seleccion en medida sin color.
        /// </summary>
        public List<Opcion> lstMedidaNoColor { set; get; }

        /// <summary>
        /// Obtiene o establece las opciones de criterio de consulta de inventario.
        /// </summary>
        public List<Opcion> lstCriterioConsulta { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase Criterio.
        /// </summary>
        public CriterioRelacion()
        {
            this.lstCriterio = new List<Opcion>();
            this.lstCriterio.Add(new Opcion
            {
                Id = 1,
                Nombre = "Producto"
            });
            this.lstCriterio.Add(new Opcion
            {
                Id = 2,
                Nombre = "Categoria de Productos"
            });

            this.lstInventario = new List<Opcion>();
            this.lstInventario.Add(new Opcion
            {
                Id = 1,
                Nombre = "Corte Pendiente"
            });
            this.lstInventario.Add(new Opcion
            {
                Id = 2,
                Nombre = "Historial de Producto"
            });

            this.lstMedidaColor = new List<Opcion>();
            this.lstMedidaColor.Add(new Opcion
            {
                Id = 1,
                Nombre = "Medida y Color"
            });
            this.lstMedidaColor.Add(new Opcion
            {
                Id = 2,
                Nombre = "Sin Media"
            });
            this.lstMedidaColor.Add(new Opcion
            {
                Id = 3,
                Nombre = "Sin Color"
            });
            this.lstMedidaColor.Add(new Opcion
            {
                Id = 4,
                Nombre = "Sin Medida y Sin Color"
            });

            this.lstMedidaNoColor = new List<Opcion>();
            this.lstMedidaNoColor.Add(new Opcion
            {
                Id = 1,
                Nombre = "Con Medida"
            });
            this.lstMedidaNoColor.Add(new Opcion
            {
                Id = 2,
                Nombre = "Sin Media"
            });

            lstCriterioConsulta = new List<Opcion>();
            lstCriterioConsulta.Add(new Opcion
            {
                Id = 0,
                Nombre = ""
            });
            lstCriterioConsulta.Add(new Opcion
            {
                Id = 1,
                Nombre = "Ultimo Registro"
            });
            lstCriterioConsulta.Add(new Opcion
            {
                Id = 2,
                Nombre = "Por Fecha"
            });
            lstCriterioConsulta.Add(new Opcion
            {
                Id = 3,
                Nombre = "Periodo de Fecha"
            });
        }
    }
}