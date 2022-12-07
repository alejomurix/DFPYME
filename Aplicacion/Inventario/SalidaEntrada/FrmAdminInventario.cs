using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BussinesLayer.Clases;
using CustomControl;
using DTO.Clases;
using Aplicacion.Compras.IngresarCompra;
using Utilities;

namespace Aplicacion.Inventario.SalidaEntrada
{
    public partial class FrmAdminInventario : Form
    {
        private DTO.Clases.Inventario ProductoSalida { set; get; }

        private DTO.Clases.Inventario ProductoEntrada { set; get; }

        /// <summary>
        /// Colección que almacena objetos, en este caso Productos.
        /// </summary>
        private ArrayList ArrayProducto;

        /// <summary>
        /// Objeto para cargar Producto.
        /// </summary>
        private DTO.Clases.Producto MiProducto;

        /// <summary>
        /// Objeto para cargar los datos de la medida del producto consultado.
        /// </summary>
        private ValorUnidadMedida miMedida;

        /// <summary>
        /// Objeto para la carga del talla y color del producto.
        /// </summary>
        private TallaYcolor miTallaYcolor;

        private BussinesProducto miBussinesProducto;

        private BussinesValorUnidadMedida miBussinesMedida;

        private BussinesColor miBussinesColor;

        private BussinesInventario miBussinesInventario;

        private bool ExtendForms;

        private bool CargaSalida;

        private ErrorProvider miError;

        private bool CantidadSalida { set; get; }

        private bool ProductoRepet { set; get; }

        private bool CantSalida { set; get; }

        private bool CantEntrada { set; get; }

        /// <summary>
        /// Indica si el Producto tiene una sola talla.
        /// </summary>
        private bool SingleSize = false;

        /// <summary>
        /// Indica si el Producto tiene un solo color.
        /// </summary>
        private bool SingleColor = false;

        private bool SizeColor = false;

        public FrmAdminInventario()
        {
            InitializeComponent();
            miError = new ErrorProvider();
            CantidadSalida = true;
            ProductoRepet = true;
            ExtendForms = false;
            CargaSalida = false;
            miTallaYcolor = new TallaYcolor();
            miBussinesProducto = new BussinesProducto();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
            miBussinesInventario = new BussinesInventario();
        }

        private void FrmEntradaSalida_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.CompletaVenta += new CompletaEventos.CompletaAccionVenta(CompletaEventosVenta_Completo);
            CompletaEventos.CompTProductoFact +=
                new CompletaEventos.ComAxTransferProductFact(CompletaEventos_CompTProductoFact);
        }

