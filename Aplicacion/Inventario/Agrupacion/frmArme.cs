using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Utilities;
using BussinesLayer.Clases;
using System.Collections;
using DTO.Clases;
using CustomControl;
using Aplicacion.Compras.IngresarCompra;
using Aplicacion.Inventario.Agrupacion;

namespace Aplicacion.Inventario.Arme
{
    public partial class frmArme : Form
    {
        #region Atributos

        /// <summary>
        /// Objeto para cargar producto.
        /// </summary>
        private DTO.Clases.Producto MiProducto;

        /// <summary>
        /// Objeto para cargar los datos de la medida del producto consultado.
        /// </summary>
        private ValorUnidadMedida MiMedida;

        /// <summary>
        /// Objeto para cargar talla y color del producto.
        /// </summary>
        private TallaYcolor mitallaYColor;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesProducto miProducto;

        /// <summary>
        /// Atributos de modelo de negocios.
        /// </summary>
        private BussinesInventario miInventario;

        /// <summary>
        /// Coleccion de objetos (producto).
        /// </summary>
        private ArrayList arrayProducto;

        /// <summary>
        /// Representa un atabla de datos en memoria.
        /// </summary>
        private DataTable miTable;

        /// <summary>
        /// Colecciona el origen de datos de un objeto.
        /// </summary>
        private BindingSource miBindingSource;

        /// <summary>
        /// Probador de mensajes de error.
        /// </summary>
        private ErrorProvider er;

        /// <summary>
        /// Obtiene o establece l valor que indica sise habilita colot o no en el formulario segun la configuracion.
        /// </summary>
        private bool EnableColor;

        /// <summary>
        /// contador de registros de productos a desagrupar
        /// </summary>
        private int contador = 0;

        /// <summary>
        /// Obtiene o establece el id de la unidad de medida del producto seleccionado.
        /// </summary>
        private int idMedida;

        /// <summary>
        /// Obtiene o estalece el id de el color dol producto seleccionado.
        /// </summary>
        private int idColor;

        /// <summary>
        /// Obtiene o establece el codigo de articulo a desagrupar.
        /// </summary>
        private string codigoAgrupacion;

        /// <summary>
        /// Obtienen o establece el id de la medida en la agrupacion.
        /// </summary>
        private int idMedidaAgrupacion;

        /// <summary>
        /// Obtiene o establece el id de el color an la agrupacion.
        /// </summary>
        private int idColorAgrupacion;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita o no el formulario de desagrupacion
        /// </summary>
        public bool AplicaDesagrupar { set; get; }

        /// <summary>
        /// Obtiene o establece el valor que indica sise encuentra abierto el formulario de listar color.
        /// </summary>
        private bool FormAgrupacion { set; get; }

        /// <summary>
        /// Establece la regla de validacion que indica si se uso el metodo keyPress de agrupar articulo.
        /// </summary>
        private bool KeyProductoPressAgrupar = false;

        /// <summary>
        /// Establece la regla de validacion que indica si se uso l metodo keypress de desagrupar articulo.
        /// </summary>
        private bool KeyProductoPressDesagrupar = false;

        /// <summary>
        /// Indica si se quiere ver las medidas en el grid.
        /// </summary>
        private bool btnVerMedidaPress = true;

        /// <summary>
        /// Indica si no quiere ver las medidas en el grid.
        /// </summary>
        private bool btnNoVerMedidaPress = true;

        /// <summary>
        /// Indica si se quiere ver color en el grid.
        /// </summary>
        private bool btnVerColorPress = true;

        /// <summary>
        /// Indica si no quiere ver color en el grid.
        /// </summary>
        private bool btnNoVerColorPress = true;

        /// <summary>
        /// Establece el valor de cantidadAgrupar en la validacion.
        /// </summary>
        private bool cantidadAgrupar = false;

        /// <summary>
        /// Establece el valor de cantidadDesagrupar en la validacion.
        /// </summary>
        private bool cantidadDesagrupada = false;

        /// <summary>
        /// Establece el valor de desagrupado en la validacion
        /// </summary>
        private bool desagrupado = false;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicacion.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa al stream de imagen de color.
        /// </summary>
        private System.IO.Stream imgColorStream;

