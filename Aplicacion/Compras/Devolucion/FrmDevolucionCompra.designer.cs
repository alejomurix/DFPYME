namespace Aplicacion.Compras.Devolucion
{
    partial class FrmDevolucionCompra
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        System.ComponentModel.ComponentResourceManager miResources =
            new System.ComponentModel.ComponentResourceManager(typeof(Ventas.Factura.FrmFacturaVenta));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucionCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatosDevolucion = new System.Windows.Forms.GroupBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.lblDatoFecha = new System.Windows.Forms.Label();
            this.btnFactura = new System.Windows.Forms.Button();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cbDescuentoProducto = new System.Windows.Forms.ComboBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.tsMenuPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnBuscarProducto = new System.Windows.Forms.ToolStripButton();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsConsultarProducto = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCambiarPrecio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRetiro = new System.Windows.Forms.ToolStripButton();
            this.tsBtnReset = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.lblDesctoProducto = new System.Windows.Forms.Label();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.dgvListaArticulos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.CLote = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorMenosDescto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalMasIva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblPesosTotal = new System.Windows.Forms.Label();
            this.gbDatosDevolucion.SuspendLayout();
            this.tsMenuPrincipal.SuspendLayout();
            this.gbCargaProducto.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosDevolucion
            // 
            this.gbDatosDevolucion.Controls.Add(this.btnBuscarProveedor);
            this.gbDatosDevolucion.Controls.Add(this.txtNombreProveedor);
            this.gbDatosDevolucion.Controls.Add(this.cbCriterio);
            this.gbDatosDevolucion.Controls.Add(this.txtCodigoProveedor);
            this.gbDatosDevolucion.Controls.Add(this.label2);
            this.gbDatosDevolucion.Controls.Add(this.label1);
            this.gbDatosDevolucion.Controls.Add(this.txtConcepto);
            this.gbDatosDevolucion.Controls.Add(this.lblDatoFecha);
            this.gbDatosDevolucion.Controls.Add(this.btnFactura);
            this.gbDatosDevolucion.Controls.Add(this.txtNumeroFactura);
            this.gbDatosDevolucion.Controls.Add(this.lblNumeroFactura);
            this.gbDatosDevolucion.Controls.Add(this.lblFecha);
            this.gbDatosDevolucion.Location = new System.Drawing.Point(13, 31);
            this.gbDatosDevolucion.Name = "gbDatosDevolucion";
            this.gbDatosDevolucion.Size = new System.Drawing.Size(889, 96);
            this.gbDatosDevolucion.TabIndex = 0;
            this.gbDatosDevolucion.TabStop = false;
            this.gbDatosDevolucion.Text = "Datos de Devolución";
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(337, 24);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(25, 22);
            this.btnBuscarProveedor.TabIndex = 1;
            this.btnBuscarProveedor.Text = "...";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProveedor.Location = new System.Drawing.Point(369, 24);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(509, 22);
            this.txtNombreProveedor.TabIndex = 2;
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(107, 22);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(104, 24);
            this.cbCriterio.TabIndex = 19;
            this.cbCriterio.ValueMember = "Id";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Location = new System.Drawing.Point(217, 24);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(106, 22);
            this.txtCodigoProveedor.TabIndex = 0;
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Proveedor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(508, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Concepto";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Location = new System.Drawing.Point(578, 57);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(300, 22);
            this.txtConcepto.TabIndex = 5;
            this.txtConcepto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConcepto_KeyPress);
            // 
            // lblDatoFecha
            // 
            this.lblDatoFecha.AutoSize = true;
            this.lblDatoFecha.Location = new System.Drawing.Point(424, 60);
            this.lblDatoFecha.Name = "lblDatoFecha";
            this.lblDatoFecha.Size = new System.Drawing.Size(72, 16);
            this.lblDatoFecha.TabIndex = 5;
            this.lblDatoFecha.Text = "20/07/2014";
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(337, 57);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(25, 23);
            this.btnFactura.TabIndex = 4;
            this.btnFactura.Text = "...";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Visible = false;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(107, 58);
            this.txtNumeroFactura.MaxLength = 100;
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(216, 22);
            this.txtNumeroFactura.TabIndex = 3;
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            this.txtNumeroFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFactura_Validating);
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(8, 61);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(93, 16);
            this.lblNumeroFactura.TabIndex = 3;
            this.lblNumeroFactura.Text = "No de Factura";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(372, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha";
            // 
            // cbDescuentoProducto
            // 
            this.cbDescuentoProducto.DisplayMember = "valordescuento";
            this.cbDescuentoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDescuentoProducto.Enabled = false;
            this.cbDescuentoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbDescuentoProducto.FormattingEnabled = true;
            this.cbDescuentoProducto.Location = new System.Drawing.Point(203, 21);
            this.cbDescuentoProducto.Name = "cbDescuentoProducto";
            this.cbDescuentoProducto.Size = new System.Drawing.Size(13, 21);
            this.cbDescuentoProducto.TabIndex = 2;
            this.cbDescuentoProducto.ValueMember = "iddescuento";
            this.cbDescuentoProducto.Visible = false;
            this.cbDescuentoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDescuentoProducto_KeyPress);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(185, 21);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(10, 22);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.Visible = false;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // tsMenuPrincipal
            // 
            this.tsMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnBuscarProducto,
            this.tsBtnGuardar,
            this.tsConsultarProducto,
            this.tsBtnCambiarPrecio,
            this.tsBtnRetiro,
            this.tsBtnReset,
            this.tsBtnSalir});
            this.tsMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tsMenuPrincipal.Name = "tsMenuPrincipal";
            this.tsMenuPrincipal.Size = new System.Drawing.Size(1063, 25);
            this.tsMenuPrincipal.TabIndex = 0;
            this.tsMenuPrincipal.Text = "toolStrip1";
            // 
            // tsBtnBuscarProducto
            // 
            this.tsBtnBuscarProducto.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnBuscarProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnBuscarProducto.Image")));
            this.tsBtnBuscarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnBuscarProducto.Name = "tsBtnBuscarProducto";
            this.tsBtnBuscarProducto.Size = new System.Drawing.Size(123, 22);
            this.tsBtnBuscarProducto.Text = "Buscar Producto";
            this.tsBtnBuscarProducto.Visible = false;
            this.tsBtnBuscarProducto.Click += new System.EventHandler(this.tsBtnBuscarProducto_Click);
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsBtnGuardar.Text = "Guardar [F2]";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsConsultarProducto
            // 
            this.tsConsultarProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultarProducto.Image")));
            this.tsConsultarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConsultarProducto.Name = "tsConsultarProducto";
            this.tsConsultarProducto.Size = new System.Drawing.Size(158, 22);
            this.tsConsultarProducto.Text = "Consultar Productos [F3]";
            this.tsConsultarProducto.ToolTipText = "Consultar Producto";
            this.tsConsultarProducto.Click += new System.EventHandler(this.tsConsultarProducto_Click);
            // 
            // tsBtnCambiarPrecio
            // 
            this.tsBtnCambiarPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCambiarPrecio.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCambiarPrecio.Image")));
            this.tsBtnCambiarPrecio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCambiarPrecio.Name = "tsBtnCambiarPrecio";
            this.tsBtnCambiarPrecio.Size = new System.Drawing.Size(142, 22);
            this.tsBtnCambiarPrecio.Text = "Cambiar Precio [F4]";
            this.tsBtnCambiarPrecio.Click += new System.EventHandler(this.tsBtnCambiarPrecio_Click);
            // 
            // tsBtnRetiro
            // 
            this.tsBtnRetiro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnRetiro.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRetiro.Image")));
            this.tsBtnRetiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRetiro.Name = "tsBtnRetiro";
            this.tsBtnRetiro.Size = new System.Drawing.Size(88, 22);
            this.tsBtnRetiro.Text = "Retiro [F5]";
            this.tsBtnRetiro.Click += new System.EventHandler(this.tsBtnRetiro_Click);
            // 
            // tsBtnReset
            // 
            this.tsBtnReset.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnReset.Image")));
            this.tsBtnReset.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnReset.Name = "tsBtnReset";
            this.tsBtnReset.Size = new System.Drawing.Size(78, 22);
            this.tsBtnReset.Text = "Reset [F6]";
            this.tsBtnReset.Click += new System.EventHandler(this.tsBtnReset_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbCargaProducto
            // 
            this.gbCargaProducto.Controls.Add(this.txtDescuento);
            this.gbCargaProducto.Controls.Add(this.lblProducto);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.lblCantidad);
            this.gbCargaProducto.Controls.Add(this.txtCantidad);
            this.gbCargaProducto.Controls.Add(this.btnTallaYcolor);
            this.gbCargaProducto.Controls.Add(this.lblDesctoProducto);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(13, 131);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(809, 112);
            this.gbCargaProducto.TabIndex = 1;
            this.gbCargaProducto.TabStop = false;
            this.gbCargaProducto.Text = "Cargar Producto";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtDescuento.Location = new System.Drawing.Point(751, 17);
            this.txtDescuento.MaxLength = 10;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.Size = new System.Drawing.Size(48, 30);
            this.txtDescuento.TabIndex = 8;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento_KeyPress);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblProducto.Location = new System.Drawing.Point(199, 21);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(77, 25);
            this.lblProducto.TabIndex = 5;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCodigoArticulo.Location = new System.Drawing.Point(276, 19);
            this.txtCodigoArticulo.MaxLength = 1000;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(349, 30);
            this.txtCodigoArticulo.TabIndex = 1;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCantidad.Location = new System.Drawing.Point(6, 19);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(91, 25);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCantidad.Location = new System.Drawing.Point(98, 17);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(95, 30);
            this.txtCantidad.TabIndex = 0;
            this.txtCantidad.Text = "1";
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.Enabled = false;
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(627, 21);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 3;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // lblDesctoProducto
            // 
            this.lblDesctoProducto.AutoSize = true;
            this.lblDesctoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblDesctoProducto.Location = new System.Drawing.Point(658, 20);
            this.lblDesctoProducto.Name = "lblDesctoProducto";
            this.lblDesctoProducto.Size = new System.Drawing.Size(91, 25);
            this.lblDesctoProducto.TabIndex = 6;
            this.lblDesctoProducto.Text = "Descto%";
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(9, 55);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(795, 41);
            this.panelProducto.TabIndex = 7;
            // 
            // lblDatosProducto
            // 
            this.lblDatosProducto.AutoSize = true;
            this.lblDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
            this.lblDatosProducto.Location = new System.Drawing.Point(5, 7);
            this.lblDatosProducto.Name = "lblDatosProducto";
            this.lblDatosProducto.Size = new System.Drawing.Size(0, 25);
            this.lblDatosProducto.TabIndex = 0;
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(13, 246);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(1038, 284);
            this.gbListadoArticulos.TabIndex = 2;
            this.gbListadoArticulos.TabStop = false;
            this.gbListadoArticulos.Text = "Listado de Articulos";
            // 
            // dgvListaArticulos
            // 
            this.dgvListaArticulos.AllowUserToAddRows = false;
            this.dgvListaArticulos.AllowUserToResizeColumns = false;
            this.dgvListaArticulos.AllowUserToResizeRows = false;
            this.dgvListaArticulos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Articulo,
            this.Unidad,
            this.Medida,
            this.Color,
            this.CLote,
            this.Cantidad,
            this.Valor,
            this.Descuento,
            this.ValorMenosDescto,
            this.Iva,
            this.TotalMasIva,
            this.Total});
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(4, 22);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.Size = new System.Drawing.Size(1028, 258);
            this.dgvListaArticulos.TabIndex = 0;
            this.dgvListaArticulos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvListaArticulos_CellValidating);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 78;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Articulo";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 203;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Unidad.Visible = false;
            this.Unidad.Width = 55;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Visible = false;
            this.Medida.Width = 60;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Color.Visible = false;
            this.Color.Width = 60;
            // 
            // CLote
            // 
            this.CLote.DataPropertyName = "Lote";
            this.CLote.HeaderText = "Lote";
            this.CLote.Name = "CLote";
            this.CLote.Visible = false;
            this.CLote.Width = 60;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 98;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "ValorUnitario";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Valor Unitario";
            this.Valor.Name = "Valor";
            this.Valor.Width = 112;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N1";
            dataGridViewCellStyle3.NullValue = null;
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle3;
            this.Descuento.HeaderText = "Descto";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 57;
            // 
            // ValorMenosDescto
            // 
            this.ValorMenosDescto.DataPropertyName = "ValorMenosDescto";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            dataGridViewCellStyle4.NullValue = null;
            this.ValorMenosDescto.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorMenosDescto.HeaderText = "Valor - Descto";
            this.ValorMenosDescto.Name = "ValorMenosDescto";
            this.ValorMenosDescto.ReadOnly = true;
            this.ValorMenosDescto.Width = 116;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "Iva";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle5;
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Width = 43;
            // 
            // TotalMasIva
            // 
            this.TotalMasIva.DataPropertyName = "TotalMasIva";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.TotalMasIva.DefaultCellStyle = dataGridViewCellStyle6;
            this.TotalMasIva.HeaderText = "Valor + Iva";
            this.TotalMasIva.Name = "TotalMasIva";
            this.TotalMasIva.ReadOnly = true;
            this.TotalMasIva.Width = 120;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Valor";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle7;
            this.Total.HeaderText = "Valor Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 130;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(7, 14);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 31);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.cbDescuentoProducto);
            this.groupBox1.Controls.Add(this.lblPesosTotal);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Location = new System.Drawing.Point(828, 131);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 112);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(30, 58);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(186, 38);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPesosTotal
            // 
            this.lblPesosTotal.AutoSize = true;
            this.lblPesosTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblPesosTotal.Location = new System.Drawing.Point(2, 61);
            this.lblPesosTotal.Name = "lblPesosTotal";
            this.lblPesosTotal.Size = new System.Drawing.Size(29, 31);
            this.lblPesosTotal.TabIndex = 1;
            this.lblPesosTotal.Text = "$";
            // 
            // FrmDevolucionCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1063, 542);
            this.Controls.Add(this.tsMenuPrincipal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbCargaProducto);
            this.Controls.Add(this.gbDatosDevolucion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDevolucionCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución de Factura Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDevolucion_FormClosing);
            this.Load += new System.EventHandler(this.FrmDevolucion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmDevolucion_KeyDown);
            this.gbDatosDevolucion.ResumeLayout(false);
            this.gbDatosDevolucion.PerformLayout();
            this.tsMenuPrincipal.ResumeLayout(false);
            this.tsMenuPrincipal.PerformLayout();
            this.gbCargaProducto.ResumeLayout(false);
            this.gbCargaProducto.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbDatosDevolucion;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.ToolStrip tsMenuPrincipal;
        private System.Windows.Forms.GroupBox gbCargaProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblDesctoProducto;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.ComboBox cbDescuentoProducto;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblPesosTotal;
        private Ventas.Factura.DataGridViewPlus dgvListaArticulos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.ToolStripButton tsBtnBuscarProducto;
        private System.Windows.Forms.ToolStripButton tsBtnCambiarPrecio;
        private System.Windows.Forms.ToolStripButton tsBtnRetiro;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.TextBox txtDescuento;
        private System.Windows.Forms.Label lblDatoFecha;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.ToolStripButton tsBtnReset;
        private System.Windows.Forms.ToolStripButton tsConsultarProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn CLote;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorMenosDescto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalMasIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;

    }
}