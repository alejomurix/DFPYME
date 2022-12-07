using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Aplicacion.Clases;
using BussinesLayer.Clases;
using DTO.Clases;
using Utilities;
using CustomControl;

namespace Aplicacion.Inventario.Cruce
{
    public partial class frmCruce : Form
    {
        /// <summary>
        /// Objeto de logica de negocio para la clase Color.
        /// </summary>
        private BussinesColor miBussinesColor;

        /// <summary>
        /// Objeto de logica de negocio de Producto.
        /// </summary>
        private BussinesProducto miBussinesProducto;

        /// <summary>
        /// Objeto de logica de negocio de Usuario.
        /// </summary>
        private BussinesUsuario miBussinesUsuario;

        /// <summary>
        /// Objeto de logica de negocio de Inventario.
        /// </summary>
        private BussinesInventario miBussinesInventario;

        private BussinesValorUnidadMedida miBussinesMedida;

        /// <summary>
        /// Colleccion que almacena objetos.
        /// </summary>
        private ArrayList arrayProducto;

        /// <summary>
        /// Objeto para cargar productos.
        /// </summary>
        private DTO.Clases.Producto miProducto;

        /// <summary>
        /// Objeto para cargar medidas.
        /// </summary>
        private ValorUnidadMedida miMedida;

        /// <summary>
        /// Obtiene o establece el valor de Id del registro.
        /// </summary>
        private int IdColor = 0;

        /// <summary>
        /// Objeto que representa la fecha y hora del dia;
        /// </summary>
        private DateTime fechaHoy;

        /// <summary>
        /// Objeto que representa una tabla de datos en memoria.
        /// </summary>
        private DataTable miTabla;

        /// <summary>
        /// Objeto que encapsula un origen de datos.
        /// </summary>
        private BindingSource miBindingSource;

        /// <summary>
        /// Objeto tipo hilo que me premite realiza ejecuciones asincronas y sincrona.
        /// </summary>
        private System.Threading.Thread miThread;

        /// <summary>
        /// Objeto que representa el panel de opcion a mostrar.
        /// </summary>
        private OptionPane miOption;

        /// <summary>
        /// Obtiene o establece el valor que indica si se presiono el boton salir.
        /// </summary>
        private bool PrestBtnSalir = false;

        /// <summary>
        /// Obtiene o establece el valor que indica si el ingreso se realizo con exito.
        /// </summary>
        private bool Success = false;

        /// <summary>
        /// Representa una variable para realizar conteo.
        /// </summary>
        private int contador;

        /// <summary>
        /// Obtiene o establece el valor que indica si la configuracion tiene color o no.
        /// </summary>
        private bool ConfigColor = true;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita o no las tallas en el formulario.
        /// </summary>
        private bool EnableTalla = false;

        /// <summary>
        /// Obtiene o establece el valor que indica si se habilita o no el color en el formulario.
        /// </summary>
        private bool EnableColor = false;

        /// <summary>
        /// Establece la regla de validacion que indica si se uso el metodo KeyPress del codigo.
        /// </summary>
        private bool myKeyPress = false;

        /// <summary>
        /// Obtiene o establece el id de la medida.
        /// </summary>
        private int idMedida = 0;

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
        /// Objeto que muestra mensajes de error
        /// </summary>
        private ErrorProvider miError;

        /// <summary>
        /// Representa un mensaje de Campo requerido o con mal formato.
        /// </summary>
        private const string codigoReq = "El Campo es requerido.",
                             codigoFor = "El codigo que ingreso es Incorrecto.",
                             codigoExi = "El Codigo que ingreso no tiene registros en la base de datos.";

        /// <summary>
        /// Establece la condicion para agregar el elemento.
        /// </summary>
        private bool cantidadMatch = false;