        /// <summary>
        /// Representa el stream de la imagen de medida.
        /// </summary>
        private System.IO.Stream imgMedidaStream;

        /// <summary>
        /// Representa la ruta de ensamblado de el color gris de el color.
        /// </summary>
        private const string imagenColor = "Aplicacion.Recursos.Iconos.colorGris.png";

        /// <summary>
        /// Representa la ruta de ensamblado de la imagen de color gris de medida
        /// </summary>
        private const string imagenMedida = "Aplicacion.Recursos.Iconos.medidaGris.png";

        /// <summary>
        /// Representa el texto:El codigo del articulo que ingresado no tiene registro en la base de datos.
        /// </summary>
        private string CodigoProductoExiste = "El codigo del articulo que ingresado no tiene registro en la base de datos.";

        #endregion

        public frmArme()
        {
            InitializeComponent();
            miTable = new DataTable();
            miTable = CrearTableDesagrupar();
            EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            miInventario = new BussinesInventario();
            miProducto = new BussinesProducto();
            miBindingSource = new BindingSource();
            er = new ErrorProvider();
        }

        private void frmArme_Load(object sender, EventArgs e)
        {
            //AplicaDesagrupar = false;
            //if (AplicaDesagrupar)
            
                CargaDesagrupar();
            /*}
            else
            {
                CargaDesagrupar();
            }*/
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.CompletaEditProveedor += 
                new CompletaEventos.CompletaAccionEditProveedor(CompletaEventosEdit_Completo);
            dgvListadoArticulos.DataSource = miBindingSource;
            dgvListadoArticulos.AutoGenerateColumns = false;
            assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CargarRecursos();
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (idMedidaAgrupacion != 0)
                {
                    if (dgvListadoArticulos.RowCount != 0)
                    {
                        DialogResult r = MessageBox.Show("Desa guardar los cambios.", "Guardar",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (r == DialogResult.Yes)
                        {
                            if (AplicaDesagrupar)
                            {
                                AgrupaDesagrupa(true, false);
                            }
                            else
                            {
                                AgrupaDesagrupa(false, true);
                            }
                            LimpiaObjeto();
                            txtCodigo.Focus();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("Debe de agregar los productos a desagrupar.");
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe seleccionar un articulo a agrupar.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                KeyProductoPressAgrupar = true;
                if (ValidaBarras(txtCodigo))
                {
                    if (ExisteBarras(txtCodigo.Text))
                    {
                        Cargar(txtCodigo.Text, false);
                        er.SetError(txtCodigo, null);
                    }
                    else
                    {
                        OptionPane.MessageInformation(CodigoProductoExiste);
                        er.SetError(txtCodigo, CodigoProductoExiste);
                        txtCodigo.Focus();
                    }
                }
                else
                {
                    txtCodigo.Focus();
                }
            }
            else
            {
                KeyProductoPressAgrupar = false;
            }
        }

        private void btnDesagruparTallaColor_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    Aplicacion.Inventario.Agrupacion.frmListarProducto Producto = 
                        new Aplicacion.Inventario.Agrupacion.frmListarProducto();
                    Producto.CargarProducto(MiProducto.CodigoInternoProducto);
                    Producto.MdiParent = this.MdiParent;
                    Producto.Show();
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar un Articulo primero.");
            }
        }

        private void btnConsultarCodigo_Click(object sender, EventArgs e)
        {
            if (!FormAgrupacion)
            {
                desagrupado = false;
                Inventario.Producto.FrmIngresarProducto producto =
                    new Producto.FrmIngresarProducto();
                producto.Extencion = true;
                producto.Agrupar = true;
                producto.tabControlProducto.SelectedIndex = 1;
                producto.MdiParent = this.MdiParent;
                FormAgrupacion = true; 
                producto.Show();
            }
        }

        private void txtCodigoDesagrupar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                KeyProductoPressDesagrupar = true;
                if(MiProducto != null)
                    MiProducto.CodigoInternoProducto = "";
                if(cantidadAgrupar)
                {
                    if (ValidaBarras(txtCodigoDesagrupar))
                    {
                        if (txtCodigo.Text != txtCodigoDesagrupar.Text)
                        {
                            er.SetError(txtCodigoDesagrupar, null);

                            if (ExisteBarras(txtCodigoDesagrupar.Text))
                            {
                                //MiProducto = null;
                                desagrupado = true;
                                Cargar(txtCodigoDesagrupar.Text, true);
                                er.SetError(txtCodigoDesagrupar, null);
                                txtCodigo.Enabled = false;
                                btnConsultarCodigo.Enabled = false;
                                txtCantidadAgrupar.Enabled = false;
                                btnEditarCantidadAgrupar.Enabled = true;
                            }
                            else
                            {
                                OptionPane.MessageInformation(CodigoProductoExiste);
                                er.SetError(txtCodigoDesagrupar, CodigoProductoExiste);
                                txtCodigoDesagrupar.Focus();
                            }

                        }
                        else
                        {
                            OptionPane.MessageInformation("Un producto a desagrupar no puede ser el mismo que el producto a agrupar.");
                            txtCodigoDesagrupar.Text = "";
                        }
                    }
                }
                else
                {
                    txtCodigoDesagrupar.Focus();
                }
            }
            else
            {
                KeyProductoPressDesagrupar = false;
            }
        }

