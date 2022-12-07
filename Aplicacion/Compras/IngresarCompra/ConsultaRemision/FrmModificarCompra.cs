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

namespace Aplicacion.Compras.IngresarCompra.ConsultaRemision
{
    public partial class FrmModificarCompra : Form
    {
        #region Atributos

        /// <summary>
        /// Obtiene o establece el valor de FacturaProveedor actual.
        /// </summary>
        public FacturaProveedor MiFacturaProveedor { set; get; }

        /// <summary>
        /// Obtiene o establece los valores de la Factura editada.
        /// </summary>
        private FacturaProveedor miFacturaEditada { set; get; }

        /// <summary>
        /// Representa el objeto de estructura las Formas de Pago.
        /// </summary>
        private FormaPago miFormaPago;

        /// <summary>
        /// Objeto con acceso al Form de Ingresar Factura.
        /// </summary>
        private FrmIngresarCompra miFrmIngresaCompra;

        private BussinesEstado miBussinesEstado;

        /// <summary>
        /// Representa un objeto de Logica de Negocio de Usuario.
        /// </summary>
        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Representa un objeto de logica de negocio de Factura.
        /// </summary>
        private BussinesFacturaProveedor miBussinesFactura;

        /// <summary>
        /// Objeto de lógica de negocio de BussinesProveedor.
        /// </summary>
        private BussinesProveedor miBussinesProveedor;

        private BussinesRemision miBussinesRemision;

        /// <summary>
        /// Establece la condición que indica si se uso KeyPress para nuevo Proveedor.
        /// </summary>
        private bool KeyProveedorPress = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si se ha llamado al Formulario de Proveedor.
        /// </summary>
        private bool FormProveedor { set; get; }

        /// <summary>
        /// Obtiene o establece la condición que indica si la fecha ingresada es correcta.
        /// </summary>
        private bool FechaMatch = true;

        /// <summary>
        /// Obtiene o establece la condición que indica si el Número de Factura ingresada es correcta.
        /// </summary>
        private bool NumeroFacturaMatch = true;

        /// <summary>
        /// Obtiene o establece la condición que indica si el Descuento de la Factura ingresada es correcto.
        /// </summary>
        private bool DescuentoMatch = false;

        private bool AjusteMatch = false;

        /// <summary>
        /// Obtiene o establece la condición que indica si ha cerrado el formulario.
        /// </summary>
        private bool PressClosing = false;

        /// <summary>
        /// Objeto tipo hilo que me premite realiza ejecuciones asincronas y sincrona.
        /// </summary>
        private System.Threading.Thread miThread;

        /// <summary>
        /// Indica si se aplica descuento al producto o a la factura.
        /// </summary>
        private bool DesctoProducto;

        /// <summary>
        /// Objeto que representa el panel de opcion a mostrar.
        /// </summary>
        private OptionPane miOption;

        /// <summary>
        /// Obtiene o establece el valor que indica si el guardado se realizo con exito.
        /// </summary>
        private bool SuccessGuardado = false;

        #endregion

        public FrmModificarCompra()
        {
            InitializeComponent();
            miFormaPago = new FormaPago();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesEstado = new BussinesEstado();
            miBussinesFactura = new BussinesFacturaProveedor();
            miBussinesProveedor = new BussinesProveedor();
            miFrmIngresaCompra = new FrmIngresarCompra();
            miBussinesRemision = new BussinesRemision();
        }

        private void FrmModificarCompra_Load(object sender, EventArgs e)
        {
            //cbFormaPago.DataSource = miFormaPago.lista;
            CargarDatos(MiFacturaProveedor);
            CompletaEventos.CompletaEditProveedor +=
                new CompletaEventos.CompletaAccionEditProveedor(CompletaEventos_Completo);
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
        }

