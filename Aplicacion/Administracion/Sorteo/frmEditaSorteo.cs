using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;
using CustomControl;


namespace Aplicacion.Administracion.Sorteo
{
    public partial class frmEditaSorteo : Form
    {
        /// <summary>
        /// Atributos del modelo de negicios.
        /// </summary>
        private BussinesSorteo miBussinesSorteo;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesProducto miProducto;

        /// <summary>
        /// Atributos de  modelo de negocios.
        /// </summary>
        private BussinesCategoria miCategoria;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesMarca miMarca;

        /// <summary>
        /// atributos del modelo de negocios.
        /// </summary>
        private BussinesTipoSorteo miBussinestipoSorteo;

        /// <summary>
        /// carga los criterios de busqueda de aplicaventa.
        /// </summary>
        private CargarCriteriosAplicaventa miAplicaVenta;

        /// <summary>
        ///Carga los criterios de tiquete multiple. 
        /// </summary>
        private CargaCriterioTiqueteMultiple miTiqueteMultiple;

        /// <summary>
        /// Carga los criterios de Aplicahora.
        /// </summary>
        private CargaCriterioHora miCriterioHora;

        /// <summary>
        /// provador de mensajes de error.
        /// </summary>
        private ErrorProvider er;

        /// <summary>
        /// obtiene o establece el valor de dato a validar.
        /// </summary>
        private string iddgv;

        /// <summary>
        /// Representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Obtiene los datos de la tabla original
        /// </summary>
        private DataTable tabla;

        /// <summary>
        /// Establese la codicion de fechas en la validacion.
        /// </summary>
        private bool dtpFechas = false;

        /// <summary>
        /// Establese la condicion de fecha sorteo en la validacion.
        /// </summary>
        private bool dtpFechasorteo = false;

        /// <summary>
        /// Establese la condicion de horas en la validacion.
        /// </summary>
        private bool dtpHoras = false;

        /// <summary>
        /// Establese la condicion de nombre sorteo e la validacion.
        /// </summary>
        private bool modificaNombre = false;

        /// <summary>
        /// Establese lña condicion de concepto categoria en la validacion.
        /// </summary>
        private bool modificaConcepto = false;

        /// <summary>
        /// Establese la condicion de patrocinador en la validacion.
        /// </summary>
        private bool modificaPatrocinador = false;

        /// <summary>
        /// Establse la condicion de premio en la validacion.
        /// </summary>
        private bool modificaPremio = false;

        /// <summary>
        /// Establece la condicion de valor minimo en la validacion.
        /// </summary>
        private bool modificaValorMinimo = false;

        /// <summary>
        /// Establece la condicion de valor premio en la validacion.
        /// </summary>
        private bool modificaValorPremio = false;

        /// <summary>
        /// Establece la condicionde valores de btn al precionarlo.
        /// </summary>
        private bool btnPreset = false;

        /// <summary>
        /// Establece la condicion de la lista de sorteo el la validacion.
        /// </summary>
        private bool lstMarca,
                     lstCategoria,
                     lstProducto = false;

        private DTO.Clases.Sorteo miSorteoOriginal;

        frmSorteo formSorteo = new frmSorteo();

        public frmEditaSorteo()
        {
            InitializeComponent();
            miBussinesSorteo = new BussinesSorteo();
            miBussinestipoSorteo = new BussinesTipoSorteo();
            miCategoria = new BussinesCategoria();
            miMarca = new BussinesMarca();
            miProducto = new BussinesProducto();
            miAplicaVenta = new CargarCriteriosAplicaventa();
            miTiqueteMultiple = new CargaCriterioTiqueteMultiple();
            miCriterioHora = new CargaCriterioHora();
            er = new ErrorProvider();
        }

        private void frmEditaSorteo_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            cbxModificaTipoSorteo.DataSource = miBussinestipoSorteo.ListaTipoSorteo();
            cbxModificaAplicaventa.DataSource = miAplicaVenta.listaAplica;
            cbxModificaTipoTiquete.DataSource = miTiqueteMultiple.listaTiquete;
            cbxModificaAplicaHora.DataSource = miCriterioHora.listahora;
            OrderComboBox();
        }