        public frmCruce()
        {
            InitializeComponent();

            ConfigColor = Convert.ToBoolean(AppConfiguracion.ValorSeccion("color"));
            InicializarFechaHoy();
            miTabla = new DataTable();
            CrearDataTable();
            miBindingSource = new BindingSource();
            miBussinesProducto = new BussinesProducto();
            miBussinesUsuario = new BussinesUsuario();
            miBussinesInventario = new BussinesInventario();
            miBussinesMedida = new BussinesValorUnidadMedida();
            miBussinesColor = new BussinesColor();
            miError = new ErrorProvider();
        }

        private void frmCruce_Load(object sender, EventArgs e)
        {
            CompletaEventos.Completa += new CompletaEventos.CompletaAccion(CompletaEventos_Completo);
            CompletaEventos.Completam += new CompletaEventos.CompletaAccionm(CompletaEventosm_Completo);
            CompletaEventos.CompAxTInvFactProvee +=
                new CompletaEventos.ComAxTransferInvFactProve(CompletaEventos_CompAxTInvFactProvee);
            ConfigurarColor();
            txtCodigo.Focus();
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.DataSource = miBindingSource;
        }

        private void frmCruce_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:
                    {
                        this.tsBtnGuardar_Click(this.tsBtnGuardar, new EventArgs());
                        break;
                    }
                case Keys.F3:
                    {
                        this.tsConsultarProducto_Click(this.tsConsultarProducto, new EventArgs());
                        break;
                    }
                case Keys.F4:
                    {
                        this.tsbtnEliminar_Click(this.tsbtnEliminar, new EventArgs());
                        break;
                    }
                case Keys.F5:
                    {
                        this.tsBtnNuevoArticulo_Click(this.tsBtnNuevoArticulo, new EventArgs());
                        break;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        break;
                    }
            }