        private void FrmAdminInventario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F2))
            {
                this.tsbtnGuardar_Click(this.tsbtnGuardar, new EventArgs());
            }
            else
            {
                if (e.KeyData.Equals(Keys.Escape))
                {
                    this.Close();
                }
            }
        }

        private void tsbtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Esta seguro de guardar los datos?", "Salida y entrada de inventario",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rta.Equals(DialogResult.Yes))
            {
                var bussinesKardex = new BussinesKardex();
                var kardex = new DTO.Clases.Kardex();
                //this.txtCantSalida_Validating(this.txtCantSalida, new CancelEventArgs());
                //this.txtCantEntrada_Validating(this.txtCantEntrada, new CancelEventArgs());
                if (CantidadSalida && ProductoRepet)// && CantSalida && CantEntrada)
                {
                    try
                    {
                        if (!txtCantSalida.Text.Equals(""))
                        {
                            ProductoSalida.Cantidad = UseObject.RemoveSeparatorMil(this.txtInventarioSalida.Text) - //Convert.ToDouble(txtInventarioSalida.Text.Replace('.', ',')) -
                                                      Convert.ToDouble(txtCantSalida.Text.Replace('.', ','));
                            miBussinesInventario.ActualizarCantidadInventario(ProductoSalida);

                            kardex.Codigo = ProductoSalida.CodigoProducto;
                            kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            kardex.IdConcepto = 13;
                            kardex.Fecha = DateTime.Now;
                            kardex.Cantidad = Convert.ToDouble(txtCantSalida.Text.Replace('.', ','));
                            kardex.Valor = ProductoSalida.Costo;
                            kardex.Total = kardex.Valor * kardex.Cantidad;
                            bussinesKardex.Insertar(kardex);
                        }
                        if (!txtInventarioEntrada.Text.Equals(""))
                        {
                            ProductoEntrada.Cantidad = Convert.ToDouble(txtCantEntrada.Text.Replace('.', ',')) +
                                                       UseObject.RemoveSeparatorMil(this.txtInventarioEntrada.Text); //Convert.ToDouble(txtInventarioEntrada.Text.Replace('.', ','));
                            miBussinesInventario.ActualizarCantidadInventario(ProductoEntrada);

                            kardex.Codigo = ProductoEntrada.CodigoProducto;
                            kardex.IdUsuario = Convert.ToInt32(AppConfiguracion.ValorSeccion("id_user"));
                            kardex.IdConcepto = 4;
                            kardex.Fecha = DateTime.Now;
                            kardex.Cantidad = Convert.ToDouble(txtCantEntrada.Text.Replace('.', ','));
                            kardex.Valor = ProductoEntrada.Costo;
                            kardex.Total = kardex.Valor * kardex.Cantidad;
                            bussinesKardex.Insertar(kardex);
                        }

                       // miBussinesInventario.ActualizarCantidadInventario(ProductoSalida);
                        //miBussinesInventario.ActualizarCantidadInventario(ProductoEntrada);
                        if (!txtCantSalida.Text.Equals("") || !txtInventarioEntrada.Text.Equals(""))
                        {
                            OptionPane.MessageInformation("Los datos del Inventario se actualizaron correctamente.");

                            txtCodigoSalida.Focus();
                            MiProducto = null;
                            ProductoSalida = null;
                            ProductoEntrada = null;
                            txtCodigoSalida.Text = "";
                            lblArticuloSalida.Text = "";
                            txtInventarioSalida.Text = "";
                            txtCantSalida.Text = "";

                            txtCodigoEntrada.Text = "";
                            lblArticuloEntrada.Text = "";
                            txtInventarioEntrada.Text = "";
                            txtCantEntrada.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                }
            }
        }

        private void tsbtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCodigoSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                CargaSalida = true;
                if (CodigoOrString(txtCodigoSalida.Text))
                {
                    if (ExisteProducto(txtCodigoSalida.Text))
                    {
                        if (CargarProducto(txtCodigoSalida.Text))
                        {
                            if (SizeColor)
                            {
                                SeleccionTallaYcolor();
                            }
                            else
                            {
                                EstructurarConsulta();
                                txtCantSalida.Focus();
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El articulo no existe.");
                    }
                }
                else
                {
                    if (!ExtendForms)
                    {
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.txtCodigoNombre.Text = txtCodigoSalida.Text;
                        ExtendForms = true;
                        CargaSalida = true;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
                    }
                }
            }
        }

        private void txtCantSalida_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                txtCodigoEntrada.Focus();
            }
        }

        private void txtCantSalida_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCantSalida, miError, "El campo salida es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtCantSalida,
                    miError, "El valor que ingreso es incorrecto."))
                {
                    if (UseObject.RemoveSeparatorMil(this.txtInventarioSalida.Text) >=
                        Convert.ToDouble(txtCantSalida.Text.Replace('.', ',')))
                    {
                        CantSalida = true;
                        miError.SetError(txtCantSalida, null);
                    }
                    else
                    {
                        CantSalida = false;
                        miError.SetError(txtCantSalida, "La cantidad del articulo debe ser igual o menor que la de inventario.");
                    }
                }
                else
                {
                    CantSalida = false;
                }
            }
            else
            {
                CantSalida = false;
            }
        }

        private void txtCodigoEntrada_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals((char)Keys.Enter))
            {
                CargaSalida = false;
                if (CodigoOrString(txtCodigoEntrada.Text))
                {
                    if (ExisteProducto(txtCodigoEntrada.Text))
                    {
                        if (CargarProducto(txtCodigoEntrada.Text))
                        {
                            if (ProductoSalida == null)
                            {
                                ProductoSalida = new DTO.Clases.Inventario();
                            }
                            if (MiProducto.CodigoInternoProducto != ProductoSalida.CodigoProducto)
                            {
                                ProductoRepet = true;
                                if (SizeColor)
                                {
                                    SeleccionTallaYcolor();
                                }
                                else
                                {
                                    EstructurarConsulta();
                                    txtCantEntrada.Focus();
                                }
                            }
                            else
                            {
                                ProductoRepet = false;
                                OptionPane.MessageInformation("El articulo de entrada no puede ser el mismo de salida.");
                                txtCodigoEntrada.Focus();
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("El articulo no existe.");
                    }
                }
                else
                {
                    if (!ExtendForms)
                    {
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.txtCodigoNombre.Text = txtCodigoEntrada.Text;
                        ExtendForms = true;
                        CargaSalida = false;
                        formInventario.Show();
                        formInventario.dgvInventario.Focus();
                    }
                }
            }
        }

        private void txtCantEntrada_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtCantEntrada, miError, "El campo entrada es requerido."))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto, txtCantEntrada,
                    miError, "El valor que ingreso es incorrecto."))
                {
                    CantEntrada = true;
                }
                else
                {
                    CantEntrada = false;
                }
            }
            else
            {
                CantEntrada = false;
            }
        }

        /// <summary>
        /// Verifica si el texto ingresado equivale a un número o palabra. Retorna true si es un número.
        /// </summary>
        /// <returns></returns>
        private bool CodigoOrString(string codigo)
        {
            var num = true;
            try
            {
                Convert.ToInt64(codigo);
            }
            catch (FormatException)
            {
                num = false;
            }
            catch (OverflowException)
            {
                num = true;
            }
            return num;

            /*try
            {
                Convert.ToInt64(txtCodigoArticulo.Text);
                return true;
            }
            catch(Exception ex)
            {
                try
                {
                    var j = (OverflowException)ex.InnerException;
                    return true;
                }
                catch 
                {
                    return false;
                }
            }*/
        }

        /// <summary>
        /// Valida si codigo ingresado existe en la base de datos.
        /// </summary>
        /// <param name="codigo">Codigo a verificar.</param>
        /// <returns></returns>
        private bool ExisteProducto(string codigo)
        {
            try
            {
                var barras = miBussinesProducto.ExisteCodigoBarras(codigo);
                var code = miBussinesProducto.ExisteCodigo(codigo);
                if (barras || code)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Carga en memoria los datos del Producto consultado segun su codigo.
        /// </summary>
        private bool CargarProducto(string codigo)
        {
            var resultado = false;
            try
            {
                ArrayProducto = miBussinesProducto.ProductoBasico(codigo);
                MiProducto = (DTO.Clases.Producto)ArrayProducto[0];
                var tabla = miBussinesMedida.MedidasDeProducto(MiProducto.CodigoInternoProducto);
                if (!MiProducto.AplicaTalla)
                {
                    miMedida = (ValorUnidadMedida)ArrayProducto[1];
                    SingleSize = true;
                }
                else
                {

                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        miTallaYcolor.IdTalla = Convert.ToInt32(q["idvalor_unidad_medida"]);
                        q = null;
                        SingleSize = true;
                    }
                    else
                    {
                        SingleSize = false;
                    }
                }
                if (MiProducto.AplicaColor)
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        var tablaColor = miBussinesColor.ColoresDeProducto
                            (MiProducto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                        if (tablaColor.Rows.Count == 1)
                        {
                            var c = (from d in tablaColor.AsEnumerable()
                                     select d).Single();
                            miTallaYcolor.IdColor = Convert.ToInt32(c["idcolor"]);
                            SingleColor = true;
                        }
                        else
                        {
                            SingleColor = false;
                        }
                    }
                    else
                    {
                        SingleColor = false;
                    }
                }
                else
                {
                    SingleColor = true;
                }
                if (CargaSalida)
                {
                    lblArticuloSalida.Text = MiProducto.NombreProducto + "  --  " + MiProducto.NombreMarca;
                }
                else
                {
                    lblArticuloEntrada.Text = MiProducto.NombreProducto + " -- " + MiProducto.NombreMarca;
                }
                if (!MiProducto.AplicaTalla && !MiProducto.AplicaColor)
                {
                    SizeColor = false;
                }
                else
                {
                    SizeColor = true;
                }
                resultado = true;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            return resultado;
        }

        private void SeleccionTallaYcolor()
        {
            if (MiProducto != null)
            {
                if (MiProducto.AplicaTalla || MiProducto.AplicaColor)
                {
                    var FrmTallaColor = new frmMedidaColor();
                    //FrmTallaColor.MdiParent = this.MdiParent;
                    FrmTallaColor.AplicaTalla = MiProducto.AplicaTalla;
                    FrmTallaColor.AplicaColor = MiProducto.AplicaColor;
                    FrmTallaColor.CodigoProducto = MiProducto.CodigoInternoProducto;
                    FrmTallaColor.Venta_ = true;
                    if (MiProducto.AplicaColor && !MiProducto.AplicaTalla)
                    {
                        FrmTallaColor.IdMedida_ = miMedida.IdValorUnidadMedida;
                    }
                    if (MiProducto.AplicaColor)
                    {
                        FrmTallaColor.ShowDialog();
                    }
                    else
                    {
                        if (MiProducto.AplicaTalla)
                        {
                            FrmTallaColor.AplicaColor = false;
                            FrmTallaColor.ShowDialog();
                        }
                    }
                }
            }
            else
            {
                OptionPane.MessageInformation("Debe seleccionar un Articulo primero.");
            }
        }

        private void EstructurarConsulta()
        {
            try
            {
                var inventario = new DTO.Clases.Inventario();
                inventario.CodigoProducto = MiProducto.CodigoInternoProducto;
                if (MiProducto.AplicaTalla)
                {
                    inventario.IdMedida = miTallaYcolor.IdTalla;
                }
                else
                {
                    inventario.IdMedida = miMedida.IdValorUnidadMedida;
                }
                if (MiProducto.AplicaColor)
                {
                    inventario.IdColor = miTallaYcolor.IdColor;
                }
                inventario.Cantidad = miBussinesInventario.CantidadInventario(inventario);
                inventario.Costo = MiProducto.ValorVentaProducto;
                if (CargaSalida)
                {
                    txtInventarioSalida.Text = UseObject.InsertSeparatorMil(inventario.Cantidad.ToString());
                    if (inventario.Cantidad > 0)
                    {
                        miError.SetError(txtInventarioSalida, null);
                        ProductoSalida = inventario;
                        txtInventarioSalida.Text = UseObject.InsertSeparatorMil(inventario.Cantidad.ToString());
                        CantidadSalida = true;
                    }
                    else
                    {
                        CantidadSalida = false;
                        miError.SetError(txtInventarioSalida, "No se puede dar salida a un artículo sin inventario.");
                    }
                }
                else
                {
                    ProductoEntrada = inventario;
                    txtInventarioEntrada.Text = UseObject.InsertSeparatorMil(inventario.Cantidad.ToString());
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                ExtendForms = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        void CompletaEventosVenta_Completo(CompletaArgumentosDeEventoVenta args)
        {
            try
            {
                miTallaYcolor = (TallaYcolor)args.objeto;
                //if (CargaSalida)
                // {
                EstructurarConsulta();
                //}
            }
            catch { }
        }

        void CompletaEventos_CompTProductoFact(CompletaTransferProductFact args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                if (CargaSalida)
                {
                    txtCodigoSalida.Text = producto.CodigoInternoProducto;
                    txtCodigoSalida_KeyPress(this.txtCodigoSalida, new KeyPressEventArgs((char)Keys.Enter));
                }
                else
                {
                    txtCodigoEntrada.Text = producto.CodigoInternoProducto;
                    txtCodigoEntrada_KeyPress(this.txtCodigoEntrada, new KeyPressEventArgs((char)Keys.Enter));
                }
            }
            catch { }
        }
    }
}