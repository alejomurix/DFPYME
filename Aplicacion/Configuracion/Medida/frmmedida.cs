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

namespace Aplicacion.Configuracion.Medida
{
    public partial class frmmedida : Form
    {
        /// <summary>
        /// 
        /// </summary>
        private BussinesUnidadMedida unidadmedida;

        /// <summary>
        /// 
        /// </summary>
        private BussinesValorUnidadMedida valorunidadmedida;

        /// <summary>
        /// Mensaje de error 
        /// </summary>
        private ErrorProvider er = new ErrorProvider();

        /// <summary>
        /// Lista los valores de la unidad de medida que se an ingresado.
        /// </summary>
        private List<ValorUnidadMedida> listaValoresMedida = new List<ValorUnidadMedida>();

        /// <summary>
        /// 
        /// </summary>
        private BindingSource Unidadmedida = new BindingSource();

        /// <summary>
        /// 
        /// </summary>
        private BindingSource ValorMedida = new BindingSource();

        /// <summary>
        /// 
        /// </summary>
        private DataSet midataset;

        /// <summary>
        /// Guarda el valor de la unidad de medida.
        /// </summary>
        private string ValorUnidadMedida = "";

        /// <summary>
        ///Guarda el valor de el valor unidad mediuda 
        /// </summary>
        private string ValorValorUnidadMedida = "";

        /// <summary>
        /// Indica la verificacion de unidad de medida en falso
        /// </summary>
        /// 
        private bool verificaunidadmedida = false;

        /// <summary>
        /// Indica verificar valor unidad de medida en falso
        /// </summary>
        private bool verificavalorunidadmedida = false;

        /// <summary>
        /// Indica verificar modificar unidad medida en falso
        /// </summary>
        private bool medidaMatch = false;

        /// <summary>
        /// Indica verificar modificar unidad mdida en falso
        /// </summary>
        private bool valormedidaMatch = false;

        /// <summary>
        /// Guarda el id de la unidad de medida.
        /// </summary>
        private int idUnidadMedida = 0;

        /// <summary>
        /// Guarda el id de valor unidad medida
        /// </summary>
        private int idValorMedida = 0;

        /// <summary>
        /// Establece la validación  que indica si se trata de un guardado o edición.
        /// </summary>
        private bool EditarMedida = false;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Agregar o deshacer Nueva Unidad de Medida.
        /// </summary>
        private System.IO.Stream ImgAgregaStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de Agregar o deshacer Nueva Unidad de Medida.
        /// </summary>
        private const string ImagenMedida = "Aplicacion.Recursos.Iconos.deshacer.png";

        /// <summary>
        /// Establece la validación  que indica si cancela una adicción de Unidad de Medida.
        /// </summary>
        private bool CancelNewMedida = true;

        /// <summary>
        /// Establece la validación  que indica si adiciona una nueva Unidad de Medida.
        /// </summary>
        private bool NewMedida = false;

        /// <summary>
        /// Objeto para visualizar texto descriptivo de un control en formulario.
        /// </summary>
        private ToolTip miToolTip;

        /// <summary>
        /// constructor
        /// </summary>
        public frmmedida()
        {
            InitializeComponent();
            unidadmedida = new BussinesUnidadMedida();
            valorunidadmedida = new BussinesValorUnidadMedida();
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            miToolTip = new ToolTip();
        }

        private void frmmedida_Load(object sender, EventArgs e)
        {
            CargaDatos();
            miToolTip.SetToolTip(btnAgregarMedida, "Agregar Medida");
            try
            {
                ImgAgregaStream = assembly.GetManifestResourceStream(ImagenMedida);
            }
            catch
            {
                OptionPane.MessageError("Ocurrio un error al cargar los recursos.");
            }
        }

        private void btnGuardarValorMedida_Click(object sender, EventArgs e)
        {

            txtValorMedida_Validating(null, null);
            txtValorMedida.Focus();
            if (verificavalorunidadmedida)
            {
                dgbValorUnidadMedida.Rows.Add(txtValorMedida.Text);
                this.txtValorMedida.Text = "";
                verificavalorunidadmedida = true;
            }
            else
            {
                verificavalorunidadmedida = false;
            }
        }

