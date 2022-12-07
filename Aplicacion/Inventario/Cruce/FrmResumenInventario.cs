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

namespace Aplicacion.Inventario.Cruce
{
    public partial class FrmResumenInventario : Form
    {
        /// <summary>
        /// Obtiene o establece el valor que indica si se carga el corte pendiente o no.
        /// </summary>
        public bool CortePendiente { set; get; }

        /// <summary>
        /// Objeto de logica de negocio de Inventario.
        /// </summary>
        private BussinesInventario miBussinesInventario;

        /// <summary>
        /// Obtiene o establece el valor de id del orden asignado
        /// </summary>
        private int idOrden { set; get; }

        /// <summary>
        /// Objeto para la manipulacion de criterios de orden.
        /// </summary>
        private CriterioOrden miCriterioOrden;

        private DateTime SelectDate { set; get; }

        /// <summary>
        /// Obtiene o establece el valor de registro inicial de consulta de Inventario.
        /// </summary>
        private int rowInventario;

        /// <summary>
        /// Obtiene o establece el total de registros a recuperar.
        /// </summary>
        private int rowMaxInventario;

        /// <summary>
        /// Obtiene o establece el total de registros que representan el inventario.
        /// </summary>
        private long totalRowInventario;

        /// <summary>
        /// Obtiene o establece el total de paginas que se generan en el DataGridView.
        /// </summary>
        private long paginasInventario;

        /// <summary>
        /// Obtiene o establece la pagina actual en la cual se encuentran los registros del Inventario en el Grid.
        /// </summary>
        private int currentPageInventario;

        private string CategoriaActual;

        private string NombreActual;

        private DateTime FechaActual;

        /// <summary>
        /// Inicaliza una nueva instancia de frmCorteGeneral.
        /// </summary>
        public FrmResumenInventario()
        {
            InitializeComponent();
            miBussinesInventario = new BussinesInventario();
            miCriterioOrden = new CriterioOrden();
            rowMaxInventario = 15;
        }

        private void frmCorteGeneral_Load(object sender, EventArgs e)
        {
            CargarUtilidades();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
            cbOrden.DataSource = miCriterioOrden.ListaOrden;
            /*if (CortePendiente)
            {
                CargarCorteGeneral();
            }*/
            /*else
            {
                CargarResumenInventario();
            }*/
            //MostrarRegistrosSinInventario();
        }

        private void frmCorteGeneral_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void tsBtnListarTodos_Click(object sender, EventArgs e)
        {
            CargarResumenInventario();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbCriterio_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(4))
            {
                txtCodigo.Enabled = false;
                btnFecha.Enabled = true;
                btnFecha.Focus();
            }
            else
            {
                btnFecha.Enabled = false;
                txtCodigo.Enabled = true;
                txtCodigo.Focus();
                //SelectDate = DateTime.;
            }
           /* var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id.Equals(1))
            {
                txtCodigo.Enabled = false;
            }
            else
            {
                if (id.Equals(2))
                {
                    txtCodigo.Enabled = true;
                    txtCodigo.Focus();
                }
                else
                {
                    txtCodigo.Enabled = false;
                }
            }*/
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            var frmCorte = new FrmCorte();
            frmCorte.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            dgvInventario.AutoGenerateColumns = false;
            switch (Convert.ToInt32(cbCriterio.SelectedValue))
            {
                case 1:
                    {
                        ConsultaResumenInventarioCategoria(txtCodigo.Text);
                        break;
                    }
                case 2:
                    {
                        ConsultaResumenInventario(txtCodigo.Text);
                        break;
                    }
                case 3:
                    {
                        ConsultaResumenInventarioNombre(txtCodigo.Text);
                        break;
                    }
                case 4:
                    {
                        if (txtCodigo.Text != "")
                        {
                            ConsultaResumenInventario(SelectDate);
                        }
                        break;
                    }
            }
            ColorearGrid();
            /*var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id.Equals(1))
            {
                CargarResumenInventario();
            }
            else
            {
                if (id.Equals(2))
                {
                    //CargarResumenInventario(txtCodigo.Text);
                }
                else
                {
                }
            }*/
        }

        private void btnListaTodos_Click(object sender, EventArgs e)
        {
            CargarResumenInventario();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPrintInforme = new FrmInformeInventario();
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(4))
                {
                    if (!String.IsNullOrEmpty(txtCodigo.Text))
                    {
                        frmPrintInforme.Tabla = miBussinesInventario.PrintInformeResumen(SelectDate, Convert.ToInt32(cbOrden.SelectedValue));
                        frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeResumenInventario.rdlc";
                        ///frmPrintInforme.ReportPath = @"C:\reports\InformeResumenInventario.rdlc";
                        frmPrintInforme.Fecha = SelectDate;
                        frmPrintInforme.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe seleccionar una fecha.");
                    }
                }
                else
                {
                    frmPrintInforme.Tabla = miBussinesInventario.PrintInformeResumen(Convert.ToInt32(cbOrden.SelectedValue));
                    frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeResumenInventario.rdlc";
                    ///frmPrintInforme.ReportPath = @"C:\reports\InformeResumenInventario.rdlc";
                    frmPrintInforme.Fecha = DateTime.Now;
                    frmPrintInforme.ShowDialog();
                }
                //frmPrint.RptvFactura.LocalReport.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeResumenInventario.rdlc";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbOrden_SelectionChangeCommitted(object sender, EventArgs e)
        {
            /*cbCriterio.SelectedIndex = 0;
            CargarResumenInventario();
           /* var id = Convert.ToInt32(cbOrden.SelectedValue);
            RecargarGridInventario(id);*/
        }