        private void btnTallaColorDesagrupar_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    Aplicacion.Inventario.Agrupacion.frmListarProducto Producto = new Aplicacion.Inventario.Agrupacion.frmListarProducto();
                    var codigo = MiProducto.CodigoInternoProducto;
                    Producto.CargarProducto(codigo);
                    Producto.MdiParent = this.MdiParent;
                    Producto.Show();
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe de seleccionar un articulo primero.");
            }
        }

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            if (MiProducto != null)
            {
                txtCantidadDesagrupar_Validating(null, null);
                if (MiProducto.CodigoInternoProducto != "")
                {
                    if (OperacionDesagrupar())
                    {
                        if (existe(idMedida, idColor))
                        {
                            if (txtCantidadDesagrupar.Text != "0")
                            {
                                er.SetError(txtCantidadDesagrupar, null);
                                CargarRegistro();
                                er.SetError(txtCodigoDesagrupar, null);
                                MiProducto = null;
                                txtCodigoDesagrupar.Focus();
                            }
                            else
                            {
                                er.SetError(txtCantidadDesagrupar, "La cantidad del articulo debe ser superior a cero.");
                                txtCantidadDesagrupar.Focus();
                            }
                        }
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Debe cargar el articulo primero.");
                    er.SetError(txtCodigoDesagrupar, "Debe cargar el articulo primero.");
                    txtCodigoDesagrupar.Focus();
                }
            }
            else
            {
                er.SetError(txtCodigoDesagrupar, "Debe seleccionar un articulo primero.");
                OptionPane.MessageInformation("Debe seleccionar un articulo primero.");
                txtCodigoDesagrupar.Focus();
            }
        }

        private void btnConsultarCodigoDesagrupar_Click(object sender, EventArgs e)
        {
            if (!FormAgrupacion)
            {
                desagrupado = true;
                Inventario.Producto.FrmIngresarProducto producto =
                   new Producto.FrmIngresarProducto();
                producto.Extencion = true;
                producto.Agrupar = true;
                producto.tabControlProducto.SelectedIndex = 1;
                producto.MdiParent = this.MdiParent;
                FormAgrupacion = true;
                producto.Show();
            }
        }

        private void btnEditarCantidadAgrupar_Click(object sender, EventArgs e)
        {
            txtCodigo.Enabled = true;
            //txtCantidadInventario.Text = "";
            txtCantidadAgrupar.Enabled = true;
            desagrupado = false;
            if (miTable.Rows.Count != 0)
            {
                miTable.Rows.Clear();
            }
            while (dgvListadoArticulos.RowCount != 0)
            {
                dgvListadoArticulos.Rows.RemoveAt(0);
            }
            LimpiaCampos();
            txtCodigo.Focus();
        }

        private void tsVerMedida_Click(object sender, EventArgs e)
        {
            if (btnVerMedidaPress)
            {
                tsVerMedida.Image = new Bitmap(imgMedidaStream);
                tsVerMedida.Text = "No Ver Unidad de Medida";
                btnNoVerMedidaPress = true;
                btnVerMedidaPress = false;
                dgvListadoArticulos.Columns["Medida"].Visible = true;
            }
            else
            {
                if (btnNoVerMedidaPress)
                {
                    tsVerMedida.Image = ((Image)(miResources.GetObject("tsVerMedida.Image")));
                    tsVerMedida.Text = "Ver Unidad de Medida";
                    btnNoVerMedidaPress = false;
                    btnVerMedidaPress = true;
                    dgvListadoArticulos.Columns["Medida"].Visible = false;
                }
            }
        }

        private void tsVerColor_Click(object sender, EventArgs e)
        {
            if (btnVerColorPress)
            {
                tsVerColor.Image = new Bitmap(imgColorStream);
                tsVerColor.Text = "No Ver Unidad de Medida";
                btnNoVerColorPress = true;
                btnVerColorPress = false;
                dgvListadoArticulos.Columns["Color"].Visible = true;
            }
            else
            {
                if (btnNoVerColorPress)
                {
                    tsVerColor.Image = ((Image)(miResources.GetObject("tsVerColor.Image")));
                    tsVerColor.Text = "Ver Color";
                    btnNoVerColorPress = false;
                    btnVerColorPress = true;
                    dgvListadoArticulos.Columns["Color"].Visible = false;
                }
            }
        }

        private void tsEliminar_Click_1(object sender, EventArgs e)
        {
            if (dgvListadoArticulos.RowCount != 0)
            {
                var id = (int)dgvListadoArticulos.CurrentRow.Cells["Id"].Value;
                var row = (from registro in miTable.AsEnumerable()
                           where registro.Field<int>("Id") == id
                           select registro);
                DataRow delete = null;
                foreach (DataRow r in row)
                {
                    delete = r;
                }
                miTable.Rows.Remove(delete);
                if (miTable.Rows.Count != 0)
                {
                    RecargaGrid();
                }
                else
                {
                    dgvListadoArticulos.Rows.RemoveAt(dgvListadoArticulos.CurrentCell.RowIndex);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hoy registros a eliminar");
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!KeyProductoPressAgrupar)
            {
                if (ValidaBarras(txtCodigo))
                {
                    if (ExisteBarras(txtCodigo.Text))
                    {
                        Cargar(txtCodigo.Text, false);
                        er.SetError(txtCodigo, null);                        
                    }
                    else
                    {
                        OptionPane.MessageInformation(CodigoProductoExiste);
                        er.SetError(txtCodigo, CodigoProductoExiste);
                        txtCodigo.Focus();
                    }
                }
                else
                {
                    txtCodigo.Focus();
                }
            }
        }

        private void txtCantidadAgrupar_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCantidadAgrupar, er, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtCantidadAgrupar, er,
                    "La cantidad ingresada no tiene un formato correcto."))
                {
                    if (!String.IsNullOrEmpty(txtCantidadInventario.Text))
                    {
                        if (AplicaDesagrupar)
                        {
                            if (Convert.ToInt32(txtCantidadAgrupar.Text) <= Convert.ToInt32(txtCantidadInventario.Text))
                            {
                                er.SetError(txtCantidadAgrupar, null);
                                cantidadAgrupar = true;
                            }
                            else
                            {
                                cantidadAgrupar = false;
                                er.SetError(txtCantidadAgrupar,
                                    "La cantidad a desagrupar debe ser menor o igual a la cantidad en inventario.");
                            }
                        }
                        else
                        {
                            if (txtCantidadAgrupar.Text != "0")
                            {
                                cantidadAgrupar = true;
                            }
                            else
                            {
                                cantidadAgrupar = false;
                                er.SetError(txtCantidadAgrupar,
                                    "La cantidad a agrupar debe ser superior a Cero.");
                            }
                        }
                    }
                }
                else
                    cantidadAgrupar = false;
            }
            else
            {
                cantidadAgrupar = false;
                txtCantidadAgrupar.Focus();
            }
        }

        private void txtCodigoDesagrupar_Validating(object sender, CancelEventArgs e)
        {
            if (!KeyProductoPressDesagrupar)
            {
                MiProducto.CodigoInternoProducto = "";
                if (txtCodigo.Text != txtCodigoDesagrupar.Text)
                {
                    if (ValidaBarras(txtCodigoDesagrupar))
                    {
                        if (AplicaDesagrupar)
                        {
                            if (ExisteBarras(txtCodigoDesagrupar.Text))
                            {
                                //MiProducto = null;
                                desagrupado = true;
                                Cargar(txtCodigoDesagrupar.Text, true);
                                er.SetError(txtCodigoDesagrupar, null);

                                txtCodigo.Enabled = false;
                                btnConsultarCodigo.Enabled = false;
                                txtCantidadAgrupar.Enabled = false;
                                btnEditarCantidadAgrupar.Enabled = true;
                            }
                            else
                            {
                                OptionPane.MessageInformation(CodigoProductoExiste);
                                er.SetError(txtCodigoDesagrupar, CodigoProductoExiste);
                                txtCodigoDesagrupar.Focus();
                            }
                        }
                    }
                    else
                    {
                        //txtCodigoDesagrupar.Focus();
                    }
                }
                else
                {
                    OptionPane.MessageInformation("Un producto a desagrupar no puede ser el mismo que el rpoducto a agrupar.");
                    txtCodigoDesagrupar.Text = "";
                }
            }
        }

        private void txtCantidadDesagrupar_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCantidadDesagrupar, er, "El campo es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, txtCantidadDesagrupar, er, "La cantidad ingresada tiene formato incorrecto."))
                {
                    cantidadDesagrupada = true;
                }
                else
                    cantidadDesagrupada = false;
            }
            else
                cantidadDesagrupada = false;
        }

        /// <summary>
        /// Valida el campo de busqueda por codigo de barras
        /// </summary>
        /// <returns></returns>
        private bool ValidaBarras(Control miControl)
        {
            var validaBarras = false;
            if (!Validacion.EsVacio(miControl, er, "El campo es requerido"))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros, miControl, er, "El codigo de barras ingresado tiene formato incorrecto."))
                {
                    return validaBarras = true;
                }
            }
            return validaBarras;
        }

        /// <summary>
        /// Valida si existe en codigo de barras ingresado existe dentro de la base de datos.
        /// </summary>
        /// <param name="codigo">codigo de barras o codigo interno a consultar</param>
        /// <returns></returns>
        private bool ExisteBarras(string codigo)
        {
            try
            {
                var codex = miProducto.ExisteCodigo(codigo);
                var barras = miProducto.ExisteCodigoBarras(codigo);
                if (codex || barras)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga en memoria los datos del producto consultado segun su codigo.
        /// </summary>
        /// <param name="codigo">codigo de l producto a cargar</param>
        /// <param name="desagrupado"></param>
        private void Cargar(string codigo, bool desagrupado)
        {
            try
            {
                arrayProducto = miProducto.ProductoBasico(codigo);
                MiProducto = (DTO.Clases.Producto)arrayProducto[0];
                if (!MiProducto.AplicaTalla)
                {
                    MiMedida = (ValorUnidadMedida)arrayProducto[1];
                }
                if (desagrupado)
                {
                    lblArticuloDesagrupar.Text = MiProducto.CodigoInternoProducto + " -- " + 
                        MiProducto.NombreProducto + " -- " + MiProducto.NombreMarca;

                    if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                    {
                        btnTallaColorDesagrupar.Enabled = false;
                        ConsultaSinColoryTalla();
                    }
                    else
                    {
                        btnDesagruparTallaColor_Click(null, null);
                    }
                }
                else
                {
                    lblArticuloCon.Text = MiProducto.CodigoInternoProducto + " -- " +
                        MiProducto.NombreProducto + " -- " + MiProducto.NombreMarca;
                    if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                    {
                        btnTallaColorAgrupar.Enabled = false;
                        ConsultaSinColoryTalla();
                    }
                    else
                    {
                        btnDesagruparTallaColor_Click(null, null);
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de estención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento arg)
        {
            try
            {
                mitallaYColor = (TallaYcolor)arg.MiObjeto;
                var medida = 0;
                if (MiProducto.AplicaTalla)
                {
                    medida = mitallaYColor.IdTalla;
                }
                else
                {
                    medida = MiMedida.IdValorUnidadMedida;
                }
                var cant = CantidadInventario(MiProducto.CodigoInternoProducto, medida, mitallaYColor.IdColor);
                if (cant > -1)
                {
                    if (desagrupado)
                    {
                        idMedida = medida;
                        idColor = mitallaYColor.IdColor;
                        txtCantidadInventarioDesagrupada.Text = ResultadoCantidadInventario(cant, idMedida, idColor).ToString();
                        txtCantidadDesagrupar.Focus();
                    }
                    else
                    {
                        if (AplicaDesagrupar)//des-agrupacion
                        {
                            if (!cant.Equals(0))
                            {
                                er.SetError(txtCodigo, null);
                                idMedidaAgrupacion = medida;
                                idColorAgrupacion = mitallaYColor.IdColor;
                                txtCantidadInventario.Text =
                                    CantidadInventario(MiProducto.CodigoInternoProducto, medida, idColorAgrupacion).ToString();
                                txtCantidadAgrupar.Focus();
                            }
                            else
                            {
                                er.SetError(txtCodigo, "La cantidad del producto en inventario debe ser superior a cero.");
                                txtCodigo.Focus();
                            }
                        }
                        else//agrupacion
                        {
                            er.SetError(txtCodigo, null);
                            idMedidaAgrupacion = medida;
                            idColorAgrupacion = mitallaYColor.IdColor;
                            txtCantidadInventario.Text =
                                CantidadInventario(MiProducto.CodigoInternoProducto, medida, idColorAgrupacion).ToString();
                            txtCantidadAgrupar.Focus();
                        }
                        //codigoAgrupacion =txtCodigo.Text;
                        /*idMedidaAgrupacion = medida;
                        idColorAgrupacion = mitallaYColor.IdColor;
                        txtCantidadInventario.Text = 
                            CantidadInventario(MiProducto.CodigoInternoProducto, medida, idColorAgrupacion).ToString();
                        txtCantidadAgrupar.Focus();*/
                    }
                }
                else
                {
                    btnDesagruparTallaColor_Click(null, null);
                }
            }
            catch
            { }
            try
            {
                FormAgrupacion = Convert.ToBoolean(arg.MiObjeto);
            }
            catch
            { }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de estacion.
        /// </summary>
        /// <param name="args">Objeto que enclapsula la informacion del formulario.</param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiMarca;
                //txtCodigo.Text = producto.CodigoInternoProducto;
                if (desagrupado)
                {
                    txtCodigoDesagrupar.Text = producto.CodigoInternoProducto;
                    txtCodigoDesagrupar_KeyPress(this.txtCodigoDesagrupar,
                        new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    txtCodigo.Text = producto.CodigoInternoProducto;
                    txtCodigo_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
                }
            }
            catch
            { }
        }

        void CompletaEventosEdit_Completo(CompletaArgumentosDeEventoEditProveedor args)
        {
            try
            {
                FormAgrupacion = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        /// <summary>
        /// Consulta los productos que no tienen talla ni color.
        /// </summary>
        private void ConsultaSinColoryTalla()
        {
            var cant = CantidadInventario(MiProducto.CodigoInternoProducto, MiMedida.IdValorUnidadMedida, 0);
            if (cant > -1)
            {
                if (desagrupado)
                {                   
                    idMedida = MiMedida.IdValorUnidadMedida;
                    idColor = 0;
                    txtCantidadInventarioDesagrupada.Text = ResultadoCantidadInventario(cant, idMedida, idColor).ToString();
                    txtCantidadDesagrupar.Focus();
                }
                else
                {
                    codigoAgrupacion = MiProducto.CodigoInternoProducto;
                    idMedidaAgrupacion = MiMedida.IdValorUnidadMedida;
                    idColor = 0;
                    txtCantidadInventario.Text = CantidadInventario(codigoAgrupacion, idMedidaAgrupacion, idColor).ToString();
                    txtCantidadAgrupar.Focus();
                }
            }
        }

        /// <summary>
        /// Obtiene la cantidad de el articuloa consultar
        /// </summary>
        /// <param name="codigo">codigo de producto a consultar</param>
        /// <param name="idMedida">id unidad medida del producto a consultar</param>
        /// <param name="idColor">id color del producto a consultar</param>
        /// <returns></returns>
        private double CantidadInventario(string codigo, int idMedida, int idColor)
        {
            var inventario = new DTO.Clases.Inventario();
            inventario.CodigoProducto = codigo;
            inventario.IdMedida = idMedida;
            inventario.IdColor = idColor;
            try
            {
                return miInventario.CantidadInventario(inventario);
            }
            catch
            {
                OptionPane.MessageInformation("La Talla o el Color no tienen registros en la base de datos.");
                return -1;
            }
        }

        /// <summary>
        /// Coonsulta la cantidad ingresada con la que aya en la tabla
        /// </summary>
        /// <param name="cantidadInventario">cantidad inventario a consultar</param>
        /// <returns></returns>
        private double ResultadoCantidadInventario(double cantidadInventario, int idMedida, int idColor)
        {
            if (miTable.Rows.Count > 0)
            {
                var consulta = (from datos in miTable.AsEnumerable()
                                where datos.Field<int>("Codigo") == Convert.ToInt32(MiProducto.CodigoInternoProducto)
                                && datos.Field<int>("IdMedida") == idMedida
                                && datos.Field<int>("IdColor") == idColor
                                select datos).ToList();
                var cant = 0.0;
                foreach (DataRow row in consulta)
                {
                    cant = (int)row["Cantidad"];
                }
               
                    if(AplicaDesagrupar)
                    {
                        return cant * Convert.ToDouble(txtCantidadAgrupar.Text);
                    }
                    else
                    {
                        return cantidadInventario - (cant * Convert.ToInt32(txtCantidadAgrupar.Text));
                    }
            }
            else
            {
                return cantidadInventario;
            }
        }

        /// <summary>
        /// Resata la catidad de los articulos a desagrupar en inventario.
        /// </summary>
        private bool OperacionDesagrupar()
        {
            try
            {
                if (AplicaDesagrupar)
                {
                    return true;
                }
                else
                {
                    var cantidad = int.Parse(txtCantidadDesagrupar.Text) * int.Parse(txtCantidadAgrupar.Text);
                    if (Convert.ToInt32(cantidad) <= Convert.ToInt32(txtCantidadInventarioDesagrupada.Text))
                    {
                        return true;
                    }
                    else
                    {
                        OptionPane.MessageInformation("No se puede agrupar el articulo, ya que la cantidad a desagrupar \n es mayor a la cantidad del  articulo que hay en inventario.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga los registros consultados a la tabla.
        /// </summary>
        private void CargarRegistro()
        {
            try
            {
                if (arrayProducto.Count > 0)
                {
                    contador++;
                    DataRow row = miTable.NewRow();
                    row["Id"] = contador;
                    if (MiProducto.AplicaTalla)
                    {
                        row["IdMedida"] = mitallaYColor.IdTalla;
                        row["Medida"] = mitallaYColor.Talla;
                    }
                    else
                    {
                        row["IdMedida"] = MiMedida.IdValorUnidadMedida;
                        row["Medida"] = MiMedida.DescripcionValorUnidadMedida;
                    }
                    if (MiProducto.AplicaColor)
                    {
                        row["IdColor"] = mitallaYColor.IdColor;
                        row["Color"] = mitallaYColor.Color;
                    }
                    else
                    {
                        row["IdColor"] = 0;
                        row["Color"] = null;
                    }
                    row["Codigo"] = MiProducto.CodigoInternoProducto;
                    row["Articulo"] = MiProducto.NombreProducto;
                    row["Cantidad"] = txtCantidadDesagrupar.Text;
                    miTable.Rows.Add(row);
                    RecargaGrid();
                    LimpiaCampos();
                }
            }
            catch
            { }
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable miTabla.
        /// </summary>
        /// <returns></returns>
        private DataTable CrearTableDesagrupar()
        {
            var general = new DataTable();
            general.Columns.Add(new DataColumn("Id", typeof(int)));
            general.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            general.Columns.Add(new DataColumn("Medida", typeof(string)));
            general.Columns.Add(new DataColumn("IdColor", typeof(int)));
            general.Columns.Add(new DataColumn("Color", typeof(Image)));
            general.Columns.Add(new DataColumn("Codigo", typeof(int)));
            general.Columns.Add(new DataColumn("Articulo", typeof(string)));
            general.Columns.Add(new DataColumn("Cantidad", typeof(int)));
            return general;
        }

        /// <summary>
        /// Recarga el DataGridView Productos segun los datos en el DataTable miTable.
        /// </summary>
        private void RecargaGrid()
        {
            IEnumerable<DataRow> query = from datos in miTable.AsEnumerable()
                                         orderby datos.Field<int>("Codigo") descending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        /// <summary>
        /// Limpia los campos de consulta en desagrupar articulo.
        /// </summary>
        private void LimpiaCampos()
        {
            txtCodigoDesagrupar.Text = "";
            lblArticuloDesagrupar.Text = "";
            txtCantidadInventarioDesagrupada.Text = "";
            txtCantidadDesagrupar.Text = "";
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void LimpiaObjeto()
        {
            txtCodigo.Focus();
            txtCantidadAgrupar.Enabled = true;
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            lblArticuloCon.Text = "";
            txtCantidadInventario.Text = "";
            txtCantidadAgrupar.Text = "";
            txtCodigoDesagrupar.Text = "";
            lblArticuloDesagrupar.Text = "";
            txtCantidadInventarioDesagrupada.Text = "";
            txtCantidadDesagrupar.Text = "";
            if (miTable.Rows.Count != 0)
            {
                miTable.Rows.Clear();
            }
            while (dgvListadoArticulos.RowCount != 0)
            {
                dgvListadoArticulos.Rows.RemoveAt(0);
            }
        }

        /// <summary>
        /// Existe dentro de el grid
        /// </summary>
        /// <returns></returns>
        private bool existe(int idMedida, int idColor)
        {
            var consulta = (from datos in miTable.AsEnumerable()
                            where datos.Field<int>("Codigo") == Convert.ToInt32(MiProducto.CodigoInternoProducto)
                            && datos.Field<int>("IdMedida") == idMedida
                            && datos.Field<int>("IdColor") == idColor
                            select datos).ToList();
            if (consulta.Count == 0)
            {
                return true;
            }
            else
            {
                OptionPane.MessageInformation("El Articulo ya existe dentro de los registros a desagrupar.");
                return false;
            }
        }

        /// <summary>
        /// Cargar los recursos del ensamblado usado en el formulario.
        /// </summary>
        private void CargarRecursos()
        {
            try
            {
                imgMedidaStream = assembly.GetManifestResourceStream(imagenMedida);
                imgColorStream = assembly.GetManifestResourceStream(imagenColor);
            }
            catch(Exception ex)
            {
                OptionPane.MessageError("Ocurrio un error al cargar los recursos."+ex.Message);
            }
        }

        /// <summary>
        /// Carga las caracteristicas de form de desagrupar.
        /// </summary>
        private void CargaDesagrupar()
        {
            if (AplicaDesagrupar)
            {
                this.Text = "Desagrupar Articulos";
                gbArticuloAAgrupar.Text = "Producto a desagrupar";
                lblCantidadAgrupar.Text = "Cantidad a desagrupar";
                lblCantidadADesagrupar.Text = "Cantidad a desagrupar";
            }
            else
            {
                this.Text = "Agrupar Articulos";
                gbArticuloAAgrupar.Text = "Producto a agrupar";
                lblCantidadAgrupar.Text = "Cantidad a agrupar";
                lblCantidadADesagrupar.Text = "Cantidad a agrupar";
            }
        }

        private void AgrupaDesagrupa(bool agrupa, bool desagrupa)
        {
            var inventario = new DTO.Clases.Inventario();
            try
            {
                inventario.CodigoProducto = codigoAgrupacion;
                inventario.IdMedida = idMedidaAgrupacion;
                inventario.IdColor = idColorAgrupacion;
                inventario.Cantidad = Convert.ToInt32(txtCantidadAgrupar.Text);

                miInventario.ActualizarInventario(inventario, agrupa);

                foreach (DataRow row in miTable.Rows)
                {
                    inventario.CodigoProducto = Convert.ToString(row["Codigo"]);
                    inventario.IdMedida = Convert.ToInt32(row["IdMedida"]);
                    inventario.IdColor = Convert.ToInt32(row["IdColor"]);
                    inventario.Cantidad = Convert.ToInt32(row["Cantidad"])*Convert.ToInt32(txtCantidadAgrupar.Text);

                    miInventario.ActualizarInventario(inventario, desagrupa);
                }
                OptionPane.MessageInformation("Se a guardado con exito.");
            }
            catch(Exception ex)
            {
                OptionPane.MessageInformation(ex.Message);
            }
        }
    }
}