        /// <summary>
        /// Guarda unidades de medida a la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnguardar_Click(object sender, EventArgs e)
        {
            txtUnidadMedida_Validating(null, null);

            if (dgbValorUnidadMedida.RowCount != 0)
            {
                if (verificaunidadmedida)
                {
                    var ingresarUnidadMedida = new DTO.Clases.UnidadMedida();
                    CargarListaValoresMedida();
                    try
                    {
                        ingresarUnidadMedida.DescripcionUnidadMedida = txtUnidadMedida.Text;
                        ingresarUnidadMedida.ListaValoresUnidaMedida = listaValoresMedida;
                        unidadmedida.InsertarUnidadMedida(ingresarUnidadMedida);
                        OptionPane.MessageInformation("La informacion se ha ingresado correctamente.");
                        CargaDatos();
                        this.txtUnidadMedida.Text = "";
                        this.txtValorMedida.Text = "";
                        while (dgbValorUnidadMedida.RowCount != 0)
                        {
                            this.dgbValorUnidadMedida.Rows.RemoveAt(
                               this.dgbValorUnidadMedida.CurrentCell.RowIndex);
                        }
                        listaValoresMedida.Clear();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe ingresar por lo menos un valor para la unidad de medida.");
            }
        }

        /// <summary>
        /// Carga lista valores de las unidades de medida.
        /// </summary>
        private void CargarListaValoresMedida()
        {
            if (this.dgbValorUnidadMedida.RowCount != 0)
            {
                foreach (DataGridViewRow row in this.dgbValorUnidadMedida.Rows)
                {
                    ValorUnidadMedida valor = new ValorUnidadMedida();
                    valor.DescripcionValorUnidadMedida =
                        Convert.ToString(row.Cells[0].Value);
                    listaValoresMedida.Add(valor);
                }
            }
        }

        /// <summary>
        /// valido la unudad de medida campo nulo y formato
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtUnidadMedida_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtUnidadMedida, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtUnidadMedida, er, "Formato incorrecto"))
                {
                    if (ExisteUnidadMedida(txtUnidadMedida.Text))
                    {
                        er.SetError(txtUnidadMedida, "La Unidad de Medida ya existe.");
                        verificaunidadmedida = false;
                    }
                    else
                    {
                        er.SetError(txtUnidadMedida, null);
                        verificaunidadmedida = true;
                    }
                }
                else
                {
                    verificaunidadmedida = false;
                }
            }
            else
            {
                verificaunidadmedida = false;
            }
        }

        /// <summary>
        /// Valida el campo valor unidad de medida por campo nulo y por formato.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtValorMedida_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorMedida, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Palabras, txtValorMedida, er, "Formato incorrecto"))
                {
                    if (ExisteValorUnidadMedida(txtValorMedida.Text))
                    {
                        er.SetError(txtValorMedida, null);
                        verificavalorunidadmedida = false;
                    }
                    else
                    {
                        er.SetError(txtValorMedida, null);
                        verificavalorunidadmedida = true;
                    }
                }

                else
                {
                    verificavalorunidadmedida = false;
                }
            }
            else
            {
                verificavalorunidadmedida = false;
            }
        }

        /// <summary>
        /// Verifica si una unidad de medida existe en la base de datos.
        /// </summary>
        /// <param name="unidadMedida"></param>
        /// <returns></returns>
        private bool ExisteUnidadMedida(string unidadMedida)
        {
            try
            {
                return unidadmedida.ExisteUnidadMedida(unidadMedida);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Verifica si un valor unidad de medida existe en la base de datos
        /// </summary>
        /// <param name="valorUnidadMedida"></param>
        /// <returns></returns>
        private bool ExisteValorUnidadMedida(string valorUnidadMedida)
        {
            try
            {
                return valorunidadmedida.ExisteValorUnidadMedida(valorUnidadMedida);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Elimino los registros del gridviw
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminarValorUnidadMedida_Click(object sender, EventArgs e)
        {
            if (dgbValorUnidadMedida.RowCount != 0)
            {
                this.dgbValorUnidadMedida.Rows.RemoveAt(
                   this.dgbValorUnidadMedida.CurrentCell.RowIndex);
            }
        }

        /// <summary>
        /// Carga las listas de unidades de medida.
        /// </summary>
        private void CargaDatos()
        {
            dgvUnidadMedida.AutoGenerateColumns = false;
            dgvValorMedida.AutoGenerateColumns = false;
            try
            {
                midataset = unidadmedida.ListadoCompleto();
                dgvUnidadMedida.DataSource = midataset;
                dgvUnidadMedida.DataMember = "unidad_medida";
                dgvValorMedida.DataSource = midataset;
                dgvValorMedida.DataMember = "unidad_medida.fk_unidad_medida";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista" + ex.Message);
            }
        }

        private bool EditM = false;

        private bool CancelEditM = true;

        /// <summary>
        /// Carga y permete la modificacion de la unidad de medida seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnModificarUnidadMedida_Click(object sender, EventArgs e)
        {
            if (this.dgvUnidadMedida.RowCount != 0)
            {
                try
                {
                    if (CancelEditM)
                    {
                        var registro = this.dgvUnidadMedida.Rows[this.dgvUnidadMedida.CurrentCell.RowIndex];
                        idUnidadMedida = Convert.ToInt32(registro.Cells["IdU"].Value);
                        this.txModificaUnidadMedida.Text = Convert.ToString(registro.Cells["NombreU"].Value);
                        ValorUnidadMedida = Convert.ToString(registro.Cells["NombreU"].Value);
                        tsbtnGuardarModificarUnidadMedida.Enabled = true;
                        tsbtnEliminarUnidadMedida.Enabled = false;
                        tsbtnModificarUnidadMedida.Image =
                            ((Image)(miResources.GetObject("recurso.Image")));
                        tsbtnModificarUnidadMedida.Text = "Cancelar";
                        EditM = true;
                        CancelEditM = false;
                    }
                    else
                    {
                        if (EditM)
                        {
                            tsbtnEliminarUnidadMedida.Enabled = true;
                            tsbtnModificarUnidadMedida.Image =
                            ((Image)(miResources.GetObject("tsbtnModificarUnidadMedida.Image")));
                            tsbtnModificarUnidadMedida.Text = "Modificar";
                            EditM = false;
                            CancelEditM = true;
                            txModificaUnidadMedida.Text = "";
                        }
                    }
                    /*var registro = this.dgvUnidadMedida.Rows[this.dgvUnidadMedida.CurrentCell.RowIndex];
                    idUnidadMedida = Convert.ToInt32(registro.Cells["IdU"].Value);
                    this.txModificaUnidadMedida.Text = Convert.ToString(registro.Cells["NombreU"].Value);
                    ValorUnidadMedida = Convert.ToString(registro.Cells["NombreU"].Value);
                    tsbtnGuardarModificarUnidadMedida.Enabled = true;*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seleccione la unidad de medida" + ex.Message);
                }
            }
        }

        private bool EditU = false;

        private bool CancelEditU = true;

        /// <summary>
        /// Carga y permite la modifivcacion de los valores de las unidades de medida. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnModificarValorMedida_Click(object sender, EventArgs e)
        {
            if (this.dgvValorMedida.RowCount != 0)
            {
                try
                {
                    if (CancelEditU)
                    {
                        var registro = this.dgvValorMedida.Rows[this.dgvValorMedida.CurrentCell.RowIndex];
                        idValorMedida = Convert.ToInt32(registro.Cells["IdM"].Value);
                        this.txModificaValorMedida.Text = Convert.ToString(registro.Cells["NombreM"].Value);
                        ValorValorUnidadMedida = Convert.ToString(registro.Cells["NombreM"].Value);
                        tsbtnGuardarModificarValorMedida.Enabled = true;
                        btnAgregarMedida.Enabled = false;
                        EditarMedida = true;
                        tsbtnEliminarValorMedida.Enabled = false;
                        tsbtnModificarValorMedida.Image =
                            ((Image)(miResources.GetObject("recurso.Image")));
                        tsbtnModificarValorMedida.Text = "Cancelar";
                        EditU = true;
                        CancelEditU = false;
                    }
                    else
                    {
                        if (EditU)
                        {
                            tsbtnEliminarValorMedida.Enabled = true;
                            tsbtnModificarValorMedida.Text = "Modificar";
                            tsbtnModificarValorMedida.Image =
                            ((Image)(miResources.GetObject("tsbtnModificarValorMedida.Image")));
                            EditU = false;
                            CancelEditU = true;
                            txModificaValorMedida.Text = "";
                            btnAgregarMedida.Enabled = true;
                        }
                    }
                    /*var registro = this.dgvValorMedida.Rows[this.dgvValorMedida.CurrentCell.RowIndex];
                    idValorMedida = Convert.ToInt32(registro.Cells["IdM"].Value);
                    this.txModificaValorMedida.Text = Convert.ToString(registro.Cells["NombreM"].Value);
                    ValorValorUnidadMedida = Convert.ToString(registro.Cells["NombreM"].Value);
                    tsbtnGuardarModificarValorMedida.Enabled = true;
                    btnAgregarMedida.Enabled = false;
                    EditarMedida = true;*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Seleccione una unidad de medida" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Modifico y guardo unidades de medida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnGuardarModificarUnidadMedida_Click(object sender, EventArgs e)
        {
            txModificaUnidadMedida_Validating();
            if (medidaMatch)
            {
                var modificarunidadmedida = new DTO.Clases.UnidadMedida();
                try
                {
                    modificarunidadmedida.IdUnidadMedida = idUnidadMedida;
                    modificarunidadmedida.DescripcionUnidadMedida = txModificaUnidadMedida.Text;
                    unidadmedida.ModificarUnidadMedida(modificarunidadmedida);
                    tsbtnGuardarModificarUnidadMedida.Enabled = false;
                    OptionPane.MessageInformation("Los datos se ha editado correctamente.");
                    this.txModificaUnidadMedida.Text = "";
                    dgvUnidadMedida.Focus();
                    er.SetError(txModificaUnidadMedida, null);
                    CargaDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar unidad de medida" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Modifica y guarda los valores de las uniades de medida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnGuardarModificarValorMedida_Click(object sender, EventArgs e)
        {
            txModificaValorMedida_Validating();
            if (valormedidaMatch)
            {
                var modificarvalormedida = new DTO.Clases.ValorUnidadMedida();
                try
                {
                    if (EditarMedida)
                    {
                        modificarvalormedida.IdValorUnidadMedida = idValorMedida;
                        modificarvalormedida.DescripcionValorUnidadMedida = txModificaValorMedida.Text;
                        valorunidadmedida.ModificaValorUnidadMedida(modificarvalormedida);
                        tsbtnGuardarModificarValorMedida.Enabled = false;
                        tsbtnModificarValorMedida.Enabled = true;
                        btnAgregarMedida.Enabled = true;
                        CancelEditU = false;
                        EditU = true;
                        tsbtnModificarValorMedida_Click(this.tsbtnModificarValorMedida, new EventArgs());
                    }
                    else
                    {
                        modificarvalormedida.IdUnidadMedida = (int)dgvUnidadMedida.CurrentRow.Cells["IdU"].Value;
                        modificarvalormedida.DescripcionValorUnidadMedida = txModificaValorMedida.Text;
                        valorunidadmedida.InsertarValorUnidadMedida(modificarvalormedida);
                        tsbtnModificarValorMedida.Enabled = true;
                        tsbtnGuardarModificarValorMedida.Enabled = false;
                        btnAgregarMedida.Image = ((Image)miResources.GetObject("btnAgregarMedida.Image"));
                        miToolTip.SetToolTip(btnAgregarMedida, "Agregar Medida");
                        NewMedida = false;
                        CancelNewMedida = true;
                    }
                    OptionPane.MessageInformation("Se a guardado exitosamente");
                    CargaDatos();
                    txModificaValorMedida.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al modificar el valor d la unidad de medida" + ex.Message);
                }
            }
        }

        /// <summary>
        /// Valida los campos por campo vacio, formato,existe de unidad de medida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txModificaUnidadMedida_Validating()
        {
            if (!Validacion.EsVacio(txModificaUnidadMedida, er, "El campo es requerido."))
            {
                if (Validacion.ConFormato(
                    Validacion.TipoValidacion.Palabras, txModificaUnidadMedida, er, "Formato incorrecto"))
                {
                    var temp = ValorUnidadMedida.ToLower();
                    if (ExisteUnidadMedida(txModificaUnidadMedida.Text) &&
                        !temp.Equals(txModificaUnidadMedida.Text.ToLower()))
                    {

                        er.SetError(txModificaUnidadMedida, "La unidad de medida ya existe");
                        medidaMatch = false;
                    }
                    else
                    {
                        er.SetError(txModificaUnidadMedida, null);
                        medidaMatch = true;
                    }
                }
                else
                    medidaMatch = false;
            }
            else
                medidaMatch = false;
        }

        /// <summary>
        /// Valido campo vacio,formato y existe de valor de unidad de medida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txModificaValorMedida_Validating()
        {
            if (!Validacion.EsVacio(txModificaValorMedida, er, "El acmpo es requerido."))
            {
                /*if (Validacion.ConFormato(
                    Validacion.TipoValidacion.Palabras, txModificaValorMedida, er, "Formato incorrecto"))
                {*/
                    var temp = ValorValorUnidadMedida.ToLower();
                    if (ExisteValorUnidadMedida(txModificaValorMedida.Text)
                        && !temp.Equals(txModificaValorMedida.Text.ToLower()))
                    {
                        er.SetError(txModificaValorMedida, "El valor de la unidad de medida ya existe");
                        valormedidaMatch = false;
                    }
                    else
                    {
                        er.SetError(txModificaValorMedida, null);
                        valormedidaMatch = true;
                    }
                /*}
                else
                {
                    medidaMatch = false;
                }*/

            }
            else
            {
                valormedidaMatch = false;
            }
        }

        /// <summary>
        /// Eliminar unidad de medida.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnEliminarUnidadMedida_Click(object sender, EventArgs e)
        {
            if (this.dgvUnidadMedida.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro de eliminar el registro?", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        int idu = (int)this.dgvUnidadMedida.CurrentRow.Cells["IdU"].Value;
                        unidadmedida.EliminarUnidadMedida(idu);
                        OptionPane.MessageInformation("Se ha eliminado Exitosamente");
                        CargaDatos();
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError("La unidad de medida esta en uso" + ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageError("Debe seleccionar una unidad de medida.");
            }
        }

        /// <summary>
        /// Elimino los valores de las unidades de medida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtnEliminarValorMedida_Click(object sender, EventArgs e)
        {
            if (this.dgvValorMedida.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro de eliminar el registro?", "Eliminar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    try
                    {
                        int id = (int)this.dgvValorMedida.CurrentRow.Cells["IdM"].Value;
                        valorunidadmedida.EliminarValorMedida(id);
                        OptionPane.MessageInformation("Se ha elimino exitosamente.");
                        if (dgvValorMedida.RowCount > 1)
                        {
                            CargaDatos();
                        }
                        else
                        {
                            dgvValorMedida.Rows.RemoveAt(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError("Error al eliminar el valor de la unidad de medida." + ex.Message);
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar un valor de la unidad de medida");
            }
        }

        private void btnAgregarMedida_Click(object sender, EventArgs e)
        {
            if (CancelNewMedida)
            {
                btnAgregarMedida.Image = new Bitmap(ImgAgregaStream);
                miToolTip.SetToolTip(btnAgregarMedida, "Cancelar");
                tsbtnModificarValorMedida.Enabled = false;
                tsbtnGuardarModificarValorMedida.Enabled = true;
                tsbtnEliminarValorMedida.Enabled = false;
                txModificaValorMedida.Focus();
                EditarMedida = false;
                NewMedida = true;
                CancelNewMedida = false;
            }
            else
            {
                if (NewMedida)
                {
                    btnAgregarMedida.Image = ((Image)miResources.GetObject("btnAgregarMedida.Image"));
                    miToolTip.SetToolTip(btnAgregarMedida, "Agregar Medida");
                    tsbtnModificarValorMedida.Enabled = true;
                    tsbtnGuardarModificarValorMedida.Enabled = false;
                    tsbtnEliminarValorMedida.Enabled = true;
                    NewMedida = false;
                    CancelNewMedida = true;
                }
            }
        }

        private void tsMedidaSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsConsultaSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnMedida_Click(object sender, EventArgs e)
        {
            gbListaUnidadMedida.Enabled = true;
            gbListaValorUnidadMedida.Enabled = false;
        }

        private void tsBtnUnidad_Click(object sender, EventArgs e)
        {
            gbListaUnidadMedida.Enabled = false;
            gbListaValorUnidadMedida.Enabled = true;
        }

        private void frmmedida_FormClosing(object sender, FormClosingEventArgs e)
        {
            //guardar cambios
            if (dgbValorUnidadMedida.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("Está a punto de salir. ¿Desea guardar los cambios?", "Unidades de Medida",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    tsbtnguardar_Click(this.tsbtnguardar, new EventArgs());
                    if (verificaunidadmedida)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
                else
                {
                    if (rta.Equals(DialogResult.No))
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
        }
    }
}