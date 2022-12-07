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
    public partial class frmCorteGeneral : Form
    {
        /// <summary>
        /// Obtiene o establece el valor que indica si se carga el corte pendiente o no.
        /// </summary>
        public bool CortePendiente { set; get; }

        /// <summary>
        /// Objeto de logica de negocio de Inventario.
        /// </summary>
        private BussinesInventario miBussinesInventario;

        private BussinesCaja miBussinesCaja;

        /// <summary>
        /// Obtiene o establece el valor de id del orden asignado
        /// </summary>
       // private int idOrden { set; get; }

        /// <summary>
        /// Objeto para la manipulacion de criterios de orden.
        /// </summary>
        private CriterioOrden miCriterioOrden;

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

        private int Iteracion;

        private DTO.Clases.Corte CorteActual { set; get; }
        //private DateTime SelectDate { set; get; }

        private string CategoriaActual;

        private string NombreActual;

        private int IdOrden { set; get; }

        /// <summary>
        /// Inicaliza una nueva instancia de frmCorteGeneral.
        /// </summary>
        public frmCorteGeneral()
        {
            InitializeComponent();
            miBussinesInventario = new BussinesInventario();
            miBussinesCaja = new BussinesCaja();
            miCriterioOrden = new CriterioOrden();
            Iteracion = 0;
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
            CargarCorteGeneral();
        }

        private void tsBtnCopia_Click(object sender, EventArgs e)
        {

        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbOrden_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //CargarCorteGeneral();
            /*var id = Convert.ToInt32(cbOrden.SelectedValue);
            RecargarGridInventario(id);*/
        }

        private void btnListaTodos_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtCodigo.Text))
            {
                CargarCorteGeneral();
            }
            else
            {
                if (CorteActual != null)
                {
                    ConsultaPorCorteOrden();
                }
                else
                {
                    CargarCorteGeneral();
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPrintInforme = new FrmInformeInventario();
                frmPrintInforme.NoCaja = miBussinesCaja.CajaId(Convert.ToInt32(AppConfiguracion.ValorSeccion("id_caja"))).Numero.ToString();
                if (Convert.ToInt32(cbCriterio.SelectedValue).Equals(4))
                {
                    if (!String.IsNullOrEmpty(txtCodigo.Text))
                    {
                        frmPrintInforme.Tabla = miBussinesInventario.PrintInformeCorte
                                    (Convert.ToInt32(cbOrden.SelectedValue), CorteActual.Numero);
                        frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeCorteInventario.rdlc";
                        ///frmPrintInforme.ReportPath = @"C:\reports\InformeCorteInventario.rdlc";
                        frmPrintInforme.Fecha = CorteActual.Fecha;
                        frmPrintInforme.ShowDialog();
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe seleccionar una fecha.");
                    }
                }
                else
                {
                    frmPrintInforme.Tabla = miBussinesInventario.PrintInformeCorte(Convert.ToInt32(cbOrden.SelectedValue));
                    frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeCorteInventario.rdlc";
                    ///frmPrintInforme.ReportPath = @"C:\reports\InformeCorteInventario.rdlc";
                    frmPrintInforme.Fecha = Convert.ToDateTime(frmPrintInforme.Tabla.AsEnumerable().Min(row => row["Fecha"]));
                    frmPrintInforme.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
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
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                                                           (IdOrden, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCortePorCategoria
                                                           (CategoriaActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaPorNombre
                                                           (NombreActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource =
                                  miBussinesInventario.ConsultaPorCorte(CorteActual.Numero, rowInventario, rowMaxInventario);
                                break;
                            }
                    }
                    MostrarRegistrosSinInventario();
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
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
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                                                           (IdOrden, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCortePorCategoria
                                                           (CategoriaActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaPorNombre
                                                           (NombreActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource =
                                  miBussinesInventario.ConsultaPorCorte(CorteActual.Numero, rowInventario, rowMaxInventario);
                                break;
                            }
                    }
                    MostrarRegistrosSinInventario();
                    /*if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                        MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
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
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                                                           (IdOrden, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCortePorCategoria
                                                           (CategoriaActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaPorNombre
                                                           (NombreActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource =
                                  miBussinesInventario.ConsultaPorCorte(CorteActual.Numero, rowInventario, rowMaxInventario);
                                /*dgvInventario.DataSource = miBussinesInventario.ConsultaPorCorte
                                         (Convert.ToInt32(cbCorte.SelectedValue), rowInventario, rowMaxInventario);*/
                                break;
                            }
                    }
                    MostrarRegistrosSinInventario();
                    /*if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                        MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
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
                    switch (Iteracion)
                    {
                        case 1:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                                                           (IdOrden, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 2:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaCortePorCategoria
                                                           (CategoriaActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 3:
                            {
                                dgvInventario.DataSource = miBussinesInventario.ConsultaPorNombre
                                                           (NombreActual, rowInventario, rowMaxInventario);
                                break;
                            }
                        case 4:
                            {
                                dgvInventario.DataSource =
                                  miBussinesInventario.ConsultaPorCorte(CorteActual.Numero, rowInventario, rowMaxInventario);
                                break;
                            }
                    }
                    MostrarRegistrosSinInventario();
                    /*if (CortePendiente)
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral
                            (idOrden, rowInventario, rowMaxInventario);
                        MostrarRegistrosSinInventario();
                    }
                    else
                    {
                        dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario
                            (idOrden, rowInventario, rowMaxInventario);
                    }*/
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
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
                Nombre = "Por Codigo"
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

        /// <summary>
        /// Carga el Grid con el resultado de la consulta del Corte de inventario pendiente.
        /// </summary>
        private void CargarCorteGeneral()
        {
            //var idOrden = Convert.ToInt32(cbOrden.SelectedValue);
            Iteracion = 1;
            rowInventario = 0;
            currentPageInventario = 1;
            IdOrden = Convert.ToInt32(cbOrden.SelectedValue);
            try
            {
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = 
                    miBussinesInventario.ConsultaCorteGeneral(Convert.ToInt32(cbOrden.SelectedValue), rowInventario, rowMaxInventario);
                MostrarRegistrosSinInventario();
                totalRowInventario = miBussinesInventario.GetRowsConsultaCorteGeneral();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CargarPaginas();
            /*paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                currentPageInventario = 0;
            lblStatusInventario.Text = currentPageInventario + " / " + paginasInventario;*/
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
                dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(rowInventario, rowMaxInventario);
                //dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(1, rowInventario, rowMaxInventario);
                //idOrden = 1;
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

       /* private void CargarResumenInventario(string codigo)
        {
            rowInventario = 0;
            currentPageInventario = 1;
            try
            {
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(codigo, rowInventario, rowMaxInventario);
                //dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(1, rowInventario, rowMaxInventario);
                //idOrden = 1;
                //totalRowInventario = miBussinesInventario.GetRowsConsultaResumenInventario();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
           /* paginasInventario = totalRowInventario / rowMaxInventario;
            if (totalRowInventario % rowMaxInventario != 0)
                paginasInventario++;
            if (currentPageInventario > paginasInventario)
                currentPageInventario = 0;*/
            //lblStatusInventario.Text = 1 + " / " + 1;
        //}

        /// <summary>
        /// Resalta los registro de los productos que no se encuentran en inventario.
        /// </summary>
        public void MostrarRegistrosSinInventario()
        {
            foreach (DataGridViewRow row in dgvInventario.Rows)
            {
                if(!Convert.ToBoolean(row.Cells["Estado"].Value))
                {
                    //row.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    row.DefaultCellStyle.BackColor = System.Drawing.Color.Silver;
                }
            }
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta a inventario segun el orden especificado.
        /// </summary>
        /// <param name="id">Id de orden seleccionado.</param>
        private void RecargarGridInventario(int id)
        {
            /*rowInventario = 0;
            try
            {
                if (CortePendiente)
                {
                    dgvInventario.DataSource = miBussinesInventario.ConsultaCorteGeneral(id, rowInventario, rowMaxInventario);
                    MostrarRegistrosSinInventario();
                }
                else
                {
                    dgvInventario.DataSource = miBussinesInventario.ConsultaResumenInventario(id, rowInventario, rowMaxInventario);
                }
                idOrden = id;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
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
            }
            /*var id = Convert.ToInt32(cbCriterio.SelectedValue);
            if (id.Equals(4))
            {
                txtCodigo.Visible = false;
                cbCorte.Visible = true;
                btnBuscar.Visible = false;
                ConsultaPorCorte();
            }
            else
            {
                cbCorte.Visible = false;
                txtCodigo.Visible = true;
                btnBuscar.Visible = true;
            }*/


            /*if (id.Equals(1))
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

        private void cbCorte_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ConsultaPorCorte();
        }

        private void btnFecha_Click(object sender, EventArgs e)
        {
            var frmCorte = new FrmCorte();
            frmCorte.ShowDialog();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(cbCriterio.SelectedValue);
            dgvInventario.AutoGenerateColumns = false;
            rowInventario = 0;
            currentPageInventario = 1;
            switch (id)
            {
                case 1:
                    {
                        ConsultaPorCategoria();
                        break;
                    }
                case 2:
                    {
                        ConsultaPorCodigo();
                        break;
                    }
                case 3:
                    {
                        ConsultaPorNombre();
                        break;
                    }
                case 4:
                    {
                        ConsultaPorCorte();
                        break;
                    }
            }
            MostrarRegistrosSinInventario();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnBuscar_Click(this.btnBuscar, new EventArgs());
            }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                CorteActual = (DTO.Clases.Corte)args.MiObjeto;
                txtCodigo.Text = CorteActual.Fecha.ToShortDateString();
                btnBuscar.Focus();

               /* SelectDate = Convert.ToDateTime(args.MiObjeto);
                txtCodigo.Text = Convert.ToDateTime(args.MiObjeto).ToShortDateString();
                btnBuscar.Focus();*/
            }
            catch { }
        }

        private void ConsultaPorCategoria()
        {
            try
            {
                Iteracion = 2;
                CategoriaActual = txtCodigo.Text;
                dgvInventario.DataSource = 
                    miBussinesInventario.ConsultaCortePorCategoria(txtCodigo.Text, rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaCortePorCategoria(txtCodigo.Text);
                //MostrarRegistrosSinInventario();
                CargarPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaPorCodigo()
        {
            try
            {
                dgvInventario.DataSource = miBussinesInventario.ConsultaPorCodigo(txtCodigo.Text);
                lblStatusInventario.Text = "1 / 1";
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaPorNombre()
        {
            try
            {
                Iteracion = 3;
                NombreActual = txtCodigo.Text;
                dgvInventario.DataSource = 
                    miBussinesInventario.ConsultaPorNombre(txtCodigo.Text, rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaPorNombre(txtCodigo.Text);
                CargarPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaPorCorte()
        {
            try
            {
                if (!String.IsNullOrEmpty(txtCodigo.Text))
                {
                    Iteracion = 4;
                    rowInventario = 0;
                    currentPageInventario = 1;
                    dgvInventario.AutoGenerateColumns = false;
                    // var idCorte = Convert.ToInt32(cbCorte.SelectedValue);
                    //rowMaxInventario = 17500;
                    dgvInventario.DataSource =
                                  miBussinesInventario.ConsultaPorCorte(CorteActual.Numero, rowInventario, rowMaxInventario);
                    totalRowInventario = miBussinesInventario.GetRowsConsultaCorteGeneral();
                    CargarPaginas();
                }
                else
                {
                    OptionPane.MessageInformation("Debe seleccionar una fecha de corte.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void ConsultaPorCorteOrden()
        {
            try
            {
                Iteracion = 5;
                rowInventario = 0;
                currentPageInventario = 1;
                IdOrden = Convert.ToInt32(cbOrden.SelectedValue);
                dgvInventario.AutoGenerateColumns = false;
                dgvInventario.DataSource = miBussinesInventario.ConsultaPorCorte
                                    (IdOrden, CorteActual.Numero, rowInventario, rowMaxInventario);
                totalRowInventario = miBussinesInventario.GetRowsConsultaCorteGeneral();
                CargarPaginas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
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
    }

    /// <summary>
    /// Representa una clase para la estructura de Criterios de Orden.
    /// </summary>
    internal class CriterioOrden
    {
        /// <summary>
        /// Obtiene o establece la lista de opciones de criterio de orden.
        /// </summary>
        public List<Producto.Criterio> ListaOrden { set; get; }

        /// <summary>
        /// Inicializa una nueva instancia de la clase CriterioOrden.
        /// </summary>
        public CriterioOrden()
        {
            this.ListaOrden = new List<Producto.Criterio>();
            this.ListaOrden.Add
                (new Producto.Criterio
                {
                    Id = 1,
                    Nombre = "Categoría"
                });
            this.ListaOrden.Add
                (new Producto.Criterio
                {
                    Id = 2,
                    Nombre = "Código"
                });
            this.ListaOrden.Add(
                new Producto.Criterio
                {
                    Id = 3,
                    Nombre = "Nombre A-Z"
                });
            this.ListaOrden.Add(
                new Producto.Criterio
                {
                    Id = 4,
                    Nombre = "Nombre Z-A"
                });
        }
    }
}