        private void FrmModificarCompra_FormClosing(object sender, FormClosingEventArgs e)
        {
            CompletaEventos.CapturaEvento(false);
            /*DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?",
                "Edición", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                PressClosing = true;
                tsBtnGuardar_Click(null, null);
                if (NumeroFacturaMatch && FechaMatch)
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
                    CompletaEventos.CapturaEvento(false);
                }
                else
                {
                    e.Cancel = true;
                }
            }*/
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            DialogResult rta;
            if (!PressClosing)
            {
                rta = MessageBox.Show("¿Está seguro(a) de gurdar los cambios?",
                   "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            }
            else
            {
                rta = DialogResult.Yes;
            }
            if (rta == DialogResult.Yes)
            {
                txtNumeroFactura_Validating(null, null);
                dtpFechaLimite_Validating(null, null);
                txtDescuento_Validating(null, null);
                txtAjuste_Validating(null, null);
                if (NumeroFacturaMatch && FechaMatch && DescuentoMatch && AjusteMatch)
                {
                    CargarFactura();
                    try
                    {
                        miBussinesRemision.EditarRemisionProveedor(miFacturaEditada);
                        OptionPane.MessageInformation("Los datos se guardaron correctamente.");
                        CompletaEventos.CapturaEvento(1);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }
                   /* miOption = new OptionPane();
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                    miOption.FrmProgressBar.Closed_ = true;
                    miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                        "Operacion en progreso");
                    this.Enabled = false;
                    miThread = new System.Threading.Thread(IniciarGuardado);
                    miThread.Start();*/
                    /*try
                    {
                        //miBussinesFactura.EditarFacturaProveedor(miFacturaEditada);
                        //OptionPane.MessageInformation("Los datos se editaron correctamente.");
                        //CompletaEventos.CapturaEvento(1);
                    }
                    catch (Exception ex)
                    {
                        OptionPane.MessageError(ex.Message);
                    }*/
                }
            }
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEditarFecha_Click(object sender, EventArgs e)
        {
            dtpFechaFactura.Value = MiFacturaProveedor.FechaFactura;
            dtpFechaFactura.Visible = true;
            txtFechaFactura.Visible = false;
            btnEditarFecha.Visible = false;
            btnDesEditarFecha.Visible = true;
        }

        private void btnDesEditarFecha_Click(object sender, EventArgs e)
        {
            dtpFechaFactura.Value = MiFacturaProveedor.FechaFactura;
        }
        //
        private void txtCodigoProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    if (ValidarCodigoProveedor())
                    {
                        var codigo = Convert.ToInt32(txtCodigoProveedor.Text);
                        if (miBussinesProveedor.ExisteProveedorConCodigo(codigo))
                        {
                            if (codigo != MiFacturaProveedor.Proveedor.CodigoInternoProveedor)
                            {
                                DialogResult rta = MessageBox.Show("¿Está seguro de querer cambiar el Proveedor de la Factura?",
                                    "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (rta == DialogResult.Yes)
                                {
                                    KeyProveedorPress = true;
                                    var miProveedor = miBussinesProveedor.ConsultarPrveedorBasico(codigo);
                                    MiFacturaProveedor.Proveedor = miProveedor;
                                    txtNombreProveedor.Text = miProveedor.CodigoInternoProveedor + " - NIT: "
                                                                + miProveedor.NitProveedor + " - "
                                                                + miProveedor.RazonSocialProveedor;
                                }
                            }
                        }
                        else
                        {
                            KeyProveedorPress = true;
                            OptionPane.MessageInformation(miFrmIngresaCompra.CodigoProveedorExiste);
                            miFrmIngresaCompra.MiError.SetError(txtCodigoProveedor, miFrmIngresaCompra.CodigoProveedorExiste);
                        }
                    }
                }
                else
                {
                    KeyProveedorPress = false;
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void txtCodigoProveedor_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (!KeyProveedorPress)
                {
                    if (ValidarCodigoProveedor())
                    {
                        var codigo = Convert.ToInt32(txtCodigoProveedor.Text);
                        if (miBussinesProveedor.ExisteProveedorConCodigo(codigo))
                        {
                            if (codigo != MiFacturaProveedor.Proveedor.CodigoInternoProveedor)
                            {
                                DialogResult rta = MessageBox.Show("¿Está seguro de querer cambiar el Proveedor de la Factura?",
                                    "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                                if (rta == DialogResult.Yes)
                                {
                                    var miProveedor = miBussinesProveedor.ConsultarPrveedorBasico(codigo);
                                    txtNombreProveedor.Text = miProveedor.CodigoInternoProveedor.ToString() + " - NIT: "
                                                                + miProveedor.NitProveedor + " - "
                                                                + miProveedor.RazonSocialProveedor;
                                }
                            }
                        }
                        else
                        {
                            OptionPane.MessageInformation(miFrmIngresaCompra.CodigoProveedorExiste);
                            miFrmIngresaCompra.MiError.SetError(txtCodigoProveedor, miFrmIngresaCompra.CodigoProveedorExiste);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            if (!FormProveedor)
            {
                var formProveedor = new Proveedor.frmProveedor();
                formProveedor.MdiParent = this.MdiParent;
                formProveedor.Extension = true;
                formProveedor.Edit = true;
                formProveedor.tcProveedor.SelectTab(1);
                FormProveedor = true;
                formProveedor.Show();
            }
        }

        private void txtNumeroFactura_Validating(object sender, CancelEventArgs e)
        {
            if (!Validacion.EsVacio(txtNumeroFactura, miFrmIngresaCompra.MiError, miFrmIngresaCompra.FacturaReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumeroGuion,
                    txtNumeroFactura, miFrmIngresaCompra.MiError, miFrmIngresaCompra.FacturaFormato))
                {
                    NumeroFacturaMatch = true;
                }
                else
                {
                    NumeroFacturaMatch = false;
                }
            }
            else
            {
                NumeroFacturaMatch = false;
            }
        }

        private void btnEditarFormaPago_Click(object sender, EventArgs e)
        {
            //cbFormaPago.SelectedValue = miFacturaProveedor.FormaPago.IdFormaPago;
            cbFormaPago.Visible = true;
            txtFormaPago.Visible = false;
            btnEditarFormaPago.Enabled = false;
        }

        private void dtpFechaLimite_Validating(object sender, CancelEventArgs e)
        {
            var id = (int)cbFormaPago.SelectedValue;
            if (id == 2)
            {
                if (dtpFechaLimite.Value <= MiFacturaProveedor.FechaIngreso)
                {
                    btnEditarFechaLimite_Click(null, null);
                    miFrmIngresaCompra.MiError.SetError(dtpFechaLimite, miFrmIngresaCompra.ErrorFecha);
                    FechaMatch = false;
                }
                else
                {
                    miFrmIngresaCompra.MiError.SetError(dtpFechaLimite, null);
                    FechaMatch = true;
                }
            }
            else
            {
                dtpFechaLimite.Value = MiFacturaProveedor.FechaLimite;
                FechaMatch = true;
            }

        }

        private void btnEditarFechaLimite_Click(object sender, EventArgs e)
        {
            dtpFechaLimite.Value = MiFacturaProveedor.FechaLimite;
            dtpFechaLimite.Visible = true;
            txtFechaLimite.Visible = false;
            btnEditarFechaLimite.Visible = false;
            btnDeshacerFechaLimite.Visible = true;
        }

        private void btnDeshacerFechaLimite_Click(object sender, EventArgs e)
        {
            dtpFechaLimite.Value = MiFacturaProveedor.FechaLimite;
        }

        private void rbtnDesctoProducto_Click(object sender, EventArgs e)
        {
            if (!DesctoProducto)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro que quiere aplicar Descuento por Producto?",
                    "Factura Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    txtDescuentoFactura.Enabled = false;
                    DesctoProducto = true;
                    txtDescuentoFactura.Text = "0";
                    txtDescuentoFactura.Text = "0";
                    OptionPane.MessageInformation("Debe editar el descuento de cada registro de Producto de la Factura.");
                }
                else
                {
                    rbtnDesctoFactura.Checked = true;
                    txtDescuentoFactura.Enabled = true;
                }
            }
            else
            {
                DesctoProducto = true;
            }
        }

        private void rbtnDesctoFactura_Click(object sender, EventArgs e)
        {
            if (DesctoProducto)
            {
                DialogResult rta = MessageBox.Show("¿Está seguro que quiere aplicar Descuento por Factura?",
                    "Factura Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rta.Equals(DialogResult.Yes))
                {
                    txtDescuentoFactura.Enabled = true;
                    DesctoProducto = false;
                    txtDescuentoFactura.Text = MiFacturaProveedor.Descuento.ToString();
                    txtDescuentoFactura.Focus();
                }
                else
                {
                    rbtnDesctoProducto.Checked = true;
                    txtDescuentoFactura.Enabled = false;
                }
            }
            else
            {
                DesctoProducto = false;
                txtDescuentoFactura.Enabled = true;
            }
        }

        private void txtDescuento_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtDescuentoFactura.Text))
            {
                txtDescuentoFactura.Text = "0";
                DescuentoMatch = true;
            }
            else
            {
                txtDescuentoFactura.Text = txtDescuentoFactura.Text.Replace(',', '.');
                if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                    txtDescuentoFactura, miFrmIngresaCompra.MiError, "El valor del Descuento que ingreso tiene formato incorrecto."))
                {
                    DescuentoMatch = true;
                    txtDescuentoFactura.Text = txtDescuentoFactura.Text.Replace('.', ',');
                }
                else
                    DescuentoMatch = false;
            }
        }

