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
using CustomControl;
using Utilities;

namespace Aplicacion.Compras.IngresarCompra
{
    public partial class FrmEditarProducto : Form
    {
        #region Propiedades

        public int IdRegimen { set; get; }

        public bool EsFactura { set; get; }

        public string NoFactura { set; get; }

        /// <summary>
        /// Obtiene o establece el registro del Producto de Factura a editar.
        /// </summary>
        public ProductoFacturaProveedor ProductoFactura { set; get; }

        /// <summary>
        /// Representa a un objeto de logica de negocio de Factura Proveedor.
        /// </summary>
        private BussinesFacturaProveedor miBussinesFacturaProveedor;

        private BussinesRemision miBussinesRemision;

        private BussinesKardex miBussineskardex;

        private Kardex Kardex { set; get; }

        /// <summary>
        /// Obtiene o establece el Color del Producto a editar.
        /// </summary>
        public Image ImageColor { set; get; }

        /// <summary>
        /// Obtiene o establece el valor del Id de la Medida.
        /// </summary>
        private int IdMedida;

        /// <summary>
        /// Obtiene o establece el valor del Id del Color.
        /// </summary>
        private int IdColor;

        /// <summary>
        /// Obtiene o establece el valor del descuento de la Factura.
        /// </summary>
        public double DesctoFactura { set; get; }

        /// <summary>
        /// Objeto que encapsula la lógica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita color o no en el formulario segun la configuración.
        /// </summary>
        private bool EnableColor { set; get; }

        private double Cantidad { set; get; }

        #endregion

        #region Validación

        /// <summary>
        /// Obtiene o establece la condición que indica si ha cerrado el formulario.
        /// </summary>
        private bool PressClosing = false;

        /// <summary>
        /// Establece la regla de validacion que indica si el campo Cantidad es valido.
        /// </summary>
        private bool CantidadMatch = true;

        /// <summary>
        /// Establece la regla de validacion que indica si el campo Valor es valido.
        /// </summary>
        private bool ValorMatch = true;

        /// <summary>
        /// Establece la regla de validadcion que indica si el campo Lote es valido.
        /// </summary>
        private bool LoteMatch = true;

        /// <summary>
        /// Establece la regla de validación que indica si el campo Descuento por Producto es válido.
        /// </summary>
        private bool DesctoProductoMatch = true;

        /// <summary>
        /// Objeto que muestra mensajes de error.
        /// </summary>
        private ErrorProvider MiError;

        /// <summary>
        /// Representa el texto: El campo Cantidad es requerido.
        /// </summary>
        private const string CantidadReq = "El campo Cantidad es requerido.";

        /// <summary>
        /// Representa el texto: El campo Cantidad tiene formato incorrecto.
        /// </summary>
        private const string CantidadFormato = "El campo Cantidad tiene formato incorrecto.";

        /// <summary>
        /// Representa el texto: El campo Valor Unitario es requerido.
        /// </summary>
        private const string ValorReq = "El campo Valor Unitario es requerido.";

        /// <summary>
        /// Representa el texto: El campo Valor Unitario tiene formato incorrecto. 
        /// </summary>
        private const string ValorFormato = "El campo Valor Unitario tiene formato incorrecto. ";

        /// <summary>
        /// Representa El mensaje. El Número de lote que ingreso tiene formato incorrecto.
        /// </summary>
        private const string LoteFormat = "El Número de lote que ingreso tiene formato incorrecto.";

        #endregion

        public FrmEditarProducto()
        {
            InitializeComponent();
            EsFactura = true;
            this.NoFactura = "";
            IdRegimen = 0;
            EnableColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            miBussinesProducto = new BussinesProducto();
            miBussinesFacturaProveedor = new BussinesFacturaProveedor();
            miBussinesRemision = new BussinesRemision();
            miBussineskardex = new BussinesKardex();
            Kardex = new Kardex();
            MiError = new ErrorProvider();
        }

        private void FrmEditarProducto_Load(object sender, EventArgs e)
        {
            CargarDatos();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
        }

