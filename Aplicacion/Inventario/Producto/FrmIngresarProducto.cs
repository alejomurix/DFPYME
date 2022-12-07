using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Aplicacion.Clases;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Utilities;
using System.Threading;

namespace Aplicacion.Inventario.Producto
{
    public partial class FrmIngresarProducto : Form
    {
        private int CodigoConfiguracionMedida;

        private int IdMedidaConfigurada;

        #region Atributos

        #region Logica de Negocio

        private BussinesEmpresa miBussinesEmpresa;

        private BussinesCategoria miBussinesCategoria;

        private BussinesMarca miBussinesMarca;

        /// <summary>
        /// Objeto de logica de negocio Iva.
        /// </summary>
        BussinesIva miBussinesIva;

        /// <summary>
        /// Objeto de logica de negocio Descuento.
        /// </summary>
        BussinesDescuento miBussinesDescuento;

        /// <summary>
        /// Objeto de logica de negocio Recargo.
        /// </summary>
        BussinesRecargo miBussinesRecargo;

        /// <summary>
        /// Objeto de logica de negocio para Unidad de medida.
        /// </summary>
        private BussinesUnidadMedida bussinesUnidadMedida;

        /// <summary>
        /// Objeto de logica de negocio para los valores de unidad de medida.
        /// </summary>
        private BussinesValorUnidadMedida miBussinesValorUnidad;

        /// <summary>
        /// Representa un objeto de logica para Color.
        /// </summary>
        private BussinesColor miBussinesColor;

        /// <summary>
        /// objeto de logica de negocio de Producto.
        /// </summary>
        public BussinesProducto miBussinesProducto;

        private BussinesConfiguracion miBussinesConfiguracion;

        /// <summary>
        /// Objeto de la clase Producto.
        /// </summary>
        DTO.Clases.Producto miProducto;

        #endregion

        #region Propiedades de Producto

        /// <summary>
        /// Obtiene o establece el valor del id de la Marca.
        /// </summary>
        private int idMarca = 0;

        /// <summary>
        /// Obtiene o estabelece el valor del codigo de la Categoria.
        /// </summary>
        private string codigoCategoria = "";

        /// <summary>
        /// Representa una lista de los Descuentos del Producto.
        /// </summary>
        private List<Descuento> listaDescuentos;

        /// <summary>
        /// Representa una lista de los Recargos del Producto.
        /// </summary>
        private List<Recargo> listaRecargos;

        /// <summary>
        /// Representa una lista de las medidas del producto.
        /// </summary>
        private List<ValorUnidadMedida> medidas;

        /// <summary>
        /// Objeto de coleccion para cargar inventario.
        /// </summary>
        private List<DTO.Clases.Inventario> inventarios;

        #endregion

        #region Utilidades

        /// <summary>
        /// Objeto para aplicar precios.
        /// </summary>
        private AplicarPrecio aplicaPrecio = new AplicarPrecio();
        
        /// <summary>
        /// Objeto para mostrar mensajes en los controles de formulario.
        /// </summary>
        private ToolTip miBtnTexto = new ToolTip();

        /// <summary>
        /// Objeto para que el usuario seleccione un color.
        /// </summary>
        private ColorDialog miColorDialog;

        /// <summary>
        /// Establece la carpeta temporal donde se almacenara la imagen.
        /// </summary>
        private const string folder = "C:\\ImagesTemp";

        /// <summary>
        /// Establece el nombre y extencion de la imagen que se almacenara. Por defecto es .JPEG.
        /// </summary>
        private const string file = "temp.jpg";

        /// <summary>
        /// Estabelce la ruta y el nombre del archivo completo.
        /// </summary>
        private const string rutaYArchivo = folder + "\\" + file;

        /// <summary>
        /// Objeto para manipulacion de colores.
        /// </summary>
        private ElColor color;

        /// <summary>
        /// Objeto para almancenar medidas.
        /// </summary>
        private ValorUnidadMedida medida;

        /// <summary>
        /// Array para almacenar objetos de medida.
        /// </summary>
        private List<ValorUnidadMedida> lstMedida;

        /// <summary>
        /// Array para almacenar objeto de color.
        /// </summary>
        private List<ElColor> listaColor;

        /// <summary>
        /// Tabla para almancenar datos en memoria.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Objeto que estructura criterios de consulta.
        /// </summary>
        private Consulta miConsulta;

        /// <summary>
        /// Objeto que estructura criterios de consulta.
        /// </summary>
        private ConsultaCategoria miConsultaCategoria;

        /// <summary>
        /// Objeto que estructura criterios de consulta combinada.
        /// </summary>
        private ConsultaCombinada miConsultaCombinada;

        /// <summary>
        /// Obtiene o establece el valor que indica si se configuro color para el formulario
        /// </summary>
        private bool EnableColor = false;

        /// <summary>
        /// Obtiene o establece el valor que indica si el Formulario de edicio de producto se encuentra abierto.
        /// </summary>
        private bool FormEditOpen { set; get; }

        public bool SearchFactura = false;

        private int BtnSearch = 0;

        #endregion

        #region Formularios de extencion

        /// <summary>
        /// Formulario para la asignacion de Marca
        /// </summary>
        private Configuracion.Marcas.frmMarca frmMiMarca;

        /// <summary>
        /// Formulario para la asignacion de Categoria.
        /// </summary>
        private Categoria.FrmCategoria frmMiCategoria;

        #endregion

        #region Atributos de Validacion

        /// <summary>
        /// Indica si el Formulario es usado como extencion de otro Formulario.
        /// </summary>
        public bool Extencion = false;

        public bool Agrupar = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si se trata de otra edición en el Form.
        /// </summary>
        public bool Edit = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si se trata de una extención del Form de Remisión.
        /// </summary>
        public bool Remision = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si se trata de una consulta de devolución de producto.
        /// </summary>
        public bool Devolucion = false;

        /// <summary>
        /// Objeto para mostrar errores de validacion al usuario.
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Establece la condicion para guardar.
        /// </summary>
        private bool codigoMatch = false,
                     barraMatch = true,
                     codigo_2Match = true,
                     codigo_3Match = true,
                     codigo_4Match = true,
                     codigo_5Match = true,
                     codigo_6Match = true,
                     codigo_7Match = true,
                     referenciaMatch = true, //
                     nombreMatch = false,
                     descripcionMatch = false,
                     utilidadMatch = false,
                     valorVentaMatch = false,
                     valorCostoMatch = false,
                     presentacionMatch = false,
                     minimaMatch = false,
                     maximaMatch = false,
                     productoInsumoMatch = false;

        private bool DesctoMayor = false;

        private bool DesctoDistrib = false;

        private bool DesctoPrecio4 = false;

        /// <summary>
        /// Representan mensajes de requerido o formato incorrecto
        /// </summary>
        private const string
            codigoRequerido = "El campo Codigo es Requerido.",
            nombreRequerido = "El campo Nombre es Requerido.",
            valorVentaRequerido = "El campo Valor de Venta es Requerido.",
            codigoFormato = "El Codigo que ingreso tiene formato incorrecto.",
            barraFormato = "El Codigo de Barras que ingreso tiene formato incorrecto.",
            referenciaFormato = "La Referencia que ingreso tiene formato incorrecto.",
            nombreFormato = "El Nombre que ingreso tiene formato incorrecto.",
            descripcionFormato = "La Descripcion que ingreso tiene formato incorrecto.",
            utilidadFormato = "El valor de la Utilidad que ingreso tiene formato incorrecto.",
            valorVentaFormato = "El Valor de Venta que ingreso tiene formato incorrecto.",
            presentacionFormato = "El valor de la Presentacion que ingreso tiene formato incorrecto.",
            minimaFormato = "La cantidad Minima que ingreso tiene formato incorrecto.",
            maximaFormato = "La Cantidad Maxima que ingreso tiene formato incorrecto.",
            codigoExiste = "El codigo que ingreso ya existe en la base de datos.",
            barrasExiste = "El codigo de barras que ingreso ya existe en la base de datos.";

        #endregion

        #region Propiedades de paginacion

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int iteracion;

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

        /// <summary>
        /// Obtiene o establece el valor del codigo del producto.
        /// </summary>
        private string CodigoProducto;

        /// <summary>
        /// Obtiene o establece el valor del nombre del producto.
        /// </summary>
        private string NombreProducto;

        /// <summary>
        /// Obtiene o establece el valor que indica si es una consulta de producto por Categoria.
        /// </summary>
        private bool SearchCategoria;

        /// <summary>
        /// Obtiene o establece el valor que indica si es una consulta de producto por Marca.
        /// </summary>
        private bool SearchMarca;

        /// <summary>
        /// Obtiene o establece el nombre de la categoria.
        /// </summary>
        private string NombreCategoria;

        /// <summary>
        /// Obtiene o establece el valor que indica si se trata de una consulta combinada.
        /// </summary>
        private bool BusquedaCombinada;

        /// <summary>
        /// Obtiene o establece el nombre de la referencia buscada.
        /// </summary>
        private string SearchReferencia;

        /// <summary>
        /// Obtiene o establece el valor que indica si se usa color en la consulta.
        /// </summary>
        private bool ColorChecked;

        /// <summary>
        /// Obtiene o establece el valor que indica si se usa codigo interno de producto en la consulta.
        /// </summary>
        private bool Code;

        /// <summary>
        /// Obtiene o establece el valor de la Marca en una consulta.
        /// </summary>
        private string Marca;

        /// <summary>
        /// Obtiene o establece el valor de la Talla en una consulta.
        /// </summary>
        private string Talla;

        /// <summary>
        /// Obtiene o establece el valor que indica si se usa Talla en la consulta.
        /// </summary>
        private bool Sixe;

        /// <summary>
        /// Obtiene o establece el valor que indica si se usa producto en la consulta.
        /// </summary>
        private bool Product;

        #endregion

        #endregion

        public bool Extend { set; get; }

        private Empresa Empresa { set; get; }

        private int IdProductoProceso { set; get; }

        public FrmIngresarProducto()
        {
            InitializeComponent();
            //this.listBox1.Size = new Size(280, 245);
            //this.listBox1.Location = new Point(367, 200);
            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("product_description")))
                {
                    lblCuenta.Visible = false;
                    cbCuentaContable.Visible = false;

                    lblDescripcion.Location = new Point(604, 93);
                    txtDescripcionProducto.Location = new Point(688, 89);
                    txtDescripcionProducto.ReadOnly = false;
                    txtDescripcionProducto.Size = new Size(230, 55);
                }

                this.CodigoConfiguracionMedida = 2;
                this.IdMedidaConfigurada = 0;

                Extend = false;
                SearchCategoria = false;
                miBussinesIva = new BussinesIva();
                miBussinesDescuento = new BussinesDescuento();
                miBussinesRecargo = new BussinesRecargo();
                bussinesUnidadMedida = new BussinesUnidadMedida();
                miBussinesValorUnidad = new BussinesValorUnidadMedida();
                miBussinesColor = new BussinesColor();
                miBussinesProducto = new BussinesProducto();
                miBussinesCategoria = new BussinesCategoria();
                miBussinesMarca = new BussinesMarca();
                miBussinesEmpresa = new BussinesEmpresa();
                miBussinesConfiguracion = new BussinesConfiguracion();
                Empresa = miBussinesEmpresa.ObtenerEmpresa();