        private void txtAjuste_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtAjuste.Text))
            {
                txtAjuste.Text = "0";
            }
            else
            {
                /*if (Validacion.ConFormato(Validacion.TipoValidacion.NumerosYPunto,
                                           txtAjuste, miFrmIngresaCompra.MiError, "El valor que ingreso es incorrecto."))*/
                if(ValidarNumero(txtAjuste.Text))
                {
                    miFrmIngresaCompra.MiError.SetError(txtAjuste, null);
                    AjusteMatch = true;
                }
                else
                {
                    miFrmIngresaCompra.MiError.SetError(txtAjuste, "El valor que ingreso es incorrecto.");
                    AjusteMatch = false;
                }
            }
        }

        /// <summary>
        /// Carga los datos de la Factura en el Formulario.
        /// </summary>
        /// <param name="factura"></param>
        private void CargarDatos(FacturaProveedor factura)
        {
            //miFacturaProveedor = factura;
            /*Usuario miUsuario = new Usuario();
            try
            {
                miUsuario = miBussinesUsuario.ConsultarUsuarioFactura(factura.Id, false);
                MiFacturaProveedor.Usuario.Id = miUsuario.Id;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }*/
            try
            {
                cbFormaPago.DataSource = miBussinesEstado.Lista();
                cbFormaPago.SelectedValue = factura.EstadoFactura.Id;
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
            lblFechaIngreso.Text = factura.FechaIngreso.Day + " de " + UseDate.MesCorto(factura.FechaIngreso.Month) +
                                    " de " + factura.FechaIngreso.Year;
            usuario.Text = factura.Usuario.Identificacion + " - " + factura.Usuario.Nombres;
            txtCodigoProveedor.Text = factura.Proveedor.CodigoInternoProveedor.ToString();
            txtNombreProveedor.Text = factura.Proveedor.CodigoInternoProveedor.ToString() + " - NIT: "
                                    + factura.Proveedor.NitProveedor + " - "
                                    + factura.Proveedor.NombreProveedor;
            txtNumeroFactura.Text = factura.Numero;
            txtFormaPago.Text = factura.EstadoFactura.Descripcion;
            txtFechaFactura.Text = factura.FechaFactura.ToShortDateString();
            dtpFechaFactura.Value = factura.FechaFactura;
            txtFechaLimite.Text = factura.FechaLimite.ToShortDateString();
            dtpFechaLimite.Value = factura.FechaLimite;
            if (factura.Descuento.Equals(0))
            {
                rbtnDesctoProducto.Checked = true;
                txtDescuentoFactura.Enabled = false;
                DesctoProducto = true;
            }
            else
            {
                rbtnDesctoFactura.Checked = true;
                txtDescuentoFactura.Enabled = true;
                txtDescuentoFactura.Text = factura.Descuento.ToString();
                DesctoProducto = false;
            }
            //cbFormaPago.SelectedValue = MiFacturaProveedor.FormaPago.IdFormaPago;
            if (factura.Estado)
            {
                rBtnActiva.Checked = true;
            }
            else
            {
                rBtnAnulada.Checked = true;
            }
            txtAjuste.Text = UseObject.InsertSeparatorMil(factura.Ajuste.ToString()).Replace(',', '.');
        }

        /// <summary>
        /// Valida el texto ingresado como codigo del Proveedor.
        /// </summary>
        /// <returns></returns>
        public bool ValidarCodigoProveedor()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigoProveedor, miFrmIngresaCompra.MiError, miFrmIngresaCompra.CodigoProveedorReq))
            {
                if (Validacion.ConFormato(Validacion.TipoValidacion.Numeros,
                    txtCodigoProveedor, miFrmIngresaCompra.MiError, miFrmIngresaCompra.CodigoProveedorFormato))
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        private bool ValidarNumero(string numero)
        {
            try
            {
                Convert.ToDouble(numero);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de extención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEventoEditProveedor args)
        {
            try
            {
                var proveedor_ = (DTO.Clases.Proveedor)args.MiObjeto;
                txtCodigoProveedor.Text = proveedor_.CodigoInternoProveedor.ToString();
                txtCodigoProveedor_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
                FormProveedor = false;
            }
            catch { }
        }

        /// <summary>
        /// Completa la secuencia de datos de un formulario de extención.
        /// </summary>
        /// <param name="args">Objeto que encapsula la información del formulario.</param>
        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                FormProveedor = Convert.ToBoolean(args.MiObjeto);
            }
            catch { }
        }

        /// <summary>
        /// Carga los datos del Fomulario en el objeto de Factura Editada.
        /// </summary>
        private void CargarFactura()
        {
            miFacturaEditada = new FacturaProveedor();
            miFacturaEditada.Id = MiFacturaProveedor.Id;
            miFacturaEditada.Proveedor.CodigoInternoProveedor = Convert.ToInt32(txtCodigoProveedor.Text);
            miFacturaEditada.EstadoFactura.Id = (int)cbFormaPago.SelectedValue;
            miFacturaEditada.Usuario.Id = MiFacturaProveedor.Usuario.Id;
            miFacturaEditada.Numero = txtNumeroFactura.Text;
            if (miFacturaEditada.EstadoFactura.Id == 1)
            {
                dtpFechaLimite.Value = MiFacturaProveedor.FechaIngreso;
                txtFechaLimite.Text = dtpFechaLimite.Value.ToShortDateString();
            }
            miFacturaEditada.FechaFactura = dtpFechaFactura.Value;
            miFacturaEditada.FechaLimite = dtpFechaLimite.Value;
            miFacturaEditada.FechaIngreso = MiFacturaProveedor.FechaIngreso;
            miFacturaEditada.Descuento = Convert.ToDouble(txtDescuentoFactura.Text);
            if (rBtnActiva.Checked)
            {
                miFacturaEditada.Estado = true;
            }
            else
            {
                miFacturaEditada.Estado = false;
            }
            miFacturaEditada.Ajuste = Convert.ToDouble(txtAjuste.Text.Replace('.', ','));
        }

        /// <summary>
        /// Despliega el proceso del hilo (Thread) para el guardado de la Factura.
        /// </summary>
        private void IniciarGuardado()
        {
            GuardarFactura();
        }

        /// <summary>
        /// Realiza los procedimientos necesarios para el guardado de la Factura.
        /// </summary>
        private void GuardarFactura()
        {
            try
            {
                miBussinesFactura.EditarFacturaProveedor(miFacturaEditada);
                //miBussinesFacturaProveedor.IngresarFactura(miFactura);
                //miBussinesFacturaProveedor.ActualizarLote(LoteConsecutivo - 1);
                SuccessGuardado = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcessGuardado));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                SuccessGuardado = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcessGuardado));
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de guardado de la Factura.
        /// </summary>
        private void FinishProcessGuardado()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
            this.Enabled = true;
            if (SuccessGuardado)
            {
                OptionPane.MessageSuccess("Los datos se editaron correctamente.");
                CompletaEventos.CapturaEvento(1);
                //LimpiarFormulario();
            }
        }
    }
}