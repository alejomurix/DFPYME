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
using System.Threading;
using DTO.Clases;

namespace Aplicacion.Ventas.Factura
{
    public partial class FrmResumenVenta : Form
    {
        private BussinesFacturaVenta miBussinesFactura;

        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Objeto para el acceso al ensamblado de la aplicación.
        /// </summary>
        private System.Reflection.Assembly assembly;

        /// <summary>
        /// Representa el Stream de la Imagen de Ver Utilidad.
        /// </summary>
        private System.IO.Stream ImgUtilidadStream;

        /// <summary>
        /// Representa la ruta del ensamblado de la imagen de color gris de Ver Utilidad
        /// </summary>
        private const string ImagenUtilidad = "Aplicacion.Recursos.Iconos.table_money_gris.png";

        private bool VerUtilidad;

        private bool NoVerUtilidad;

        private bool Transfer { set; get; }

        /// <summary>
        /// Obteien o establece el numero que indica que iteracion se realizo.
        /// </summary>
        private int Iteracion;

        /// <summary>
        /// Obtiene o establece el valor del registro a segir o registro base.
        /// </summary>
        private int RowResumen;

        /// <summary>
        /// Obtiene o establece el número maximo de registro a cargar.
        /// </summary>
        private int RowMaxResumen;

        /// <summary>
        /// Obtiene o establece el total de registros en la base de datos.
        /// </summary>
        private long TotalRowResumen;

        /// <summary>
        /// Obtiene o establece el número total de paginas que componen la consulta.
        /// </summary>
        private long PaginasResumen;

        /// <summary>
        /// Obtiene o establece el número de la pagina actual.
        /// </summary>
        private int CurrentPageResumen;

        private Thread miThread;

        private OptionPane miOption;

        private string NitActual { set; get; }

        private DateTime FechaActual { set; get; }

        private DateTime FechaActual2 { set; get; }

        private DataTable TResumen { set; get; }

        private List<ProductoFacturaProveedor> Productos;

        private int IdUsuario { set; get; }

        public FrmResumenVenta()
        {
            InitializeComponent();
            this.Transfer = false;
            this.VerUtilidad = true;
            this.NoVerUtilidad = true;
            this.miBussinesFactura = new BussinesFacturaVenta();
            this.miBussinesUsuario = new BussinesUsuario();
            this.RowMaxResumen = 10;
            this.TResumen = new DataTable();
            this.Productos = new List<ProductoFacturaProveedor>();
            this.IdUsuario = 0;
        }

        private void FrmResumenVenta_Load(object sender, EventArgs e)
        {
            this.assembly = System.Reflection.Assembly.GetExecutingAssembly();
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completa);
            CargarDatos();
            //this.miBussinesFactura.VistaFaltante();
        }