        private void tsbtnEditaGuardar_Click(object sender, EventArgs e)
        {
            revalidar();
            var sorteo = new DTO.Clases.Sorteo();
            var aplicaVenta = (int)cbxModificaAplicaventa.SelectedValue;
            var tiqueteMultiple = (int)cbxModificaTipoTiquete.SelectedValue;
            var aplicaHora = (int)cbxModificaAplicaHora.SelectedValue;
            sorteo.IdTipoSorteo = Convert.ToInt32(this.cbxModificaTipoSorteo.SelectedValue);
            
            if (!ExisteBd(sorteo.IdTipoSorteo))
            {
                try
                {
                    if (modificaNombre && modificaConcepto && modificaPatrocinador && modificaPremio &&
                        modificaValorMinimo && modificaValorPremio && dtpFechas && dtpFechasorteo)
                    {
                        sorteo.IdSorteo = miSorteoOriginal.IdSorteo;

                        sorteo.NombreSorteo = txtModificarNombreSorteo.Text;
                        sorteo.FechaInicioSorteo = dtpModificaFechaInicio.Value;
                        miSorteoOriginal.FechaInicioSorteo = dtpModificaFechaInicio.Value;
                        sorteo.FechaFinalSorteo = dtpModificaFechaFin.Value;
                        miSorteoOriginal.FechaFinalSorteo = dtpModificaFechaFin.Value;
                        sorteo.FechaSorteo = dtpModificaFechaSorteo.Value;                        
                        sorteo.PatrocinadoresSorteo = txtModificarPatrocinaador.Text;
                        sorteo.PremioSorteo = txtModificarPremio.Text;
                        sorteo.ValorMinimoCompraSorteo = Convert.ToDouble(txtModificarValorminimoCompra.Text);
                        sorteo.ValorPremio = Convert.ToDouble(txtModificarValorPremio.Text);
                        if (rbbtnModificarActivo.Checked)
                        {
                            sorteo.EstadoSorteo = true;
                        }
                        else
                        {
                            sorteo.EstadoSorteo = false;
                        }
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
                        if (aplicaHora == 2)
                        {
                            sorteo.HoraInicio = dtpModificarHoraInicio.Value;
                            sorteo.HoraFin = dtpModificarHoraFin.Value;
                            sorteo.AplicaHora = true;
                        }
                        else
                        {
                            sorteo.HoraInicio = dtpModificarHoraInicio.Value;
                            sorteo.HoraFin = dtpModificarHoraFin.Value;
                            sorteo.AplicaHora = false;
                        }
                        sorteo.Concepto = txtModificarConcepto.Text;
                        if (sorteo.IdTipoSorteo == 2)
                        {
                            if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount > 0)
                            {
                                if (!ExisteBd(sorteo.IdTipoSorteo))
                                {

                                    lstMarca = true;
                                    er.SetError(dgvModificaSeleccionMarcaCategoriaProducto, null);
                                }
                            }
                            else
                            {
                                lstMarca = false;
                                er.SetError(dgvModificaSeleccionMarcaCategoriaProducto, "Debe igresar almenos un marca.");
                            }
                        }
                        else
                        {
                            if (sorteo.IdTipoSorteo == 3)
                            {
                                if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount > 0)
                                {
                                    lstCategoria = true;
                                    er.SetError(dgvModificaSeleccionMarcaCategoriaProducto, null);
                                }
                                else
                                {
                                    lstCategoria = false;
                                    er.SetError(dgvModificaSeleccionMarcaCategoriaProducto, "Debe igresar almenos una categoria.");
                                }
                            }
                            else
                            {
                                if (sorteo.IdTipoSorteo == 4)
                                {
                                    if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount > 0)
                                    {
                                        lstProducto = true;
                                        er.SetError(dgvModificaSeleccionMarcaCategoriaProducto, null);
                                    }
                                    else
                                    {
                                        lstProducto = false;
                                        er.SetError(dgvModificaSeleccionMarcaCategoriaProducto, "Debe igresar almenos un producto.");
                                    }
                                }
                                else
                                {
                                    if (sorteo.IdTipoSorteo == 5)
                                    {
                                        lstMarca = true;
                                    }
                                }
                            }
                        }
                        if (lstMarca || lstCategoria || lstProducto)
                        {
                            if (aplicaHora == 2)
                            {
                                if (dtpHoras)
                                {
                                    miBussinesSorteo.EditaSorteo(sorteo);
                                    OptionPane.MessageInformation("Se a ingresado sorteo con exito");
                                    lstCategoria = false;
                                    lstMarca = false;
                                    lstProducto = false;
                                }
                            }

                            else
                            {
                                miBussinesSorteo.EditaSorteo(sorteo);
                                OptionPane.MessageInformation("Se a ingresado sorteo con exito");
                                lstCategoria = false;
                                lstMarca = false;
                                lstProducto = false;
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("Desea guardar los cambios", "Edicion",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (r == DialogResult.Yes)
            {
                tsbtnEditaGuardar_Click(null, null);
                if (dtpFechas && dtpFechasorteo && modificaNombre && modificaConcepto
                    && modificaPatrocinador && modificaPremio && modificaValorMinimo && modificaValorPremio)
                {
                    if (dtpHoras)
                    {
                        btnPreset = true;
                        Close();
                    }
                    else
                    {
                        btnPreset = true;
                        Close();
                    }
                }
                else
                {
                    btnPreset = false;
                }
            }
            else
            {
                if (r == DialogResult.No)
                {
                    CompletaEventos.CapturaEventom(false);
                    btnPreset = true;
                    this.Close();
                }
            }
        }

        private void btnModificarAgregarMarcaCategoriaProducto_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxModificaTipoSorteo.SelectedValue;
            var sorteo = new DTO.Clases.Sorteo();
            var existe = false;
            try
            {
                if (criterio == 2)
                {
                    Configuracion.Marcas.frmMarca marca = new Configuracion.Marcas.frmMarca();
                    marca.CargaGrillaMarca();
                    marca.Extension = true;
                    marca.Show();
                }
                else
                {
                    if (criterio == 3)
                    {
                        if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount > 0)
                        {
                            if (!Existe(3, txtModificarBuscarMarcaCategoriaProducto.Text, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                            {
                                var consultar = ConsultaCategoriaProducto(3, txtModificarBuscarMarcaCategoriaProducto.Text);
                                {
                                    if (consultar != null)
                                    {
                                        miTabla.Rows.Add(consultar);
                                        InsertaRelacion(txtModificarBuscarMarcaCategoriaProducto.Text);
                                        dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                                        txtModificarBuscarMarcaCategoriaProducto.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("La categoria ya tiene un sorteo asociado.");
                            }
                        }
                        else
                        {
                            if (!Existe(3, txtModificarBuscarMarcaCategoriaProducto.Text, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                            {
                                var consulta = ConsultaCategoriaProducto(3, txtModificarBuscarMarcaCategoriaProducto.Text);

                                if (consulta != null)
                                {
                                    InsertaRelacion(txtModificarBuscarMarcaCategoriaProducto.Text);
                                    miTabla.Rows.Add(consulta);
                                    dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                                    txtModificarBuscarMarcaCategoriaProducto.Text = "";
                                }                               

                            }
                            else
                            {
                                OptionPane.MessageInformation("La categoria ya tiene un sorteo asociado.");
                            }
                        }

                    }
                    else
                    {
                        if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount > 0)
                        {
                            if (!Existe(4, txtModificarBuscarMarcaCategoriaProducto.Text, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                            {
                                var consultar = ConsultaCategoriaProducto(4, txtModificarBuscarMarcaCategoriaProducto.Text);
                                {
                                    if (consultar != null)
                                    {                                       
                                        miTabla.Rows.Add(consultar);
                                        InsertaRelacion(txtModificarBuscarMarcaCategoriaProducto.Text);
                                        dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                                        txtModificarBuscarMarcaCategoriaProducto.Text = "";
                                    }
                                }
                            }
                            else
                            {
                                OptionPane.MessageInformation("La categoria ya tiene un sorteo asociado.");
                            }
                        }
                        else
                        {
                            if (!Existe(4, txtModificarBuscarMarcaCategoriaProducto.Text, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                            {
                                var consulta = ConsultaCategoriaProducto(4, txtModificarBuscarMarcaCategoriaProducto.Text);

                                if (consulta != null)
                                {
                                    InsertaRelacion(txtModificarBuscarMarcaCategoriaProducto.Text);
                                    miTabla.Rows.Add(consulta);
                                    dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                                    txtModificarBuscarMarcaCategoriaProducto.Text = "";
                                }                               
                            }
                            else
                            {
                                OptionPane.MessageInformation("La categoria ya tiene un sorteo asociado.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnModificarEliminarMarcaCategoriaProducto_Click(object sender, EventArgs e)
        {
            if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount != 0)
            {
                DialogResult r = MessageBox.Show("Esta seguro que lo desea eliminar ", "Eliminar",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (r == DialogResult.OK)
                {
                    var id = dgvModificaSeleccionMarcaCategoriaProducto.CurrentRow.Cells["Column1"].Value;

                    EliminarRelacion(id);
                    this.dgvModificaSeleccionMarcaCategoriaProducto.Rows.RemoveAt(
                   this.dgvModificaSeleccionMarcaCategoriaProducto.CurrentCell.RowIndex);

                }
            }
            else
            {
                OptionPane .MessageInformation("No tiene registros a eliminar");
            }
        }

        private void btnModificarBuscarMarcaCategoriaProducto_Click(object sender, EventArgs e)
        {
            var criterio = (int)cbxModificaTipoSorteo.SelectedValue;

            if (criterio == 2)
            {
                Configuracion.Marcas.frmMarca marca = new Configuracion.Marcas.frmMarca();
                marca.CargaGrillaMarca();
                marca.Extension = true;
                marca.Show();
            }
            else
            {
                if (criterio == 3)
                {
                    Inventario.Categoria.FrmCategoria categoria = new Inventario.Categoria.FrmCategoria();
                    categoria.CargarGridCategorias();
                    categoria.Extencion = true;
                    categoria.Show();
                }
                else
                {
                    if (criterio == 4)
                    {
                        Inventario.Producto.Consulta producto = new Inventario.Producto.Consulta();

                    }
                }
            }
        }

        private void btnModificaTipoSorteo_Click(object sender, EventArgs e)
        {
            txtModificaTipoSorteo.Visible = false;
            cbxModificaTipoSorteo.Visible = true;

        }

        private void btnModificarAplicaVenta_Click(object sender, EventArgs e)
        {
            txtModificaAplicaVenta.Visible = false;
            cbxModificaAplicaventa.Visible = true;
        }

        private void btnModificarTiqueteMultiple_Click(object sender, EventArgs e)
        {
            txtModificaTiqueteMultiple.Visible = false;
            cbxModificaTipoTiquete.Visible = true;
        }

        private void btnModifucarFichaInicio_Click(object sender, EventArgs e)
        {
            txtModificarFechaInicio.Visible = false;
            btnRestaurarFechaInicio.Visible = true;
            btnModifucarFichaInicio.Visible = false;
        }

        private void btnModificarFechaFin_Click(object sender, EventArgs e)
        {
            txtModificarFechaFin.Visible = false;
            btnRestaurarFechaFin.Visible = true;
            btnModificarFechaFin.Visible = false;
        }

        private void btnModificarFechaSorteo_Click(object sender, EventArgs e)
        {
            txtModificarFechaSorteo.Visible = false;
            btnRestaurarFechaSorteo.Visible = true;
            btnModificarFechaSorteo.Visible = false;
        }

        private void btnModificarAplicaHora_Click(object sender, EventArgs e)
        {
            txtModificaAplicaHora.Visible = false;
            cbxModificaAplicaHora.Visible = true;

        }

        private void btnModificarHoraInicio_Click(object sender, EventArgs e)
        {
            txtModificarHoraInicio.Visible = false;
            btnRestaurarHoraInicio.Visible = true;
            btnModificarHoraInicio.Visible = false;
        }

        private void btnModificarHoraFin_Click(object sender, EventArgs e)
        {
            txtModificarHoraFin.Visible = false;
            btnRestaurarHoraFin.Visible = true;
            btnModificarHoraFin.Visible = false;
        }

        private void btnRestaurarFechaInicio_Click(object sender, EventArgs e)
        {
            dtpModificaFechaInicio.Value = miSorteoOriginal.FechaInicioSorteo;
        }

        private void btnRestaurarFechaFin_Click(object sender, EventArgs e)
        {
            dtpModificaFechaFin.Value = miSorteoOriginal.FechaFinalSorteo;
        }

        private void btnRestaurarFechaSorteo_Click(object sender, EventArgs e)
        {
            dtpModificaFechaSorteo.Value = miSorteoOriginal.FechaSorteo;
        }

        private void btnRestaurarHoraInicio_Click(object sender, EventArgs e)
        {
            dtpModificarHoraInicio.Value = ConvertirFecha(miSorteoOriginal.HoraInicio);
        }

        private void btnRestaurarHoraFin_Click(object sender, EventArgs e)
        {
            dtpModificarHoraFin.Value = ConvertirFecha(miSorteoOriginal.HoraFin);
        }

        private void cbxModificaAplicaHora_SelectedValueChanged(object sender, EventArgs e)
        {
            var criterio = (int)cbxModificaAplicaHora.SelectedValue;
            if (criterio == 1)
            {
                dtpModificarHoraInicio.Enabled = false;
                dtpModificarHoraFin.Enabled = false;
                btnModificarHoraFin.Enabled = false;
                btnModificarHoraInicio.Enabled = false;
                btnRestaurarHoraInicio.Visible = false;
                btnRestaurarHoraFin.Visible = false;
            }
            else
            {
                if (criterio == 2)
                {
                    dtpModificarHoraInicio.Enabled = true;
                    dtpModificarHoraFin.Enabled = true;
                    btnModificarHoraFin.Enabled = true;
                    btnModificarHoraInicio.Enabled = true;

                }
            }
        }

        private void cbxModificaTipoSorteo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (btnPreset)
            {               
                var criterio = (int)cbxModificaTipoSorteo.SelectedValue;
                if (criterio == 2)
                {
                    gbxModificaSeleccionar.Text = "Seleccione marca";
                    txtModificarBuscarMarcaCategoriaProducto.Enabled = false;
                    gbxModificaSeleccionar.Enabled = true;
                }
                else
                {
                    if (criterio == 3)
                    {
                        gbxModificaSeleccionar.Text = "Seleccione categoria";
                        txtModificarBuscarMarcaCategoriaProducto.Enabled = true;
                        gbxModificaSeleccionar.Enabled = true;
                    }
                    else
                    {
                        if (criterio == 4)
                        {
                            gbxModificaSeleccionar.Text = "Seleccione producto";
                            txtModificarBuscarMarcaCategoriaProducto.Enabled = true;
                            gbxModificaSeleccionar.Enabled = true;
                        }
                        else
                        {
                            gbxModificaSeleccionar.Text = "";
                            gbxModificaSeleccionar.Enabled = false;
                        }

                    }
                }
            }
        }

        private void dtpModificaFechaFin_Validating(object sender, CancelEventArgs e)
        {
            var fechaInicio = new DateTime(dtpModificaFechaInicio.Value.Year, dtpModificaFechaInicio.Value.Month
                , dtpModificaFechaInicio.Value.Day);
            var fechaFin = new DateTime(dtpModificaFechaFin.Value.Year, dtpModificaFechaFin.Value.Month
                , dtpModificaFechaFin.Value.Day);

            if (fechaInicio <= fechaFin)
            {
                dtpFechas = true;
                er.SetError(dtpModificaFechaFin, null);
            }
            else
            {
                er.SetError(dtpModificaFechaFin, "La Fecha de inicio debe ser menor a la fecha final");
                dtpFechas = false;
            }
        }

        private void dtpModificaFechaSorteo_Validating(object sender, CancelEventArgs e)
        {
            var fechaFin = new DateTime(dtpModificaFechaFin.Value.Year, dtpModificaFechaFin.Value.Month
                , dtpModificaFechaFin.Value.Day);
            var fechaSorteo = new DateTime(dtpModificaFechaSorteo.Value.Year, dtpModificaFechaSorteo.Value.Month
                , dtpModificaFechaSorteo.Value.Day);

            if (fechaSorteo >= fechaFin)
            {
                dtpFechasorteo = true;
                er.SetError(dtpModificaFechaSorteo, null);
            }
            else
            {
                er.SetError(dtpModificaFechaSorteo, "La fecha de sorteo debe ser mayor o igual a la fecha final");
                dtpFechasorteo = false;
            }
        }

        private void dtpModificarHoraFin_Validating(object sender, CancelEventArgs e)
        {
            var horaInicio = new DateTime(0001, 01, 01, dtpModificarHoraInicio.Value.Hour, dtpModificarHoraInicio.Value.Minute
                , dtpModificarHoraInicio.Value.Second);
            var horaFin = new DateTime(001, 01, 01, dtpModificarHoraFin.Value.Hour, dtpModificarHoraFin.Value.Minute
                , dtpModificarHoraFin.Value.Second);

            if (dtpModificarHoraFin.Enabled)
            {
                if (horaInicio != horaFin)
                {
                    dtpHoras = true;
                    er.SetError(dtpModificarHoraFin, null);
                }
                else
                {
                    er.SetError(dtpModificarHoraFin, "La hora de inicio deve ser menor que la fecha final");
                    dtpHoras = false;
                }
            }
        }

        private void txtModificarNombreSorteo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarNombreSorteo, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtModificarNombreSorteo, er, "Formato incorrecto"))
                {
                    modificaNombre = true;
                }
                else
                {
                    modificaNombre = false;
                }
            }
            else
            {
                modificaNombre = false;
            }
        }

        private void txtModificarConcepto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarConcepto, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtModificarConcepto, er, "Formato incorrecto"))
                {
                    modificaConcepto = true;
                }
                else
                {
                    modificaConcepto = false;
                }
            }
            else
            {
                modificaConcepto = false;
            }
        }

        private void txtModificarPatrocinaador_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarPatrocinaador, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtModificarPatrocinaador, er, "Formato incorrecto"))
                {
                    modificaPatrocinador = true;
                }
                else
                {
                    modificaPatrocinador = false;
                }
            }
            else
            {
                modificaPatrocinador = false;
            }
        }

        private void txtModificarPremio_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarPremio, er, "El campo es equerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.PalabrasNumeroCaracter, txtModificarPremio, er, "Format incorrecto"))
                {
                    modificaPremio = true;
                }
                else
                {
                    modificaPremio = false;
                }
            }
            else
            {
                modificaPremio = false;
            }
        }

        private void txtModificarValorminimoCompra_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarValorminimoCompra, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtModificarValorminimoCompra, er, "Formato incorrecto"))
                {
                    modificaValorMinimo = true;
                }
                else
                {
                    modificaValorMinimo = false;
                }
            }
            else
            {
                modificaValorMinimo = false;
            }
        }

        private void txtModificarValorPremio_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtModificarValorPremio, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtModificarValorPremio, er, "Formato incorrecto"))
                {
                    modificaValorPremio = true;
                }
                else
                {
                    modificaValorPremio = false;
                }
            }
            else
            {
                modificaValorPremio = false;
            }
        }

        private void txtModificaTipoSorteo_Click(object sender, EventArgs e)
        {
            if (dgvModificaSeleccionMarcaCategoriaProducto.RowCount != 0)
            {
                var registro = "";
                if (miSorteoOriginal.IdTipoSorteo == 2)
                    registro = "Marca";
                if (miSorteoOriginal.IdTipoSorteo == 3)
                    registro = "Categoria";
                if (miSorteoOriginal.IdTipoSorteo == 4)
                    registro = "Producto";

                MessageBox.Show("Debe eliminar todos los registros de " + registro + " asociados al Sorteo.", "Sorteo",
                 MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPreset = false;


            }
            else
                btnPreset = true;
        }

        private void frmEditaSorteo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!btnPreset)
            {
                DialogResult r = MessageBox.Show("Desea guardar los cambios", "Edicion",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (r == DialogResult.OK)
                {
                    tsbtnEditaGuardar_Click(null, null);

                    if (dtpFechas && dtpFechasorteo && modificaNombre && modificaConcepto
                        && modificaPatrocinador && modificaPremio && modificaValorMinimo && modificaValorPremio)
                    {
                        if (dtpHoras)
                        {
                            btnPreset = true;
                            Close();
                        }
                        else
                        {
                            btnPreset = true;
                            Close();
                        }
                    }
                    else
                    {
                        btnPreset = false;
                    }
                }
                else
                {
                    if (r == DialogResult.No)
                    {
                        btnPreset = true;
                        this.Close();
                    }
                    else
                    {
                        btnPreset = false;
                    }
                }
            }
            CompletaEventos.CapturaEventom(false);
        }

        /// <summary>
        /// carga el sorteo a editar.
        /// </summary>
        /// <param name="idSorteo">id de sorteo a editar</param>
        /// <param name="historial">determina el valor de la consulta</param>
        public void CargaSorteoEditar(int idSorteo, bool historial)
        {

            miTabla = formSorteo.General();
            try
            {
                if (historial)
                {
                    miSorteoOriginal = miBussinesSorteo.CargaSorteo(idSorteo, true);
                }
                else
                {
                    miSorteoOriginal = miBussinesSorteo.CargaSorteo(idSorteo, false);
                }
                txtModificaTipoSorteo.Text = miSorteoOriginal.NombreTipoSorteo;

                if (miSorteoOriginal.AplicaVenta)
                {
                    txtModificaAplicaVenta.Text = "Venta minima";
                }
                else
                {
                    txtModificaAplicaVenta.Text = "Unidad del producto";
                }
                if (miSorteoOriginal.TiqueteMultiple)
                {
                    txtModificaTiqueteMultiple.Text = "Tiquete por factura";
                }
                else
                {
                    txtModificaTiqueteMultiple.Text = "Tiquete por producto";
                }
                txtModificarFechaInicio.Text = miSorteoOriginal.FechaInicioSorteo.ToShortDateString();
                dtpModificaFechaInicio.Value = miSorteoOriginal.FechaInicioSorteo;
                txtModificarFechaFin.Text = miSorteoOriginal.FechaFinalSorteo.ToShortDateString();
                dtpModificaFechaFin.Value = miSorteoOriginal.FechaFinalSorteo;
                txtModificarFechaSorteo.Text = miSorteoOriginal.FechaSorteo.ToShortDateString();
                dtpModificaFechaSorteo.Value = miSorteoOriginal.FechaSorteo;
                if (miSorteoOriginal.AplicaHora)
                {
                    txtModificaAplicaHora.Text = "Si";
                    txtModificarHoraInicio.Text = miSorteoOriginal.HoraInicio.ToShortTimeString();
                    dtpModificarHoraInicio.Value = ConvertirFecha(miSorteoOriginal.HoraInicio);
                    txtModificarHoraFin.Text = miSorteoOriginal.HoraFin.ToShortTimeString();
                    dtpModificarHoraFin.Value = ConvertirFecha(miSorteoOriginal.HoraFin);
                    btnModificarHoraInicio.Enabled = true;
                    btnModificarHoraFin.Enabled = true;

                }
                else
                {
                    txtModificaAplicaHora.Text = "NO";
                    txtModificarHoraInicio.Enabled = false;
                    txtModificarHoraFin.Enabled = false;
                    btnModificarHoraInicio.Enabled = false;
                    btnModificarHoraFin.Enabled = false;
                }
                txtModificarNombreSorteo.Text = miSorteoOriginal.NombreSorteo;
                txtModificarConcepto.Text = miSorteoOriginal.Concepto;
                txtModificarPatrocinaador.Text = miSorteoOriginal.PatrocinadoresSorteo;
                txtModificarPremio.Text = miSorteoOriginal.PremioSorteo;
                txtModificarValorminimoCompra.Text = miSorteoOriginal.ValorMinimoCompraSorteo.ToString();
                txtModificarValorPremio.Text = miSorteoOriginal.ValorPremio.ToString();
                if (miSorteoOriginal.EstadoSorteo)
                {
                    rbbtnModificarActivo.Checked = true;
                }
                else
                {
                    rbtModificarInactivo.Checked = true;
                }

                if (miSorteoOriginal.IdTipoSorteo == 2)
                {
                    gbxModificaSeleccionar.Text = "Seleccionar marcas";
                    txtModificarBuscarMarcaCategoriaProducto.Enabled = false;
                    foreach (Marca m in miSorteoOriginal.Marcas)
                    {
                        var row = miTabla.NewRow();
                        row["Codigo"] = m.IdMarca;
                        row["Nombre"] = m.NombreMarca;
                        miTabla.Rows.Add(row);
                    }
                }
                else
                {
                    if (miSorteoOriginal.IdTipoSorteo == 3)
                    {
                        gbxModificaSeleccionar.Text = "Seleccionar categoria";
                        foreach (Categoria c in miSorteoOriginal.Categorias)
                        {
                            var row = miTabla.NewRow();
                            row["Codigo"] = c.CodigoCategoria;
                            row["Nombre"] = c.NombreCategoria;
                            miTabla.Rows.Add(row);
                        }

                    }
                    else
                    {
                        if (miSorteoOriginal.IdTipoSorteo == 4)
                        {
                            gbxModificaSeleccionar.Text = "Seleccionar Producto";
                            foreach (Producto p in miSorteoOriginal.Producto)
                            {
                                var row = miTabla.NewRow();
                                row["Codigo"] = p.CodigoInternoProducto;
                                row["Nombre"] = p.NombreProducto;
                                miTabla.Rows.Add(row);
                            }
                        }
                        else
                        {
                            if (miSorteoOriginal.IdTipoSorteo == 5)
                            {
                                gbxModificaSeleccionar.Enabled = false;
                            }
                        }
                    }
                }
                dgvModificaSeleccionMarcaCategoriaProducto.AutoGenerateColumns = false;
                tabla = miTabla;
                dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Ordena los combobox segun como vengan desde la base de datos
        /// </summary>
        private void OrderComboBox()
        {
            cbxModificaTipoSorteo.SelectedValue = miSorteoOriginal.IdTipoSorteo;
            if (miSorteoOriginal.AplicaHora)
            {
                cbxModificaAplicaHora.SelectedValue = 2;
            }
            else
            {
                cbxModificaAplicaHora.SelectedValue = 1;
            }
        }

        /// <summary>
        /// convierte la timpo q bienen desde la base de datos solo seleccionando las hh/mm/ss
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        private DateTime ConvertirFecha(DateTime date)
        {
            DateTime miDate = new DateTime
            (2000, 01, 01, date.Hour, date.Minute, date.Second);
            return miDate;
        }



        /// <summary>
        /// Tranferencia de datos de un formulario externo.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                TransferirMarca m = (TransferirMarca)args.MiMarca;
                var existe = true;
                if (!Existe(2, m.IdMarca, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                {
                    foreach (DataGridViewRow row in dgvModificaSeleccionMarcaCategoriaProducto.Rows)
                    {
                        var id = Convert.ToInt32(row.Cells["Column1"].Value);
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
                        miTabla.Clear();
                        miBussinesSorteo.InsertaMarcaSorteo(miSorteoOriginal.IdSorteo, m.IdMarca, false);
                        var marcas = miBussinesSorteo.MarcasSorteo(miSorteoOriginal.IdSorteo, false);
                        foreach (Marca miMarca in marcas)
                        {
                            var row = miTabla.NewRow();
                            row["Codigo"] = miMarca.IdMarca;
                            row["Nombre"] = miMarca.NombreMarca;
                            miTabla.Rows.Add(row);
                        }

                        dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La marca ya tiene un sorteo asociado.");
                    btnModificarBuscarMarcaCategoriaProducto_Click(null, null);
                }
            }
            catch
            { }
            try
            {
                var c = (DTO.Clases.Categoria)args.MiMarca;
                var existe = true;
                if (!Existe(3, c.CodigoCategoria, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                {
                    foreach (DataGridViewRow row in dgvModificaSeleccionMarcaCategoriaProducto.Rows)
                    {
                        var id = Convert.ToString(row.Cells["Column1"].Value);
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
                        miTabla.Clear();
                        miBussinesSorteo.InsertarCategoriaSorteo(miSorteoOriginal.IdSorteo, c.CodigoCategoria, false);
                        var categoria = miBussinesSorteo.CategoriaSorteo(miSorteoOriginal.IdSorteo, false);
                        foreach (Categoria micategoria in categoria)
                        {
                            var row = miTabla.NewRow();
                            row["Codigo"] = micategoria.CodigoCategoria;
                            row["Nombre"] = micategoria.NombreCategoria;
                            miTabla.Rows.Add(row);

                        }

                        dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("La marca ya tiene un sorteo asociado.");
                    btnModificarBuscarMarcaCategoriaProducto_Click(null, null);
                }
            }

            catch
            { }
            try
            {
                Producto p = (Producto)args.MiMarca;
                var existe = true;
                if (!Existe(4, p.CodigoInternoProducto, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
                {
                    foreach (DataGridViewRow row in dgvModificaSeleccionMarcaCategoriaProducto.Rows)
                    {
                        var id = Convert.ToString(row.Cells["Codigo"].Value);
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
                        miTabla.Clear();
                        miBussinesSorteo.InsertaProductoSorteo(miSorteoOriginal.IdSorteo, p.CodigoInternoProducto, false);
                        var producto = miBussinesSorteo.CargarProducto(miSorteoOriginal.IdSorteo, false);
                        foreach (Producto miproducto in producto)
                        {
                            var row = miTabla.NewRow();
                            row["Codigo"] = p.CodigoInternoProducto;
                            row["Nombre"] = p.NombreProducto;
                            miTabla.Rows.Add(row);
                        }
                        dgvModificaSeleccionMarcaCategoriaProducto.DataSource = miTabla;
                    }
                }
                else
                {
                    OptionPane.MessageInformation("El producto ya tiene un sorteo asociado.");
                    btnModificarBuscarMarcaCategoriaProducto_Click(null, null);
                }
            }
            catch
            { }
        }
      
       

        /// <summary>
        /// Consulta existe en base de datos.
        /// </summary>
        /// <param name="idTipo">id tipo sorteo</param>
        /// <param name="codigo">codigo del articulo a validar a validar</param>
        /// <param name="fecha1">fecha 1 rango de fecha a validar</param>
        /// <param name="fecha2">fecha 2 rango de fechas a validar</param>
        /// <returns></returns>
        private bool Existe(int idTipo, object codigo, DateTime fecha1, DateTime fecha2)
        {
            miBussinesSorteo = new BussinesSorteo();
            var existe = false;
            try
            {
                if (idTipo == 2)
                {
                    existe = miBussinesSorteo.ExisteSorteoMarca(Convert.ToInt32(codigo), fecha1, fecha2);
                }
                else
                {
                    if (idTipo == 3)
                    {
                        existe = miBussinesSorteo.ExisteSorteocategoria(Convert.ToString(codigo), fecha1, fecha2);
                    }
                    else
                    {
                        if (idTipo == 4)
                        {
                            existe = miBussinesSorteo.ExisteSorteoProducto(Convert.ToString(codigo), fecha1, fecha2);
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
        /// <param name="idTipo">id tipo sorteo</param>
        /// <returns></returns>
        private bool ExisteBd(int idTipo)
        {
            var existeBd = false;

            List<string> list = new List<string>();

            if ((miSorteoOriginal.FechaInicioSorteo != dtpModificaFechaInicio.Value) ||
                    (miSorteoOriginal.FechaFinalSorteo != dtpModificaFechaFin.Value))
            {
                foreach (DataRow row in miTabla.Rows)
                {
                    var id = Convert.ToString(row["Codigo"]);
                    if (Existe(idTipo, id, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value))
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
                            if (idTipo == 4)
                            {
                                t = "Producto(s)";
                            }
                        }
                    }
                    string r = "";
                    foreach (var art in list)
                    {
                        r += art + " ,";
                    }
                    string msm = "L@s " + t + " " + r + " " + "Ya tiene registros asociados en Sorteo en el rango de fechas.";
                    OptionPane.MessageInformation(msm);
                }
                if (idTipo == 5)
                {
                    if (ExisteFactura(5))
                    {
                        OptionPane.MessageInformation("Ya existe un sorteo por factura en las fechas seleccionadas.");
                        existeBd = true;
                    }                   
                }
            }
            return existeBd;
        }

        /// <summary>
        /// Obtiene los datos de categoria, producto.
        /// </summary>
        /// <param name="codigo"> codigo a consultar</param>
        /// <returns></returns>
        public DataRow ConsultaCategoriaProducto(int idTipo, object codigo)
        {
            var rows = miTabla.NewRow();
            var existe = true;
            try
            {
                foreach (DataRow row in miTabla.Rows)
                {
                    var id = Convert.ToInt32(row["Codigo"]);
                    if (id == Convert.ToInt32(codigo))
                    {
                        existe = false;
                        break;
                    }
                    else
                    {
                        existe = true;
                    }
                }

                if (idTipo == 3)
                {
                    if (existe)
                    {
                        var consultaC = miCategoria.consultaCategoriaCodigo(Convert.ToString(codigo));
                        if (consultaC.Count > 0)
                        {
                            var cattemp = (Categoria)consultaC[0];
                            rows["Codigo"] = cattemp.CodigoCategoria;
                            rows["Nombre"] = cattemp.NombreCategoria;
                            return rows;
                        }
                    }
                }
                else
                {
                    var consultaP = miProducto.ConsultaProductoSimple(Convert.ToString(codigo));
                    if (consultaP.CodigoInternoProducto != null)
                    {
                        rows["Codigo"] = consultaP.CodigoCategoria;
                        rows["Nombre"] = consultaP.NombreCategoria;
                        return rows;
                    }

                }
                OptionPane.MessageInformation("No se encontraron registros con este codigo." + codigo);
                return null;
            }

            catch
            {
                return null;
            }

        }

        
        /// <summary>
        /// Obtine o establece  el existe factura en la bd.
        /// </summary>
        /// <param name="idTipo"> id tipo sorteo a consultar</param>
        /// <returns></returns>
        private bool ExisteFactura(int idTipo)
        {
            var existe = false;
            try
            {
                existe = miBussinesSorteo.ExisteSorteoFactura(idTipo, dtpModificaFechaInicio.Value, dtpModificaFechaFin.Value);
                return existe;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return existe;
            }
        }

        /// <summary>
        /// Inserta las relaciones de marca producto categorias a sorteo.
        /// </summary>
        /// <param name="id">codigo</param>
        private void InsertaRelacion(object id)
        {
            try
            {
                if (miSorteoOriginal.IdTipoSorteo == 2)
                {
                    var idMarca = Convert.ToInt32(id);
                    miBussinesSorteo.InsertaMarcaSorteo(miSorteoOriginal.IdSorteo, idMarca, false);
                }
                else
                {
                    if (miSorteoOriginal.IdTipoSorteo == 3)
                    {
                        var codigoCategoria = Convert.ToString(id);
                        miBussinesSorteo.InsertarCategoriaSorteo(miSorteoOriginal.IdSorteo, codigoCategoria, false);
                    }
                    else
                    {
                        if (miSorteoOriginal.IdTipoSorteo == 4)
                        {
                            var codigoInternoProducto = Convert.ToString(id);
                            miBussinesSorteo.InsertaProductoSorteo(miSorteoOriginal.IdSorteo, codigoInternoProducto, false);
                        }
                    }
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Elimina la relacion producto, marca, categoria de sorteo.
        /// </summary>
        /// <param name="id"></param>
        private void EliminarRelacion(object id)
        {
            try
            {
                if (miSorteoOriginal.IdTipoSorteo == 2)
                {
                    var idMarca = Convert.ToInt32(id);
                    miBussinesSorteo.EliminarMarcaSoreo(miSorteoOriginal.IdSorteo, idMarca);
                }
                else
                {
                    if (miSorteoOriginal.IdTipoSorteo == 3)
                    {
                        var codigoCategoria = Convert.ToString(id);
                        miBussinesSorteo.EliminaCategoriaSorteo(miSorteoOriginal.IdSorteo, codigoCategoria);
                    }
                    else
                    {
                        if (miSorteoOriginal.IdTipoSorteo == 4)
                        {
                            var codigointernoproducto = Convert.ToString(id);
                            miBussinesSorteo.EliminarProductoSorteo(miSorteoOriginal.IdSorteo, codigointernoproducto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Valida los campos del formulario por campo bacio y por formato.
        /// </summary>
        private void revalidar()
        {
            txtModificarNombreSorteo_Validating(null, null);
            txtModificarConcepto_Validating(null, null);
            txtModificarPatrocinaador_Validating(null, null);
            txtModificarPremio_Validating(null, null);
            txtModificarValorminimoCompra_Validating(null, null);
            txtModificarValorPremio_Validating(null, null);
            dtpModificaFechaFin_Validating(null, null);
            dtpModificaFechaSorteo_Validating(null, null);
            dtpModificarHoraFin_Validating(null, null);
        }
    }
}