            /*if (e.KeyData == Keys.F2)
            {
                tsBtnGuardar_Click(null, null);
            }
            else
            {
                if (e.KeyData == Keys.F3)
                {
                    tsbtnEliminar_Click(null, null);
                }
                else
                {
                    if (e.KeyData == Keys.F4)
                    {
                        this.tsBtnNuevoArticulo_Click(this.tsBtnNuevoArticulo, new EventArgs());
                        //btnBuscarProducto_Click(this.btnBuscarProducto, new EventArgs());
                    }
                    else
                    {
                        if (e.KeyData == Keys.Escape)
                        {
                            myKeyPress = true;
                            this.Close();
                        }
                    }
                }
            }*/
        }

        private void tsBtnGuardar_Click(object sender, EventArgs e)
        {
            if (miTabla.Rows.Count != 0)
            {
                miOption = new OptionPane();
                miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Marquee;
                miOption.FrmProgressBar.Closed_ = true;
                miOption.ProgressShow("Espere mientras se realizan las operaciones necesarias...",
                    "Operacion en progreso");
                this.Enabled = false;
                miThread = new System.Threading.Thread(start);
                miThread.Start();
            }
        }

        private void tsConsultarProducto_Click(object sender, EventArgs e)
        {
            var formInventario = new Inventario.Consulta.FrmConsultaInventario();
            formInventario.MdiParent = this.MdiParent;
            formInventario.ExtendVenta = true;
            formInventario.IsCompra = true;
            //formInventario.txtCodigoNombre.Text = txtCodigo.Text;
            myKeyPress = true;
            formInventario.Show();

            formInventario.dgvInventario.Focus();
        }

        private void tsbtnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.RowCount != 0)
            {
                string rta = CustomControl.OptionPane.OptionBox
                    ("Ingresar contraseña de Administrador .", "Administrador", CustomControl.OptionPane.Icon.LoginAdmin);
                if (!rta.Equals("false"))
                {
                    if (miBussinesUsuario.VerificarUsuarioAdmin(Encode.Encrypt(rta)))
                    {
                        int id = (int)this.dgvProductos.CurrentRow.Cells["Column8"].Value;
                        var row = (from registro in miTabla.AsEnumerable()
                                   where registro.Field<int>("Id") == id
                                   select registro);
                        DataRow delet = null;
                        foreach (DataRow r in row)
                        {
                            delet = r;
                        }
                        miTabla.Rows.Remove(delet);

                        if (miTabla.Rows.Count != 0)
                        {
                            RecargarGirdView();
                        }
                        else
                        {
                            this.dgvProductos.Rows.RemoveAt(this.dgvProductos.CurrentCell.RowIndex);
                        }
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es Incorrecta.", "Inventario",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void tsBtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            var formProducto = new Inventario.Producto.FrmIngresarProducto();
            //formProducto.Extend = true;
            //formProducto.MdiParent = this.MdiParent;
            formProducto.Extencion = true;
            formProducto.txtNombreProducto.Text = txtCodigo.Text;
            //formProducto.tabControlProducto.SelectedIndex = 1;
            formProducto.ShowDialog();
        }

        private void tsBtnSalir_Click(object sender, EventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?", "Ingresar Inventario.",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (rta == DialogResult.Yes)
            {
                tsBtnGuardar_Click(null, null);
                PrestBtnSalir = true;
                myKeyPress = true;
                this.Close();
            }
            else
            {
                if (rta == DialogResult.No)
                {
                    PrestBtnSalir = true;
                    myKeyPress = true;
                    this.Close();
                }
            }
        }

        private void frmCruce_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!PrestBtnSalir)
            {
                DialogResult rta = MessageBox.Show("¿Desea guardar los cambios?", "Ingresar Inventario.",
                 MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (rta == DialogResult.Yes)
                {
                    tsBtnGuardar_Click(null, null);
                    e.Cancel = false;
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
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (CodigoOrString())
                {
                    if (ValidarCodigoBarras() || ValidarCodigo())
                    {
                        if (ExisteProducto(txtCodigo.Text))
                        {
                            CargarProducto(txtCodigo.Text);
                            miError.SetError(txtCodigo, null);
                            myKeyPress = true;
                            FocoDespuesDeCodigo();
                        }
                        else
                        {
                            MessageBox.Show(codigoExi, "Inventario",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            miError.SetError(txtCodigo, codigoExi);
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
                    if (miBussinesInventario.ConsultaInventarioNombre(txtCodigo.Text, 0, 10).Rows.Count != 0)
                    {
                        /* if (!FormInventario)
                    {*/
                        var formInventario = new Inventario.Consulta.FrmConsultaInventario();
                        formInventario.MdiParent = this.MdiParent;
                        formInventario.ExtendVenta = true;
                        formInventario.IsCompra = true;
                        formInventario.txtCodigoNombre.Text = txtCodigo.Text;
                        myKeyPress = true;
                        // FormInventario = true;
                        formInventario.Show();

                        formInventario.dgvInventario.Focus();
                        //}
                    }
                    else
                    {
                        DialogResult rta = MessageBox.Show("No se encontraron coincidencias.\n¿Desea ingresar un nuevo artículo?", 
                            "Inventario", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (rta.Equals(DialogResult.Yes))
                        {
                            var formProducto = new Inventario.Producto.FrmIngresarProducto();
                            formProducto.Extend = true;
                            formProducto.MdiParent = this.MdiParent;
                            formProducto.Extencion = true;
                            formProducto.txtNombreProducto.Text = txtCodigo.Text;
                            //formProducto.tabControlProducto.SelectedIndex = 1;
                            formProducto.Show();
                        }
                    }
                }
            }
            else
            {
                myKeyPress = false;
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            /*var formProducto = new Inventario.Producto.FrmIngresarProducto();
            formProducto.MdiParent = this.MdiParent;
            formProducto.Extencion = true;
            formProducto.tabControlProducto.SelectedIndex = 1;
            formProducto.Show();*/
        }

        private void txtCodigo_Validating(object sender, CancelEventArgs e)
        {
           /* if (!myKeyPress)
            {
                if (ValidarCodigoBarras() || ValidarCodigo())
                {
                    if (ExisteProducto(txtCodigo.Text))
                    {
                        CargarProducto(txtCodigo.Text);
                        miError.SetError(txtCodigo, null);
                        FocoDespuesDeCodigo();
                    }
                    else
                    {
                        MessageBox.Show(codigoExi, "Inventario",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        miError.SetError(txtCodigo, codigoExi);
                        txtCodigo.Focus();
                    }
                }
                else
                {
                    txtCodigo.Focus();
                }
            }*/
        }

        private void cbTalla_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (btnSelecionarColor.Enabled)
                    btnSelecionarColor.Focus();
                else
                    txtCantidad.Focus();
            }
        }

        private void btnSelecionarColor_Click(object sender, EventArgs e)
        {
            var frmColor = new Compras.IngresarCompra.frmMedidaColor();
            frmColor.MdiParent = this.MdiParent;
            frmColor.AplicaTalla = false;
            frmColor.AplicaColor = miProducto.AplicaColor;
            frmColor.CodigoProducto = miProducto.CodigoInternoProducto;
            if (miProducto.AplicaColor && !miProducto.AplicaTalla)
            {
                frmColor.IdMedida_ = miMedida.IdValorUnidadMedida;
            }
            if (EnableColor && miProducto.AplicaColor)
            {
                frmColor.Show();
            }
            else
            {
                if (miProducto.AplicaTalla)
                {
                    frmColor.AplicaColor = false;
                    frmColor.Show();
                }
            }
            /*this.gbSelecionarColor.Visible = true;
            this.dgvListaColor.Focus();
            CargarGridColor();*/
        }

        private void btnLimpiarColor_Click(object sender, EventArgs e)
        {
            this.pbColor.Image = null;
            IdColor = 0;
        }

        private void btnAgregarColor_Click(object sender, EventArgs e)
        {
            ElColor miColor = new ElColor();
            miColorDialog.AllowFullOpen = true;
            miColorDialog.Color = System.Drawing.Color.White;
            if (miColorDialog.ShowDialog() == DialogResult.OK)
            {
                if (!ExisteColor())
                {
                    pbColor.BackColor = miColorDialog.Color;
                    miColor.MapaBits = ImagenComoString();
                    try
                    {
                        IdColor = miBussinesColor.InsertarColor(miColor);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    this.gbSelecionarColor.Visible = false;
                    this.txtCantidad.Focus();
                }
                else
                {
                    pbColor.BackColor = System.Drawing.Color.White;
                    pbColor.Image = null;
                    MessageBox.Show(
                        "El color seleccionado ya existe. ", "Inventario",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnElegirColor_Click(object sender, EventArgs e)
        {
            if (this.dgvListaColor.RowCount != 0)
            {
                DataGridViewRow row =
                        this.dgvListaColor.Rows[this.dgvListaColor.CurrentCell.RowIndex];
                IdColor = Convert.ToInt16(row.Cells[0].Value);
                pbColor.Image = (Image)row.Cells[1].Value;
                this.gbSelecionarColor.Visible = false;
                this.txtCantidad.Focus();
            }
        }

        private void btnCancelarColor_Click(object sender, EventArgs e)
        {
            this.gbSelecionarColor.Visible = false;
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCantidad_Validating(null, null);
                if (cantidadMatch && arrayProducto != null)
                {
                    EstructurarConsulta();
                }
            }
        }

        private void txtCantidad_Validating(object sender, CancelEventArgs e)
        {
            //var l = this.txtCantidad.TextLength;
            if (!txtCodigo.Focused)
            {
                if (!Validacion.EsVacio(txtCantidad, miError, codigoReq))
                {
                    if (Validacion.ConFormato(
                       Validacion.TipoValidacion.NumerosYPunto, txtCantidad, miError, "El numero que ingreso no es valido."))
                    {
                        if (this.txtCantidad.TextLength > 9)
                        {
                            this.miError.SetError(this.txtCantidad, "El valor es demasiado grande para ser cantidad.");
                            cantidadMatch = false;
                            txtCantidad.Focus();
                        }
                        else
                        {
                            this.miError.SetError(this.txtCantidad, null);
                            cantidadMatch = true;
                        }
                        //cantidadMatch = true;
                    }
                    else
                    {
                        cantidadMatch = false;
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    cantidadMatch = false;
                    txtCantidad.Focus();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            txtCantidad_KeyPress(null, new KeyPressEventArgs((char)Keys.Enter));
        }

        /// <summary>
        /// Despliega el proceso en el hilo (Thread).
        /// </summary>
        private void start()
        {
            IngresarInvetario();
        }

        /// <summary>
        /// Realiza la operacion en el inventario con ayuda de el hilo (Thread).
        /// </summary>
        private void IngresarInvetario()
        {
            try
            {
                foreach (DataRow row in miTabla.Rows)
                {
                    InventarioFisico inventario = new InventarioFisico();
                    inventario.Fecha = fechaHoy;
                    inventario.CodigoProducto = row.Field<string>("Codigo");
                    inventario.IdMedida = row.Field<int>("IdMedida");
                    inventario.IdColor = row.Field<int>("IdColor");
                    inventario.Cantidad = row.Field<double>("Cantidad");
                    inventario.Costo = row.Field<double>("Costo");
                    miBussinesInventario.InsertarInventarioFisico(inventario);
                }
                Success = true;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
                Success = false;
                if (this.InvokeRequired)
                    this.Invoke(new Action(FinishProcess));
            }
        }

        /// <summary>
        /// Finaliza las funciones del proceso de Ingreso de Inventario Fisico.
        /// </summary>
        private void FinishProcess()
        {
            miOption.FrmProgressBar.barraProgreso.Style = ProgressBarStyle.Blocks;
            miOption.FrmProgressBar.Closed_ = false;
            miOption.FrmProgressBar.Close();
            this.Enabled = true;
            if (Success)
            {
                OptionPane.MessageSuccess("Las operaciones se realizaron correctamente.");
                while (miTabla.Rows.Count != 0)
                {
                    miTabla.Rows.Clear();
                }
                while (dgvProductos.RowCount != 0)
                {
                    dgvProductos.Rows.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// Muestra o retira los controles que gestionan los recursos de Color.
        /// </summary>
        private void ConfigurarColor()
        {
            if (!ConfigColor)
            {
                lblColor.Visible = false;
                pbColor.Visible = false;
                btnSelecionarColor.Visible = false;
                btnLimpiarColor.Visible = false;
                this.dgvProductos.Columns.Remove("Column6");
                this.dgvProductos.Columns["Column3"].Width = 150;
                this.dgvProductos.Columns["Column4"].Width = 120;
            }
        }

        /// <summary>
        /// Inicializa una instancia de fecha, con la fecha del dia actual y la carga en Formulario.
        /// </summary>
        private void InicializarFechaHoy()
        {
            fechaHoy = DateTime.Today;
            lblFechaActual.Text = fechaHoy.ToLongDateString();
        }

        private bool SingleSize = false;

        private bool SingleColor = false;

        /// <summary>
        /// Cargar el producto y establece la validacion para talla y color.
        /// </summary>
        /// <param name="codigo">Codigo del producto</param>
        private void CargarProducto(string codigo)
        {
            arrayProducto = new ArrayList();
            miProducto = new DTO.Clases.Producto();
            miMedida = new ValorUnidadMedida();
            try
            {
                arrayProducto = miBussinesProducto.ProductoBasico(codigo);
                miProducto = (DTO.Clases.Producto)arrayProducto[0];
                var tabla = miBussinesMedida.MedidasDeProducto(miProducto.CodigoInternoProducto);
                if (!miProducto.AplicaTalla)
                {
                    miMedida = (ValorUnidadMedida)arrayProducto[1];
                    //SingleSize = true;
                }
                //defino SingleColor:
                if (miProducto.AplicaColor)
                {
                    if (tabla.Rows.Count == 1)
                    {
                        var q = (from d in tabla.AsEnumerable()
                                 select d).Single();
                        var tablaColor = miBussinesColor.ColoresDeProducto
                            (miProducto.CodigoInternoProducto, Convert.ToInt32(q["idvalor_unidad_medida"]));
                        if (tablaColor.Rows.Count == 1)
                        {
                            var c = (from d in tablaColor.AsEnumerable()
                                     select d).Single();
                            IdColor = Convert.ToInt32(c["idcolor"]);
                            pbColor.Image = (Image)c["ImagenBit"];
                            SingleColor = true;
                            btnSelecionarColor.Enabled = false;
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
                lblProducto.Text = miProducto.CodigoInternoProducto + " - " + miProducto.NombreProducto;
                EnableTalla = miProducto.AplicaTalla;
                if (miProducto.AplicaColor)
                {
                    if (SingleColor)
                    {
                        EnableColor = false;
                    }
                    else
                    {
                        EnableColor = true;
                    }
                }
                else
                {
                    EnableColor = false;
                }

                /*if (!SingleColor && miProducto.AplicaColor)
                {
                    EnableColor = miProducto.AplicaColor;
                }*/
                HabilitarTallaYColor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Habilita o no la eleccion de talla y color en el formulario.
        /// </summary>
        private void HabilitarTallaYColor()
        {
            if (EnableTalla && EnableColor)     //Con Talla y Con Color.
            {
                Talla(true);
                CargarComboBoxTalla();
                if (ConfigColor)
                {
                    Color(true);
                    InicializarUtilidadColor();
                }
            }
            if (!EnableTalla && !EnableColor)   //Sin Talla y Sin Color.
            {
                Talla(false);
                if (ConfigColor)
                    Color(false);
            }
            if (EnableTalla && !EnableColor)    //Con Talla y Sin Color.
            {
                Talla(true);
                CargarComboBoxTalla();
                if (ConfigColor)
                    Color(false);

            }
            if (!EnableTalla && EnableColor)    //Sin Talla y Con Color.
            {
                Talla(false);
                if (ConfigColor)
                {
                    Color(true);
                    InicializarUtilidadColor();
                }
            }
        }

        /// <summary>
        /// Establece el estado de los obetos de Talla.
        /// </summary>
        /// <param name="estado"></param>
        private void Talla(bool estado)
        {
            lblTalla.Enabled = estado;
            cbTalla.Enabled = estado;
        }

        /// <summary>
        /// Establece el estado de los objetos de Color.
        /// </summary>
        /// <param name="estado"></param>
        private void Color(bool estado)
        {
            lblColor.Enabled = estado;
            pbColor.Enabled = estado;
            btnSelecionarColor.Enabled = estado;
            btnLimpiarColor.Enabled = estado;
        }

        /// <summary>
        /// Carga el combo box con las tallas.
        /// </summary>
        private void CargarComboBoxTalla()
        {
            BussinesValorUnidadMedida miBussinesValorMedida =
                new BussinesValorUnidadMedida();
            try
            {
                this.cbTalla.DataSource = miBussinesValorMedida.ListadoDeTallas();
                if (this.cbTalla.Items.Count != 0)
                    idMedida = Convert.ToInt16(this.cbTalla.SelectedValue);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inicializa nuevas instancias de las utilidades para el manejo de Color.
        /// </summary>
        private void InicializarUtilidadColor()
        {
            miBussinesColor = new BussinesColor();
            miColorDialog = new ColorDialog();
            CrearDirectorio();
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
                    (ex.Message, "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Verifica si el texto ingresado equivale a un número o palabra. Retorna true si es un número.
        /// </summary>
        /// <returns></returns>
        private bool CodigoOrString()
        {
            try
            {
                Convert.ToInt64(txtCodigo.Text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Valida el texto ingresado como codigo del producto.
        /// </summary>
        /// <returns></returns>
        private bool ValidarCodigo()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigo, miError, codigoReq))
            {
                if (Validacion.ConFormato(
                    Validacion.TipoValidacion.LetrasGuionNumeros, txtCodigo, miError, codigoFor))
                {
                    resultado = true;
                }
            }
            return resultado;
        }

        /// <summary>
        /// Valida el texto ingresado como codigo de barras del producto.
        /// </summary>
        /// <returns></returns>
        private bool ValidarCodigoBarras()
        {
            bool resultado = false;
            if (!Validacion.EsVacio(txtCodigo, miError, codigoReq))
            {
                if (Validacion.ConFormato(
                    Validacion.TipoValidacion.Numeros, txtCodigo, miError, codigoFor))
                {
                    resultado = true;
                }
            }
            return resultado;
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
        /// Establece el siguiente control en obtener el foco.
        /// </summary>
        private void FocoDespuesDeCodigo()
        {
            if (cbTalla.Enabled)
            {
                cbTalla.Focus();
            }
            else
            {
                if (btnSelecionarColor.Enabled)
                {
                    btnSelecionarColor.Focus();
                }
                else
                {
                    txtCantidad.Focus();
                }
            }
        }

        /// <summary>
        /// Crea las respectivas columnas del DataTable.
        /// </summary>
        private void CrearDataTable()
        {
            miTabla.Columns.Add(new DataColumn("Id", typeof(int)));
            miTabla.Columns.Add(new DataColumn("Codigo", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Codigo de Barras", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Producto", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Marca", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Unidad", typeof(string)));
            miTabla.Columns.Add(new DataColumn("Medida", typeof(string)));
            if (ConfigColor)
                miTabla.Columns.Add(new DataColumn("Color", typeof(Image)));
            miTabla.Columns.Add(new DataColumn("Cantidad", typeof(double)));

            miTabla.Columns.Add(new DataColumn("IdMedida", typeof(int)));
            miTabla.Columns.Add(new DataColumn("IdColor", typeof(int)));

            miTabla.Columns.Add(new DataColumn("Costo", typeof(double)));
            miTabla.Columns.Add(new DataColumn("ValorVenta", typeof(int)));
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }

        void CompletaEventos_Completo(CompletaArgumentosDeEvento args)
        {
            try
            {
                var tallaYcolor = (Compras.IngresarCompra.TallaYcolor)args.MiObjeto;
                IdColor = tallaYcolor.IdColor;
                pbColor.Image = tallaYcolor.Color;
                this.txtCantidad.Focus();
            }
            catch { }
        }

        void CompletaEventosm_Completo(CompletaArgumentosDeEventom args)
        {
            try
            {
                var product = (DTO.Clases.Producto) args.MiMarca;
                txtCodigo.Text = product.CodigoInternoProducto;
            }
            catch { }
        }

        void CompletaEventos_CompAxTInvFactProvee(CompletaTransInvFactProvee args)
        {
            try
            {
                var producto = (DTO.Clases.Producto)args.MiObjeto;
                txtCodigo.Text = producto.CodigoInternoProducto;
                txtCodigo_KeyPress(txtCodigo, new KeyPressEventArgs((char)Keys.Enter));
            }
            catch { }
        }

        /// <summary>
        /// Estructura la consulta segun los datos de entrada y la configuracion.
        /// </summary>
        private void EstructurarConsulta()
        {
            try
            {
                contador++;
                if (arrayProducto.Count != 0)
                {
                    miProducto.ValorCosto = miBussinesProducto.PrecioDeCosto(miProducto.CodigoInternoProducto);
                    var inventario = new DTO.Clases.Inventario();
                    inventario.CodigoProducto = miProducto.CodigoInternoProducto;
                    if (EnableTalla)
                    {
                        var medida = (DataRowView)this.cbTalla.SelectedItem;
                        inventario.IdMedida = Convert.ToInt16(medida["idvalor_unidad_medida"]);
                    }
                    else
                    {
                        inventario.IdMedida = miMedida.IdValorUnidadMedida;
                    }
                    inventario.IdColor = IdColor;
                    var query = from data in miTabla.AsEnumerable()
                                where data.Field<string>("Codigo").Equals(inventario.CodigoProducto)
                                   && data.Field<int>("IdMedida").Equals(inventario.IdMedida)
                                   && data.Field<int>("IdColor").Equals(inventario.IdColor)
                                select data;
                    var tCant = 0.0;
                    var lstRow = new List<DataRow>();
                    foreach (var qRow in query)
                    {
                        tCant += Convert.ToDouble(qRow["Cantidad"]);
                        lstRow.Add(qRow);
                    }
                    /*query = from data in miTabla.AsEnumerable()
                                where data.Field<string>("Codigo").Equals(inventario.CodigoProducto)
                                   && data.Field<int>("IdMedida").Equals(inventario.IdMedida)
                                   && data.Field<int>("IdColor").Equals(inventario.IdColor)
                                select data;*/
                    foreach (var qRow in lstRow)
                    {
                        miTabla.Rows.Remove(qRow);
                    }

                    DataRow row = miTabla.NewRow();
                    row["Id"] = contador;
                    row["Codigo"] = miProducto.CodigoInternoProducto;
                    row["Codigo de Barras"] = miProducto.CodigoBarrasProducto;
                    row["Producto"] = miProducto.NombreProducto;
                    row["Marca"] = miProducto.NombreMarca;
                    if (ConfigColor)
                        row["Color"] = pbColor.Image;
                    row["IdColor"] = IdColor;
                    row["Cantidad"] = Convert.ToDouble(txtCantidad.Text.Replace('.', ',')) + tCant;
                    if (EnableTalla)
                    {
                        var medida = (DataRowView)this.cbTalla.SelectedItem;
                        row["Unidad"] = "Talla";
                        row["Medida"] = Convert.ToString(medida["descripcionvalor_unidad_medida"]);
                        row["IdMedida"] = Convert.ToInt16(medida["idvalor_unidad_medida"]);
                    }
                    else
                    {
                        row["Unidad"] = miMedida.DescripcionUnidadMedida;
                        row["Medida"] = miMedida.DescripcionValorUnidadMedida;
                        row["IdMedida"] = miMedida.IdValorUnidadMedida;
                    }
                    row["Costo"] = Math.Round((miProducto.ValorCosto + (miProducto.ValorCosto * miProducto.ValorIva / 100)) + 
                                                    miProducto.Impoconsumo, 0);
                    row["ValorVenta"] = miProducto.ValorVentaProducto;
                    //var query = 
                    miTabla.Rows.Add(row);
                    RecargarGirdView();
                    LimpiarCampos();
                }
            }
            catch (Exception ex)
            {
                OptionPane.MessageError(ex.Message);
            }
        }

        /// <summary>
        /// Recarga los datos del GridView segun los datos en el DataTable.
        /// </summary>
        private void RecargarGirdView()
        {
            IEnumerable<DataRow> query = from datos in miTabla.AsEnumerable()
                                         orderby datos.Field<int>("Id") descending
                                         select datos;
            DataTable copy = query.CopyToDataTable<DataRow>();
            miBindingSource.DataSource = copy;
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void LimpiarCampos()
        {
            this.txtCodigo.Focus();
            this.txtCodigo.Text = "";
            this.pbColor.BackColor = System.Drawing.Color.White;
            this.pbColor.Image = null;
            this.IdColor = 0;
            this.txtCantidad.Text = "";
            this.lblProducto.Text = "";
        }
    }

    /// <summary>
    /// Representa una clase para estucturar opciones.
    /// </summary>
    internal class Opcion
    {
        /// <summary>
        /// Obtiene o establece el Id de la opcion.
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// Obtiene o establece el nombre de la opcion.
        /// </summary>
        public string Nombre { set; get; }
    }
}