                miError = new ErrorProvider();

                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));

                rowMaxProducto = 12;
                miTabla = new DataTable();

                //this.medidas = new List<ValorUnidadMedida>();

                LoadItemsIco();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void FrmIngresarProducto_Load(object sender, EventArgs e)
        {
            miBtnTexto.SetToolTip(btnBuscarCategoriaIngresarProd, "Buscar Categoria");
            miBtnTexto.SetToolTip(btnBuscarMarca, "Buscar Marca");
            miBtnTexto.SetToolTip(btnSelecionarColor, "Seleccionar Color");
            miBtnTexto.SetToolTip(btnEliminarColor, "Eliminar Color");

            this.cbAplicarPrecio.DataSource = aplicaPrecio.lista();
            CrearDirectorio();
            CargarIva();
            CargarUnidadMedida();
            CargarTallas();
            HabilitarColor();
            CrearTabla();

            CargarDescuentosYrecargos();

            this.dgvMedidaColor.AutoGenerateColumns = false;
                        
            //CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.Completaz += new CompletaEventos.CompletaAccionz(CompletaEventos_Completaz);

            //this.dgvConsultaProducto.AutoGenerateColumns = false;

            miConsulta = new Consulta();
            cbConsulta.DataSource = miConsulta.lista1;
            cbConsulta1.DataSource = miConsulta.lista2;

            miConsultaCategoria = new ConsultaCategoria();
            cbConsutlaCategoria.DataSource = miConsultaCategoria.lista1;
            cbConsutlaCategoria1.DataSource = miConsultaCategoria.lista2;


            miConsultaCombinada = new ConsultaCombinada();
            cbBusquedaCombinada.DataSource = miConsultaCombinada.lista;
            cbBusquedaCombinada1.DataSource = miConsultaCombinada.lista1;

            try
            {
                IdProductoProceso = 4;

                cbCuentaContable.DataSource = miBussinesProducto.CuentasContables();

                cbTipoInventario.DataSource = miBussinesProducto.TiposInventario();
                cbProdProceso.DataSource = miBussinesProducto.ProductosProceso(IdProductoProceso);

                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                {
                    miBtnTexto.SetToolTip(btnInfoCosto, "El costo incluye IVA.");
                }
                else
                {
                    miBtnTexto.SetToolTip(btnInfoCosto, "El costo no incluye IVA.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void LoadItemsIco()
        {
            this.cbAplicaICO.DataSource =
                new List<Criterio>
                {
                    new Criterio
                    {
                        Id = 0,
                        Nombre = "No",
                        Valor = false
                    },
                    new Criterio
                    {
                        Id = 1,
                        Nombre = "Si",
                        Valor = true
                    }
                };
            this.cbValorICO.DataSource = this.miBussinesProducto.Ico();

            this.cbImprime.DataSource =
                new List<Criterio>
                {
                    new Criterio
                    {
                        Id = 0,
                        Nombre = "No",
                        Valor = false
                    },
                    new Criterio
                    {
                        Id = 1,
                        Nombre = "Si",
                        Valor = true
                    }
                };
            this.cbAplicaDescuento.DataSource =
                new List<Criterio>
                {
                    new Criterio
                    {
                        Id = 0,
                        Nombre = "No",
                        Valor = false
                    },
                    new Criterio
                    {
                        Id = 1,
                        Nombre = "Si",
                        Valor = true
                    }
                };
        }

        #region Crear Producto

        private void tsbGuardarProducto_Click(object sender, EventArgs e)
        {
            ValidacionGuardar();
            if (codigoCategoria.Equals(""))
            {
                miError.SetError(txtCategoria, "Debe cargar la categoria del producto.");
            }
            else
            {
                miError.SetError(txtCategoria, null);
            }
            if (txtNombreMarca.Text.Equals(""))
            {
                miError.SetError(txtNombreMarca, "Debe cargar la marca del producto.");
            }
            else
            {
                miError.SetError(txtNombreMarca, null);
            }
            /*if (lbDescuento.SelectedItems.Count == 0)
            {
                lbDescuento.SelectedIndex = 0;
            }
            if (lbRecargo.SelectedItems.Count == 0)
            {
                lbRecargo.SelectedIndex = 0;
            }*/
            if (rbtnTalla.Checked && lstbTalla.SelectedItems.Count == 0)
            {
                miError.SetError(lstbTalla, "Debe seleccionar al menos una talla.");
            }
            else
            {
                miError.SetError(lstbTalla, null);
            }
            if (this.codigoMatch &&
                this.barraMatch && 
                this.codigo_2Match &&
                this.codigo_3Match &&
                this.codigo_4Match &&
                this.codigo_5Match &&
                this.codigo_6Match &&
                this.codigo_7Match && 
                this.referenciaMatch &&
                this.nombreMatch &&
                this.descripcionMatch &&
                this.utilidadMatch &&
                this.valorVentaMatch &&
                this.DesctoMayor && 
                this.DesctoDistrib && 
                this.DesctoPrecio4 &&
                //valorCostoMatch &&
                this.presentacionMatch &&
                this.minimaMatch &&
                this.maximaMatch && 
                this.productoInsumoMatch && 
                !codigoCategoria.Equals("") &&
                !(this.rbtnTalla.Checked && this.lstbTalla.SelectedItems.Count == 0))
            {
                DialogResult rta = MessageBox.Show("¿Esta seguro de guardar los datos?", "Producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    CargarProducto();
                    try
                    {
                        miBussinesProducto.InsertarProducto(miProducto);
                        MessageBox.Show("Los datos se almacenaron correctamente.", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (Extend)
                        {
                            CompletaEventos.CapturaEvenTransInvFactProvee(miProducto);
                            this.Close();
                        }
                        LimpiarCampos();
                        txtCodigoInternoProducto.Focus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsbSalirIngresarProd_Click(object sender, EventArgs e)
        {
           /* DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?", "Edicion",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                this.tsbGuardarProducto_Click(this.tsbGuardarProducto, new EventArgs());
                if (codigoMatch &&
                barraMatch &&
                referenciaMatch &&
                nombreMatch &&
                descripcionMatch &&
                utilidadMatch &&
                valorVentaMatch &&
                presentacionMatch &&
                minimaMatch &&
                maximaMatch)
                {
                    this.Close();
                }
            }
            else
            {
                if (rta.Equals(DialogResult.No))
                {
                    this.Close();
                }
            }*/

            this.Close();
        }

        private void llGenerarCodigoInterno_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtCodigoInternoProducto.Text = Convert.ToString(
                    miBussinesProducto.CapturarCodigoInterno());
                txtCodigoInternoProducto_Validating(this.txtCodigoInternoProducto, null);
                txtCodigoInternoProducto_KeyPress(this.txtCodigoInternoProducto, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //txtCodigoInternoProducto_Validating(null, null);
        }

        private void llGenerarCodigoBarrasProducto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtCodigoBarrasProducto.Text = miBussinesProducto.CapturarCodbarras();
                txtCodigoBarrasProducto_Validating(this.txtCodigoBarrasProducto, null);
                txtCodigoBarrasProducto_KeyPress(this.txtCodigoBarrasProducto, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCodigoCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtCodigoCategoria.Text))
                {
                    if (CodigoOString(txtCodigoCategoria.Text))
                    {
                        CargarCategoria(txtCodigoCategoria.Text);
                    }
                    else
                    {
                        var frmCategoria = new Categoria.FrmCategoriaNuevo();
                        frmCategoria.Extension = true;
                        frmCategoria.PressBoton = false;
                        frmCategoria.txtConsulta.Text = this.txtCodigoCategoria.Text;
                        DialogResult rta = frmCategoria.ShowDialog();
                        if (rta.Equals(DialogResult.Cancel))
                        {
                            this.txtCodigoMarca.Focus();
                        }

                        /*frmMiCategoria = new Categoria.FrmCategoria();
                        frmMiCategoria.PresBoton = false;
                        frmMiCategoria.TblCategoria.SelectTab(1);
                        frmMiCategoria.Extencion = true;
                        frmMiCategoria.txtbuscarporcategoria.Text = txtCodigoCategoria.Text;
                        frmMiCategoria.Show();
                        frmMiCategoria.dgvListadocategoria.Focus();*/
                    }
                }
                else
                {
                    this.btnBuscarCategoriaIngresarProd_Click(this.btnBuscarCategoriaIngresarProd, new EventArgs());
                }
            }
        }

        private void txtCodigoMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtCodigoMarca.Text))
                {
                    if (CodigoOString(txtCodigoMarca.Text))
                    {
                        CargarMarca(txtCodigoMarca.Text);
                    }
                    else
                    {

                        var frmMarca = new Configuracion.Marcas.FrmMarcaNuevo();
                        frmMarca.PressBoton = false;
                        frmMarca.txtConsulta.Text = this.txtCodigoMarca.Text;
                        frmMarca.Extension = true;
                        frmMarca.ShowDialog();
                      /*  frmMiMarca = new Configuracion.Marcas.frmMarca();
                        frmMiMarca.PressBoton = false;
                        frmMiMarca.MdiParent = this.MdiParent;
                        frmMiMarca.txtMarcaNombre.Text = txtCodigoMarca.Text;
                        frmMiMarca.Extension = true;
                        frmMiMarca.Show();
                        frmMiMarca.grillamarca.Focus();*/
                    }
                }
                else
                {
                    this.btnBuscarMarca_Click(this.btnBuscarMarca, new EventArgs());
                }
            }
        }

        private void btnBuscarCategoriaIngresarProd_Click(object sender, EventArgs e)
        {
            if (!Extencion)
            {
                var frmCategoria = new Categoria.FrmCategoriaNuevo();
                frmCategoria.Extension = true;
                this.Extencion = true;
                this.SearchCategoria = false;
                frmCategoria.MdiParent = this.MdiParent;
                frmCategoria.Show();
            }
            /*frmMiCategoria = new Categoria.FrmCategoria();
            frmMiCategoria.TblCategoria.SelectTab(1);
            frmMiCategoria.CargarGridCategorias();
            frmMiCategoria.Extencion = true;
            frmMiCategoria.ShowDialog();
            frmMiCategoria.dgvListadocategoria.Focus();*/

            /*var frmCategoria = new Categoria.FrmCategoriaNuevo();
            frmCategoria.Extension = true;
            frmCategoria.ShowDialog();*/
        }

        private void btnBuscarCategoriaIngresarProd_Validating(object sender, CancelEventArgs e)
        {
            if (!codigoCategoria.Equals(""))
            {
                miError.SetError(btnBuscarCategoriaIngresarProd, null);
            }
        }

        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            if (!this.Extencion)
            {
                var frmMarca = new Configuracion.Marcas.FrmMarcaNuevo();
                frmMarca.Extension = true;
                this.Extencion = true;
                frmMarca.MdiParent = this.MdiParent;
                frmMarca.Show();
            }

            /*var frmMarca = new Configuracion.Marcas.FrmMarcaNuevo();
            frmMarca.Extension = true;
            frmMarca.ShowDialog();*/


            /*frmMiMarca = new Configuracion.Marcas.frmMarca();
            frmMiMarca.CargaGrillaMarca();
            frmMiMarca.Extension = true;
            frmMiMarca.ShowDialog();
            frmMiMarca.grillamarca.Focus();*/
        }

        Validacion validacion = new Validacion();

        /// Section price and coste  ************************************************************************

        private void txtValorCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValorVentaProducto_KeyUp(this.txtValorVentaProducto, null);
                
                txtUtilidadPorcentualProducto.Focus();
            }
        }

        private void txtValorCosto_KeyUp(object sender, KeyEventArgs e)
        {
            ///txtUtilidadPorcentualProducto_KeyUp(txtUtilidadPorcentualProducto, null);
        }

        private void txtValorCosto_Validating(object sender, CancelEventArgs e)
        {
            /*if (!Validacion.EsVacio(txtValorCosto, miError, valorVentaRequerido))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValorCosto, miError, "El campo Costo de venta es requerido."))
                {
                    valorCostoMatch = true;
                }
                else
                    valorCostoMatch = false;
            }
            else
                valorCostoMatch = false;*/
        }


        private void txtUtilidadPorcentualProducto_KeyUp_copy(object sender, KeyEventArgs e)
        { 
            try
            {
                /**
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIva.SelectedItem).PorcentajeIva;
                txtUtilidadPorcentualProducto.Text = txtUtilidadPorcentualProducto.Text.Replace(',', '.');
                var utilidad = txtUtilidadPorcentualProducto.Text;
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (validacion.ValidarNumeroDecima(utilidad))
                {
                    miError.SetError(txtUtilidadPorcentualProducto, null);
                    if (String.IsNullOrEmpty(costo))
                    {
                        costo = "0";
                    }
                    if (validacion.ValidarNumeroInt(costo))
                    {
                        miError.SetError(txtValorCosto, null);
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (valorIva / 100)))).ToString();
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                costo = Convert.ToInt32(Convert.ToInt32(costo) + (Convert.ToInt32(costo) * valorIva / 100)).ToString();
                            }
                        }
                        
                        var precioUtil = 0.0;
                        var precioVenta = 0;
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioUtil = UseObject.RemoveSeparatorMil(costo) +
                                             (UseObject.RemoveSeparatorMil(costo) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                            }
                            else
                            {
                                precioUtil = (UseObject.RemoveSeparatorMil(costo) / ((100 -
                                             Convert.ToDouble(utilidad.Replace('.', ','))) / 100));
                            }
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioVenta = Convert.ToInt32(precioUtil + (precioUtil * valorIva / 100));
                            }
                            else
                            {
                                precioVenta = Convert.ToInt32(precioUtil);
                            }
                        }
                        else   // Utilidad despues de IVA.
                        {
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioUtil = Convert.ToInt32(Convert.ToDouble(costo) + (Convert.ToDouble(costo) * valorIva / 100));
                            }
                            else
                            {
                                precioUtil = Convert.ToInt32(costo);
                            }

                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioVenta = Convert.ToInt32(precioUtil + (precioUtil * Convert.ToDouble(utilidad.Replace('.', ',')) / 100));
                            }
                            else
                            {
                                precioVenta = Convert.ToInt32(
                                    precioUtil / ((100 - Convert.ToDouble(utilidad.Replace('.', ','))) / 100));
                            }
                        }
                        
                       
                        
                        //precioVenta = UseObject.Aproximar(precioVenta, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                        txtValorVentaProducto.Text = precioVenta.ToString();

                        utilidadMatch = true;
                        this.txtDesctoMayor_KeyUp(this.txtDesctoMayor, null);
                        this.txtDesctoDistribuidor_KeyUp(this.txtDesctoDistribuidor, null);
                        this.txtDesctoPrecio4_KeyUp(this.txtDesctoPrecio4, null);
                    }
                    else
                    {
                        miError.SetError(txtValorCosto, "El valor que ingreso es invalido.");
                        utilidadMatch = false;
                    }
                }
                else
                {
                    miError.SetError(txtUtilidadPorcentualProducto, "El valor que ingreso es invalido.");
                    utilidadMatch = false;
                }

                */
            }
            catch (Exception ex)
            {
                miError.SetError(txtValorCosto, ex.Message);
                //OptionPane.MessageError(ex.Message);
            }
        }

        private void txtUtilidadPorcentualProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIva.SelectedItem).PorcentajeIva;
                txtUtilidadPorcentualProducto.Text = txtUtilidadPorcentualProducto.Text.Replace(',', '.');
                var utilidad = txtUtilidadPorcentualProducto.Text;
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (validacion.ValidarNumeroDecima(utilidad))
                {
                    miError.SetError(txtUtilidadPorcentualProducto, null);
                    if (String.IsNullOrEmpty(costo))
                    {
                        costo = "0";
                    }
                    if (validacion.ValidarNumeroInt(costo))
                    {
                        miError.SetError(txtValorCosto, null);
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (valorIva / 100)))).ToString();
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                            {
                                costo = Convert.ToInt32(Convert.ToInt32(costo) + (Convert.ToInt32(costo) * valorIva / 100)).ToString();
                            }
                        }
                        /*if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            costo = Convert.ToInt32((Convert.ToInt32(costo) / (1 + (valorIva / 100)))).ToString();
                        }*/
                        var precioUtil = 0.0;
                        var precioVenta = 0;
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                        {
                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioUtil = UseObject.RemoveSeparatorMil(costo) +
                                             (UseObject.RemoveSeparatorMil(costo) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                            }
                            else
                            {
                                precioUtil = (UseObject.RemoveSeparatorMil(costo) / ((100 -
                                             Convert.ToDouble(utilidad.Replace('.', ','))) / 100));
                            }
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioVenta = Convert.ToInt32(precioUtil + (precioUtil * valorIva / 100));
                            }
                            else
                            {
                                precioVenta = Convert.ToInt32(precioUtil);
                            }
                        }
                        else   // Utilidad despues de IVA.
                        {
                            if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen                                                                (1)
                            {
                                precioUtil = Convert.ToInt32(Convert.ToDouble(costo) + (Convert.ToDouble(costo) * valorIva / 100));
                            }
                            else
                            {
                                precioUtil = Convert.ToInt32(costo);
                            }

                            if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                            {
                                precioVenta = Convert.ToInt32(precioUtil + (precioUtil * Convert.ToDouble(utilidad.Replace('.', ',')) / 100));
                            }
                            else
                            {
                                precioVenta = Convert.ToInt32(
                                    precioUtil / ((100 - Convert.ToDouble(utilidad.Replace('.', ','))) / 100));
                            }
                        }

                        /* var precioUtil = 0.0;
                         if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica")))
                         {
                             precioUtil = UseObject.RemoveSeparatorMil(costo) +
                                          (UseObject.RemoveSeparatorMil(costo) * Convert.ToDouble(utilidad.Replace('.', ',')) / 100);
                         }
                         else
                         {
                             precioUtil = UseObject.RemoveSeparatorMil(costo) / ((100 -
                                          Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
                         }
                         var precioVenta = 0;
                         if (empresa.Regimen.IdRegimen.Equals(1))
                         {
                             precioVenta = Convert.ToInt32(precioUtil + (precioUtil * valorIva / 100));
                         }
                         else
                         {
                             precioVenta = Convert.ToInt32(precioUtil);
                         }*/

                        //precioVenta = UseObject.Aproximar(precioVenta, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                        txtValorVentaProducto.Text = precioVenta.ToString();

                        utilidadMatch = true;
                        this.txtDesctoMayor_KeyUp(this.txtDesctoMayor, null);
                        this.txtDesctoDistribuidor_KeyUp(this.txtDesctoDistribuidor, null);
                        this.txtDesctoPrecio4_KeyUp(this.txtDesctoPrecio4, null);
                    }
                    else
                    {
                        miError.SetError(txtValorCosto, "El valor que ingreso es invalido.");
                        utilidadMatch = false;
                    }
                }
                else
                {
                    miError.SetError(txtUtilidadPorcentualProducto, "El valor que ingreso es invalido.");
                    utilidadMatch = false;
                }
            }
            catch (Exception ex)
            {
                miError.SetError(txtValorCosto, ex.Message);
                //OptionPane.MessageError(ex.Message);
            }
        }

        private void txtUtilidadPorcentualProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                /**
                try
                {
                    if (validacion.ValidarNumeroDecima(txtUtilidadPorcentualProducto.Text))
                    {
                        miError.SetError(txtUtilidadPorcentualProducto, null);
                        EditPrice(false, Convert.ToDouble(txtUtilidadPorcentualProducto.Text.Replace('.', ',')));
                        utilidadMatch = true;
                        cbIva.Focus();
                    }
                    else
                    {
                        miError.SetError(txtValorCosto, "El valor que ingreso es invalido.");
                        utilidadMatch = false;
                    }
                }
                catch { }
                */
                cbIva.Focus(); 
            }
        }

        private void txtUtilidadPorcentualProducto_Validating(object sender, CancelEventArgs e)
        {
            /*var id = (int)cbAplicarPrecio.SelectedValue;
            if (id == 1)
            {
                if (!String.IsNullOrEmpty(txtUtilidadPorcentualProducto.Text))
                {
                    if (Validacion.ConFormato
                        (Validacion.TipoValidacion.NumerosYPunto, txtUtilidadPorcentualProducto, miError, utilidadFormato))
                    {
                        utilidadMatch = true;
                    }
                    else
                        utilidadMatch = false;
                }
                else
                {
                    utilidadMatch = true;
                    miError.SetError(txtUtilidadPorcentualProducto, null);
                }
            }
            else
            {
                if (!Validacion.EsVacio(txtUtilidadPorcentualProducto, miError, "El campo Utilidad es requerido."))
                {
                    if (Validacion.ConFormato
                        (Validacion.TipoValidacion.NumerosYPunto, txtUtilidadPorcentualProducto, miError, utilidadFormato))
                    {
                        utilidadMatch = true;
                    }
                    else
                        utilidadMatch = false;
                }
                else
                    utilidadMatch = false;
            }*/
        }


        private void cbIva_Enter(object sender, EventArgs e)
        {
            //cbIva.DroppedDown = true;
        }

        private void cbIva_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtValorVentaProducto.Focus();
            }
        }

        private void cbIva_SelectedIndexChanged(object sender, EventArgs e)
        {
            //txtUtilidadPorcentualProducto_KeyUp(this.txtUtilidadPorcentualProducto, null);
        }


        private void txtValorVentaProducto_KeyUp_copy(object sender, KeyEventArgs e)
        {
            /**
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIva.SelectedItem).PorcentajeIva;
                var venta = txtValorVentaProducto.Text;
                if (String.IsNullOrEmpty(venta))
                {
                    venta = "0";
                }
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(costo))
                {
                    costo = "0";
                }
                if (validacion.ValidarNumeroInt(venta))
                {
                    miError.SetError(txtValorVentaProducto, null);
                    var valorCosto = Convert.ToInt32(costo);
                    var valorVenta = Convert.ToInt32(venta);
                    var util = 0.0;
                    if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            valorCosto = Convert.ToInt32(valorCosto + (valorCosto * valorIva / 100));
                        }
                    }
                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                    {
                        // Retiro el IVA del precio de venta.
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            valorVenta = Convert.ToInt32((valorVenta / (1 + (valorIva / 100))));
                        }
                    }
                    else     // Utilidad despues de IVA.
                    {
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                        }
                    }
                    // Incremento de la Utilidad.
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                    {
                        // Costo x Util
                        util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                    }
                    else
                    {
                        var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                        util = 100 - (div * 100);
                    }
                    txtUtilidadPorcentualProducto.Text = Math.Round(util, 1).ToString().Replace(',', '.');
                    valorVentaMatch = true;

                    

                }
                else
                {
                    miError.SetError(txtValorVentaProducto, "El valor que ingreso es invalido.");
                    valorVentaMatch = false;
                }
            }
            catch (Exception ex)
            {
                miError.SetError(txtValorVentaProducto, "ERROR.\n" + ex.Message);
                //OptionPane.MessageError(ex.Message);
            }
            //this.txtUtilidadPorcentualProducto_KeyUp(txtUtilidadPorcentualProducto, null);

            */
        }

        private void txtValorVentaProducto_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIva.SelectedItem).PorcentajeIva;
                var venta = txtValorVentaProducto.Text;
                if (String.IsNullOrEmpty(venta))
                {
                    venta = "0";
                }
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(costo))
                {
                    costo = "0";
                }
                if (validacion.ValidarNumeroInt(venta))
                {
                    miError.SetError(txtValorVentaProducto, null);
                    var valorCosto = Convert.ToInt32(costo);
                    var valorVenta = Convert.ToInt32(venta);
                    var util = 0.0;
                    if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                    {
                        if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                        }
                    }
                    else
                    {
                        if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))//  Precio de Costo                                   (2)
                        {
                            valorCosto = Convert.ToInt32(valorCosto + (valorCosto * valorIva / 100));
                        }
                    }
                    if (!Convert.ToBoolean(AppConfiguracion.ValorSeccion("utilidad_mas_iva")))   // Utilidad antes de IVA.                       (3)
                    {
                        // Retiro el IVA del precio de venta.
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            valorVenta = Convert.ToInt32((valorVenta / (1 + (valorIva / 100))));
                        }
                    }
                    else     // Utilidad despues de IVA.
                    {
                        if (empresa.Regimen.IdRegimen.Equals(1))//  Regimen   (Comun)                                                          (1)
                        {
                            valorCosto = Convert.ToInt32((valorCosto / (1 + (valorIva / 100))));
                        }
                    }
                    // Incremento de la Utilidad.
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) // Incremento de Utilidad         (4)
                    {
                        // Costo x Util
                        util = Math.Round(Convert.ToDouble(((valorVenta - valorCosto) * 100) / valorCosto), 3);
                    }
                    else
                    {
                        var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(valorVenta), 3);
                        util = 100 - (div * 100);
                    }
                    txtUtilidadPorcentualProducto.Text = Math.Round(util, 1).ToString().Replace(',', '.');
                    valorVentaMatch = true;

                    /*if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //multiplica la utilidad
                    {
                        if (valorCosto != 0)
                        {
                            util = Math.Round(Convert.ToDouble(((pVentaNoIva - valorCosto) * 100) / valorCosto), 2);
                        }
                        else
                        {
                            util = 0;
                        }
                    }
                    else
                    {
                        var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(pVentaNoIva), 2);
                        util = 100 - (div * 100);
                    }*/

                }
                else
                {
                    miError.SetError(txtValorVentaProducto, "El valor que ingreso es invalido.");
                    valorVentaMatch = false;
                }
            }
            catch (Exception ex)
            {
                miError.SetError(txtValorVentaProducto, "ERROR.\n" + ex.Message);
                //OptionPane.MessageError(ex.Message);
            }
            //this.txtUtilidadPorcentualProducto_KeyUp(txtUtilidadPorcentualProducto, null);

            /*
            try
            {
                var valorIva = ((Iva)cbIva.SelectedItem).PorcentajeIva;
                var venta = txtValorVentaProducto.Text;
                if (String.IsNullOrEmpty(venta))
                {
                    venta = "0";
                }
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(costo))
                {
                    costo = "0";
                }
                if (validacion.ValidarNumeroInt(venta))
                {
                    miError.SetError(txtValorVentaProducto, null);
                    var valorVenta = Convert.ToInt32(venta);
                    var valorCosto = Convert.ToInt32(costo);
                    var pVentaNoIva = Convert.ToInt32(valorVenta / (1 + (valorIva / 100)));
                    var util = 0.0;
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("calculo_util_multiplica"))) //multiplica la utilidad
                    {
                        if (valorCosto != 0)
                        {
                            util = Math.Round(Convert.ToDouble(((pVentaNoIva - valorCosto) * 100) / valorCosto), 2);
                        }
                        else
                        {
                            util = 0;
                        }
                    }
                    else
                    {
                        var div = Math.Round(Convert.ToDouble(valorCosto) / Convert.ToDouble(pVentaNoIva), 2);
                        util = 100 - (div * 100);
                    }
                    txtUtilidadPorcentualProducto.Text = util.ToString();
                    valorVentaMatch = true;
                }
                else
                {
                    miError.SetError(txtValorVentaProducto, "El valor que ingreso es invalido.");
                    valorVentaMatch = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            */
        }

        private void txtValorVentaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                /**
                if (validacion.ValidarNumeroInt(txtValorVentaProducto.Text))
                {
                    miError.SetError(txtValorVentaProducto, null);
                    EditPrice(true, Convert.ToDouble(txtValorVentaProducto.Text.Replace('.', ',')));
                    valorVentaMatch = true;
                }
                else
                {
                    miError.SetError(txtValorVentaProducto, "El valor que ingreso es invalido.");
                    valorVentaMatch = false;
                }
                */
                chkCantDecimal.Focus();
            }
        }

        private void txtValorVentaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorVentaProducto, miError, valorVentaRequerido))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValorVentaProducto, miError, valorVentaFormato))
                {
                    valorVentaMatch = true;
                }
                else
                    valorVentaMatch = false;
            }
            else
                valorVentaMatch = false;
        }


        /// End Section price and coste  ************************************************************************

        private void rbtnUnidadMedida_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnUnidadMedida.Checked)
            {
                for (int i = 1; i < lstbTalla.Items.Count; i++)
                {
                    lstbTalla.SetSelected(i, false);
                }
                lstbTalla.Enabled = false;
                lbUnidadMedida.Enabled = true;
                lbValorMedida.Enabled = true;
                pMedidaColor.Visible = false;
            }
            LimpiarGridMedidaColor();
        }

        private void rbtnTalla_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTalla.Checked)
            {
                lstbTalla.Enabled = true;
                lbUnidadMedida.Enabled = false;
                lbValorMedida.Enabled = false;
                pMedidaColor.Visible = false;
            }
            LimpiarGridMedidaColor();
        }

        private void lbUnidadMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            int idUnidadMedida = Convert.ToInt32(this.lbUnidadMedida.SelectedValue);
            CargarValorUnidadMedida(idUnidadMedida);
            this.pMedidaColor.Visible = false;
            LimpiarGridMedidaColor();
        }

        private void lbValorMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            this.pMedidaColor.Visible = false;
            LimpiarGridMedidaColor();
        }

        private void lstbTalla_SelectedValueChanged(object sender, EventArgs e)
        {
            this.pMedidaColor.Visible = false;
            LimpiarGridMedidaColor();
        }

        private void btnOpcionColor_Click(object sender, EventArgs e)
        {
            this.pMedidaColor.Visible = true;
            lstMedida = new List<ValorUnidadMedida>();
            if (rbtnUnidadMedida.Checked)
            {
                medida = (ValorUnidadMedida)
                    this.lbValorMedida.SelectedItem;
                lstMedida.Add(medida);
            }
            else
            {
                foreach (DataRowView view in lstbTalla.SelectedItems)
                {
                    medida = new ValorUnidadMedida();
                    medida.IdValorUnidadMedida = (int)view.Row["idvalor_unidad_medida"];
                    medida.DescripcionValorUnidadMedida = (string)view.Row["descripcionvalor_unidad_medida"];
                    lstMedida.Add(medida);
                }
            }
            //lstMedida.Reverse();
            cbMedida.DataSource = lstMedida;
            cbMedida.Focus();
        }

        private void btnSelecionarColor_Click(object sender, EventArgs e)
        {
            this.gbSelecionarColor.Visible = true;
            CargarGridColor();
        }

        private void btnEliminarColor_Click(object sender, EventArgs e)
        {
            if (dgvMedidaColor.RowCount != 0)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro de eliminar el Color?",
                    "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    var idMedida = (int)dgvMedidaColor.CurrentRow.Cells["IdMedida"].Value;
                    var idColor = (int)dgvMedidaColor.CurrentRow.Cells["IdColor"].Value;
                    var query = from datos in miTabla.AsEnumerable()
                                where datos.Field<int>("IdMedida") == idMedida &&
                                      datos.Field<int>("IdColor") == idColor
                                select datos;
                    DataRow del = null;
                    foreach (DataRow row in query)
                    {
                        del = row;
                    }
                    miTabla.Rows.Remove(del);
                }
            }
            else
            {
                OptionPane.MessageInformation("No hay colores a eliminar.");
            }
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            ElColor miColor = new ElColor();
            miColorDialog = new ColorDialog();
            miColorDialog.AllowFullOpen = true;
            if (miColorDialog.ShowDialog() == DialogResult.OK)
            {
                if (!ExisteColor())
                {
                    miColor.MapaBits = ImagenComoString();
                    try
                    {
                        miBussinesColor.InsertarColor(miColor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    CargarGridColor();
                }
                else
                {
                    MessageBox.Show("El color seleccionado ya existe.", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnElegirColor_Click(object sender, EventArgs e)
        {
            listaColor = new List<ElColor>();
            foreach (DataGridViewRow row in this.dgvListaColor.SelectedRows)
            {
                color = new ElColor();
                color.IdColor = (int)row.Cells[0].Value;
                color.Imagen = (Image)row.Cells[1].Value;
                listaColor.Add(color);
            }
            CargarGridMedidaColor();
            this.gbSelecionarColor.Visible = false;
        }

        private void btnCancelarColor_Click(object sender, EventArgs e)
        {
            this.gbSelecionarColor.Visible = false;
        }

        private void menuGrid_Click(object sender, EventArgs e)
        {
            dgvMedidaColor.Rows.RemoveAt(this.dgvMedidaColor.CurrentCell.RowIndex);
            var t = miTabla.Rows.Count;
        }

        private void txtCodigoInternoProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCodigoInternoProducto, this.miError, codigoRequerido))
            {
                this.codigoMatch = this.ValidarCodigo(this.txtCodigoInternoProducto);
            }
            else
            {
                this.codigoMatch = false;
            }
           /* if (!Validacion.EsVacio(txtCodigoInternoProducto, miError, codigoRequerido))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.LetrasGuionNumeros, txtCodigoInternoProducto, miError, codigoFormato))
                {
                    if (ExisteCodigo(txtCodigoInternoProducto.Text))
                    {
                        codigoMatch = false;
                        miError.SetError(txtCodigoInternoProducto, codigoExiste);
                    }
                    else
                    {
                        codigoMatch = true;
                        miError.SetError(txtCodigoInternoProducto, null);
                    }
                }
                else
                    codigoMatch = false;
            }
            else
                codigoMatch = false;*/
        }

        private void txtCodigoBarrasProducto_Validating(object sender, CancelEventArgs e)
        {
            this.barraMatch = this.ValidarCodigo(this.txtCodigoBarrasProducto);
            //if (!Validacion.EsVacio(txtCodigoBarrasProducto, miError, "El codigo de barras es requerido."))
           /* if(!String.IsNullOrEmpty(this.txtCodigoBarrasProducto.Text))
            {
                if (Validacion.ConFormato
                  (Validacion.TipoValidacion.Numeros, txtCodigoBarrasProducto, miError, barraFormato))
                {
                    if (ExisteCodigo(txtCodigoBarrasProducto.Text))
                    {
                        barraMatch = false;
                        miError.SetError(txtCodigoBarrasProducto, barrasExiste);
                    }
                    else
                    {
                        barraMatch = true;
                        miError.SetError(txtCodigoBarrasProducto, null);
                    }
                }
                else
                    barraMatch = false;
            }
            else
                barraMatch = true;*/
        }

        private void txtReferencia_Validating(object sender, CancelEventArgs e)
        {
            /*if (!String.IsNullOrEmpty(txtReferencia.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.LetrasGuionNumeros, txtReferencia, miError, referenciaFormato))
                {
                    referenciaMatch = true;
                }
                else
                    referenciaMatch = false;
            }
            else
                referenciaMatch = true;*/
        }

        private void txtCodigo_2_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_2Match = this.ValidarCodigo(this.txtCodigo_2);
        }

        private void txtCodigo_3_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_3Match = this.ValidarCodigo(this.txtCodigo_3);
        }

        private void txtCodigo_4_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_4Match = this.ValidarCodigo(this.txtCodigo_4);
        }

        private void txtCodigo_5_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_5Match = this.ValidarCodigo(this.txtCodigo_5);
        }

        private void txtCodigo_6_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_6Match = this.ValidarCodigo(this.txtCodigo_6);
        }

        private void txtCodigo_7_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_7Match = this.ValidarCodigo(this.txtCodigo_7);
        }

        private bool ValidarCodigo(Control c)
        {
            var valida = true;
            if (!String.IsNullOrEmpty(c.Text))
            {
                if (this.ExisteCodigo(c.Text))
                {
                    this.miError.SetError(c, "El codigo ya existe.");
                    valida = false;
                }
                else
                {
                    this.miError.SetError(c, null);
                    valida = true;
                }
            }
            return valida;
        }

        private void txtNombreProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombreProducto, miError, nombreRequerido))
            {
                /*if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombreProducto, miError, nombreFormato))
                {*/
                    nombreMatch = true;
               /* }
                else
                    nombreMatch = false;*/
            }
            else
                nombreMatch = false;
        }

        private void txtDescripcionProducto_Validating(object sender, CancelEventArgs e)
        {
            if (cbCuentaContable.Items.Count > 1)
            {
                if (!String.IsNullOrEmpty(txtDescripcionProducto.Text))
                {
                    miError.SetError(cbCuentaContable, "");
                    descripcionMatch = true;
                }
                else
                {
                    descripcionMatch = false;
                    miError.SetError(cbCuentaContable, "Debe seleccionar una cuenta.");
                }
            }
            else
            {
                descripcionMatch = true;
            }
            ///if (!String.IsNullOrEmpty(txtDescripcionProducto.Text))
            ///{
                /*if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtDescripcionProducto, miError, descripcionFormato))
                {*/
                   /// descripcionMatch = true;
                /*}
                else
                    descripcionMatch = false;*/
            ///}
           /// else
              ///  descripcionMatch = true;
        }

        private void cbTipoInventarioProducto_Validating()
        {
            if (Convert.ToInt32(cbTipoInventario.SelectedValue).Equals(2))
            {
                //if (Convert.ToInt32(cbProdProceso.SelectedValue).Equals(1))
                if(cbProdProceso.SelectedValue.ToString().Equals(""))
                {
                    miError.SetError(cbProdProceso, "Debe seleccionar un producto como materia prima.");
                    productoInsumoMatch = false;
                }
                else
                {
                    miError.SetError(cbProdProceso, "");
                    productoInsumoMatch = true;
                }
            }
            else
            {
                productoInsumoMatch = true;
            }
        }

        

        

        

        private void txtUnidadVentaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUnidadVentaProducto.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtUnidadVentaProducto, miError, presentacionFormato))
                {
                    presentacionMatch = true;
                }
                else
                    presentacionMatch = false;
            }
            else
            {
                presentacionMatch = true;
            }
        }

        private void txtCantidadMinimaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantidadMinimaProducto.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCantidadMinimaProducto, miError, minimaFormato))
                {
                    minimaMatch = true;
                }
                else
                    minimaMatch = false;
            }
            else
                minimaMatch = true;
        }

        private void txtCntidadMaximaProducto_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantidadMaximaProducto.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCantidadMaximaProducto, miError, maximaFormato))
                {
                    maximaMatch = true;
                }
                else
                    maximaMatch = false;
            }
            else
                maximaMatch = true;
        }


        private void EditPrice(bool venta_, double valor)
        {
            try
            {
                PriceProduct p = new PriceProduct
                {
                    Costo = Convert.ToDouble(this.txtValorCosto.Text.Replace('.', ','))
                };
                if (venta_)
                {
                    p.Price = Convert.ToDouble(this.txtValorVentaProducto.Text.Replace('.', ','));
                    this.txtUtilidadPorcentualProducto.Text = PriceProduct.GetUtil(p).ToString().Replace(',', '.');
                }
                else
                {
                    p.Util = Convert.ToDouble(this.txtUtilidadPorcentualProducto.Text.Replace('.', ','));
                    this.txtValorVentaProducto.Text = PriceProduct.GetPrice(p).ToString();
                }
            }
            catch { }
            /*
            PriceProduct p = new PriceProduct
            {
                Costo = Convert.ToDouble(this.txtCostoConIvaP1.Text.Replace('.', ',')),
                Util = Convert.ToDouble(this.txtUtilidadP1.Text.Replace('.', ',')),
                Price = Convert.ToDouble(this.txtValorVentaP1.Text.Replace('.', ','))
            };

            if (venta_)
            {
                this.txtValorSugeridoP1.Text = valor.ToString();
                this.txtUtilidadP1.Text = PriceProduct.GetUtil(p).ToString().Replace(',', '.');
            }
            else
            {
                this.txtValorSugeridoP1.Text = PriceProduct.GetPrice(p).ToString();
            }
            */
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de Producto.
        /// </summary>
        /// <param name="codigo">Codigo a comprobar.</param>
        /// <returns></returns>
        private bool ExisteCodigo(string codigo)
        {
            try
            {
                return this.miBussinesProducto.ExisteCodigo(codigo);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Comprueba si el codigo existe en un registro de Producto.
        /// </summary>
        /// <param name="codigo">Codigo a comprobar.</param>
        /// <returns></returns>
        private bool ExisteCodigoBarras(string codigo)
        {
            try
            {
                return miBussinesProducto.ExisteCodigoBarras(codigo);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Proveedor", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private bool CodigoOString(string codigo)
        {
            var num = true;
            try
            {
                Convert.ToInt64(codigo);
                num = true;
            }
            catch (FormatException)
            {
                num = false;
            }
            return num;
        }

        private void CargarCategoria(string codigo)
        {
            try
            {
                var arrCategoria = miBussinesCategoria.consultaCategoriaCodigo(codigo);
                if (arrCategoria.Count > 0)
                {
                    var categoria = (DTO.Clases.Categoria)arrCategoria[0];
                    codigoCategoria = categoria.CodigoCategoria;
                    txtCodigoCategoria.Text = categoria.CodigoCategoria;
                    txtCategoria.Text = categoria.NombreCategoria;
                    txtCodigoMarca.Focus();
                }
                else
                {
                    OptionPane.MessageInformation("No existe Categoría con ese código.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void CargarMarca(string codigo)
        {
            try
            {
                var marca = miBussinesMarca.Marca(Convert.ToInt32(codigo));
                if (!marca.NombreMarca.Equals(""))
                {
                    idMarca = Convert.ToInt32(marca.IdMarca);
                    txtCodigoMarca.Text = marca.IdMarca.ToString();
                    txtNombreMarca.Text = Convert.ToString(marca.NombreMarca);
                    txtDescripcionProducto.Focus();
                }
                else
                {
                    OptionPane.MessageInformation("No existe Marca con ese código.");
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Crea un directorio para la pertinencia temporal de archivos.
        /// </summary>
        private void CrearDirectorio()
        {
            try
            {
                if (!System.IO.Directory.Exists(folder))
                {
                    System.IO.Directory.CreateDirectory(folder);
                    System.IO.File.SetAttributes
                        (folder, System.IO.FileAttributes.Hidden);
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Cargar el DataGridView con la lista de colores.
        /// </summary>
        private void CargarGridColor()
        {
            this.dgvListaColor.AutoGenerateColumns = false;
            try
            {
                this.dgvListaColor.DataSource = miBussinesColor.ListadoDeColores();
            }
            catch (Exception ex)
            {
                MessageBox.Show
                    (ex.Message, "Producto", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Valida si un color existe en la base de datos.
        /// </summary>
        /// <returns></returns>
        private bool ExisteColor()
        {
            AlmacenarImagen();
            string stringColor = ImagenComoString();
            try
            {
                return miBussinesColor.ExisteColor(stringColor);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Almacena el color seleccionado como una imagen en un archivo y carpeta temporal.
        /// </summary>
        private void AlmacenarImagen()
        {
            pbColor.Image = new Bitmap(pbColor.Width, pbColor.Height);
            Graphics grafico = Graphics.FromImage(pbColor.Image);
            grafico.Clear(miColorDialog.Color);
            pbColor.Refresh();
            Rectangle r = new Rectangle(new Point(0, 0),
                new Size(pbColor.Width - 1, pbColor.Height - 1));
            grafico.DrawRectangle(new Pen(System.Drawing.Color.Black, 1), r);
            pbColor.Refresh();
            pbColor.Image.Save(rutaYArchivo, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        /// <summary>
        /// Obtiene un string Base64 que representa el mapa de bits del color, de la imagen almacenada.
        /// </summary>
        /// <returns></returns>
        private string ImagenComoString()
        {
            string sBase64 = "";
            System.IO.FileStream fs = new System.IO.FileStream
                            (rutaYArchivo, System.IO.FileMode.Open);
            System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
            byte[] bytes = new byte[(int)fs.Length];
            try
            {
                br.Read(bytes, 0, bytes.Length);
                sBase64 = Convert.ToBase64String(bytes);
                return sBase64;
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al cargar el Color. ", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                fs.Close();
                fs = null;
                br = null;
                bytes = null;
            }
        }

        /// <summary>
        /// Crea las columnas para la tabla (miTabla)
        /// </summary>
        private void CrearTabla()
        {
            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
        }

        private void CargarDescuentosYrecargos()
        {
            try
            {
                this.lbDescuento.DataSource = miBussinesDescuento.ListadoDescuento();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            try
            {
                this.lbRecargo.DataSource = miBussinesRecargo.ListadoRecargo();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Cargar el comboBox con las medidas seleccionadas por el usuario.
        /// </summary>
        private void CargarGridMedidaColor()
        {
            ValorUnidadMedida medida = (ValorUnidadMedida)
                this.cbMedida.SelectedItem;
            foreach (ElColor color in listaColor)
            {
                DataRow row = miTabla.NewRow();
                row["IdMedida"] = medida.IdValorUnidadMedida;
                row["IdColor"] = color.IdColor;
                row["Medida"] = medida.DescripcionValorUnidadMedida;
                row["Color"] = color.Imagen;
                miTabla.Rows.Add(row);
            }
            this.dgvMedidaColor.DataSource = miTabla;
        }

        /// <summary>
        /// Remueve todos los registros de medida y color en el grid.
        /// </summary>
        private void LimpiarGridMedidaColor()
        {
            if (dgvMedidaColor.RowCount != 0)
            {
                var length = dgvMedidaColor.RowCount;
                for (int i = 0; i < length; i++)
                {
                    dgvMedidaColor.Rows.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// Valida de nuevo todos los campos del formulario.
        /// </summary>
        private void ValidacionGuardar()
        {
            this.txtCodigoInternoProducto_Validating(null, null);
            this.txtCodigoBarrasProducto_Validating(null, null);
            this.txtCodigo_2_Validating(this.txtCodigo_2, new CancelEventArgs(false));
            this.txtCodigo_3_Validating(this.txtCodigo_3, new CancelEventArgs(false));
            this.txtCodigo_4_Validating(this.txtCodigo_4, new CancelEventArgs(false));
            this.txtCodigo_5_Validating(this.txtCodigo_5, new CancelEventArgs(false));
            this.txtCodigo_6_Validating(this.txtCodigo_6, new CancelEventArgs(false));
            this.txtCodigo_7_Validating(this.txtCodigo_7, new CancelEventArgs(false));
            this.txtReferencia_Validating(null, null);
            this.txtNombreProducto_Validating(null, null);
            this.txtDescripcionProducto_Validating(null, null);
            this.cbTipoInventarioProducto_Validating();
            this.txtUtilidadPorcentualProducto_Validating(null, null);
            this.txtValorVentaProducto_Validating(null, null);
            this.txtDesctoMayor_Validating(this.txtDesctoMayor, new CancelEventArgs(false));
            this.txtDesctoDistribuidor_Validating(this.txtDesctoDistribuidor, new CancelEventArgs(false));
            this.txtDesctoPrecio4_Validating(this.txtDesctoPrecio4, new CancelEventArgs(false));

            this.txtUnidadVentaProducto_Validating(null, null);
            this.txtCantidadMinimaProducto_Validating(null, null);
            this.txtCntidadMaximaProducto_Validating(null, null);
        }

        /// <summary>
        /// Cargar un objeto Producto con los datos del formulario.
        /// </summary>
        private void CargarProducto()
        {
            try
            {
                this.miProducto = new DTO.Clases.Producto();
                this.miProducto.CodigoInternoProducto = txtCodigoInternoProducto.Text;
                this.miProducto.CodigoBarrasProducto = txtCodigoBarrasProducto.Text;
                this.miProducto.Codigo_2 = this.txtCodigo_2.Text;
                this.miProducto.Codigo_3 = this.txtCodigo_3.Text;
                this.miProducto.Codigo_4 = this.txtCodigo_4.Text;
                this.miProducto.Codigo_5 = this.txtCodigo_5.Text;
                this.miProducto.Codigo_6 = this.txtCodigo_6.Text;
                this.miProducto.Codigo_7 = this.txtCodigo_7.Text;
                this.miProducto.ReferenciaProducto = txtReferencia.Text.ToUpper();
                this.miProducto.NombreProducto = txtNombreProducto.Text.ToUpper();
                this.miProducto.DescripcionProducto = txtDescripcionProducto.Text;
                this.miProducto.CodigoCategoria = codigoCategoria;
                this.miProducto.IdMarca = idMarca;
                this.miProducto.IdTipoInventario = Convert.ToInt32(cbTipoInventario.SelectedValue);

                if (miProducto.IdTipoInventario.Equals(2))
                {
                    this.miProducto.CodProductoProceso = cbProdProceso.SelectedValue.ToString();
                }
                
                if (!String.IsNullOrEmpty(this.txtUtilidadPorcentualProducto.Text))
                {
                    this.miProducto.Utilidad2 = miProducto.Utilidad3 =
                    this.miProducto.UtilidadPorcentualProducto = Convert.ToDouble(txtUtilidadPorcentualProducto.Text.Replace('.', ','));
                }
                if (!String.IsNullOrEmpty(txtValorVentaProducto.Text))
                    this.miProducto.ValorVentaProducto = Convert.ToInt32(txtValorVentaProducto.Text);

                if (!String.IsNullOrEmpty(txtValorCosto.Text))
                {
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva"))) //TRUE indica q el costo si incluye iva
                    {
                        this.miProducto.ValorCosto = Convert.ToInt32(
                            Convert.ToInt32(txtValorCosto.Text) / (1 + (((Iva)cbIva.SelectedItem).PorcentajeIva / 100)));
                    }
                    else
                    {
                        this.miProducto.ValorCosto = Convert.ToInt32(txtValorCosto.Text);
                        //miProducto.ValorCosto = Convert.ToInt32(txtValorCosto.Text) +
                        //(Convert.ToInt32(txtValorCosto.Text) * ((Iva)cbIva.SelectedItem).PorcentajeIva / 100);
                    }
                }

                if (Convert.ToInt32(cbAplicarPrecio.SelectedValue) == 1)
                {
                    this.miProducto.AplicaPrecioPorcentaje = false;
                }
                this.miProducto.IdIva = Convert.ToInt32(cbIva.SelectedValue);

                if (!String.IsNullOrEmpty(txtDesctoMayor.Text))
                    this.miProducto.DescuentoMayor = Convert.ToDouble(txtDesctoMayor.Text.Replace('.', ','));

                if (!String.IsNullOrEmpty(txtDesctoDistribuidor.Text))
                    this.miProducto.DescuentoDistribuidor = Convert.ToDouble(txtDesctoDistribuidor.Text.Replace('.', ','));

                if (!String.IsNullOrEmpty(this.txtDesctoPrecio4.Text))
                {
                    this.miProducto.DescuentoPrecio4 = Convert.ToDouble(this.txtDesctoPrecio4.Text.Replace('.', ','));
                }

                if (!String.IsNullOrEmpty(txtUnidadVentaProducto.Text))
                    this.miProducto.UnidadVentaProducto = Convert.ToInt32(txtUnidadVentaProducto.Text);

                if (!String.IsNullOrEmpty(txtCantidadMinimaProducto.Text))
                    this.miProducto.CantidadMinimaProducto = Convert.ToInt32(txtCantidadMinimaProducto.Text);

                if (!String.IsNullOrEmpty(txtCantidadMaximaProducto.Text))
                    this.miProducto.CantidadMaximaProducto = Convert.ToInt32(txtCantidadMaximaProducto.Text);

                if (chkCantDecimal.Checked)
                {
                    miProducto.CantidadDecimal = true;
                }
                CargarDescuentos();
                CargarRecargos();

                if (miTabla.Rows.Count != 0)
                {
                    this.miProducto.AplicaColor = true;
                    CargarInventariosDeTabla();
                }
                else
                {
                    this.miProducto.AplicaColor = false;
                    CargarInventarios();
                }
                if (rbtnTalla.Checked)
                    this.miProducto.AplicaTalla = true;
                else
                    this.miProducto.AplicaTalla = false;
                CargarMedidas();
                this.miProducto.Descuentos = listaDescuentos;
                this.miProducto.Recargos = listaRecargos;
                this.miProducto.Medidas = medidas;
                this.miProducto.Inventarios = inventarios;

                this.miProducto.IdIvaTemp = miProducto.IdIva;

                this.miProducto.IdIco = Convert.ToInt32(cbValorICO.SelectedValue);
                this.miProducto.AplicaIco = Convert.ToBoolean(cbAplicaICO.SelectedValue);
                this.miProducto.Imprime = Convert.ToBoolean(cbImprime.SelectedValue);
                this.miProducto.AplicaDescto = Convert.ToBoolean(cbAplicaDescuento.SelectedValue);

            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario restableciendolo.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCodigoInternoProducto.Text = "";
            this.txtCodigoBarrasProducto.Text = "";
            this.txtCodigo_2.Text = "";
            this.txtCodigo_3.Text = "";
            this.txtCodigo_4.Text = "";
            this.txtCodigo_5.Text = "";
            this.txtCodigo_6.Text = "";
            this.txtCodigo_7.Text = "";
            this.txtReferencia.Text = "";
            this.txtNombreProducto.Text = "";
            this.txtDescripcionProducto.Text = "";
            this.codigoCategoria = "";
            this.txtCategoria.Text = "";
            this.txtCodigoCategoria.Text = "";
            this.idMarca = 0;
            this.txtNombreMarca.Text = "";
            this.txtCodigoMarca.Text = "";
            this.txtValorCosto.Text = "";
            this.txtUtilidadPorcentualProducto.Text = "";
            this.txtValorVentaProducto.Text = "";
            this.txtDesctoMayor.Text = "";
            this.txtDesctoDistribuidor.Text = "";
            this.txtValorDesctoMayor.Text = "";
            this.txtValorDesctoDistrib.Text = "";
            this.txtUnidadVentaProducto.Text = "";
            this.txtCantidadMinimaProducto.Text = "";
            this.txtCantidadMaximaProducto.Text = "";
            this.lbUnidadMedida.SetSelected(0, true);

            this.cbValorICO.SelectedIndex = 0;
            this.cbAplicaICO.SelectedIndex = 0;
            this.cbImprime.SelectedIndex = 0;
            this.cbAplicaDescuento.SelectedIndex = 0;



         //   lbDescuento.SetSelected(0, true);
            for(int i = 1; i < lbDescuento.Items.Count; i++)
            {
                lbDescuento.SetSelected(i, false);
            }
           // lbRecargo.SetSelected(0, true);
            for (int i = 1; i < lbRecargo.Items.Count; i++)
            {
                lbRecargo.SetSelected(i, false);
            }
            if (lstbTalla.Items.Count != 0)
            {
                lstbTalla.SetSelected(0, true);
            }
            for (int i = 1; i < lstbTalla.Items.Count; i++)
            {
                lstbTalla.SetSelected(i, false);
            }
            miTabla.Rows.Clear();
            listaDescuentos.Clear();
            listaRecargos.Clear();
            medidas.Clear();
            inventarios.Clear();
            pMedidaColor.Visible = false;
            if (!this.IdMedidaConfigurada.Equals(0))
            {
                this.lbUnidadMedida.SelectedValue = this.IdMedidaConfigurada;
            }
            this.cbIva.SelectedIndex = 0;

            cbCuentaContable.SelectedIndex = 0;
            cbTipoInventario.SelectedIndex = 0;
            cbProdProceso.SelectedIndex = 0;
            txtUnidadVentaProducto.Text = "1";
        }

        #endregion

        #region Consultas Producto

        private void tsbBuscarProducto_Click(object sender, EventArgs e)
        {
            //miDelegado delegado = new miDelegado(ListarTodos);
            //this.Invoke(delegado);
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 1;
            try
            {
                dgvConsultaProducto.AutoGenerateColumns = false;
                dgvConsultaProducto.DataSource = miBussinesProducto.ListarProductos
                    (rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsListarProductos();
                MostrarColumnasDataGrid(true, false, false, false);
                ComboBoxColumnMedida();
                BtnSearch = 1;
                if (dgvConsultaProducto.RowCount.Equals(0))
                {
                    MessageBox.Show("No se encontraron registros en la consulta. ", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    this.dgvConsultaProducto.Focus();
                }
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
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        private void tsbtnCodigo_Click(object sender, EventArgs e)
        {
            this.gBCodigos.Enabled = true;
            this.gbBusquedaporCategoria.Enabled = false;
            this.gbBusquedaReferencia.Enabled = false;
            this.btnBuscarporCodigos.Enabled = true;
            BusquedaCombinada = false;
            MostrarColumnasDataGrid(true, false, false, false);
        }

        private void tsbBuscarPorCategoria_Click(object sender, EventArgs e)
        {
            this.gbBusquedaporCategoria.Enabled = true;
            this.gBCodigos.Enabled = false;
            this.gbBusquedaReferencia.Enabled = false;
            BusquedaCombinada = false;
            MostrarColumnasDataGrid(true, false, false, false);
        }

        private void tsbBuscarporMarca_Click(object sender, EventArgs e)
        {
            this.gbBusquedaReferencia.Enabled = true;
            this.gBCodigos.Enabled = true;
            this.gbBusquedaporCategoria.Enabled = false;
            this.btnBuscarporCodigos.Enabled = false;
            this.cbConsulta1.Enabled = false;
            BusquedaCombinada = true;
            if (!EnableColor)
            {
                //lblIncluir.Enabled = false;
                //lblIncluirColor.Enabled = false;
                cbIncluirColor.Enabled = false;
            }
            btnSearchMarca.Enabled = false;
            cbBusquedaCombinada.SelectedIndex = 0;
            cbBusquedaCombinada1.Enabled = false;
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsBtnSeleccionar_Click(object sender, EventArgs e)
        {
            dgvConsultaProducto_CellDoubleClick(null, null);
        }

        private void tsbVerDetalle_Click(object sender, EventArgs e)
        {
            if (dgvConsultaProducto.RowCount != 0)
            {
                frmDetalleProducto detalle = new frmDetalleProducto();
                detalle.MdiParent = this.MdiParent;
                detalle.CodigoProducto = (string)dgvConsultaProducto.CurrentRow.Cells[1].Value;
                detalle.Show();
            }
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvConsultaProducto.RowCount != 0)
            {
               // if (!FormEditOpen)
                //{
                    frmEditarProducto FrmEditarProducto = new frmEditarProducto();
                    FrmEditarProducto.MdiParent = this.MdiParent;
                    FrmEditarProducto.CodigoProducto = (string)dgvConsultaProducto.CurrentRow.Cells[1].Value;
                    FrmEditarProducto.Show();
                    FormEditOpen = true;
                //}
            }
        }

        private void tsBtnImprimir_Click(object sender, EventArgs e)
        {
            try
            {
                var frmPrintInforme = new FrmInformeProducto();
                frmPrintInforme.ReportPath = AppConfiguracion.ValorSeccion("report") + @"\reports\InformeProductos.rdlc";
                ///frmPrintInforme.ReportPath = @"c:\reports\InformeProductos.rdlc";
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                {
                    frmPrintInforme.AddIva = "El precio de costo incluye IVA.";
                }
                else
                {
                    frmPrintInforme.AddIva = "El precio de costo no incluye IVA.";
                }
                frmPrintInforme.Tabla =
                    miBussinesProducto.ImprimirProductos(Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")));
                frmPrintInforme.Total = frmPrintInforme.Tabla.Rows.Count.ToString();
                frmPrintInforme.ShowDialog();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de eliminar el Producto?",
                "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                if (dgvConsultaProducto.RowCount != 0)
                {
                    var codigo = Convert.ToString(dgvConsultaProducto.CurrentRow.Cells[1].Value);
                    try
                    {
                        miBussinesProducto.EliminarProducto(codigo);
                        OptionPane.MessageInformation("El Producto se ha eliminado con exito.");
                        switch (BtnSearch)
                        {
                            case 1:
                                {
                                    tsbBuscarProducto_Click(this.tsbBuscarProducto, new EventArgs());
                                    break;
                                }
                            case 2:
                                {
                                    btnBuscarporCodigos_Click(this.btnBuscarporCodigos, new EventArgs());
                                    break;
                                }
                            case 3:
                                {
                                    btnBusquedaCombinada_Click(this.btnBusquedaCombinada, new EventArgs());
                                    break;
                                }
                            case 4:
                                {
                                    btnBuscarCategoria_Click(this.btnBuscarCategoria, new EventArgs());
                                    break;
                                }
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void cbConsulta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbConsulta.SelectedValue) == 2)
            {
                this.cbConsulta1.SelectedIndex = 1;
                this.cbConsulta1.Enabled = true;
            }
            else
            {
                this.cbConsulta1.SelectedIndex = 0;
                this.cbConsulta1.Enabled = false;
            }
            txtConsulta.Focus();
        }

        private void cbConsulta1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtConsulta.Focus();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter) && !BusquedaCombinada)
                btnBuscarporCodigos_Click(null, null);
        }

        private void btnBuscarporCodigos_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtConsulta.Text))
            {
                int criterio = Convert.ToInt32(cbConsulta.SelectedValue);
                int criterio1 = Convert.ToInt32(cbConsulta1.SelectedValue);
                dgvConsultaProducto.AutoGenerateColumns = false;

                if (criterio == 1)
                {
                    ConsultaPorCodigo(txtConsulta.Text);
                }
                else
                {
                    if (criterio == 2 && criterio1 == 1)
                    {
                        ConsultaNombre(txtConsulta.Text);
                    }
                    else
                    {
                        if (criterio == 2 && criterio1 == 2)
                        {
                            NombreProducto = txtConsulta.Text;
                            FiltroNombre(NombreProducto);
                        }
                    }
                }
                BtnSearch = 2;
                if (this.dgvConsultaProducto.RowCount != 0)
                {
                    ComboBoxColumnMedida();
                //    AjustarCeldasGrid();
                }
                else
                    MessageBox.Show("No se encontraron registros en la consulta. ", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("El campo de busqueda es requerido. ", "Producto",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cbConsutlaCategoria_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbConsutlaCategoria.SelectedValue) == 2)
            {
                cbConsutlaCategoria1.SelectedIndex = 1;
                this.cbConsutlaCategoria1.Enabled = true;
            }
            else
            {
                this.cbConsutlaCategoria1.SelectedIndex = 0;
                this.cbConsutlaCategoria1.Enabled = false;
            }
        }

        private void txtBuscarporCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                if (!String.IsNullOrEmpty(txtBuscarporCategoria.Text))
                {
                    int criterio = Convert.ToInt32(this.cbConsutlaCategoria.SelectedValue);
                    int criterio1 = Convert.ToInt32(this.cbConsutlaCategoria1.SelectedValue);
                    dgvConsultaProducto.AutoGenerateColumns = false;
                    if (criterio == 1 && criterio1 == 1)
                    {
                        codigoCategoria = txtBuscarporCategoria.Text;
                        ConsultaPorCodigoCategoria(codigoCategoria);
                    }

                    if (criterio == 2 && criterio1 == 1)
                    {
                        NombreCategoria = txtBuscarporCategoria.Text;
                        ConsultaPorNombreCategoria(NombreCategoria);
                    }

                    if (criterio == 2 && criterio1 == 2)
                    {
                        NombreCategoria = txtBuscarporCategoria.Text;
                        FiltroPorNombreCategoria(NombreCategoria);
                    }

                    if (this.dgvConsultaProducto.RowCount == 0)
                    {
                        //AjustarCeldasGrid();
                        MessageBox.Show("No se encontraron registros en la consulta. ", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                    MessageBox.Show("El campo de busqueda es requerido. ", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscarporCategoria_Click(object sender, EventArgs e)
        {
            frmMiCategoria = new Categoria.FrmCategoria();
            frmMiCategoria.TblCategoria.SelectTab(1);
            frmMiCategoria.CargarGridCategorias();
            frmMiCategoria.Extencion = true;
            frmMiCategoria.Show();
            SearchCategoria = true;
        }

        private void cbBusquedaCombinada_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(cbBusquedaCombinada.SelectedValue);
            if (id == 1)
            {
                cbBusquedaCombinada1.DataSource = miConsultaCombinada.lista1;
                this.txtTalla.Enabled = false;
                btnSearchMarca.Enabled = false;
                cbBusquedaCombinada1.Enabled = false;
            }
            if (id == 2)
            {
                cbBusquedaCombinada1.DataSource = miConsultaCombinada.lista3;
                cbBusquedaCombinada1_SelectionChangeCommitted(null, null);
                btnSearchMarca.Enabled = true;
                cbBusquedaCombinada1.Enabled = true;
            }
            if (id == 3)
            {
                cbBusquedaCombinada1.DataSource = miConsultaCombinada.lista2;
                this.txtTalla.Enabled = false;
                btnSearchMarca.Enabled = false;
                cbBusquedaCombinada1.Enabled = false;
            }
            txtBusquedaNombreMarca.Focus();
        }

        private void cbBusquedaCombinada1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.cbBusquedaCombinada1.SelectedValue);

            if (id == 2)
            {
                this.txtTalla.Enabled = true;
            }
            else
                this.txtTalla.Enabled = false;
            txtBusquedaNombreMarca.Focus();
        }

        private void txtBusquedaNombreMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtBusquedaNombreMarca.Text))
                {
                    btnBusquedaCombinada_Click(null, null);
                }
                else
                {
                    MessageBox.Show("El campo de busqueda es requerido. ", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtBusquedaNombreMarca.Focus();
                }
            }
        }

        private void txtTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var criterio = Convert.ToInt32(cbBusquedaCombinada.SelectedValue);
                var criterio1 = Convert.ToInt32(cbBusquedaCombinada1.SelectedValue);
                if (criterio == 2 && criterio1 == 2)
                {
                    if (!String.IsNullOrEmpty(txtBusquedaNombreMarca.Text))
                    {
                        if (!String.IsNullOrEmpty(txtTalla.Text))
                        {
                            btnBusquedaCombinada_Click(null, null);
                            txtTalla.Focus();
                        }
                        else
                        {
                            OptionPane.MessageInformation("El campo de busqueda es requerido. ");
                            txtTalla.Focus();
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El campo de busqueda es requerido. ");
                        txtBusquedaNombreMarca.Focus();
                    }
                }
            }
        }

        private void btnSearchMarca_Click(object sender, EventArgs e)
        {
            Configuracion.Marcas.frmMarca frmMarca = new Configuracion.Marcas.frmMarca();
            frmMarca.CargaGrillaMarca();
            frmMarca.Extension = true;
            SearchMarca = true;
            frmMarca.Show();
        }

        private void btnBusquedaCombinada_Click(object sender, EventArgs e)
        {
            int criterioProducto = Convert.ToInt32(this.cbConsulta.SelectedValue);
            //int criterioProducto1 = Convert.ToInt32(this.cbConsulta1.SelectedValue);
            int criterio = Convert.ToInt32(this.cbBusquedaCombinada.SelectedValue);
            int criterio1 = Convert.ToInt32(this.cbBusquedaCombinada1.SelectedValue);
            dgvConsultaProducto.AutoGenerateColumns = false;
            BtnSearch = 3;
            if (criterio == 1)
            {
                if (!String.IsNullOrEmpty(txtBusquedaNombreMarca.Text))
                {
                    if (!String.IsNullOrEmpty(txtConsulta.Text))
                    {
                        if (criterioProducto == 1)
                        {
                            ConsultaProductoConReferencia
                                (txtConsulta.Text, null, txtBusquedaNombreMarca.Text, true);
                        }
                        else
                        {
                            ConsultaProductoConReferencia
                                (null, txtConsulta.Text, txtBusquedaNombreMarca.Text, false);
                        }
                    }
                    else
                        ConsultaPorReferencia(txtBusquedaNombreMarca.Text);

                   
                }
                else
                {
                    MessageBox.Show("El campo de busqueda es requerido.", "Producto",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (criterio == 2 && criterio1 == 1)//consulta marca
                {
                    if (!String.IsNullOrEmpty(txtBusquedaNombreMarca.Text))
                    {
                        if (!String.IsNullOrEmpty(txtConsulta.Text))
                        {
                            if (criterioProducto == 1)
                            {
                                //con codigo de producto
                                ConsultaProductoConMarca
                                    (txtConsulta.Text, null, txtBusquedaNombreMarca.Text, null, true, false);
                            }
                            else
                            {
                                ///con nombre de producto
                                ConsultaProductoConMarca
                                    (null, txtConsulta.Text, txtBusquedaNombreMarca.Text, null, false, false);
                            }
                        }
                        else
                        {
                            //sin producto
                            ConsultaPorMarca(txtBusquedaNombreMarca.Text, null, false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("El campo de busqueda es requerido.", "Producto",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (criterio == 2 && criterio1 == 2) //consulta marca con talla
                    {
                        if (!String.IsNullOrEmpty(txtBusquedaNombreMarca.Text) && !String.IsNullOrEmpty(txtTalla.Text))
                        {
                            if (!String.IsNullOrEmpty(txtConsulta.Text))//consulta con producto
                            {
                                if (criterioProducto == 1)//con codigo de producto
                                {
                                    ConsultaProductoConMarca
                                        (txtConsulta.Text, null, txtBusquedaNombreMarca.Text, txtTalla.Text, true, true);
                                }
                                else
                                {
                                    ConsultaProductoConMarca
                                        (null, txtConsulta.Text, txtBusquedaNombreMarca.Text, txtTalla.Text, false, true);
                                }
                            }
                            else//consulta sin producto
                            {
                                ConsultaPorMarca(txtBusquedaNombreMarca.Text, txtTalla.Text, true);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Los campos de busqueda es requerido.", "Producto",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else//consulta por talla
                    {
                        if (!String.IsNullOrEmpty(txtConsulta.Text))//consulta talla con producto
                        {
                            if (criterioProducto == 1)//con codigo producto
                            {
                                ConsultaProductoConTalla
                                    (txtConsulta.Text, null, txtBusquedaNombreMarca.Text, true, true, cbIncluirColor.Checked);
                            }
                            else//con nombre
                            {
                                ConsultaProductoConTalla
                                    (null, txtConsulta.Text, txtBusquedaNombreMarca.Text, true, false, cbIncluirColor.Checked);
                            }
                        }
                        else//consulta talla sola
                        {
                            ConsultaProductoConTalla
                                (null, null, txtBusquedaNombreMarca.Text, false, false, cbIncluirColor.Checked);
                        }
                    }
                }
            }
            if (dgvConsultaProducto.RowCount.Equals(0))
            {
                MessageBox.Show("No se encontraron registros en la consulta. ", "Producto",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            /*if (criterio == 1)
            {
                //ConsultaPorReferencia(txtBusquedaNombreMarca.Text);
            }
            if (criterio == 2 && criterio1 == 2)
            {
                //ConsultaPorMarca(txtBusquedaNombreMarca.Text);
            }*/


            /**BussinesProducto mibussinesproducto = new BussinesProducto();
            try
            {

                string nombremarca = txtBusquedaNombreMarca.Text;
                dgvConsultaProducto.Visible = true;
                this.dgvConsultaProducto.AutoGenerateColumns = false;
                dgvConsultaProducto.DataSource = null;
                dgvConsultaProducto.DataSource = mibussinesproducto.ListarProductosMarca(nombremarca);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void dgvConsultaProducto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewComboBoxCell cell = (DataGridViewComboBoxCell)
                    dgvConsultaProducto.Rows[e.RowIndex].Cells[e.ColumnIndex];
                dgvConsultaProducto.EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            }
            catch
            {
                dgvConsultaProducto.EditMode = DataGridViewEditMode.EditProgrammatically;
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
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
                    if (iteracion == 1)
                    {
                        dgvConsultaProducto.DataSource = miBussinesProducto.ListarProductos
                                                        (rowProducto, rowMaxProducto);
                    }
                    else
                    {
                        if (iteracion == 2)
                        {
                            dgvConsultaProducto.DataSource = miBussinesProducto.FiltroNombre
                                        (NombreProducto, rowProducto, rowMaxProducto);
                        }
                        else
                        {
                            if (iteracion == 3)
                            {
                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorCodigoCategoria
                                            (codigoCategoria, rowProducto, rowMaxProducto);
                            }
                            else
                            {
                                if (iteracion == 4)
                                {
                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                                (NombreCategoria, rowProducto, rowMaxProducto, false);
                                }
                                else
                                {
                                    if (iteracion == 5)
                                    {
                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                                    (NombreCategoria, rowProducto, rowMaxProducto, true);
                                    }
                                    else
                                    {
                                        if (iteracion == 6)
                                        {
                                            dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorReferencia
                                                (SearchReferencia, rowProducto, rowMaxProducto, ColorChecked);
                                        }
                                        else
                                        {
                                            if (iteracion == 7)
                                            {
                                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoConReferencia
                                                    (CodigoProducto, NombreProducto, SearchReferencia, Code, ColorChecked, rowProducto, rowMaxProducto);
                                            }
                                            else
                                            {
                                                if (iteracion == 8)
                                                {
                                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                }
                                                else
                                                {
                                                    if (iteracion == 9)
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                    }
                                                    else
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorTalla
                                                        (CodigoProducto, NombreProducto, Talla, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
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
                ComboBoxColumnMedida();
                lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            ///Retrocede a la pagina anterior de la actual.
            if (currentPageProducto > 1)
            {
                try
                {
                    rowProducto = rowProducto - rowMaxProducto;
                    if (rowProducto <= 0)
                        rowProducto = 0;
                    if (iteracion == 1)
                    {
                        dgvConsultaProducto.DataSource = miBussinesProducto.ListarProductos
                            (rowProducto, rowMaxProducto);
                    }
                    else
                    {
                        if (iteracion == 2)
                        {
                            dgvConsultaProducto.DataSource = miBussinesProducto.FiltroNombre
                                 (NombreProducto, rowProducto, rowMaxProducto);
                        }
                        else
                        {
                            if (iteracion == 3)
                            {
                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorCodigoCategoria
                                (codigoCategoria, rowProducto, rowMaxProducto);
                            }
                            else
                            {
                                if (iteracion == 4)
                                {
                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                    (NombreCategoria, rowProducto, rowMaxProducto, false);
                                }
                                else
                                {
                                    if (iteracion == 5)
                                    {
                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                        (NombreCategoria, rowProducto, rowMaxProducto, true);
                                    }
                                    else
                                    {
                                        if (iteracion == 6)
                                        {
                                            dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorReferencia
                                                (SearchReferencia, rowProducto, rowMaxProducto, ColorChecked);
                                        }
                                        else
                                        {
                                            if (iteracion == 7)
                                            {
                                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoConReferencia
                                                (CodigoProducto, NombreProducto, SearchReferencia, Code, ColorChecked, rowProducto, rowMaxProducto);
                                            }
                                            else
                                            {
                                                if (iteracion == 8)
                                                {
                                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                    (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                }
                                                else
                                                {
                                                    if (iteracion == 9)
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                    }
                                                    else
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorTalla
                                                        (CodigoProducto, NombreProducto, Talla, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
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
                ComboBoxColumnMedida();
                currentPageProducto--;
                lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            ///Avanza a la pagina siguiente de la actual
            if (currentPageProducto < paginasProducto)
            {
                rowProducto = rowProducto + rowMaxProducto;
                try
                {
                    if (iteracion == 1)
                    {
                        dgvConsultaProducto.DataSource = miBussinesProducto.ListarProductos
                                                        (rowProducto, rowMaxProducto);
                        //ComboBoxColumnMedida();
                    }
                    else
                    {
                        if (iteracion == 2)
                        {
                            dgvConsultaProducto.DataSource = miBussinesProducto.FiltroNombre
                                        (NombreProducto, rowProducto, rowMaxProducto);
                        }
                        else
                        {
                            if (iteracion == 3)
                            {
                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorCodigoCategoria
                                            (codigoCategoria, rowProducto, rowMaxProducto);
                            }
                            else
                            {
                                if (iteracion == 4)
                                {
                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                                (NombreCategoria, rowProducto, rowMaxProducto, false);
                                }
                                else
                                {
                                    if (iteracion == 5)
                                    {
                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                                    (NombreCategoria, rowProducto, rowMaxProducto, true);
                                    }
                                    else
                                    {
                                        if (iteracion == 6)
                                        {
                                            dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorReferencia
                                                (SearchReferencia, rowProducto, rowMaxProducto, ColorChecked);
                                        }
                                        else
                                        {
                                            if (iteracion == 7)
                                            {
                                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoConReferencia
                                                    (CodigoProducto, NombreProducto, SearchReferencia, Code, ColorChecked, rowProducto, rowMaxProducto);
                                            }
                                            else
                                            {
                                                if (iteracion == 8)
                                                {
                                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                }
                                                else
                                                {
                                                    if (iteracion == 9)
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                    }
                                                    else
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorTalla
                                                        (CodigoProducto, NombreProducto, Talla, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
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
                ComboBoxColumnMedida();
                currentPageProducto++;
                lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
            }
        }

        private void btnFinal_Click(object sender, EventArgs e)
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
                    if (iteracion == 1)
                    {
                        dgvConsultaProducto.DataSource = miBussinesProducto.ListarProductos
                                                        (rowProducto, rowMaxProducto);
                        //ComboBoxColumnMedida();
                    }
                    else
                    {
                        if (iteracion == 2)
                        {
                            dgvConsultaProducto.DataSource = miBussinesProducto.FiltroNombre
                                        (NombreProducto, rowProducto, rowMaxProducto);
                        }
                        else
                        {
                            if (iteracion == 3)
                            {
                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorCodigoCategoria
                                            (codigoCategoria, rowProducto, rowMaxProducto);
                            }
                            else
                            {
                                if (iteracion == 4)
                                {
                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                                (NombreCategoria, rowProducto, rowMaxProducto, false);
                                }
                                else
                                {
                                    if (iteracion == 5)
                                    {
                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombreCategoria
                                                    (NombreCategoria, rowProducto, rowMaxProducto, true);
                                    }
                                    else
                                    {
                                        if (iteracion == 6)
                                        {
                                            dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorReferencia
                                                (SearchReferencia, rowProducto, rowMaxProducto, ColorChecked);
                                        }
                                        else
                                        {
                                            if (iteracion == 7)
                                            {
                                                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoConReferencia
                                                    (CodigoProducto, NombreProducto, SearchReferencia, Code, ColorChecked, rowProducto, rowMaxProducto);
                                            }
                                            else
                                            {
                                                if (iteracion == 8)
                                                {
                                                    dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                }
                                                else
                                                {
                                                    if (iteracion == 9)
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                                                        (CodigoProducto, NombreProducto, Marca, Talla, Sixe, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
                                                    }
                                                    else
                                                    {
                                                        dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorTalla
                                                        (CodigoProducto, NombreProducto, Talla, Product, Code, ColorChecked, rowProducto, rowMaxProducto);
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
                ComboBoxColumnMedida();
                lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
            }
        }

        /// <summary>
        /// Carga las medidas de acuerdo a los registros del DataGridView.
        /// </summary>
        private void ComboBoxColumnMedida()
        {
            var registro = 0;
            foreach (DataGridViewRow row in dgvConsultaProducto.Rows)
            {
                string codigo = Convert.ToString(row.Cells["Column2"].Value);
                var tabla = miBussinesValorUnidad.MedidasDeProducto(codigo);
                string miMedida = "";
                if (tabla.Rows.Count > 1)
                {
                    foreach (DataRow row_ in tabla.Rows)
                    {
                        miMedida = miMedida +
                            Convert.ToString(row_["descripcionvalor_unidad_medida"]) + ", ";
                    }
                }
                else
                {
                    foreach (DataRow row_ in tabla.Rows)
                    {
                        miMedida = Convert.ToString(row_["descripcionvalor_unidad_medida"]);
                    }
                }
                dgvConsultaProducto[7, registro].Value = miMedida;
                registro++;
            }
        }

        /// <summary>
        /// Visualiza o no las columans extras del DataGridView.
        /// </summary>
        /// <param name="medidaDropDown">Estado para la columna Medida de tipo DropDownList.</param>
        /// <param name="medidaText">Estado para la columna Medida de tipo TextBox.</param>
        /// <param name="referencia">Estado para la columna Referencia.</param>
        /// <param name="color">Estado para la columna Color.</param>
        private void MostrarColumnasDataGrid
            (bool medidaDropDown, bool medidaText, bool referencia, bool color)
        {
           /* dgvConsultaProducto.Columns["Column5"].Visible = medidaDropDown;
            dgvConsultaProducto.Columns["Medida2"].Visible = medidaText;
            dgvConsultaProducto.Columns["Referencia"].Visible = referencia;
            dgvConsultaProducto.Columns["ColumnColor"].Visible = color;*/
        }

        /// <summary>
        /// Cargar el GridView con el resultado de la consulta.
        /// </summary>
        /// <param name="codigo">Codigo Interno o de Barras a consultar.</param>
        private void ConsultaPorCodigo(string codigo) 
        {
            try
            {
                this.dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorCodigo(codigo);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Cargar el gridView con el resultado de la consulta.
        /// </summary>
        /// <param name="nombre">Nombre a consultar.</param>
        private void ConsultaNombre(string nombre)
        {
            try
            {
                this.dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaPorNombre(nombre);
                //ComboBoxColumnMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cargar el gridView con el resultado de la consulta.
        /// </summary>
        /// <param name="nombre">Nombre a filtrar.</param>
        private void FiltroNombre(string nombre)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 2;
            try
            {
                this.dgvConsultaProducto.DataSource = miBussinesProducto.FiltroNombre
                    (nombre, rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsFiltroNombre(nombre);
                //ComboBoxColumnMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            paginasProducto = totalRowProducto / rowMaxProducto;
            if (totalRowProducto % rowMaxProducto != 0)
                paginasProducto++;
            if (currentPageProducto > paginasProducto)
                currentPageProducto = 0;
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta.
        /// </summary>
        /// <param name="codigo">Codigo de la categoria.</param>
        private void ConsultaPorCodigoCategoria(string codigo)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 3;
            try
            {
                this.dgvConsultaProducto.DataSource = miBussinesProducto.
                    ConsultaPorCodigoCategoria(codigo, rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsConsultaPorCodigoCategoria(codigo);
                ComboBoxColumnMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            paginasProducto = totalRowProducto / rowMaxProducto;
            if (totalRowProducto % rowMaxProducto != 0)
                paginasProducto++;
            if (currentPageProducto > paginasProducto)
                currentPageProducto = 0;
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria.</param>
        private void ConsultaPorNombreCategoria(string nombre)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 4;
            try
            {
                this.dgvConsultaProducto.DataSource = 
                    miBussinesProducto.ConsultaPorNombreCategoria(nombre, rowProducto, rowMaxProducto, false);
                totalRowProducto = miBussinesProducto.RowsConsultaPorNombreCategoria(nombre, false);
                ComboBoxColumnMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            paginasProducto = totalRowProducto / rowMaxProducto;
            if (totalRowProducto % rowMaxProducto != 0)
                paginasProducto++;
            if (currentPageProducto > paginasProducto)
                currentPageProducto = 0;
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta.
        /// </summary>
        /// <param name="nombre">Nombre de la categoria o parte de este.</param>
        private void FiltroPorNombreCategoria(string nombre)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 5;
            try
            {
                this.dgvConsultaProducto.DataSource =
                    miBussinesProducto.ConsultaPorNombreCategoria(nombre, rowProducto, rowMaxProducto, true);
                totalRowProducto = miBussinesProducto.RowsConsultaPorNombreCategoria(nombre, true);
                ComboBoxColumnMedida();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            paginasProducto = totalRowProducto / rowMaxProducto;
            if (totalRowProducto % rowMaxProducto != 0)
                paginasProducto++;
            if (currentPageProducto > paginasProducto)
                currentPageProducto = 0;
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta Por referencia e indica si incluye color.
        /// </summary>
        /// <param name="referencia">Referencia a consultar.</param>
        private void ConsultaPorReferencia(string referencia)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 6;
            try
            {
                dgvConsultaProducto.DataSource =  miBussinesProducto.ConsultaProductoPorReferencia
                        (referencia, rowProducto, rowMaxProducto, cbIncluirColor.Checked);
                SearchReferencia = referencia;
                ColorChecked = cbIncluirColor.Checked;
                totalRowProducto = miBussinesProducto.RowsConsultaProductoPorReferencia
                    (referencia, cbIncluirColor.Checked);
                if (cbIncluirColor.Checked)
                {
                    MostrarColumnasDataGrid(false, true, true, true);
                }
                else
                {
                    MostrarColumnasDataGrid(true, false, true, false);
                    ComboBoxColumnMedida();
                }
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
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta de productos segun el codigo o el nombre y la referencia.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="referencia">Referencia o parte de esta a consultar.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        private void ConsultaProductoConReferencia
            (string codigo, string nombre, string referencia, bool code)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 7;
            try
            {
                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoConReferencia
                    (codigo, nombre, referencia, code, cbIncluirColor.Checked, 
                     rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsConsultaProductoConReferencia
                    (codigo, nombre, referencia, code, cbIncluirColor.Checked);
                CodigoProducto = codigo;
                NombreProducto = nombre;
                SearchReferencia = referencia;
                Code = code;
                ColorChecked = cbIncluirColor.Checked;
                if (cbIncluirColor.Checked)
                {
                    MostrarColumnasDataGrid(false, true, true, true);
                }
                else
                {
                    MostrarColumnasDataGrid(true, false, true, false);
                    ComboBoxColumnMedida();
                }
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
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta de productos segun la Marca.
        /// </summary>
        /// <param name="marca">Nombre o parte de la marca del producto a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="size">Indica si la consulta incluye talla o no.</param>
        private void ConsultaPorMarca
            (string marca, string talla, bool size)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 8;
            try
            {
                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                    (null, null, marca, talla, size, false, false, cbIncluirColor.Checked, rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsConsultaProductoPorMarca(null, null, marca,
                    talla, size, false, false, cbIncluirColor.Checked);
                NombreProducto = null;
                CodigoProducto = null;
                Marca = marca;
                Talla = talla;
                Sixe = size;
                Product = false;
                Code = false;
                ColorChecked = cbIncluirColor.Checked;
                if (cbIncluirColor.Checked)
                {
                    MostrarColumnasDataGrid(false, true, true, true);
                }
                else
                {
                    if (!String.IsNullOrEmpty(talla))
                    {
                        MostrarColumnasDataGrid(false, true, true, false);
                    }
                    else
                    {
                        MostrarColumnasDataGrid(true, false, true, false);
                        ComboBoxColumnMedida();
                    }
                }
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
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta de productos segun la Marca.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="marca">Marca o parte de esta a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="size">Indica si la consulta incluye talla o no.</param>
        private void ConsultaProductoConMarca
            (string codigo, string nombre, string marca, string talla, bool code, bool size)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 9;
            try
            {
                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorMarca
                    (codigo, nombre, marca, talla, size, true, code, cbIncluirColor.Checked, rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsConsultaProductoPorMarca(codigo, nombre, marca, talla,
                    size, true, code, cbIncluirColor.Checked);
                CodigoProducto = codigo;
                NombreProducto = nombre;
                Marca = marca;
                Talla = talla;
                Sixe = size;
                Product = true;
                Code = code;
                ColorChecked = cbIncluirColor.Checked;
                if (cbIncluirColor.Checked)
                {
                    MostrarColumnasDataGrid(false, true, true, true);
                }
                else
                {
                    if (!String.IsNullOrEmpty(talla))
                    {
                        MostrarColumnasDataGrid(false, true, true, false);
                    }
                    else
                    {
                        MostrarColumnasDataGrid(true, false, true, false);
                        ComboBoxColumnMedida();
                    }
                }
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
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        /// <summary>
        /// Carga el Grid con el resultado de la consulta de productos segun la Talla o Medida.
        /// </summary>
        /// <param name="codigo">Codigo del producto a consultar.</param>
        /// <param name="nombre">Nombre o parte de este del producto a consultar.</param>
        /// <param name="talla">Talla o parte de esta a consultar.</param>
        /// <param name="product">Indica si la consulta incluye Producto o no.</param>
        /// <param name="code">Indica si se consulta por Codigo del producto o no.</param>
        /// <param name="color">Indica si la consulta incluye color o no.</param>
        private void ConsultaProductoConTalla(string codigo, string nombre, string talla, 
            bool product, bool code, bool color)
        {
            rowProducto = 0;
            currentPageProducto = 1;
            iteracion = 10;
            try
            {
                dgvConsultaProducto.DataSource = miBussinesProducto.ConsultaProductoPorTalla
                    (codigo, nombre, talla, product, code, cbIncluirColor.Checked, rowProducto, rowMaxProducto);
                totalRowProducto = miBussinesProducto.RowsConsultaProductoPorTalla(codigo, nombre, talla,
                    product, code, cbIncluirColor.Checked);
                CodigoProducto = codigo;
                NombreProducto = nombre;
                Talla = talla;
                Product = product;
                Code = code;
                ColorChecked = cbIncluirColor.Checked;
                if (cbIncluirColor.Checked)
                {
                    MostrarColumnasDataGrid(false, true, true, true);
                }
                else
                {
                    if (!String.IsNullOrEmpty(talla))
                    {
                        MostrarColumnasDataGrid(false, true, true, false);
                    }
                    else
                    {
                        MostrarColumnasDataGrid(true, false, true, false);
                        ComboBoxColumnMedida();
                    }
                }
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
            lblStatusPaginaProducto.Text = currentPageProducto + " / " + paginasProducto;
        }

        #endregion

        /// <summary>
        /// Habilita la eleccion de color en el formulario segun la configuracion.
        /// </summary>
        private void HabilitarColor()
        {
            if (EnableColor)
            {
                btnOpcionColor.Visible = true;
                lblSeleccionarColor.Visible = true;
            }
        }

        /// <summary>
        /// Carga los valores del Iva en el Combo Box
        /// </summary>
        private void CargarIva()
        {
            try
            {
                cbIva.DataSource = miBussinesIva.ListadoIva();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Carga las unidades de medida en el List Box.
        /// </summary>
        private void CargarUnidadMedida()
        {
            try
            {
                ///cbUnidadesMedida.DataSource = miBussinesValorUnidad.UnidadesDeMedida();
                this.cbUnidadesMedida.DataSource = miBussinesProducto.UnidadDeMedida();
                this.cbUnidadesMedida.SelectedValue = 3;

                this.lbUnidadMedida.DataSource = bussinesUnidadMedida.ListadoUnidadMedidaNoTalla();
                this.IdMedidaConfigurada = Convert.ToInt32(
                    miBussinesConfiguracion.Configuracion(CodigoConfiguracionMedida).Valor);
                if (!this.IdMedidaConfigurada.Equals(0))
                {
                    this.lbUnidadMedida.SelectedValue = this.IdMedidaConfigurada;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cargar las tallas en el ListBox.
        /// </summary>
        private void CargarTallas()
        {
            try
            {
                lstbTalla.DataSource = miBussinesValorUnidad.ListadoDeTallas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los Valores de las unidades de medida segun la medida en el List Box.
        /// </summary>
        /// <param name="idUnidadMedida"></param>
        private void CargarValorUnidadMedida(int idUnidadMedida)
        {
            try
            {
                lbValorMedida.DataSource =
                    miBussinesValorUnidad.ListadoValorUnidadMedida(idUnidadMedida);
                if (!EnableColor)
                {
                    lbValorMedida.SelectionMode = SelectionMode.One;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Carga el listado de Descuentos elegidos por el usuario.
        /// </summary>
        private void CargarDescuentos()
        {
            listaDescuentos = new List<Descuento>();
            foreach (Descuento d in lbDescuento.SelectedItems)
            {
                listaDescuentos.Add(d);
            }
        }

        /// <summary>
        /// Carga el listado de Recargos elegidos por el usuario.
        /// </summary>
        private void CargarRecargos() 
        {
            listaRecargos = new List<Recargo>();
            foreach (Recargo r in lbRecargo.SelectedItems)
            {
                listaRecargos.Add(r);
            }
        }

        /// <summary>
        /// Carga las medidas del producto seleccionadas por el usuario.
        /// </summary>
        private void CargarMedidas()
        {
            medidas = new List<ValorUnidadMedida>();
            var medida = new ValorUnidadMedida();
            medida.IdValorUnidadMedida = Convert.ToInt32(cbUnidadesMedida.SelectedValue);
            medidas.Add(medida);


            /*foreach (DTO.Clases.Inventario i in inventarios)
            {
                var medida = new ValorUnidadMedida();
                medida.IdValorUnidadMedida = i.IdMedida;
                medidas.Add(medida);
            }*/
            /*if (rbtnUnidadMedida.Checked)
            {
                var medida = new ValorUnidadMedida();
                medida.IdValorUnidadMedida = Convert.ToInt32(this.lbValorMedida.SelectedValue);
                medidas.Add(medida);
            }
            else
            {
                foreach (DataRowView view in lstbTalla.SelectedItems)
                {
                    var medida = new ValorUnidadMedida();
                    medida.IdValorUnidadMedida = Convert.ToInt32(view.Row["idvalor_unidad_medida"]);
                    medidas.Add(medida);
                }
            }*/
        }

        /// <summary>
        /// Carga la relacion de inventario del producto
        /// </summary>
        private void CargarInventarios()
        {
            inventarios = new List<DTO.Clases.Inventario>();
            inventarios.Add(new DTO.Clases.Inventario { IdMedida = Convert.ToInt32(cbUnidadesMedida.SelectedValue) });

           // inventarios = new List<DTO.Clases.Inventario>();
           /*if (rbtnUnidadMedida.Checked)
            {
                var inventario = new DTO.Clases.Inventario();
                inventario.IdMedida = Convert.ToInt32(this.lbValorMedida.SelectedValue);
                inventarios.Add(inventario);
            }
            else
            {
                foreach (DataRowView view in lstbTalla.SelectedItems)
                {
                    var inventario = new DTO.Clases.Inventario();
                    inventario.IdMedida = Convert.ToInt32(view.Row["idvalor_unidad_medida"]);
                    inventarios.Add(inventario);
                }
            }*/
        }

        /// <summary>
        /// Carga la relacion de medida y color en inventario del producto.
        /// </summary>
        private void CargarInventariosDeTabla()
        {
            inventarios = new List<DTO.Clases.Inventario>();
            inventarios.Add(new DTO.Clases.Inventario { IdMedida = Convert.ToInt32(cbUnidadesMedida.SelectedValue) });

            /*foreach (DataRow row in miTabla.Rows)
            {
                var inventario = new DTO.Clases.Inventario();
                inventario.IdMedida = row.Field<int>("IdMedida");
                inventario.IdColor = row.Field<int>("IdColor");
                inventarios.Add(inventario);
            }*/
        }

        /// <summary>
        /// Completa la transferencia de datos de Marca.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                TransferirMarca m = (TransferirMarca)args.MiMarca;
                if (SearchMarca)
                {
                    txtBusquedaNombreMarca.Text = m.NombreMarca;
                    SearchMarca = false;
                    txtBusquedaNombreMarca.Focus();
                }
                else
                {
                    idMarca = Convert.ToInt32(m.IdMarca);
                    txtCodigoMarca.Text = m.IdMarca.ToString();
                    txtNombreMarca.Text = Convert.ToString(m.NombreMarca);
                    this.Extencion = false;
                    txtDescripcionProducto.Focus();
                }
                
            }
            catch { }

            try
            {
                DTO.Clases.Categoria c = (DTO.Clases.Categoria)args.MiMarca;
                if (SearchCategoria)
                {
                    var criterio = Convert.ToInt32(cbConsutlaCategoria.SelectedValue);
                    if (criterio == 1)
                    {
                        txtBuscarporCategoria.Text = c.CodigoCategoria;
                    }
                    else
                    {
                        txtBuscarporCategoria.Text = c.NombreCategoria;
                    }
                    txtBuscarporCategoria.Focus();
                    SearchCategoria = false;
                }
                else
                {
                    codigoCategoria = c.CodigoCategoria;
                    txtCodigoCategoria.Text = c.CodigoCategoria;
                    txtCategoria.Text = c.NombreCategoria;
                    txtCodigoMarca.Focus();
                }
            }
            catch { }

            try
            {
                FormEditOpen = (bool)args.MiMarca;
            }
            catch { }

            try
            {
                this.Extencion = (bool)args.MiMarca;
            }
            catch { }
        }

        void CompletaEventos_Completaz(CompletaArgumentosDeEventoz args)
        {
            try
            {
                if (FormEditOpen)
                {
                    var code = Convert.ToInt32(args.MiZona);
                    if (code.Equals(223))
                    {
                        switch (BtnSearch)
                        {
                            case 1:
                                {
                                    this.tsbBuscarProducto_Click(this.tsbBuscarProducto, new EventArgs());
                                    break;
                                }
                            case 2:
                                {
                                    this.btnBuscarporCodigos_Click(this.btnBuscarporCodigos, new EventArgs());
                                    break;
                                }
                            case 3:
                                {
                                    this.btnBusquedaCombinada_Click(this.btnBusquedaCombinada, new EventArgs());
                                    break;
                                }
                            case 4:
                                {
                                    this.btnBuscarCategoria_Click(this.btnBuscarCategoria, new EventArgs());
                                    break;
                                }
                        }
                    }
                    FormEditOpen = false;
                }
                /*var codigo = Convert.ToString(args.MiZona);
                this.tsbtnCodigo_Click(this.tsbtnCodigo, new EventArgs());
                this.cbConsulta.SelectedIndex = 0;
                this.cbConsulta_SelectionChangeCommitted(this.cbConsulta, new EventArgs());
                this.txtConsulta.Text = codigo;
                this.btnBuscarporCodigos_Click(this.btnBuscarporCodigos, new EventArgs());*/
            }
            catch { }
        }

        public bool Fact { set; get; }

        private void FrmIngresarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro(a) de salir?",
                   "Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rta.Equals(DialogResult.Yes))
            {
                if (Edit)
                {
                    CompletaEventos.CapturaEventoEditProveedor(false);
                }
                else
                {
                    if (Fact)
                    {
                        CompletaEventos.CapturaEvento(false);
                    }
                }
                if (Agrupar)
                {
                    CompletaEventos.CapturaEventoEditProveedor(false);
                }
                if (Remision)
                {
                    CompletaEventos.CapturaEventoRemision(false);
                }
                if (Devolucion)
                {
                    CompletaEventos.CapturaEventom(false);
                }
                if (Extend)
                {
                    CompletaEventos.CapturaEvenTransInvFactProvee(false);
                }
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }

          /*  if (Edit)
            {
                CompletaEventos.CapturaEventoEditProveedor(false);
            }
            else
            {
                if (Fact)
                {
                    CompletaEventos.CapturaEvento(false);
                }
            }
            if (Agrupar)
            {
                CompletaEventos.CapturaEventoEditProveedor(false);
            }
            if (Remision)
            {
                CompletaEventos.CapturaEventoRemision(false);
            }
            if (Devolucion)
            {
                CompletaEventos.CapturaEventom(false);
            }
            if (Extend)
            {
                CompletaEventos.CapturaEvenTransInvFactProvee(false);
            }*/
        }

        private void dgvConsultaProducto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvConsultaProducto.RowCount != 0 && Extencion)
            {
                var producto = new DTO.Clases.Producto();
                producto.CodigoInternoProducto = Convert.ToString
                    (dgvConsultaProducto.CurrentRow.Cells["Column2"].Value);
                producto.NombreProducto = Convert.ToString
                    (dgvConsultaProducto.CurrentRow.Cells["Column4"].Value);
                if (Edit)
                {
                    CompletaEventos.CapturaEventoEditProveedor(producto);
                }
                else
                {
                    if (Remision)
                    {
                        CompletaEventos.CapturaEventoRemision(producto);
                    }
                    else
                    {
                        CompletaEventos.CapturaEventom(producto);
                    }
                }
                Extencion = false;
                this.Close();
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            BtnSearch = 4;
            txtBuscarporCategoria_KeyPress(this.txtBuscarporCategoria, new KeyPressEventArgs((char)Keys.Enter));
        }

        private void FrmIngresarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsbGuardarProducto_Click(this.tsbGuardarProducto, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        llGenerarCodigoInterno_LinkClicked(
                            this.llGenerarCodigoInterno, null);
                        break;
                    }
                case Keys.F4:
                    {
                        llGenerarCodigoBarrasProducto_LinkClicked(
                            this.llGenerarCodigoBarrasProducto, null);
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsbBuscarProducto_Click(this.tsbBuscarProducto, new EventArgs());
                        break;
                    }
                case Keys.F7:
                    {
                        this.dgvConsultaProducto.Focus();
                        break;
                    }
                case Keys.F8:
                    {
                        this.tsbVerDetalle_Click(this.tsVerDetalle, new EventArgs());
                        break;
                    }
                case Keys.F9:
                    {
                        this.tsbEditar_Click(this.tsEditar, new EventArgs());
                        break;
                    }
                case Keys.F10:
                    {
                        this.tsBtnImprimir_Click(this.tsBtnImprimir, new EventArgs());
                        break;
                    }
                case Keys.F11:
                    {
                        this.tsbEliminar_Click(this.tsEliminar, new EventArgs());
                        break;
                    }
                case Keys.F12:
                    {
                        Replicas();
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
                case Keys.Add: // " + "
                        {
                            if (dgvConsultaProducto.Focused)
                            {
                                this.btnSiguiente_Click(this.btnSiguiente, new EventArgs());
                            }
                            break;
                        }
                case Keys.Subtract:  // " - "
                        {
                            if (dgvConsultaProducto.Focused)
                            {
                                this.btnAnterior_Click(this.btnAnterior, new EventArgs());
                            }
                            break;
                        }
            }
        }

        private void txtCodigoInternoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigoBarrasProducto.Focus();
            }
        }

        private void txtCodigoBarrasProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtReferencia.Focus();
            }
        }

        private void txtReferencia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreProducto.Focus();
                //this.txtCodigo_2.Focus();
            }
        }

        private void txtCodigo_2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigo_3.Focus();
            }
        }

        private void txtCodigo_3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigo_4.Focus();
            }
        }

        private void txtCodigo_4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigo_5.Focus();
            }
        }

        private void txtCodigo_5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigo_6.Focus();
            }
        }

        private void txtCodigo_6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCodigo_7.Focus();
            }
        }

        private void txtCodigo_7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtNombreProducto.Focus();
            }
        }

        private void txtNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtNombreProducto.Text = txtNombreProducto.Text.ToUpper();
                txtCodigoCategoria.Focus();
            }
        }

        private void txtDescripcionProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtValorCosto.Focus();
            }
        }

        

        

        

        private void chkCantDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                //cbAplicarPrecio.Focus();
                this.txtDesctoMayor.Focus();
            }
        }

        private void cbAplicarPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
               txtDesctoMayor.Focus();
            }
        }

        private void rbtnUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                lbUnidadMedida.Focus();
            }
        }

        private void rbtnTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                lstbTalla.Focus();
            }
        }

        private void lbUnidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                lbValorMedida.Focus();
            }
        }

        private void lbValorMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtUnidadVentaProducto.Focus();
            }
        }

        private void lstbTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtUnidadVentaProducto.Focus();
            }
        }

        private void txtUnidadVentaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCantidadMinimaProducto.Focus();
            }
        }

        private void txtCantidadMinimaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCantidadMaximaProducto.Focus();
            }
        }

        private void txtCantidadMaximaProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnOpcionColor.Focus();
            }
        }

        private void cbMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            /*if (e.KeyChar.Equals((char)Keys.Enter))
            {
                btnSelecionarColor.Focus();
            }*/
        }

        

        private void cbAplicarPrecio_Enter(object sender, EventArgs e)
        {
            cbAplicarPrecio.DroppedDown = true;
        }

        private void txtDesctoMayor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = txtValorVentaProducto.Text;
                if (String.IsNullOrEmpty(precioVenta))
                {
                    precioVenta = "0";
                }
                var destoMayor = txtDesctoMayor.Text.Replace('.', ',');
                if (String.IsNullOrEmpty(destoMayor))
                {
                    destoMayor = "0";
                }
                var precioMayor = Convert.ToInt32(UseObject.RemoveSeparatorMil(precioVenta) -
                        (UseObject.RemoveSeparatorMil(precioVenta) * Convert.ToDouble(destoMayor) / 100));
                txtValorDesctoMayor.Text = UseObject.InsertSeparatorMil(
                UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                miError.SetError(txtDesctoMayor, null);
            }
            catch (Exception ex)
            {
                miError.SetError(txtDesctoMayor, ex.Message);
             //   OptionPane.MessageError(ex.Message);
            }
        }

        private void txtDesctoMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtDesctoDistribuidor.Focus();
            }
        }

        private void txtDesctoMayor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDesctoMayor.Text))
            {
                if (validacion.ValidarNumeroDecima(this.txtDesctoMayor.Text))
                {
                    this.DesctoMayor = true;
                }
                else
                {
                    this.DesctoMayor = false;
                }
            }
            else
            {
                this.DesctoMayor = true;
            }
        }

        private void txtDesctoDistribuidor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = txtValorVentaProducto.Text;
                if (String.IsNullOrEmpty(precioVenta))
                {
                    precioVenta = "0";
                }
                var destoDistrib = txtDesctoDistribuidor.Text.Replace('.', ',');
                if (String.IsNullOrEmpty(destoDistrib))
                {
                    destoDistrib = "0";
                }
                var precioMayor = Convert.ToInt32(UseObject.RemoveSeparatorMil(precioVenta) -
                        (UseObject.RemoveSeparatorMil(precioVenta) * Convert.ToDouble(destoDistrib) / 100));
                txtValorDesctoDistrib.Text = UseObject.InsertSeparatorMil(
                UseObject.Aproximar(precioMayor, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                miError.SetError(txtValorDesctoDistrib, null);
            }
            catch (Exception ex)
            {
                miError.SetError(txtValorDesctoDistrib, ex.Message);
                //   OptionPane.MessageError(ex.Message);
            }
        }

        private void txtDesctoDistribuidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                //rbtnUnidadMedida.Focus();
                this.txtDesctoPrecio4.Focus();
            }
        }

        private void txtDesctoDistribuidor_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDesctoDistribuidor.Text))
            {
                if (validacion.ValidarNumeroDecima(this.txtDesctoDistribuidor.Text))
                {
                    this.DesctoDistrib = true;
                }
                else
                {
                    this.DesctoDistrib = false;
                }
            }
            else
            {
                this.DesctoDistrib = true;
            }
        }

        private void txtDesctoPrecio4_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = this.txtValorVentaProducto.Text;
                if (String.IsNullOrEmpty(precioVenta))
                {
                    precioVenta = "0";
                }
                var desctoPrecio4 = this.txtDesctoPrecio4.Text.Replace('.', ',');
                if (String.IsNullOrEmpty(desctoPrecio4))
                {
                    desctoPrecio4 = "0";
                }
                var precio4 = Convert.ToInt32(UseObject.RemoveSeparatorMil(precioVenta) -
                        (UseObject.RemoveSeparatorMil(precioVenta) * Convert.ToDouble(desctoPrecio4) / 100));
                this.txtValorPrecio4.Text = UseObject.InsertSeparatorMil(
                    UseObject.Aproximar(precio4, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio"))).ToString());
                this.miError.SetError(this.txtDesctoPrecio4, null);
            }
            catch (Exception ex)
            {
                this.miError.SetError(this.txtDesctoPrecio4, ex.Message);
            }
        }

        private void txtDesctoPrecio4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.rbtnUnidadMedida.Focus();
                //this.txtDesctoPrecio4.Focus();
            }
        }

        private void txtDesctoPrecio4_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.txtDesctoPrecio4.Text))
            {
                if (validacion.ValidarNumeroDecima(this.txtDesctoPrecio4.Text))
                {
                    this.DesctoPrecio4 = true;
                }
                else
                {
                    this.DesctoPrecio4 = false;
                }
            }
            else
            {
                this.DesctoPrecio4 = true;
            }
        }

        private void chkCantDecimal_Enter(object sender, EventArgs e)
        {
            chkCantDecimal.BackColor = SystemColors.GradientActiveCaption;
        }

        private void chkCantDecimal_Leave(object sender, EventArgs e)
        {
            chkCantDecimal.BackColor = Color.White;
        }

        private void rbtnUnidadMedida_Enter(object sender, EventArgs e)
        {
            rbtnUnidadMedida.BackColor = SystemColors.GradientActiveCaption;
        }

        private void rbtnUnidadMedida_Leave(object sender, EventArgs e)
        {
            rbtnUnidadMedida.BackColor = Color.White;
        }

        private void lbUnidadMedida_Enter(object sender, EventArgs e)
        {
            lbUnidadMedida.BackColor = SystemColors.GradientActiveCaption;
        }

        private void lbUnidadMedida_Leave(object sender, EventArgs e)
        {
            lbUnidadMedida.BackColor = Color.White;
        }

        private void lbValorMedida_Enter(object sender, EventArgs e)
        {
            lbValorMedida.BackColor = SystemColors.GradientActiveCaption;
        }

        private void lbValorMedida_Leave(object sender, EventArgs e)
        {
            lbValorMedida.BackColor = Color.White;
        }

        private void lstbTalla_Enter(object sender, EventArgs e)
        {
            lstbTalla.BackColor = SystemColors.GradientActiveCaption;
        }

        private void lstbTalla_Leave(object sender, EventArgs e)
        {
            lstbTalla.BackColor = Color.White;
        }

        private void Replicas()
        {
            string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
            if (rta.Equals("ajustereplica"))
            {
                RevisarReplicas();
            }
            else
            {
                if (rta.Equals("ajustereplica2"))
                {
                    AjustarReplicas();
                }
            }
        }

        private void RevisarReplicas()
        {
            try
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("replica2014"))
                {
                    var frmReplicas = new FrmReplicas();
                    frmReplicas.dgvReplicas.DataSource = miBussinesProducto.Replicas(true);
                    frmReplicas.Show();
                }
                else
                {
                    if (rta.Equals("replica20142"))
                    {
                        var frmReplicas = new FrmReplicas();
                        frmReplicas.dgvReplicas.DataSource = miBussinesProducto.Replicas(false);
                        frmReplicas.Show();
                    }
                    else
                    {
                        if (rta.Equals("replica20143"))
                        {
                            var frmReplicas = new FrmReplicas();
                            frmReplicas.dgvReplicas.DataSource = miBussinesProducto.ReplicasEnFactura();
                            frmReplicas.Show();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void AjustarReplicas()
        {
            try
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (rta.Equals("replica2014"))
                {
                    miBussinesProducto.AjustarReplicas(true);
                    OptionPane.MessageInformation("Las Replicas se ajustarón con exito.");
                }
                else
                {
                    if (rta.Equals("replica20142"))
                    {
                        miBussinesProducto.AjustarReplicas(false);
                        OptionPane.MessageInformation("Las Replicas se ajustarón con exito.");
                    }
                    else
                    {
                        if (rta.Equals("replica20143"))
                        {
                            miBussinesProducto.AjustarBarrasVacia();
                            OptionPane.MessageInformation("Las Replicas se ajustarón con exito.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        private void tsBtnEliminarProductosNoNecesarios_Click(object sender, EventArgs e)
        {
            string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
            if (rta.Equals("1002-105-AJUST"))
            {
                this.miOption = new OptionPane();
                this.miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                this.miOption.FrmProgressBar.Closed_ = true;
                this.miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                this.miThread = new Thread(Cargar);
                this.miThread.Start();
            }
        }

        private Thread miThread;

        private OptionPane miOption;

        private void Cargar()
        {
            try
            {
                this.miBussinesProducto.EliminarProductosNoNecesarios();
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
            }
            catch (Exception ex)
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(Finalizar));
                }
                OptionPane.MessageError(ex.Message);
            }
        }

        private void Finalizar()
        {
            try
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageInformation("La operación se realizó con éxito.");
            }
            catch (Exception ex)
            {
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbTipoInventario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbTipoInventario.SelectedValue).Equals(2))
            {
                cbProdProceso.Enabled = true;
            }
            else
            {
                cbProdProceso.Enabled = false;
                cbProdProceso.SelectedIndex = 0;
            }
        }

        private void cbCuentaContable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCuentaContable.SelectedIndex != 0)
            {
                txtDescripcionProducto.Text = cbCuentaContable.SelectedValue.ToString();
            }
            else
            {
                txtDescripcionProducto.Text = "";
            }
        }

        private void txtUnidadMCantidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                /*this.listBox1.DataSource = this.miBussinesProducto.UnidadDeMedida(txtUnidadMCantidad.Text);
                this.listBox1.SelectedIndex = -1;
                this.listBox1.Visible = true;*/
            }
            catch (Exception ex)
            {

            }
            
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (listBox1.SelectedValue != null)
            {
                this.medida = new ValorUnidadMedida();
                this.medida.IdValorUnidadMedida = Convert.ToInt32(((DataRowView)this.listBox1.SelectedItem).Row["id"]);
                this.medida.DescripcionValorUnidadMedida = ((DataRowView)this.listBox1.SelectedItem).Row["descripcion"].ToString();

                this.txtUnidadMCantidad.Text = this.medida.DescripcionValorUnidadMedida;
                this.listBox1.Visible = false;


                
            }*/
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            //var obj = listBox1.SelectedValue;
        }

        

    }

    /// <summary>
    /// Representa una clase para Aplicar precios
    /// </summary>
    internal class AplicarPrecio
    {
        /// <summary>
        /// Obtiene o establece el Id
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el valor
        /// </summary>
        public string Valor { set; get; }

        /// <summary>
        /// Obtiene una lista de las opciones para aplicar precio
        /// </summary>
        /// <returns></returns>
        public List<AplicarPrecio> lista()
        {
            List<AplicarPrecio> lst = new List<AplicarPrecio>();
            lst.Add
            (
                new AplicarPrecio
                {
                    Id = 1,
                    Valor = "Valor"
                }
            );

            lst.Add
            (
                new AplicarPrecio
                {
                    Id = 2,
                    Valor = "Porcentaje"
                }
            );

            return lst;
        }
    }

    /// <summary>
    /// Representa una clase para estructura criterios de consulta.
    /// </summary>
    internal class Consulta
    {
        /// <summary>
        /// Obtiene o establece el listado de criterios primarios.
        /// </summary>
        public List<Criterio> lista1 { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de criterios secundarios.
        /// </summary>
        public List<Criterio> lista2 { set; get; }

        /// <summary>
        /// Inicaliza una nueva instancia de la clase Consulta.
        /// </summary>
        public Consulta()
        {
            this.lista1 = new List<Criterio>();
            this.lista1.Add(
                new Criterio
                {
                    Id = 1,
                    Nombre = "Codigo"
                });
            this.lista1.Add(
                new Criterio
                {
                    Id = 2,
                    Nombre = "Nombre"
                });

            this.lista2 = new List<Criterio>();
            this.lista2.Add(
                new Criterio
                {
                    Id = 1,
                    Nombre = "Que sea Igual"
                });
            this.lista2.Add(
                new Criterio
                {
                    Id = 2,
                    Nombre = "Que contenga"
                });
        }
    }

    /// <summary>
    /// Representa una Clase para estructurar Criterios de consulta.
    /// </summary>
    internal class ConsultaCategoria
    {
        /// <summary>
        /// Obtiene o establece el listado de criterios primarios.
        /// </summary>
        public List<Criterio> lista1 { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de criterios secundarios.
        /// </summary>
        public List<Criterio> lista2 { set; get; }

        /// <summary>
        /// Inicaliza una nueva instancia de la clase ConsultaCategoria.
        /// </summary>
        public ConsultaCategoria()
        {
            this.lista1 = new List<Criterio>();
            this.lista1.Add(
                new Criterio
                {
                    Id = 1,
                    Nombre = "Codigo"
                });
            this.lista1.Add(
                new Criterio
                {
                    Id = 2,
                    Nombre = "Nombre"
                });

            this.lista2 = new List<Criterio>();
            this.lista2.Add(
                new Criterio
                {
                    Id = 1,
                    Nombre = "Que se Igual"
                });
            this.lista2.Add(
                new Criterio
                {
                    Id = 2,
                    Nombre = "Que Contenga"
                });
        }
    }

    /// <summary>
    /// Representa una clase para la estructura de consultas combinadas
    /// </summary>
    internal class ConsultaCombinada
    {
        /// <summary>
        /// Obtiene o establece el listado de criterios primarios.
        /// </summary>
        public List<Criterio> lista { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de criterios secundarios.
        /// </summary>
        public List<Criterio> lista1 { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de criterios terciarios.
        /// </summary>
        public List<Criterio> lista2 { set; get; }

        /// <summary>
        /// Obtiene o establece el listado de criterios cuaternarios.
        /// </summary>
        public List<Criterio> lista3 { set; get; }

        /// <summary>
        /// Inicializa una nueva instacia de la clase ConsultaCombinada
        /// </summary>
        public ConsultaCombinada()
        {
            Criterio SinCombinacion = new Criterio { Id = 1, Nombre = "[Seleccione]" };
            Criterio Marca = new Criterio { Id = 2, Nombre = "Marca" };
            Criterio Talla = new Criterio { Id = 2, Nombre = "Medida o Talla" };

            this.lista = new List<Criterio>();
            this.lista.Add(
                new Criterio
                {
                    Id = 1,
                    Nombre = "Por Referencia"
                });
            this.lista.Add(
                new Criterio
                {
                    Id = 2,
                    Nombre = "Por Marca"
                });
            this.lista.Add(
                new Criterio
                {
                    Id = 3,
                    Nombre = "Por Medida o Talla"
                });

            this.lista1 = new List<Criterio>();
            this.lista1.Add(SinCombinacion);

            this.lista2 = new List<Criterio>();
            this.lista2.Add(SinCombinacion);
            //this.lista2.Add(Marca);

            this.lista3 = new List<Criterio>();
            this.lista3.Add(SinCombinacion);
            this.lista3.Add(Talla);
            
        }

    }

    /// <summary>
    /// Representa una clase que conforman los criterios.
    /// </summary>
    internal class Criterio
    {
        public int Id { set; get; }

        public string Nombre { set; get; }

        public bool Valor { set; get; }
    }
}