        private void FrmResumenVenta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData.Equals(Keys.F5))
            {
                try
                {
                    string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                    if (rta.Equals("ajuste2014"))
                    {
                        miBussinesFactura.AjustarCosto();
                        OptionPane.MessageInformation("Los datos se ajustaron con exito.");
                    }
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }

            /*if (e.KeyData.Equals(Keys.F8))
            {
                try
                {
                    var frm = new Form1();
                    frm.dataGridView1.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (this.dtpFecha1.Value, this.dtpFecha2.Value, 0, 100000);
                    frm.Show();
                }
                catch { }
            }*/
        }

        private void btnVerUtilidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.VerUtilidad)
                {
                    if (this.dgvFactura.RowCount != 0)
                    {
                        string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                        if (!rta.Equals("false"))
                        {
                            if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                            {
                                this.btnVerUtilidad.Image = new Bitmap(ImgUtilidadStream);
                                this.btnVerUtilidad.Text = "No Ver Utilidad";
                                this.NoVerUtilidad = true;
                                this.VerUtilidad = false;

                                this.txtCosto.Visible = true;
                                this.txtVenta.Visible = true;
                                this.txtUtilidad.Visible = true;

                                this.txtCostoView.Visible = false;
                                this.txtVentaView.Visible = false;
                                this.txtUtilidadView.Visible = false;
                            }
                            else
                            {
                                OptionPane.MessageError("La contraseña es incorrecta.");
                            }
                        }
                    }
                    else
                    {
                        OptionPane.MessageInformation("No hay registros para mostrar.");
                    }
                }
                else
                {
                    if (this.NoVerUtilidad)
                    {
                        this.btnVerUtilidad.Image = ((Image)(miResources.GetObject("btnVerUtilidad.Image")));
                        this.btnVerUtilidad.Text = "Ver Utilidad";
                        this.NoVerUtilidad = false;
                        this.VerUtilidad = true;
                        this.txtCosto.Visible = false;
                        this.txtVenta.Visible = false;
                        this.txtUtilidad.Visible = false;

                        this.txtCostoView.Visible = true;
                        this.txtVentaView.Visible = true;
                        this.txtUtilidadView.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void cbCliente_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbCliente.SelectedValue).Equals(1))
            {
                this.txtCliente.Enabled = false;
                this.btnBuscarCliente.Enabled = false;
            }
            else
            {
                this.txtCliente.Text = "";
                this.txtCliente.Enabled = true;
                this.btnBuscarCliente.Enabled = true;
            }
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cbCliente.SelectedValue).Equals(2))
            {
                var frmCliente = new Cliente.frmCliente();
                frmCliente.FacturaVenta = true;
                frmCliente.tcClientes.SelectedIndex = 1;
                this.Transfer = true;
                frmCliente.ShowDialog();
            }
            else
            {
                if (Convert.ToInt32(cbCliente.SelectedValue).Equals(3))
                {
                    var frmUsuarios = new Administracion.Usuario.FrmUsuarios();
                    frmUsuarios.ShowDialog();
                }
            }
        }

        private void cbFecha_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.cbFecha.SelectedValue).Equals(1))
            {
                this.dtpFecha2.Enabled = false;
            }
            else
            {
                this.dtpFecha2.Enabled = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cCliente = Convert.ToInt32(cbCliente.SelectedValue);
            var cFecha = Convert.ToInt32(cbFecha.SelectedValue);
            this.dgvFactura.AutoGenerateColumns = false;

            switch (Convert.ToInt32(cbCriterio.SelectedValue))
            {
                case 1:  // todas
                    {
                        if (cCliente.Equals(1))  // sin cliente
                        {
                            if (cFecha.Equals(1)) // fecha
                            {
                                ConsultaTodas(this.dtpFecha1.Value);
                            }
                            else  // periodo
                            {
                                ConsultaTodas(this.dtpFecha1.Value, this.dtpFecha2.Value);
                            }
                        }
                        else  
                        {
                            if (cCliente.Equals(2))  // con cliente
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaTodas(this.txtCliente.Text, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaTodas(this.txtCliente.Text, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                            else  // con usuario
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaTodas(this.IdUsuario, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaTodas(this.IdUsuario, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                        }
                        break;
                    }
                case 2:  // canceladas
                    {
                        if (cCliente.Equals(1))  // sin cliente
                        {
                            if (cFecha.Equals(1)) // fecha
                            {
                                ConsultaCanceladas(this.dtpFecha1.Value);
                            }
                            else  // periodo
                            {
                                ConsultaCanceladas(this.dtpFecha1.Value, this.dtpFecha2.Value);
                            }
                        }
                        else
                        {
                            if (cCliente.Equals(2))  // con cliente
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaCanceladas(this.txtCliente.Text, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaCanceladas(this.txtCliente.Text, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                            else  // con usuario
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaCanceladas(this.IdUsuario, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaCanceladas(this.IdUsuario, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                        }
                        break;
                    }
                case 3:  // crédito
                    {
                        if (cCliente.Equals(1))  // sin cliente
                        {
                            if (cFecha.Equals(1)) // fecha
                            {
                                ConsultaCreditos(this.dtpFecha1.Value);
                            }
                            else  // periodo
                            {
                                ConsultaCreditos(this.dtpFecha1.Value, this.dtpFecha2.Value);
                            }
                        }
                        else
                        {
                            if (cCliente.Equals(2))  // con cliente
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaCreditos(this.txtCliente.Text, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaCreditos(this.txtCliente.Text, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                            else  // con usuario
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaCreditos(this.IdUsuario, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaCreditos(this.IdUsuario, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                        }
                        break;
                    }
                case 4:  // anuladas
                    {
                        if (cCliente.Equals(1))  // sin cliente
                        {
                            if (cFecha.Equals(1)) // fecha
                            {
                                ConsultaAnuladas(this.dtpFecha1.Value);
                            }
                            else  // periodo
                            {
                                ConsultaAnuladas(this.dtpFecha1.Value, this.dtpFecha2.Value);
                            }
                        }
                        else  
                        {
                            if (cCliente.Equals(2))  // con cliente
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaAnuladas(this.txtCliente.Text, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaAnuladas(this.txtCliente.Text, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                            else  // con usuario
                            {
                                if (cFecha.Equals(1)) // fecha
                                {
                                    ConsultaAnuladas(this.IdUsuario, this.dtpFecha1.Value);
                                }
                                else  // periodo
                                {
                                    ConsultaAnuladas(this.IdUsuario, this.dtpFecha1.Value, this.dtpFecha2.Value);
                                }
                            }
                        }
                        break;
                    }
            }
            if (this.dgvFactura.RowCount.Equals(0))
            {
                LimpiarResumen();
                OptionPane.MessageInformation("No se encontraron registros de la consulta.");
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageResumen > 1)
            {
                var paginaActual = this.CurrentPageResumen;
                for (int i = paginaActual; i > 1; i--)
                {
                    this.RowResumen = this.RowResumen - this.RowMaxResumen;
                    this.CurrentPageResumen--;
                }
                try
                {
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                               (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 7:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 8:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 9:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 10:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                  (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 11:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 12:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 13:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                                (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 14:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 15:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 16:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 17:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 18:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 19:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 20:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 21:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 22:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 23:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 24:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                    }
                    this.lblStatus.Text = this.CurrentPageResumen + " / " + this.PaginasResumen;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageResumen > 1)
            {
                this.RowResumen = this.RowResumen - this.RowMaxResumen;
                if (this.RowResumen <= 0)
                    this.RowResumen = 0;
                try
                {
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                               (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 7:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 8:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 9:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 10:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                  (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 11:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 12:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 13:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                                (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 14:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 15:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 16:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 17:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 18:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 19:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 20:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 21:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 22:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 23:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 24:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                    }
                    this.CurrentPageResumen--;
                    this.lblStatus.Text = this.CurrentPageResumen + " / " + this.PaginasResumen;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageResumen < this.PaginasResumen)
            {
                this.RowResumen = this.RowResumen + this.RowMaxResumen;
                try
                {
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                               (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 7:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 8:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 9:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 10:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                  (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 11:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 12:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 13:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                                (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 14:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 15:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 16:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 17:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 18:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 19:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 20:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 21:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 22:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 23:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 24:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                    }
                    this.CurrentPageResumen++;
                    this.lblStatus.Text = this.CurrentPageResumen + " / " + this.PaginasResumen;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void btnFin_Click(object sender, EventArgs e)
        {
            if (this.CurrentPageResumen < this.PaginasResumen)
            {
                var paginaActual = this.CurrentPageResumen;
                for(int i = paginaActual; i < this.PaginasResumen; i++)
                {
                    this.RowResumen = this.RowResumen + this.RowMaxResumen;
                    this.CurrentPageResumen++;
                }
                try
                {
                    switch (this.Iteracion)
                    {
                        case 1:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                               (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 2:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 3:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 4:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 5:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 6:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 7:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 8:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 9:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                                     (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 10:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                  (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 11:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 12:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 13:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                                (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 14:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 15:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 16:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 17:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 18:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 19:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 20:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 21:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 22:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 23:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                        case 24:
                            {
                                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                    (this.IdUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                                break;
                            }
                    }
                    this.lblStatus.Text = this.CurrentPageResumen + " / " + this.PaginasResumen;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                }
            }
        }

        private void CargarDatos()
        {
            var lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Todas"
            });
            /*lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Cancelada"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Crédito"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 4,
                Nombre = "Anulada"
            });*/
            cbCriterio.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = ""
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Cliente"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 3,
                Nombre = "Usuario"
            });
            cbCliente.DataSource = lst;

            lst = new List<Inventario.Producto.Criterio>();
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 1,
                Nombre = "Fecha"
            });
            lst.Add(new Inventario.Producto.Criterio
            {
                Id = 2,
                Nombre = "Periodo"
            });
            cbFecha.DataSource = lst;
            try
            {
                this.ImgUtilidadStream = assembly.GetManifestResourceStream(ImagenUtilidad);
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        void CompletaEventos_Completa(CompletaArgumentosDeEvento args)
        {
            try
            {
                if (this.Transfer)
                {
                    var cliente = (string)args.MiObjeto;
                    this.txtCliente.Text = cliente;
                    this.Transfer = false;
                }
            }
            catch { }

            try
            {
                ObjectAbstract obj = (ObjectAbstract)args.MiObjeto;
                if (obj.Id.Equals(822114433))
                {
                    var usuario_ = (DTO.Clases.Usuario)obj.Objeto;
                    this.IdUsuario = usuario_.Id;
                    this.txtCliente.Text = usuario_.Nombres;
                }
            }
            catch { }
        }



        // Consultas.

        // 1. Todas + Fecha
        private void ConsultaTodas(DateTime fecha)
        {
            try
            {
                this.Iteracion = 1;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasActivas(this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentas(this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentas(this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 2. Todas + Periodo
        private void ConsultaTodas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 2;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasActivas(this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentas(this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 3. Todas + Cliente + Fecha
        private void ConsultaTodas(string cliente, DateTime fecha)
        {
            try
            {
                this.Iteracion = 3;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasActivas(this.NitActual, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentas(this.NitActual, this.FechaActual);
                   // MostrarInformacion(miBussinesFactura.ResumenDeVentas(this.NitActual, this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 4. Todas + Cliente + Periodo
        private void ConsultaTodas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 4;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasActivas(this.NitActual, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentas(this.NitActual, this.FechaActual, this.FechaActual2);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentas(this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 5. Canceladas + Fecha
        private void ConsultaCanceladas(DateTime fecha)
        {
            try
            {
                this.Iteracion = 5;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                             (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasContadoActivas(this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasContado(this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasContado(this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 6. Canceladas + Periodo
        private void ConsultaCanceladas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 6;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = 
                    miBussinesFactura.GetRowsConsultaFacturasContadoActivas(this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasContado(this.FechaActual, this.FechaActual2);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasContado(this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 7. Cancelada + Cliente + Fecha
        private void ConsultaCanceladas(string cliente, DateTime fecha)
        {
            try
            {
                this.Iteracion = 7;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                             (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasContadoActivas(this.NitActual, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                   // ResumenDeVentasContado(this.NitActual, this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasContado(this.NitActual, this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 8. Cancelada + Cliente + Periodo
        private void ConsultaCanceladas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 8;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                             (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasContadoActivas(this.NitActual, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    // ResumenDeVentasContado(this.NitActual, this.FechaActual, this.FechaActual2);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasContado
                        //(this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 9. Crédito + Fecha
        private void ConsultaCreditos(DateTime fecha)
        {
            try
            {
                this.Iteracion = 9;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                             (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasCreditoActivas(this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasCredito(this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasCredito(this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 10. Crédito + Periodo
        private void ConsultaCreditos(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 10;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                             (this.FechaActual, this.FechaActual2,  this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasCreditoActivas(this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasCredito(this.FechaActual, this.FechaActual2);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasCredito(this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 11. Credito + Cliente + Fecha
        private void ConsultaCreditos(string cliente, DateTime fecha)
        {
            try
            {
                this.Iteracion = 11;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                             (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasCreditoActivas(this.NitActual, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasCredito(this.NitActual, this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasCredito(this.NitActual, this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 12. Credito + Cliente + Periodo
        private void ConsultaCreditos(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 12;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                             (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasCreditoActivas(this.NitActual, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasCredito(this.NitActual, this.FechaActual, this.FechaActual2);
                   // MostrarInformacion(miBussinesFactura.ResumenDeVentasCredito
                     //   (this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //13. Anulada + Fecha
        private void ConsultaAnuladas(DateTime fecha)
        {
            try
            {
                this.Iteracion = 13;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                             (this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasAnuladas(this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasAnuladas(this.FechaActual);
                    //MostrarInformacionAnulada(miBussinesFactura.ResumenDeVentasAnulada(this.FechaActual));
                    MostrarInformacionAnulada();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //14. Anulada + Periodo
        private void ConsultaAnuladas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 14;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                             (this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasAnuladas(this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasAnuladas(this.FechaActual, this.FechaActual2);
                    //MostrarInformacionAnulada(miBussinesFactura.ResumenDeVentasAnulada(this.FechaActual, this.FechaActual2));
                    MostrarInformacionAnulada();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //15. Anulada + Cliente + Fecha
        private void ConsultaAnuladas(string cliente, DateTime fecha)
        {
            try
            {
                this.Iteracion = 15;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                             (this.NitActual, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasAnuladas(this.NitActual, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasAnuladas(this.NitActual, this.FechaActual);
                    //MostrarInformacionAnulada(miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual));
                    MostrarInformacionAnulada();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //16. Anulada + Cliente + Periodo
        private void ConsultaAnuladas(string cliente, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 16;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.NitActual = cliente;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                             (this.NitActual, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasAnuladas(this.NitActual, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasAnuladas(this.NitActual, this.FechaActual, this.FechaActual2);
                    //TResumen = miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual, this.FechaActual2);
                    //MostrarInformacionAnulada(miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacionAnulada();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }


        // funciones de consulta con usuario

        //17  todas + usuario + fecha
        private void ConsultaTodas(int idUsuario, DateTime fecha)
        {
            try
            {
                this.Iteracion = 17;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (idUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasActivas(idUsuario, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentas(this.NitActual, this.FechaActual);
                    // MostrarInformacion(miBussinesFactura.ResumenDeVentas(this.NitActual, this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 18. Todas + usuario + Periodo
        private void ConsultaTodas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 18;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasActivas
                                             (idUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasActivas(idUsuario, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentas(this.NitActual, this.FechaActual, this.FechaActual2);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentas(this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 19. Cancelada + usuario + Fecha
        private void ConsultaCanceladas(int idUsuario, DateTime fecha)
        {
            try
            {
                this.Iteracion = 19;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                             (idUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasContadoActivas(idUsuario, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    // ResumenDeVentasContado(this.NitActual, this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasContado(this.NitActual, this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 20. Cancelada + usuario + Periodo
        private void ConsultaCanceladas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 20;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasContadoActivas
                                             (idUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasContadoActivas(idUsuario, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    // ResumenDeVentasContado(this.NitActual, this.FechaActual, this.FechaActual2);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasContado
                    //(this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 21. Credito + usuario + Fecha
        private void ConsultaCreditos(int idUsuario, DateTime fecha)
        {
            try
            {
                this.Iteracion = 21;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                             (idUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasCreditoActivas(idUsuario, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasCredito(this.NitActual, this.FechaActual);
                    //MostrarInformacion(miBussinesFactura.ResumenDeVentasCredito(this.NitActual, this.FechaActual));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 22. Credito + usuario + Periodo
        private void ConsultaCreditos(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 22;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasCreditoActivas
                                             (idUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasCreditoActivas(idUsuario, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasCredito(this.NitActual, this.FechaActual, this.FechaActual2);
                    // MostrarInformacion(miBussinesFactura.ResumenDeVentasCredito
                    //   (this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacion();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //23. Anulada + usuario + Fecha
        private void ConsultaAnuladas(int idUsuario, DateTime fecha)
        {
            try
            {
                this.Iteracion = 23;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                             (idUsuario, this.FechaActual, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasAnuladas(idUsuario, this.FechaActual);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasAnuladas(this.NitActual, this.FechaActual);
                    //MostrarInformacionAnulada(miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual));
                    MostrarInformacionAnulada();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        //24. Anulada + usuario + Periodo
        private void ConsultaAnuladas(int idUsuario, DateTime fecha, DateTime fecha2)
        {
            try
            {
                this.Iteracion = 24;
                this.RowResumen = 0;
                this.CurrentPageResumen = 1;
                this.FechaActual = fecha;
                this.FechaActual2 = fecha2;
                this.dgvFactura.DataSource = miBussinesFactura.ConsultaFacturasAnuladas
                                             (idUsuario, this.FechaActual, this.FechaActual2, this.RowResumen, this.RowMaxResumen);
                this.TotalRowResumen = miBussinesFactura.GetRowsConsultaFacturasAnuladas(idUsuario, this.FechaActual, this.FechaActual2);
                CalcularPaginas();
                if (this.dgvFactura.RowCount != 0)
                {
                    // calcular
                    //ResumenDeVentasAnuladas(this.NitActual, this.FechaActual, this.FechaActual2);
                    //TResumen = miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual, this.FechaActual2);
                    //MostrarInformacionAnulada(miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual, this.FechaActual2));
                    MostrarInformacionAnulada();
                }
                else
                {
                    // limpiar
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }



        /*
        // 1
        private void ResumenDeVentas(DateTime fecha)
        {
            try
            {
                MostrarInformacion(miBussinesFactura.ResumenDeVentas(fecha));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 2
        private void ResumenDeVentas(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tVentas = miBussinesFactura.ResumenDeVentas(fecha, fecha2);

                this.txtBase.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Base")).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                // Resumen de Utilidad
                this.txtCosto.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString());
                this.txtVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());
                this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 5
        private void ResumenDeVentasContado(DateTime fecha)
        {
            try
            {
                var tVentas = miBussinesFactura.ResumenDeVentasContado(fecha);

                this.txtBase.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Base")).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                // Resumen de Utilidad
                this.txtCosto.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString());
                this.txtVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());
                this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 6
        private void ResumenDeVentasContado(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tVentas = miBussinesFactura.ResumenDeVentasContado(fecha, fecha2);

                this.txtBase.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Base")).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                // Resumen de Utilidad
                this.txtCosto.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString());
                this.txtVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());
                this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 9
        private void ResumenDeVentasCredito(DateTime fecha)
        {
            try
            {
                var tVentas = miBussinesFactura.ResumenDeVentasCredito(fecha);

                this.txtBase.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Base")).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                // Resumen de Utilidad
                this.txtCosto.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString());
                this.txtVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());
                this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        // 10
        private void ResumenDeVentasCredito(DateTime fecha, DateTime fecha2)
        {
            try
            {
                var tVentas = miBussinesFactura.ResumenDeVentasCredito(fecha, fecha2);

                this.txtBase.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Base")).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                // Resumen de Utilidad
                this.txtCosto.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString());
                this.txtVenta.Text = UseObject.InsertSeparatorMil(
                    tVentas.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());
                this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }
        */

        private void MostrarInformacion(DataTable tabla)
        {
            if (tabla.Rows.Count != 0)
            {
                this.txtBase.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    tabla.AsEnumerable().Sum(s => s.Field<double>("Base"))).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    tabla.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    tabla.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    tabla.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                // Resumen de Utilidad
                this.txtCosto.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("TotalC")).ToString());
                this.txtVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    tabla.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());
                this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());
            }
            else
            {
                LimpiarResumen();
            }
        }

        private void MostrarInformacionAnulada(DataTable tabla)
        {
            if (tabla.Rows.Count != 0)
            {
                this.txtBase.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("Base")).ToString());
                this.txtIva.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtTotal.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("Total")).ToString());

                // Resumen Tributario
                this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(
                    tabla.AsEnumerable().Sum(s => s.Field<int>("Iva")).ToString());
                this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());
            }
            else
            {
                LimpiarResumen();
            }
        }

        private void MostrarInformacion()
        {
            miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            this.Enabled = false;
            miThread = new Thread(Consultar);
            miThread.Start();
        }

        private void Consultar()
        {
            try
            {
                switch (this.Iteracion)
                {
                    case 1:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas2(this.FechaActual);

                            //this.Productos = this.miBussinesFactura.ResumenVentas3(this.FechaActual);
                            break;
                        }
                    case 2:
                        {
                            //this.TResumen = miBussinesFactura.ResumenDeVentas(this.FechaActual, this.FechaActual2);
                            this.TResumen = miBussinesFactura.ResumenDeVentas2(this.FechaActual, this.FechaActual2);

                            //this.Productos = this.miBussinesFactura.ResumenVentas3(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 3:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas2(this.NitActual, this.FechaActual);

                            //this.Productos = this.miBussinesFactura.ResumenVentas3(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 4:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas2(this.NitActual, this.FechaActual, this.FechaActual2);

                            //this.Productos = this.miBussinesFactura.ResumenVentas3(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 5:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado2(this.FechaActual);
                            break;
                        }
                    case 6:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado2(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 7:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado2(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 8:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado2(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 9:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito2(this.FechaActual);
                            break;
                        }
                    case 10:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito2(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 11:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito2(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 12:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito2(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 13:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.FechaActual);
                            break;
                        }
                    case 14:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 15:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 16:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 17:  // consultas con usuario
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas2(this.IdUsuario, this.FechaActual);

                            //this.Productos = this.miBussinesFactura.ResumenVentas3(this.IdUsuario, this.FechaActual);
                            break;
                        }
                    case 18:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas2(this.IdUsuario, this.FechaActual, this.FechaActual2);

                            //this.Productos = this.miBussinesFactura.ResumenVentas3(this.IdUsuario, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 19:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado2(this.IdUsuario, this.FechaActual);
                            break;
                        }
                    case 20:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado2(this.IdUsuario, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 21:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito2(this.IdUsuario, this.FechaActual);
                            break;
                        }
                    case 22:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito2(this.IdUsuario, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 23:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.IdUsuario, this.FechaActual);
                            break;
                        }
                    case 24:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.IdUsuario, this.FechaActual, this.FechaActual2);
                            break;
                        }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
        }

        private void Finalizar()
        {
            if (this.TResumen.Rows.Count != 0)
            {
                try
                {
                    this.txtBase.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                    this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Base"))).ToString());
                    this.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());

                    this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());

                    //this.txtTotal.Text = UseObject.InsertSeparatorMil(this.Productos.Sum(s => s.Valor).ToString());

                    // Resumen Tributario
                    this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                    this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                    this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                        UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                    // Resumen de Utilidad
                    this.txtCosto.Text = UseObject.InsertSeparatorMil(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<Int64>("TotalC")).ToString());

               //this.txtCosto.Text = UseObject.InsertSeparatorMil(this.Productos.Sum(s => s.Costo).ToString());

                    /*this.txtVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());*/
                    this.txtVenta.Text = this.txtTotal.Text;
                    this.txtUtilidad.Text = UseObject.InsertSeparatorMil(Convert.ToInt64(
                        UseObject.RemoveSeparatorMil(this.txtVenta.Text) - UseObject.RemoveSeparatorMil(this.txtCosto.Text)).ToString());

                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.Enabled = true;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.Enabled = true;
                }
            }
            else
            {
                LimpiarResumen();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                miOption.FrmProgressBar.Closed_ = false;
                miOption.FrmProgressBar.Close();
                this.Enabled = true;
            }
        }

        private void MostrarInformacionAnulada()
        {
            miOption = new OptionPane();
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
            miOption.FrmProgressBar.Closed_ = true;
            miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                "Operacion en progreso");
            this.Enabled = false;
            miThread = new Thread(ConsultarAnulada);
            miThread.Start();
        }

        private void ConsultarAnulada()
        {
            try
            {
                switch (this.Iteracion)
                {
                    case 1:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas(this.FechaActual);
                            break;
                        }
                    case 2:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 3:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 4:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentas(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 5:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado(this.FechaActual);
                            break;
                        }
                    case 6:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 7:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 8:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasContado(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 9:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito(this.FechaActual);
                            break;
                        }
                    case 10:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 11:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 12:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasCredito(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 13:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada(this.FechaActual);
                            break;
                        }
                    case 14:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada(this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 15:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual);
                            break;
                        }
                    case 16:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada(this.NitActual, this.FechaActual, this.FechaActual2);
                            break;
                        }
                    case 23:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.IdUsuario, this.FechaActual);
                            break;
                        }
                    case 24:
                        {
                            this.TResumen = miBussinesFactura.ResumenDeVentasAnulada2(this.IdUsuario, this.FechaActual, this.FechaActual2);
                            break;
                        }
                }
                if (this.InvokeRequired)
                    this.Invoke(new Action(Finalizar));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinalizarAnulada));
            }
        }

        private void FinalizarAnulada()
        {
            if (this.TResumen.Rows.Count != 0)
            {
                try
                {
                    this.txtBase.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                    this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Base"))).ToString());
                    this.txtIva.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                    this.txtTotal.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Total"))).ToString());

                    // Resumen Tributario
                    this.txtIvaCompra.Text = UseObject.InsertSeparatorMil(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<int>("IvaC")).ToString());
                    this.txtIvaVenta.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        this.TResumen.AsEnumerable().Sum(s => s.Field<double>("Iva"))).ToString());
                    this.txtDiferencia.Text = UseObject.InsertSeparatorMil(Convert.ToInt32(
                        UseObject.RemoveSeparatorMil(this.txtIvaVenta.Text) - UseObject.RemoveSeparatorMil(this.txtIvaCompra.Text)).ToString());

                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.Enabled = true;
                }
                catch (Exception ex)
                {
                    OptionPane.MessageError(ex.Message);
                    miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
                    miOption.FrmProgressBar.Closed_ = false;
                    miOption.FrmProgressBar.Close();
                    this.Enabled = true;
                }
            }
            else
            {
                LimpiarResumen();
            }
        }

        private void LimpiarResumen()
        {
            this.txtBase.Text = "0";
            this.txtIva.Text = "0";
            this.txtTotal.Text = "0";

            this.txtIvaCompra.Text = "0";
            this.txtIvaVenta.Text = "0";
            this.txtDiferencia.Text = "0";

            this.txtCosto.Text = "0";
            this.txtVenta.Text = "0";
            this.txtUtilidad.Text = "0";
        }


        private void CalcularPaginas()
        {
            PaginasResumen = TotalRowResumen / RowMaxResumen;
            if (TotalRowResumen % RowMaxResumen != 0)
                PaginasResumen++;
            if (CurrentPageResumen > PaginasResumen)
                CurrentPageResumen = 0;
            lblStatus.Text = CurrentPageResumen + " / " + PaginasResumen;
        }

        
    }
}