        private void FrmEditarProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsGuardar_Click(this.tsGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void FrmEditarProducto_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro que desea salir?",
                "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                //PressClosing = true;
                CompletaEventos.CapturaEvento(false);
            }
            else
            {
                e.Cancel = true;
                CompletaEventos.CapturaEvento("3");
            }


           /* DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?",
                "Información", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                PressClosing = true;
                tsGuardar_Click(null, null);
                if (CantidadMatch && ValorMatch && LoteMatch)
                {
                    e.Cancel = false;
                    CompletaEventos.CapturaEvento(false);
                }
                else
                    e.Cancel = true;
            }
            else
            {
                if (rta == DialogResult.No)
                {
                    e.Cancel = false;
                    CompletaEventos.CapturaEvento("3");
                }
                else
                {
                    e.Cancel = true;
                }
            }*/
        }

        private void tsGuardar_Click(object sender, EventArgs e)
        {
            DialogResult rta;
           // if (!PressClosing)
           // {
                rta = MessageBox.Show("¿Está seguro de guardar los cambios?",
                    "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
           /* }
            else
            {
                rta = DialogResult.Yes;
            }*/
            if (rta == DialogResult.Yes)
            {
                txtCantidad_Validating(null, null);
                txtValorUnitario_Validating(null, null);
                txtLote_Validating(null, null);
                if (CantidadMatch && ValorMatch && LoteMatch && DesctoProductoMatch)
                {
                    var producto = new ProductoFacturaProveedor();
                    producto.Id = ProductoFactura.Id;
                    producto.IdFactura = ProductoFactura.IdFactura;
                    producto.Producto.IdTipoInventario = ProductoFactura.Producto.IdTipoInventario;
                    producto.Producto.CodigoInternoProducto = ProductoFactura.Producto.CodigoInternoProducto;
                    producto.Inventario.IdMedida = IdMedida;
                    producto.Inventario.IdColor = IdColor;
                    producto.Cantidad = Convert.ToDouble(txtCantidad.Text);
                    producto.Inventario.Cantidad = ProductoFactura.Cantidad;
                    if (this.chkIva.Checked)
                    {
                        producto.Producto.ValorVentaProducto = Math.Round((Convert.ToDouble(txtValorUnitario.Text.Replace('.', ',')) /
                            (1 + (ProductoFactura.Producto.ValorIva / 100))), 2);
                    }
                    else
                    {
                        producto.Producto.ValorVentaProducto = Convert.ToDouble(txtValorUnitario.Text.Replace('.', ','));
                    }
                    if (String.IsNullOrEmpty(txtLote.Text))
                    {
                        txtLote.Text = ProductoFactura.Lote.Numero;
                        producto.Lote.Id = ProductoFactura.Lote.Id;
                    }
                    else
                    {
                        if (ProductoFactura.Lote.Numero != txtLote.Text)
                        {
                            producto.Lote.Numero = txtLote.Text;
                            producto.Lote.Id = 0;
                            producto.Lote.CodigoProducto = txtCodigoArticulo.Text;
                            producto.Lote.Fecha = ProductoFactura.Lote.Fecha;
                        }
                        else
                        {
                            producto.Lote.Id = ProductoFactura.Lote.Id;
                        }
                    }
                    producto.Producto.ValorIva = ProductoFactura.Producto.ValorIva;
                    producto.Producto.Descuento = Convert.ToDouble(txtDescuentoProducto.Text.Replace('.', ','));
                    try
                    {
                        var actInventario = true;
                        if (producto.Cantidad == this.Cantidad)
                        {
                            actInventario = false;
                        }
                        if (EsFactura) // Factura Proveedor
                        {
                            //miBussinesFacturaProveedor.EditarProductoFacturaProveedor(producto);
                            miBussinesFacturaProveedor.EditarProductoFacturaProveedor(producto, actInventario);

                            Kardex.Cantidad = producto.Cantidad - this.Cantidad;
                            if (Kardex.Cantidad < 0)  // cantidad negativa
                            {
                                Kardex.IdConcepto = 14;
                                Kardex.Cantidad *= -1;
                            }
                            else
                            {
                                Kardex.IdConcepto = 5;
                            }
                        }
                        else  // Remision Proveedor
                        {
                            //miBussinesRemision.EditarProductoRemisionProveedor(producto);
                            miBussinesRemision.EditarProductoRemisionProveedor(producto, actInventario);

                            Kardex.Cantidad = producto.Cantidad - this.Cantidad;
                            if (Kardex.Cantidad < 0)
                            {
                                Kardex.IdConcepto = 15;
                                Kardex.Cantidad *= -1;
                            }
                            else
                            {
                                Kardex.IdConcepto = 6;
                            }
                        }
                        Kardex.Codigo = ProductoFactura.Producto.CodigoInternoProducto;
                        Kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                        Kardex.IdCompra = ProductoFactura.Id;
                        Kardex.NoDocumento = NoFactura;
                        Kardex.Fecha = DateTime.Now;
                        double iva = Math.Round(
                            (producto.Producto.ValorVentaProducto * producto.Producto.ValorIva / 100), 2);
                        Kardex.Valor = producto.Producto.ValorVentaProducto + Convert.ToInt32(iva);
                        Kardex.Total = Kardex.Cantidad * Kardex.Valor;
                        if (actInventario)
                        {
                            miBussineskardex.Insertar(Kardex);
                        }
                        rta = MessageBox.Show("¿Desea actualizar el precio de costo del producto?",
                            "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            this.miBussinesProducto.EditarPrecioDeCosto
                                (producto.Producto.CodigoInternoProducto, producto.Producto.ValorVentaProducto, 0);
                        }
                        OptionPane.MessageInformation("Los datos se han guardado correctamente.");
                        this.Cantidad = producto.Cantidad;
                        ActualizarLote();
                        CompletaEventos.CapturaEvento("2");
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void tsSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTallaYcolor_Click(object sender, EventArgs e)
        {
            if (ProductoFactura != null)
            {
                if (ProductoFactura.Producto.AplicaTalla || ProductoFactura.Producto.AplicaColor)
                {
                    Inventario.Agrupacion.frmListarProducto listaProducto =
                        new Inventario.Agrupacion.frmListarProducto();
                    listaProducto.MdiParent = this.MdiParent;
                    listaProducto.CargarProducto(ProductoFactura.Producto.CodigoInternoProducto);
                    listaProducto.Show();
                }
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCantidad, MiError, CantidadReq))
            {
                txtCantidad.Text = txtCantidad.Text.Replace(',', '.');
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                    txtCantidad, MiError, CantidadFormato))
                {
                    CantidadMatch = true;
                    txtCantidad.Text = txtCantidad.Text.Replace('.', ',');
                }
                else
                    CantidadMatch = false;
            }
            else
                CantidadMatch = false;
        }

        private void txtValorUnitario_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtValorUnitario, MiError, ValorFormato))
            {
                txtValorUnitario.Text = txtValorUnitario.Text.Replace(',', '.');
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                    txtValorUnitario, MiError, ValorFormato))
                {
                    ValorMatch = true;
                    txtValorUnitario.Text = txtValorUnitario.Text.Replace('.', ',');
                }
                else
                    ValorMatch = true;
            }
            else
                ValorMatch = false;
        }

        private void txtLote_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtLote.Text))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.LetrasGuionNumeros,
                    txtLote, MiError, LoteFormat))
                {
                    LoteMatch = true;
                }
                else
                    LoteMatch = false;
            }
            else
                LoteMatch = true;
        }

        private void lkbGenerarLote_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                txtLote.Text = miBussinesFacturaProveedor.ObtenerNumeroLote();
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Carga los datos del Producto a editar en el formulario.
        /// </summary>
        private void CargarDatos()
        {
            var Producto = GetProducto(ProductoFactura.Producto.CodigoInternoProducto);
            ProductoFactura.Producto.AplicaTalla = Producto.AplicaTalla;
            ProductoFactura.Producto.AplicaColor = Producto.AplicaColor;
            if (Producto != null)
            {
                txtCodigoArticulo.Text = ProductoFactura.Producto.CodigoInternoProducto;
                lblDatosProducto.Text = Producto.NombreProducto + " - " + Producto.NombreMarca;
                IdMedida = ProductoFactura.Inventario.IdMedida;
                if (Producto.AplicaTalla)
                {
                    lblMedida.Text = "Talla";
                }
                txtMedida.Text = ProductoFactura.Producto.ValorUnidadMedida;
                if (!EnableColor)
                {
                    lblColor.Visible = false;
                    pbColor.Visible = false;
                }
                IdColor = ProductoFactura.Inventario.IdColor;
                pbColor.Image = ImageColor;
                txtCantidad.Text = ProductoFactura.Cantidad.ToString();
                txtValorUnitario.Text = ProductoFactura.Producto.ValorVentaProducto.ToString();
                txtLote.Text = ProductoFactura.Lote.Numero;
                if (EnableColor && Producto.AplicaColor)
                {
                    btnTallaYcolor.Enabled = true;
                }
                else
                {
                    if (Producto.AplicaTalla)
                    {
                        btnTallaYcolor.Enabled = true;
                    }
                }
                if (DesctoFactura.Equals(0))
                {
                    txtDescuentoProducto.Text = ProductoFactura.Producto.Descuento.ToString().Replace(',', '.');
                }
                else
                {
                    txtDescuentoProducto.ReadOnly = true;
                    txtDescuentoProducto.Text = DesctoFactura.ToString().Replace(',', '.');
                }
            }
            this.Cantidad = ProductoFactura.Cantidad;
        }

        /// <summary>
        /// Obtiene los datos de un registro de Producto.
        /// </summary>
        /// <param name="codigo">Código del producto a consultar.</param>
        /// <returns></returns>
        private Producto GetProducto(string codigo)
        {
            try
            {
                var producto = miBussinesProducto.ProductoBasico(codigo);
                return (Producto)producto[0];
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Termina el proceso de carga de datos desde otro formulario.
        /// </summary>
        /// <param name="args"></param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var tallaYColor = (TallaYcolor)args.MiObjeto;
                if (ProductoFactura.Producto.AplicaTalla)
                {
                    IdMedida = tallaYColor.IdTalla;
                    txtMedida.Text = tallaYColor.Talla;
                }
                if (ProductoFactura.Producto.AplicaColor)
                {
                    IdColor = tallaYColor.IdColor;
                    pbColor.Image = tallaYColor.Color;
                }
            }
            catch { }
        }

        /// <summary>
        /// Actualiza el numero de lote en la base de datos.
        /// </summary>
        private void ActualizarLote()
        {
            try
            {
                var loteTemp = miBussinesFacturaProveedor.ObtenerNumeroLote();
                if (txtLote.Text == loteTemp)
                {
                    miBussinesFacturaProveedor.ActualizarLote(Convert.ToInt32(loteTemp));
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtDescuentoProducto_Click(object sender, EventArgs e)
        {
            txtDescuentoProducto.SelectAll();
        }

        private void txtDescuentoProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!String.IsNullOrEmpty(txtDescuentoProducto.Text))
                {
                    if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtDescuentoProducto,
                        MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                    {
                        if (Convert.ToDouble(txtDescuentoProducto.Text) > 100)
                        {
                            MiError.SetError(txtDescuentoProducto, "El porcentaje de descuento no puede ser superior al 100%.");
                            DesctoProductoMatch = false;
                        }
                        else
                        {
                            MiError.SetError(txtDescuentoProducto, null);
                            DesctoProductoMatch = true;
                        }
                    }
                }
                else
                {
                    txtDescuentoProducto.Text = "0";
                    DesctoProductoMatch = true;
                }
            }
        }

        private void txtDescuentoProducto_Validating(object sender, CancelEventArgs e)
        {
            txtDescuentoProducto_KeyPress(txtDescuentoProducto, new KeyPressEventArgs((char)Keys.Enter));
        }
    }
}