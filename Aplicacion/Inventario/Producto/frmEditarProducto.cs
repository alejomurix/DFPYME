using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DTO.Clases;
using Aplicacion.Configuracion.Marcas;
using BussinesLayer.Clases;
using System.Collections;
using Utilities;
using CustomControl;

namespace Aplicacion.Inventario.Producto
{
    public partial class frmEditarProducto : Form
    {
        #region Atributos

        /// <summary>
        /// Obtiene o establece los datos del Producto.
        /// </summary>
        private DTO.Clases.Producto ProductoOriginal { set; get; }

        /// <summary>
        /// Obtiene o establece los datos del Producto Editado.
        /// </summary>
        private DTO.Clases.Producto ProductoEditado { set; get; }

        /// <summary>
        /// Representa una Lista de los Descuentos de Producto.
        /// </summary>
        private List<Descuento> Descuentos;

        /// <summary>
        /// Representa una Lista de los Recargos del Producto.
        /// </summary>
        private List<Recargo> Recargos;

        /// <summary>
        /// Obtiene o establece el valor del Codigo Interno del Producto.
        /// </summary>
        public string CodigoProducto { set; get; }

        /// <summary>
        /// Obtiene o establece el Codigo de la Categoria del Producto
        /// </summary>
        private string CodigoCategoria;

        /// <summary>
        /// Obtiene o establece el Id de la Marca del Producto.
        /// </summary>
        private int IdMarca;

        /// <summary>
        /// Objeto de logica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Objeto de logica de negocio de Descuento.
        /// </summary>
        private BussinesDescuento miBussinesDescuento;

        /// <summary>
        /// Objeto de logica de negocio de Recargo.
        /// </summary>
        private BussinesRecargo miBussinesRecargo;

        /// <summary>
        /// Objeto de logica de negocio de Iva.
        /// </summary>
        private BussinesIva miBussinesIva;

        /// <summary>
        /// Objeto de logica de negocio de Color.
        /// </summary>
        private BussinesColor miBussinesColor;

        /// <summary>
        /// Objeto de logica de negocio de Inventario.
        /// </summary>
        private BussinesInventario miBussinesInventario;

        /// <summary>
        /// Objeto de logica de negocio de Unidad de Medida.
        /// </summary>
        private BussinesUnidadMedida miBussinesUnidad;

        /// <summary>
        /// Objeto de logica de negocio de Valor de Unidad de Medida.
        /// </summary>
        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesEmpresa miBussinesEmpresa;

        #endregion

        #region Utilidades

        /// <summary>
        /// Objeto para el uso de AplicaPrecio.
        /// </summary>
        private AplicarPrecio aplicaPrecio;

        /// <summary>
        /// Obtiene o establece el valor que indica si se configuro color para el formulario
        /// </summary>
        private bool EnableColor;

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

        #endregion

        #region Utilidades de Validacion

        private Validacion validacion;

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
                     referenciaMatch = false,
                     nombreMatch = false,
                     descripcionMatch = false,
                     utilidadMatch = false,
                     valorVentaMatch = false,
                     presentacionMatch = false,
                     minimaMatch = false,
                     maximaMatch = false;

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
            nombreFormato = "El NOmbre que ingreso tiene formato incorrecto.",
            descripcionFormato = "La Descripcion que ingreso tiene formato incorrecto.",
            utilidadFormato = "El valor de la Utilidad que ingreso tiene formato incorrecto.",
            valorVentaFormato = "El Valor de Venta que ingreso tiene formato incorrecto.",
            presentacionFormato = "El valor de la Presentacion que ingreso tiene formato incorrecto.",
            minimaFormato = "La cantidad Minima que ingreso tiene formato incorrecto.",
            maximaFormato = "La Cantidad Maxima que ingreso tiene formato incorrecto.",
            codigoExiste = "El codigo que ingreso ya existe en la base de datos.",
            barrasExiste = "El codigo de barras que ingreso ya existe en la base de datos.";

        /// <summary>
        /// Establece la condicion que indica si el usuario presiono el boton de salir.
        /// </summary>
        private bool PrestBtnSalir = false;

        #endregion

        public bool Extencion = false;

        private int IdProductoProceso { set; get; }

        public frmEditarProducto()
        {
            InitializeComponent();

            try
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("product_description")))
                {
                    lblCuenta.Visible = false;
                    cbCuentaContable.Visible = false;

                    lblDescripcion.Location = new Point(611, 98);
                    txtDescripcion.Location = new Point(698, 94);
                    txtDescripcion.ReadOnly = false;
                    txtDescripcion.Size = new Size(230, 94);
                }

                ProductoEditado = new DTO.Clases.Producto();
                EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
                miBussinesProducto = new BussinesProducto();
                miBussinesDescuento = new BussinesDescuento();
                miBussinesRecargo = new BussinesRecargo();
                miBussinesIva = new BussinesIva();
                miBussinesColor = new BussinesColor();
                miBussinesInventario = new BussinesInventario();
                miBussinesUnidad = new BussinesUnidadMedida();
                miBussinesMedida = new BussinesValorUnidadMedida();
                miBussinesEmpresa = new BussinesEmpresa();
                miError = new ErrorProvider();
                validacion = new Validacion();

                IdProductoProceso = 4;

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
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        public void frmEditarProducto_Load(object sender, EventArgs e)
        {
            try
            {
                cbCuentaContable.DataSource = miBussinesProducto.CuentasContables();
                cbUnidadesMedida.DataSource = miBussinesMedida.UnidadesDeMedida();
                cbTipoInventario.DataSource = miBussinesProducto.TiposInventario();
                cbProdProceso.DataSource = miBussinesProducto.ProductosProceso(IdProductoProceso);
                
            }
            catch(Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            CargarProductoAEditar();
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventos_Completo);
        }