        private void btnInicioRowInventario_Click(object sender, EventArgs e)
        {
            if (currentPageInventario > 1)
            {
                var paginaActual = currentPageInventario;
                for (int i = paginaActual; i > 1; i--)
                {
                    rowInventario = rowInventario - rowMaxInventario;
                    currentPageInventario--;
                }
                try
                {
                    if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                       // MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                ColorearGrid();
                lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (currentPageInventario > 1)
            {
                rowInventario = rowInventario - rowMaxInventario;
                if (rowInventario <= 0)
                    rowInventario = 0;
                try
                {
                    if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                      //  MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                ColorearGrid();
                currentPageInventario--;
                lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ///Avanza a la pagina siguiente de la actual
            if (currentPageInventario < paginasInventario)
            {
                rowInventario = rowInventario + rowMaxInventario;
                try
                {
                    if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                       // MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                ColorearGrid();
                currentPageInventario++;
                lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
        }

        private void btnFinRowInventario_Click(object sender, EventArgs e)
        {
            if (currentPageInventario < paginasInventario)
            {
                var paginaActual = currentPageInventario;
                for (int i = paginaActual; i < paginasInventario; i++)
                {
                    rowInventario = rowInventario + rowMaxInventario;
                    currentPageInventario++;
                }
                try
                {
                    if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                       // MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
                ColorearGrid();
                lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;
            }
        }

        private void CargarUtilidades()
        {
            var lst = new List<Aplicacion.Inventario.Producto.Criterio>();
            lst.Add(new Producto.Criterio
            {
                Id = 1,
                Nombre = "Por Categoria"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 2,
                Nombre = "Por Código"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 3,
                Nombre = "Por Nombre"
            });
            lst.Add(new Producto.Criterio
            {
                Id = 4,
                Nombre = "Por Fecha"
            });
            cbCriterio.DataSource = lst;
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                //SelectDate = Convert.ToDateTime(args.MiObjeto);
                var corte = (DTO.Clases.Corte)args.MiObjeto;
                SelectDate = corte.Fecha;
                txtCodigo.Text = corte.Fecha.ToShortDateString();//Convert.ToDateTime(args.MiObjeto).ToShortDateString();
                btnBuscar.Focus();
            }
            catch { }
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta del resultado del inventario cruzado.
        /// </summary>
        private void CargarResumenInventario()
        {
            rowInventario = 0;
            currentPageInventario = 1;
            try
            {
                dgvInventario.AutoGenerateColumns = false;
                //dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(rowInventario, rowMaxInventario);
                dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                                           (Convert.ToInt32(cbOrden.SelectedValue), rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaResumenInventario();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                currentPageInventario = 0;
            lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;
        }

        private void ConsultaResumenInventario(string codigo)
        {
            try
            {
                dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(codigo);//, rowInventario, rowMaxInventario);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            lblStatusInventario.Text = "1 / 1";
        }

        private void ConsultaResumenInventarioCategoria(string categoria)
        {
            rowInventario = 0;
            currentPageInventario = 1;
            CategoriaActual = categoria;
            try
            {
                dgvInventario.DataSource = miBussinesInventario.
                    ConsultaResumenInventarioCategoria(categoria, rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaResumenInventarioCategoria(categoria);
                CargarPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaResumenInventarioNombre(string nombre)
        {
            rowInventario = 0;
            currentPageInventario = 1;
            NombreActual = nombre;
            try
            {
                dgvInventario.DataSource = miBussinesInventario.
                    ConsultaResumenInventarioNombre(nombre, rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaResumenInventarioNombre(nombre);
                CargarPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaResumenInventario(DateTime fecha)
        {
            rowInventario = 0;
            currentPageInventario = 1;
            FechaActual = fecha;
            try
            {
                dgvInventario.DataSource = 
                    miBussinesInventario.ConsultaResumenInventario(fecha, rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaResumenInventario(fecha);
                CargarPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarPaginas()
        {
            paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                currentPageInventario = 0;
            lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;
        }

        private void ColorearGrid()
        {
            var cont = 0;
            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                cont++;
                if (cont % 2 != 0)
                {
                    row.DefaultCellStyle.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
                }
            }
        }
    }
}