        private void frmEditarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.Escape))
            {
                this.Close();
            }
            else
            {
                if (e.KeyData.Equals(Keys.F2))
                {
                    this.tsbGuardarCambiosEditarProducto_Click(this.tsbGuardarCambiosEditarProducto, new EventArgs());
                }
            }
        }

        private void tsbGuardarCambiosEditarProducto_Click(object sender, EventArgs e)
        {
            ValidacionParaGuardar();
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
                CargarProducto();
                try
                {
                   /* foreach (DataGridViewRow row in dgvMedida.Rows)
                    {
                        var inventario = new DTO.Clases.Inventario();
                        inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                        inventario.IdMedida = (int)row.Cells[0].Value;
                        if (!miBussinesInventario.ComprobarInventario(inventario, false))
                        {
                            miBussinesInventario.InsertarInventario(inventario);
                        }
                    }*/

                    /*var inventario = new DTO.Clases.Inventario();
                    inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                    inventario.IdMedida = Convert.ToInt32(cbUnidadesMedida.SelectedValue);
                    if (!miBussinesInventario.ComprobarInventario(inventario, false))
                    {
                        miBussinesInventario.InsertarInventario(inventario);
                    }*/

                    ProductoEditado.IdMedida = Convert.ToInt32(cbUnidadesMedida.SelectedValue);
                    ProductoEditado.IdTipoInventario = Convert.ToInt32(cbTipoInventario.SelectedValue);
                    ProductoEditado.CodProductoProceso = Convert.ToString(cbProdProceso.SelectedValue);

                    miBussinesProducto.EditarProducto(ProductoEditado);
                    ProductoOriginal.CodigoBarrasProducto = ProductoEditado.CodigoBarrasProducto;
                    //CompletaEventos.CapturaEventoz(ProductoEditado.CodigoInternoProducto);
                    CompletaEventos.CapturaEventoz(223);
                    OptionPane.MessageInformation("Los datos se editaron correctamente.");
                   // miError.SetError(txtBarras, null);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void tsbSalirEditarProducto_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?", "Edicion",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                tsbGuardarCambiosEditarProducto_Click(null, null);
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
                    PrestBtnSalir = true;
                    this.Close();
                }
                else
                {
                    PrestBtnSalir = false;
                }
            }
            else
            {
                if (rta == DialogResult.No)
                {
                    CompletaEventos.CapturaEventom(false);
                    PrestBtnSalir = true;
                    this.Close();
                }
            }
        }

        private void frmEditarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PrestBtnSalir)
            {
                DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?", "Edicion",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (rta == DialogResult.Yes)
                {
                    tsbGuardarCambiosEditarProducto_Click(null, null);
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
                        e.Cancel = false;
                    }
                    else
                        e.Cancel = true;
                }
                else
                {
                    if (rta == DialogResult.No)
                    {
                        e.Cancel = false;
                    }
                    else
                    {
                        e.Cancel = true;
                    }
                }
            }
            CompletaEventos.CapturaEventom(false);
        }

        private void lkGenerarCodigo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtCodigo.Text = Convert.ToString(
                    miBussinesProducto.CapturarCodigoInterno());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtCodigo_Validating(null, null);
        }

        private void lkGenerarBarras_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtBarras.Text = miBussinesProducto.CapturarCodbarras();
                this.txtBarras_Validating(this.txtBarras, new CancelEventArgs(false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            if (!Extencion)
            {
                DialogResult rta = MessageBox.Show("¿Desea editar la Categoria?", "Edición Producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var frmCategoria = new Categoria.FrmCategoriaNuevo();
                    frmCategoria.Extension = true;
                    this.Extencion = true;
                    frmCategoria.MdiParent = this.MdiParent;
                    frmCategoria.Show();
                }
                else
                {
                    this.btnBuscarMarca.Focus();
                }
            }
            /*Categoria.FrmCategoria frmCategoria = new Categoria.FrmCategoria();
            frmCategoria.TblCategoria.SelectTab(1);
            frmCategoria.CargarGridCategorias();
            frmCategoria.Extencion = true;
            frmCategoria.Show();*/
        }

        private void btnBuscarMarca_Click(object sender, EventArgs e)
        {
            if (!this.Extencion)
            {
                DialogResult rta = MessageBox.Show("¿Desea editar la Marca?", "Edición Producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rta.Equals(DialogResult.Yes))
                {
                    var frmMarca = new Configuracion.Marcas.FrmMarcaNuevo();
                    frmMarca.Extension = true;
                    this.Extencion = true;
                    frmMarca.MdiParent = this.MdiParent;
                    frmMarca.Show();
                }
                else
                {
                    this.txtDescripcion.Focus();
                }
            }
            /*frmMarca cargamarca = new frmMarca();
            cargamarca.Extension = true;
            cargamarca.CargaGrillaMarca();
            cargamarca.Show();*/
        }

        private void txtValorCosto_KeyUp(object sender, KeyEventArgs e)
        {
            this.txtUtilidad_KeyUp(this.txtUtilidad, null);
        }

        private void txtUtilidad_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                var utilidad = txtUtilidad.Text.Replace(',', '.');
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (validacion.ValidarNumeroDecima(utilidad))
                {
                    miError.SetError(txtUtilidad, null);
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
                                precioUtil = UseObject.RemoveSeparatorMil(costo) / ((100 -
                                             Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
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

                        precioVenta = UseObject.Aproximar(precioVenta, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                        txtValorVenta.Text = precioVenta.ToString();

                        utilidadMatch = true;
                    }
                    else
                    {
                        miError.SetError(txtValorCosto, "El valor que ingreso es invalido.");
                        utilidadMatch = false;
                    }
                }
                else
                {
                    miError.SetError(txtUtilidad, "El valor que ingreso es invalido.");
                    utilidadMatch = false;
                }
                this.txtDesctoMayor_KeyUp(this.txtDesctoMayor, null);
                this.txtDesctoDistribuidor_KeyUp(this.txtDesctoDistribuidor, null);

               /* var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                var utilidad = txtUtilidad.Text;
                var costo = txtValorCosto.Text;
                if (String.IsNullOrEmpty(utilidad))
                {
                    utilidad = "0";
                }
                if (validacion.ValidarNumeroDecima(utilidad))
                {
                    miError.SetError(txtUtilidad, null);
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
                                precioUtil = UseObject.RemoveSeparatorMil(costo) / ((100 -
                                             Convert.ToDouble(utilidad.Replace('.', ','))) / 100);
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
                        precioVenta = UseObject.Aproximar(precioVenta, Convert.ToBoolean(AppConfiguracion.ValorSeccion("tipo_aprox_precio")));
                        txtValorVenta.Text = precioVenta.ToString();

                        utilidadMatch = true;
                    }
                    else
                    {
                        miError.SetError(txtValorCosto, "El valor que ingreso es invalido.");
                        utilidadMatch = false;
                    }
                }
                else
                {
                    miError.SetError(txtUtilidad, "El valor que ingreso es invalido.");
                    utilidadMatch = false;
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void cbIvaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!txtValorCosto.Text.Equals("0") || String.IsNullOrEmpty(txtValorCosto.Text))
            {
                this.txtUtilidad_KeyUp(this.txtUtilidad, null);
            }
        }

        private void btnEditarAplicaPrecio_Click(object sender, EventArgs e)
        {
            txtAplicaPrecio.Visible = false;
            cbAplicarPrecio.Visible = true;
            btnEditarAplicaPrecio.Enabled = false;
            cbAplicarPrecio.Focus();
        }

        private void txtDesctoMayor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = txtValorVenta.Text;
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

        private void txtDesctoDistribuidor_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var precioVenta = txtValorVenta.Text;
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

        private void txtValorVenta_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                var venta = txtValorVenta.Text;
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
                    miError.SetError(txtValorVenta, null);
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
                    txtUtilidad.Text = Math.Round(util, 1).ToString();
                    valorVentaMatch = true;
                }
                else
                {
                    miError.SetError(txtValorVenta, "El valor que ingreso es invalido.");
                    valorVentaMatch = false;
                }


                /*
                var empresa = miBussinesEmpresa.ObtenerEmpresa();
                var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                var venta = txtValorVenta.Text;
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
                    miError.SetError(txtValorVenta, null);
                    var valorCosto = 0;
                    if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoMasIva")))
                    {
                        valorCosto = Convert.ToInt32(
                            Convert.ToInt32(costo) / (1 + (valorIva / 100)));
                    }
                    else
                    {
                        valorCosto = Convert.ToInt32(costo);
                    }
                    //var valorCosto = Convert.ToInt32(costo);

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
                    txtUtilidad.Text = Math.Round(util, 1).ToString();
                    valorVentaMatch = true;
                }
                else
                {
                    miError.SetError(txtValorVenta, "El valor que ingreso es invalido.");
                    valorVentaMatch = false;
                }*/



                /*var valorIva = ((Iva)cbIvaEditar.SelectedItem).PorcentajeIva;
                var venta = txtValorVenta.Text;
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
                    miError.SetError(txtValorVenta, null);
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
                    txtUtilidad.Text = util.ToString();
                    valorVentaMatch = true;
                }
                else
                {
                    miError.SetError(txtValorVenta, "El  valor que ingreso es invalido.");
                }*/
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnEditarIva_Click(object sender, EventArgs e)
        {
            txtIva.Visible = false;
            cbIvaEditar.Visible = true;
            btnEditarIva.Enabled = false;
            cbIvaEditar.Focus();
        }

        private void dgvMedida_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvMedida.RowCount != 0)
            {
                var idMedida = (int)dgvMedida.CurrentRow.Cells["IdMedida"].Value;
                try
                {
                    dgvColor.DataSource = miBussinesProducto.ProductoConMedidaYcolor(CodigoProducto, idMedida);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            else
                dgvColor.DataSource = null;
        }

        private void dgvMedida_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up || e.KeyData == Keys.Down)
            {
                dgvMedida_CellClick(null, null);
            }
        }

        private void btnAddMedida_Click(object sender, EventArgs e)
        {
            if (dgvMedida.RowCount == 0)
            {
                dgvColor.Visible = false;
                btnAddColor.Visible = false;
                btnEliminarColor.Visible = false;

                CargarUnidadMedida();
                CargarListBoxTallas();
                gbSeleccionarMedida.Visible = true;
                dgvListaMedida.Visible = false;

                gbSeleccionarMedida.Size = new Size(320, 246);
                gbSeleccionarMedida.Controls.Add(lbUnidadMedida);
                gbSeleccionarMedida.Controls.Add(lbValorMedida);
                gbSeleccionarMedida.Controls.Add(lstbTalla);
                gbSeleccionarMedida.Controls.Add(rbtnTalla);
                gbSeleccionarMedida.Controls.Add(rbtnUnidadMedida);

                lbUnidadMedida.Size = new Size(100, 175);
                lbUnidadMedida.Location = new Point(16, 65);
                lbUnidadMedida.Visible = true;

                lbValorMedida.Size = new Size(100, 175);
                lbValorMedida.Location = new Point(128, 65);
                lbValorMedida.Visible = true;

                lstbTalla.Size = new Size(60, 175);
                lstbTalla.Location = new Point(250, 65);
                lstbTalla.Visible = true;
                lstbTalla.Enabled = false;

                rbtnUnidadMedida.Location = new Point(16, 40);
                rbtnUnidadMedida.Visible = true;
                rbtnUnidadMedida.Checked = true;

                rbtnTalla.Location = new Point(250, 40);
                rbtnTalla.Visible = true;
            }
            else
            {
                if (ProductoOriginal.AplicaTalla)
                {
                    CargarTallas();
                    dgvListaMedida.Visible = true;
                    gbSeleccionarMedida.Visible = true;
                    lbUnidadMedida.Visible = false;
                    lbValorMedida.Visible = false;
                    lstbTalla.Visible = false;
                    rbtnTalla.Visible = false;
                    rbtnUnidadMedida.Visible = false;
                }
                else
                {
                    OptionPane.MessageError
                        ("No se puede agregar mas de una medida al producto.");
                }
            }
        }

        private void btnEliminarMedida_Click(object sender, EventArgs e)
        {
            if (dgvColor.RowCount == 0)
            {
                if (dgvMedida.RowCount != 0)
                {
                    DialogResult result = MessageBox.Show("Esta seguro que quiere eliminar el registro?", "Producto",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        var idMedida = (int)dgvMedida.CurrentRow.Cells[0].Value;
                        var inventario = new DTO.Clases.Inventario();
                        inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                        inventario.IdMedida = idMedida;
                        try
                        {
                            if (miBussinesInventario.EliminarInventario(inventario))
                            {
                                miBussinesMedida.EliminarProductoMedida(ProductoOriginal.CodigoInternoProducto, idMedida);
                                CargarMedida();
                                dgvMedida_CellClick(null, null);
                            }
                            else
                            {
                                OptionPane.MessageError
                                    ("El registro no se puede eliminar porque aun se encuentra en inventario.");
                            }
                        }
                        catch (InvalidCastException)
                        {
                            miBussinesMedida.EliminarProductoMedida(ProductoOriginal.CodigoInternoProducto, idMedida);
                            CargarMedida();
                            dgvMedida_CellClick(null, null);
                            //OptionPane.MessageError(ex.Message);
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation
                    ("Debe eliminar todos los colores asociados a la medida.");
            }
            if (dgvMedida.RowCount == 0)
            {
                ProductoEditado.AplicaTalla = false;
            }
        }

        private void btnElegirMedida_Click(object sender, EventArgs e)
        {
            int idSelect = 0;
            if (dgvMedida.RowCount != 0) //Selecciona Talla.
            {
                foreach (DataGridViewRow row in dgvListaMedida.SelectedRows)
                {
                    var existe = true;
                    foreach (DataGridViewRow row_ in dgvMedida.Rows)
                    {
                        idSelect = (int)row.Cells[0].Value;
                        var id = (int)row_.Cells[0].Value;
                        if (idSelect == id)
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
                        var inventario = new DTO.Clases.Inventario();
                        inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                        inventario.IdMedida = idSelect;
                        var medida = new ValorUnidadMedida();
                        medida.CodigoInternoProducto = ProductoOriginal.CodigoInternoProducto;
                        medida.IdValorUnidadMedida = idSelect;
                        try
                        {
                            //miBussinesInventario.InsertarInventario(inventario);
                            miBussinesMedida.InsertarMedidaProducto(medida);
                        }
                        catch (Exception ex)
                        {
                            OptionPane.MessageError(ex.Message);
                        }
                    }
                }
            }
            else
            {
                int idMedida = 0;
                var inventario = new DTO.Clases.Inventario();
                inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                if (rbtnUnidadMedida.Checked)
                {
                    idMedida = Convert.ToInt32(lbValorMedida.SelectedValue);
                    ProductoOriginal.AplicaTalla = false;
                }
                else
                {
                    idMedida = Convert.ToInt32(lstbTalla.SelectedValue);
                    ProductoOriginal.AplicaTalla = true;
                }
                inventario.IdMedida = idMedida;
                var medida = new ValorUnidadMedida();
                medida.CodigoInternoProducto = ProductoOriginal.CodigoInternoProducto;
                medida.IdValorUnidadMedida = idMedida;
                try
                {
                    //miBussinesInventario.InsertarInventario(inventario);
                    miBussinesMedida.InsertarMedidaProducto(medida);
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
            CargarMedida();
            dgvMedida_CellClick(null, null);
            gbSeleccionarMedida.Visible = false;
            dgvColor.Visible = true;
            btnAddColor.Visible = true;
            btnEliminarColor.Visible = true;
        }

        private void btnCancelarMedida_Click(object sender, EventArgs e)
        {
            gbSeleccionarMedida.Visible = false;
            dgvColor.Visible = true;
            btnAddColor.Visible = true;
            btnEliminarColor.Visible = true;
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            gbSelecionarColor.Visible = true;
            CargarGridColor();
        }

        private void btnEliminarColor_Click(object sender, EventArgs e)
        {
            if (dgvColor.RowCount != 0)
            {
                DialogResult result = MessageBox.Show("Esta seguro que quiere eliminar el registro?", "Producto",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //OptionPane.MessageInformation("Si es el ultimo color del registro se eliminara su medida relacionada.");
                var r = dgvColor.RowCount;
                if (result == DialogResult.Yes)
                {
                    var idColor = (int)dgvColor.CurrentRow.Cells[0].Value;
                    var idMedida = (int)dgvMedida.CurrentRow.Cells[0].Value;
                    var inventario = new DTO.Clases.Inventario();
                    inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                    inventario.IdMedida = idMedida;
                    inventario.IdColor = idColor;
                    try
                    {
                        miBussinesInventario.ActualizarInventario(inventario);
                        CargarMedida();
                        dgvMedida_CellClick(null, null);
                        /*if (miBussinesInventario.EliminarInventario(inventario))
                        {
                            if (dgvColor.RowCount == 1)
                            {
                                /*miBussinesMedida.EliminarProductoMedida
                                    (ProductoOriginal.CodigoInternoProducto,
                                      Convert.ToInt32(dgvMedida.CurrentRow.Cells[0].Value));
                            }
                            CargarMedida();
                            dgvMedida_CellClick(null, null);
                        }
                        else
                        {
                            OptionPane.MessageError
                                ("El registro no se puede eliminar porque aun se encuentra en inventario.");
                        }*/
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
            if (dgvColor.RowCount == 1)
            {
                ProductoEditado.AplicaColor = false;
            }
            if (dgvMedida.RowCount == 1)
            {
                ProductoEditado.AplicaTalla = false;
            }
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            var miColor = new ElColor();
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
                        OptionPane.MessageError(ex.Message);
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
            int idSelect = 0;
            if (dgvColor.RowCount != 0)
            {
                foreach (DataGridViewRow row in dgvListaColor.SelectedRows)
                {
                    var existe = true;
                    foreach (DataGridViewRow row_ in dgvColor.Rows)
                    {
                        idSelect = (int)row.Cells[0].Value;
                        var id = (int)row_.Cells[0].Value;
                        if (idSelect == id)
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
                        var inventario = new DTO.Clases.Inventario();
                        inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                        inventario.IdMedida = (int)dgvMedida.CurrentRow.Cells[0].Value;
                        inventario.IdColor = idSelect;
                        miBussinesInventario.InsertarInventario(inventario);
                        dgvMedida_CellClick(null, null);
                    }
                }
            }
            else
            {
                var inventario = new DTO.Clases.Inventario();
                inventario.CodigoProducto = ProductoOriginal.CodigoInternoProducto;
                inventario.IdMedida = (int)dgvMedida.CurrentRow.Cells[0].Value;
                inventario.IdColor = (int)dgvListaColor.CurrentRow.Cells[0].Value;
                miBussinesInventario.InsertarInventario(inventario);
                dgvMedida_CellClick(null, null);
            }
        }

        private void btnCancelarColor_Click(object sender, EventArgs e)
        {
            gbSelecionarColor.Visible = false;
        }

        /// <summary>
        /// Carga los datos del producto a editar en el formulario.
        /// </summary>
        private void CargarProductoAEditar()
        {
            try
            {
                this.ProductoOriginal = this.miBussinesProducto.ProductoCompleto(CodigoProducto);
                CargarIva();
                this.txtCodigo.Text = this.ProductoOriginal.CodigoInternoProducto;
                this.txtBarras.Text = this.ProductoOriginal.CodigoBarrasProducto;
                this.txtReferencia.Text = this.ProductoOriginal.ReferenciaProducto;
                this.txtCodigo_2.Text = this.ProductoOriginal.Codigo_2;
                this.txtCodigo_3.Text = this.ProductoOriginal.Codigo_3;
                this.txtCodigo_4.Text = this.ProductoOriginal.Codigo_4;
                this.txtCodigo_5.Text = this.ProductoOriginal.Codigo_5;
                this.txtCodigo_6.Text = this.ProductoOriginal.Codigo_6;
                this.txtCodigo_7.Text = this.ProductoOriginal.Codigo_7;
                this.txtNombre.Text = ProductoOriginal.NombreProducto;
                this.cbCuentaContable.SelectedValue = ProductoOriginal.DescripcionProducto;
                this.txtDescripcion.Text = ProductoOriginal.DescripcionProducto;
                this.CodigoCategoria = ProductoOriginal.CodigoCategoria;
                this.txtCategoria.Text = ProductoOriginal.NombreCategoria;
                this.IdMarca = ProductoOriginal.IdMarca;
                this.txtMarca.Text = ProductoOriginal.NombreMarca;
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva")))
                {
                    this.txtValorCosto.Text = Convert.ToInt32(ProductoOriginal.ValorCosto + 
                        (ProductoOriginal.ValorCosto * ProductoOriginal.ValorIva / 100)).ToString();
                }
                else
                {
                    this.txtValorCosto.Text = ProductoOriginal.ValorCosto.ToString();
                }


                this.txtUtilidad.Text = ProductoOriginal.UtilidadPorcentualProducto.ToString();
                this.txtValorVenta.Text = ProductoOriginal.ValorVentaProducto.ToString();
                if (ProductoOriginal.CantidadDecimal)
                {
                    this.chkCantDecimal.Checked = true;
                }
                //CargarDescuentos();
                //CargarRecargos();
                this.CargarAplicaPrecio();
                this.txtDesctoMayor.Text = this.ProductoOriginal.DescuentoMayor.ToString();
                this.txtDesctoMayor_KeyUp(this.txtDesctoMayor, null);
                this.txtDesctoDistribuidor.Text = this.ProductoOriginal.DescuentoDistribuidor.ToString();
                this.txtDesctoDistribuidor_KeyUp(this.txtDesctoDistribuidor, null);
                //CargarIva();
                this.txtUnidadVenta.Text = ProductoOriginal.UnidadVentaProducto.ToString();
                this.txtCantMinima.Text = ProductoOriginal.CantidadMinimaProducto.ToString();
                this.txtCantMaxima.Text = ProductoOriginal.CantidadMaximaProducto.ToString();
                if (this.ProductoOriginal.EstadoProducto)
                {
                    this.rbActivo.Checked = true;
                }
                else
                {
                    this.rbInactivo.Checked = true;
                }

                cbUnidadesMedida.SelectedValue = miBussinesProducto.ProductoMedida(ProductoOriginal.CodigoInternoProducto).IdValorUnidadMedida;
                cbTipoInventario.SelectedValue = ProductoOriginal.IdTipoInventario;
                if (!String.IsNullOrEmpty(ProductoOriginal.CodProductoProceso))
                {
                    cbProdProceso.SelectedValue = ProductoOriginal.CodProductoProceso;
                }
                //ProductoOriginal.CodigoInternoProducto

                cbTipoInventario_SelectionChangeCommitted(cbTipoInventario, new EventArgs());

                cbValorICO.SelectedValue = ProductoOriginal.IdIco;
                cbAplicaICO.SelectedValue = Convert.ToInt32(ProductoOriginal.AplicaIco);
                cbImprime.SelectedValue = Convert.ToInt32(ProductoOriginal.Imprime);
                cbAplicaDescuento.SelectedValue = Convert.ToInt32(ProductoOriginal.AplicaDescto);

                this.CargarMedida();
                if (this.EnableColor)
                {
                    this.dgvColor.Visible = true;
                    this.btnAddColor.Visible = true;
                    this.btnEliminarColor.Visible = true;
                    this.dgvColor.AutoGenerateColumns = false;
                    //this.dgvMedida_CellClick(null, null);
                }
                miBussinesProducto.EditarInical(ProductoOriginal.CodigoInternoProducto);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga el listado de Descuentos y chekea los usados por el Producto.
        /// </summary>
        private void CargarDescuentos()
        {
            try
            {
                chkLstDescuento.DataSource = miBussinesDescuento.ListadoDescuento();
                chkLstDescuento.DisplayMember = "ValorDescuento";
                chkLstDescuento.ValueMember = "IdDescuento";
                for (int i = 0; i < chkLstDescuento.Items.Count; i++)
                {
                    var decsto = (Descuento)chkLstDescuento.Items[i];
                    foreach (Descuento des in ProductoOriginal.Descuentos)
                    {
                        if (decsto.IdDescuento == des.IdDescuento)
                        {
                            chkLstDescuento.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga el listado de Recargos y chekea los usados por el Producto.
        /// </summary>
        private void CargarRecargos()
        {
            try
            {
                chkLstRecargo.DataSource = miBussinesRecargo.ListadoRecargo();
                chkLstRecargo.DisplayMember = "ValorRecargo";
                chkLstRecargo.ValueMember = "IdRecargo";
                for (int i = 0; i < chkLstRecargo.Items.Count; i++)
                {
                    var recargo = (Recargo)chkLstRecargo.Items[i];
                    foreach (Recargo rec in ProductoOriginal.Recargos)
                    {
                        if (recargo.IdRecargo == rec.IdRecargo)
                        {
                            chkLstRecargo.SetItemChecked(i, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga el ComboBox de aplica precio con las opciones y selecciona la usada por el Producto.
        /// </summary>
        private void CargarAplicaPrecio()
        {
            aplicaPrecio = new AplicarPrecio();
            cbAplicarPrecio.DataSource = aplicaPrecio.lista();
            if (ProductoOriginal.AplicaPrecioPorcentaje)
            {
                txtAplicaPrecio.Text = "Porcentaje";
                cbAplicarPrecio.SelectedValue = 2;
            }
            else
            {
                txtAplicaPrecio.Text = "Valor";
                cbAplicarPrecio.SelectedValue = 1;
            }
        }

        /// <summary>
        /// Carga el ComboBox Iva y selecciona el Iva usado por el Producto.
        /// </summary>
        private void CargarIva()
        {
            try
            {
                cbIvaEditar.DataSource = miBussinesIva.ListadoIva();
                cbIvaEditar.SelectedValue = ProductoOriginal.IdIva;
                txtIva.Text = ((Iva)cbIvaEditar.SelectedItem).ConceptoIva;
                ///txtIva.Text = ProductoOriginal.ValorIva.ToString();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga las medidas de un Producto en el formulario.
        /// </summary>
        private void CargarMedida()
        {
            try
            {
                dgvMedida.AutoGenerateColumns = false;
                dgvMedida.DataSource = miBussinesProducto.ProductoConMedida(ProductoOriginal.CodigoInternoProducto);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Valida de nuevo todos los campos del formulario.
        /// </summary>
        private void ValidacionParaGuardar()
        {
            txtCodigo_Validating(null, null);
            txtBarras_Validating(null, null);
            txtReferencia_Validating(null, null);
            txtCodigo_2_Validating(this.txtCodigo_2, new CancelEventArgs(false));
            txtCodigo_3_Validating(this.txtCodigo_3, new CancelEventArgs(false));
            txtCodigo_4_Validating(this.txtCodigo_4, new CancelEventArgs(false));
            txtCodigo_5_Validating(this.txtCodigo_5, new CancelEventArgs(false));
            txtCodigo_6_Validating(this.txtCodigo_6, new CancelEventArgs(false));
            txtCodigo_7_Validating(this.txtCodigo_7, new CancelEventArgs(false));
            txtNombre_Validating(null, null);
            txtDescripcion_Validating(null, null);
            txtUtilidad_Validating(null, null);
            txtValorVenta_Validating(null, null);
            txtUnidadVenta_Validating(null, null);
            txtCantMinima_Validating(null, null);
            txtCantMaxima_Validating(null, null);
        }

        /// <summary>
        /// Cargar un objeto Producto con los datos del formulario.
        /// </summary>
        private void CargarProducto()
        {
            ProductoEditado.CodigoInternoProducto = ProductoOriginal.CodigoInternoProducto;
            ProductoEditado.CodigoInternoEditado = txtCodigo.Text;
            ProductoEditado.CodigoBarrasProducto = txtBarras.Text;
            ProductoEditado.ReferenciaProducto = txtReferencia.Text;
            ProductoEditado.Codigo_2 = this.txtCodigo_2.Text;
            ProductoEditado.Codigo_3 = this.txtCodigo_3.Text;
            ProductoEditado.Codigo_4 = this.txtCodigo_4.Text;
            ProductoEditado.Codigo_5 = this.txtCodigo_5.Text;
            ProductoEditado.Codigo_6 = this.txtCodigo_6.Text;
            ProductoEditado.Codigo_7 = this.txtCodigo_7.Text;
            ProductoEditado.NombreProducto = txtNombre.Text;
            ProductoEditado.DescripcionProducto = txtDescripcion.Text;
            ProductoEditado.CodigoCategoria = CodigoCategoria;
            ProductoEditado.IdMarca = IdMarca;

            ProductoEditado.IdIco = Convert.ToInt32(cbValorICO.SelectedValue);
            ProductoEditado.AplicaIco = Convert.ToBoolean(cbAplicaICO.SelectedValue);
            ProductoEditado.Imprime = Convert.ToBoolean(cbImprime.SelectedValue);
            ProductoEditado.AplicaDescto = Convert.ToBoolean(cbAplicaDescuento.SelectedValue);

            if (!String.IsNullOrEmpty(this.txtValorCosto.Text))
            {
                if (Convert.ToBoolean(AppConfiguracion.ValorSeccion("costoIva"))) //TRUE indica q el costo si incluye iva
                {
                    ProductoEditado.ValorCosto = Convert.ToInt32(
                        Convert.ToInt32(this.txtValorCosto.Text) / (1 + (((Iva)cbIvaEditar.SelectedItem).PorcentajeIva / 100)));
                }
                else
                {
                    ProductoEditado.ValorCosto = Convert.ToInt32(txtValorCosto.Text);
                }
            }
            //ProductoEditado.ValorCosto = Convert.ToInt32(txtValorCosto.Text);

            ProductoEditado.UtilidadPorcentualProducto = Convert.ToDouble(txtUtilidad.Text.Replace('.', ','));
            ProductoEditado.ValorVentaProducto = Convert.ToInt32(txtValorVenta.Text);
            if(Convert.ToInt32(cbAplicarPrecio.SelectedValue) == 1)
            {
                ProductoEditado.AplicaPrecioPorcentaje = false;
            }
            if(!String.IsNullOrEmpty(txtDesctoMayor.Text))
                ProductoEditado.DescuentoMayor = Convert.ToDouble(txtDesctoMayor.Text.Replace('.', ','));
            if(!String.IsNullOrEmpty(txtDesctoDistribuidor.Text))
                ProductoEditado.DescuentoDistribuidor = Convert.ToDouble(txtDesctoDistribuidor.Text.Replace('.', ','));
            ProductoEditado.IdIva = Convert.ToInt32(cbIvaEditar.SelectedValue);
            ProductoEditado.IdIvaTemp = Convert.ToInt32(cbIvaEditar.SelectedValue);
            LlenarDescuentos();
            ProductoEditado.Descuentos = Descuentos;
            LlenarRecargos();
            ProductoEditado.Recargos = Recargos;
            ProductoEditado.UnidadVentaProducto = Convert.ToInt32(txtUnidadVenta.Text);
            ProductoEditado.CantidadMinimaProducto = Convert.ToInt32(txtCantMinima.Text);
            ProductoEditado.CantidadMaximaProducto = Convert.ToInt32(txtCantMaxima.Text);
            if (rbActivo.Checked)
                ProductoEditado.EstadoProducto = true;
            else
                ProductoEditado.EstadoProducto = false;
            if (dgvMedida.RowCount > 1)
                ProductoEditado.AplicaTalla = true;
            else
                ProductoEditado.AplicaTalla = false;
            if (dgvColor.RowCount != 0)
                ProductoEditado.AplicaColor = true;
            else
                ProductoEditado.AplicaColor = false;
            if (chkCantDecimal.Checked)
                ProductoEditado.CantidadDecimal = true;
            else
                ProductoEditado.CantidadDecimal = false;
        }

        /// <summary>
        /// Carga el listado de Descuentos elegidos por el usuario.
        /// </summary>
        private void LlenarDescuentos()
        {
            Descuentos = new List<Descuento>();
            foreach (Descuento des in chkLstDescuento.CheckedItems)
            {
                Descuentos.Add(des);
            }
        }

        /// <summary>
        /// Carga el listado de Recargos elegidos por el usuario.
        /// </summary>
        private void LlenarRecargos()
        {
            Recargos = new List<Recargo>();
            foreach (Recargo re in chkLstRecargo.CheckedItems)
            {
                Recargos.Add(re);
            }
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                var categoria = (DTO.Clases.Categoria)args.MiMarca;
                CodigoCategoria = categoria.CodigoCategoria;
                txtCategoria.Text = categoria.NombreCategoria;
                this.btnBuscarMarca.Focus();
            }
            catch { }

            try
            {
                var marca = (TransferirMarca)args.MiMarca;
                IdMarca = marca.IdMarca;
                txtMarca.Text = marca.NombreMarca;
                this.txtDescripcion.Focus();
            }
            catch { }

            try
            {
                this.Extencion = (bool)args.MiMarca;
            }
            catch { }
        }

        /// <summary>
        /// Cargar las tallas en el DataGrid.
        /// </summary>
        private void CargarTallas()
        {
            try
            {
                dgvListaMedida.AutoGenerateColumns = false;
                dgvListaMedida.DataSource = miBussinesMedida.ListadoDeTallas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga las unidades de medida en el List Box.
        /// </summary>
        private void CargarUnidadMedida()
        {
            try
            {
                lbUnidadMedida.DataSource = miBussinesUnidad.ListadoUnidadMedidaNoTalla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Cargar las tallas en el ListBox.
        /// </summary>
        private void CargarListBoxTallas()
        {
            try
            {
                lstbTalla.DataSource = miBussinesMedida.ListadoDeTallas();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void lbUnidadMedida_SelectedValueChanged(object sender, EventArgs e)
        {
            int idMedida = Convert.ToInt32(lbUnidadMedida.SelectedValue);
            CargarValorUnidadMedida(idMedida);
        }

        /// <summary>
        /// Carga los Valores de las unidades de medida segun la medida en el List Box.
        /// </summary>
        /// <param name="idUnidadMedida">Id de la Unidad de Medida a Cargar.</param>
        private void CargarValorUnidadMedida(int idUnidadMedida)
        {
            try
            {
                lbValorMedida.DataSource =
                    miBussinesMedida.ListadoValorUnidadMedida(idUnidadMedida);
                /*if (!EnableColor)
                {
                    lbValorMedida.SelectionMode = SelectionMode.One;
                }*/
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

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
                ProductoEditado.AplicaTalla = false;
            }
        }

        private void rbtnTalla_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnTalla.Checked)
            {
                lstbTalla.Enabled = true;
                lbUnidadMedida.Enabled = false;
                lbValorMedida.Enabled = false;
                ProductoEditado.AplicaTalla = true;
            }
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(this.txtCodigo, this.miError, codigoRequerido))
            {
                this.codigoMatch = this.ValidarCodigo(this.txtCodigo, this.ProductoOriginal.CodigoInternoProducto);
            }
            else
            {
                this.codigoMatch = false;
            }
            /*if (!Validacion.EsVacio(txtCodigo, miError, codigoRequerido))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.LetrasGuionNumeros, txtCodigo, miError, codigoFormato))
                {
                    var codigoTemp = txtCodigo.Text;
                    if (ExisteCodigo(txtCodigo.Text) && codigoTemp != ProductoOriginal.CodigoInternoProducto)
                    {
                        codigoMatch = false;
                        miError.SetError(txtCodigo, codigoExiste);
                    }
                    else
                    {
                        codigoMatch = true;
                        miError.SetError(txtCodigo, null);
                    }
                }
                else
                    codigoMatch = false;
            }
            else
                codigoMatch = false;*/
        }

        private void txtBarras_Validating(object sender, CancelEventArgs e)
        {
            this.barraMatch = this.ValidarCodigo(this.txtBarras, this.ProductoOriginal.CodigoBarrasProducto);
            /*if (!Validacion.EsVacio(txtBarras, miError, "El codigo de Barras es Requerido"))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumeroGuion, txtBarras, miError, barraFormato))
                {
                    if (ExisteCodigoBarras(txtBarras.Text) && txtBarras.Text != ProductoOriginal.CodigoBarrasProducto)
                    {
                        miError.SetError(txtBarras, barrasExiste);
                        barraMatch = false;
                    }
                    else
                    {
                        miError.SetError(txtBarras, null);
                        barraMatch = true;
                    }
                }
                else
                    barraMatch = false;
            }
            else
                barraMatch = false;*/
        }

        private void txtReferencia_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtReferencia.Text))
            {
                /* if (Validacion.ConFormato
                     (Validacion.TipoValidacion.LetrasGuionNumeros, txtReferencia, miError, referenciaFormato))
                 {*/
                referenciaMatch = true;
                /* }
                 else
                     referenciaMatch = false;*/
            }
            else
                referenciaMatch = true;
        }

        private void txtCodigo_2_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_2Match = this.ValidarCodigo(this.txtCodigo_2, this.ProductoOriginal.Codigo_2);
        }

        private void txtCodigo_3_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_3Match = this.ValidarCodigo(this.txtCodigo_3, this.ProductoOriginal.Codigo_3);
        }

        private void txtCodigo_4_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_4Match = this.ValidarCodigo(this.txtCodigo_4, this.ProductoOriginal.Codigo_4);
        }

        private void txtCodigo_5_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_5Match = this.ValidarCodigo(this.txtCodigo_5, this.ProductoOriginal.Codigo_5);
        }

        private void txtCodigo_6_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_6Match = this.ValidarCodigo(this.txtCodigo_6, this.ProductoOriginal.Codigo_6);
        }

        private void txtCodigo_7_Validating(object sender, CancelEventArgs e)
        {
            this.codigo_7Match = this.ValidarCodigo(this.txtCodigo_7, this.ProductoOriginal.Codigo_7);
        }

        private void txtNombre_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNombre, miError, nombreRequerido))
            {
               /* if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtNombre, miError, nombreFormato))
                {*/
                    nombreMatch = true;
               /* }
                else
                    nombreMatch = false;*/
            }
            else
                nombreMatch = false;
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtDescripcion.Text))
            {
               /* if (Validacion.ConFormato
                    (Validacion.TipoValidacion.PalabrasNumeroCaracter, txtDescripcion, miError, descripcionFormato))
                {*/
                    descripcionMatch = true;
                /*}
                else
                    descripcionMatch = false;*/
            }
            else
                descripcionMatch = true;
        }

        private void txtUtilidad_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUtilidad.Text))
            {
                txtUtilidad.Text = txtUtilidad.Text.Replace(',', '.');
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.NumerosYPunto, txtUtilidad, miError, utilidadFormato))
                {
                    utilidadMatch = true;
                }
                else
                    utilidadMatch = false;
            }
            else
                utilidadMatch = true;
        }

        private void txtValorVenta_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorVenta, miError, valorVentaRequerido))
            {
                txtUtilidad.Text = txtUtilidad.Text.Replace(',', '.');
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtValorVenta, miError, valorVentaFormato))
                {
                    valorVentaMatch = true;
                }
                else
                    valorVentaMatch = false;
            }
            else
                valorVentaMatch = false;
        }

        private void txtUnidadVenta_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtUnidadVenta.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtUnidadVenta, miError, presentacionFormato))
                {
                    presentacionMatch = true;
                }
                else
                    presentacionMatch = false;
            }
            else
                presentacionMatch = true;
        }

        private void txtCantMinima_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantMinima.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCantMinima, miError, minimaFormato))
                {
                    minimaMatch = true;
                }
                else
                    minimaMatch = false;
            }
            else
                minimaMatch = true;
        }

        private void txtCantMaxima_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCantMaxima.Text))
            {
                if (Validacion.ConFormato
                    (Validacion.TipoValidacion.Numeros, txtCantMaxima, miError, maximaFormato))
                {
                    maximaMatch = true;
                }
                else
                    maximaMatch = false;
            }
            else
                maximaMatch = true;
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
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Crea un directorio para la pertinencia temporal de archivos.
        /// </summary>
        private void CrearDirectorio()
        {
            if (!System.IO.Directory.Exists(folder))
            {
                System.IO.Directory.CreateDirectory(folder);
                System.IO.File.SetAttributes
                    (folder, System.IO.FileAttributes.Hidden);
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
                OptionPane.MessageError("Ocurrio un error al cargar el Color.");
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
                OptionPane.MessageError(ex.Message);
                return false;
            }
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
                return miBussinesProducto.ExisteCodigo(codigo);
            }
            catch (Exception ex)
            {
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
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        private bool ValidarCodigo(Control c, string codeSave)
        {
            var valida = true;
            if (!String.IsNullOrEmpty(c.Text))
            {
                if (this.ExisteCodigo(c.Text) && c.Text != codeSave)
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
            else
            {
                this.miError.SetError(c, null);
            }
            return valida;
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtBarras.Focus();
            }
        }

        private void txtBarras_KeyPress(object sender, KeyPressEventArgs e)
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
                this.txtNombre.Focus();
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
                this.txtNombre.Focus();
            }
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
               // this.txtDescripcion.Focus();
                this.txtNombre.Text = this.txtNombre.Text.ToUpper();
                this.btnBuscarCategoria.Focus();
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValorCosto.Focus();
            }
        }

        private void txtValorCosto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtUtilidad.Focus();
            }
        }

        private void txtUtilidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                if (this.cbIvaEditar.Visible)
                {
                    this.cbIvaEditar.Focus();
                }
                else
                {
                    this.btnEditarIva.Focus();
                }
            }
        }

        private void cbIvaEditar_Enter(object sender, EventArgs e)
        {
            cbIvaEditar.DroppedDown = true;
        }

        private void cbIvaEditar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtValorVenta.Focus();
            }
        }

        private void txtValorVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.chkCantDecimal.Focus();
            }
        }

        private void chkCantDecimal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDesctoMayor.Focus();
            }
        }

        private void txtDesctoMayor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtDesctoDistribuidor.Focus();
            }
        }

        private void txtDesctoDistribuidor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtUnidadVenta.Focus();
            }
        }

        private void txtUnidadVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCantMinima.Focus();
            }
        }

        private void txtCantMinima_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                this.txtCantMaxima.Focus();
            }
        }

        private void txtCantMaxima_KeyPress(object sender, KeyPressEventArgs e)
        {
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
                cbProdProceso.SelectedValue = ProductoOriginal.CodProductoProceso;
            }
        }

        private void cbCuentaContable_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (cbCuentaContable.SelectedIndex != 0)
            {
                txtDescripcion.Text = cbCuentaContable.SelectedValue.ToString();
            }
            else
            {
                txtDescripcion.Text = "";
            }
        }
    }
}