namespace Aplicacion.Ventas.Devolucion
{
    partial class FrmDevolucionRemision
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDevolucionRemision));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbDatosDevolucion = new System.Windows.Forms.GroupBox();
            this.btnFactura = new System.Windows.Forms.Button();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.tsMenuPrincipal = new System.Windows.Forms.ToolStrip();
            this.tsBtnBuscarProducto = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCambiarPrecio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnRetiro = new System.Windows.Forms.ToolStripButton();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnResetear = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.cbDescuentoProducto = new System.Windows.Forms.ComboBox();
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
            this.gbInfo = new System.Windows.Forms.GroupBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.gbDatosDevolucion.SuspendLayout();
            this.tsMenuPrincipal.SuspendLayout();
            this.gbCargaProducto.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.gbInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDatosDevolucion
            // 
            this.gbDatosDevolucion.Controls.Add(this.btnFactura);
            this.gbDatosDevolucion.Controls.Add(this.txtNumeroFactura);
            this.gbDatosDevolucion.Controls.Add(this.dtpFecha);
            this.gbDatosDevolucion.Controls.Add(this.lblNumeroFactura);
            this.gbDatosDevolucion.Controls.Add(this.lblFecha);
            this.gbDatosDevolucion.Location = new System.Drawing.Point(13, 31);
            this.gbDatosDevolucion.Name = "gbDatosDevolucion";
            this.gbDatosDevolucion.Size = new System.Drawing.Size(809, 57);
            this.gbDatosDevolucion.TabIndex = 1;
            this.gbDatosDevolucion.TabStop = false;
            this.gbDatosDevolucion.Text = "Datos de Devolución";
            // 
            // btnFactura
            // 
            this.btnFactura.Location = new System.Drawing.Point(371, 23);
            this.btnFactura.Name = "btnFactura";
            this.btnFactura.Size = new System.Drawing.Size(25, 23);
            this.btnFactura.TabIndex = 1;
            this.btnFactura.Text = "...";
            this.btnFactura.UseVisualStyleBackColor = true;
            this.btnFactura.Click += new System.EventHandler(this.btnFactura_Click);
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(153, 24);
            this.txtNumeroFactura.MaxLength = 5;
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(216, 22);
            this.txtNumeroFactura.TabIndex = 0;
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            this.txtNumeroFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFactura_Validating);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(483, 24);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(92, 22);
            this.dtpFecha.TabIndex = 2;
            this.dtpFecha.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpFecha_KeyPress);
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(9, 27);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(138, 16);
            this.lblNumeroFactura.TabIndex = 3;
            this.lblNumeroFactura.Text = "Número de Remisión:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(431, 27);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha";
            // 
            // tsMenuPrincipal
            // 
            this.tsMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnBuscarProducto,
            this.tsBtnGuardar,
            this.tsBtnCambiarPrecio,
            this.tsBtnRetiro,
            this.tsBtnResetear,
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
            this.tsBtnBuscarProducto.Size = new System.Drawing.Size(148, 22);
            this.tsBtnBuscarProducto.Text = "Buscar Producto [F4]";
            this.tsBtnBuscarProducto.Visible = false;
            this.tsBtnBuscarProducto.Click += new System.EventHandler(this.tsBtnBuscarProducto_Click);
            // 
            // tsBtnCambiarPrecio
            // 
            this.tsBtnCambiarPrecio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCambiarPrecio.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCambiarPrecio.Image")));
            this.tsBtnCambiarPrecio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCambiarPrecio.Name = "tsBtnCambiarPrecio";
            this.tsBtnCambiarPrecio.Size = new System.Drawing.Size(142, 22);
            this.tsBtnCambiarPrecio.Text = "Cambiar Precio [F3]";
            this.tsBtnCambiarPrecio.Click += new System.EventHandler(this.tsBtnCambiarPrecio_Click);
            // 
            // tsBtnRetiro
            // 
            this.tsBtnRetiro.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnRetiro.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnRetiro.Image")));
            this.tsBtnRetiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnRetiro.Name = "tsBtnRetiro";
            this.tsBtnRetiro.Size = new System.Drawing.Size(88, 22);
            this.tsBtnRetiro.Text = "Retiro [F4]";
            this.tsBtnRetiro.Click += new System.EventHandler(this.tsBtnRetiro_Click);
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
            // tsBtnResetear
            // 
            this.tsBtnResetear.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnResetear.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsBtnResetear.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnResetear.Image")));
            this.tsBtnResetear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnResetear.Name = "tsBtnResetear";
            this.tsBtnResetear.Size = new System.Drawing.Size(85, 22);
            this.tsBtnResetear.Text = "Reset [F5]";
            this.tsBtnResetear.Click += new System.EventHandler(this.tsBtnResetear_Click);
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
            this.gbCargaProducto.Controls.Add(this.cbDescuentoProducto);
            this.gbCargaProducto.Controls.Add(this.lblProducto);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.lblCantidad);
            this.gbCargaProducto.Controls.Add(this.txtCantidad);
            this.gbCargaProducto.Controls.Add(this.btnTallaYcolor);
            this.gbCargaProducto.Controls.Add(this.lblDesctoProducto);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(13, 91);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(809, 127);
            this.gbCargaProducto.TabIndex = 2;
            this.gbCargaProducto.TabStop = false;
            this.gbCargaProducto.Text = "Cargar Producto";
            // 
            // cbDescuentoProducto
            // 
            this.cbDescuentoProducto.DisplayMember = "valordescuento";
            this.cbDescuentoProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDescuentoProducto.Enabled = false;
            this.cbDescuentoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cbDescuentoProducto.FormattingEnabled = true;
            this.cbDescuentoProducto.Location = new System.Drawing.Point(752, 22);
            this.cbDescuentoProducto.Name = "cbDescuentoProducto";
            this.cbDescuentoProducto.Size = new System.Drawing.Size(52, 33);
            this.cbDescuentoProducto.TabIndex = 2;
            this.cbDescuentoProducto.ValueMember = "iddescuento";
            this.cbDescuentoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbDescuentoProducto_KeyPress);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblProducto.Location = new System.Drawing.Point(199, 28);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(77, 25);
            this.lblProducto.TabIndex = 5;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigoArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCodigoArticulo.Location = new System.Drawing.Point(276, 26);
            this.txtCodigoArticulo.MaxLength = 10;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(349, 30);
            this.txtCodigoArticulo.TabIndex = 1;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.lblCantidad.Location = new System.Drawing.Point(6, 26);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(91, 25);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.txtCantidad.Location = new System.Drawing.Point(98, 24);
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
            this.btnTallaYcolor.Location = new System.Drawing.Point(627, 28);
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
            this.lblDesctoProducto.Location = new System.Drawing.Point(658, 27);
            this.lblDesctoProducto.Name = "lblDesctoProducto";
            this.lblDesctoProducto.Size = new System.Drawing.Size(91, 25);
            this.lblDesctoProducto.TabIndex = 6;
            this.lblDesctoProducto.Text = "Descto%";
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(9, 65);
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
            this.gbListadoArticulos.Location = new System.Drawing.Point(13, 223);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(1038, 357);
            this.gbListadoArticulos.TabIndex = 3;
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
            this.dgvListaArticulos.Size = new System.Drawing.Size(1028, 327);
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
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N0";
            dataGridViewCellStyle29.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle29;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            this.Cantidad.Width = 98;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "ValorUnitario";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "C0";
            dataGridViewCellStyle30.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle30;
            this.Valor.HeaderText = "Valor Unitario";
            this.Valor.Name = "Valor";
            this.Valor.Width = 112;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle31.NullValue = null;
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle31;
            this.Descuento.HeaderText = "Descto";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            this.Descuento.Width = 57;
            // 
            // ValorMenosDescto
            // 
            this.ValorMenosDescto.DataPropertyName = "ValorMenosDescto";
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle32.Format = "C2";
            dataGridViewCellStyle32.NullValue = null;
            this.ValorMenosDescto.DefaultCellStyle = dataGridViewCellStyle32;
            this.ValorMenosDescto.HeaderText = "Valor - Descto";
            this.ValorMenosDescto.Name = "ValorMenosDescto";
            this.ValorMenosDescto.ReadOnly = true;
            this.ValorMenosDescto.Width = 116;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "Iva";
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle33;
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Width = 43;
            // 
            // TotalMasIva
            // 
            this.TotalMasIva.DataPropertyName = "TotalMasIva";
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle34.Format = "C2";
            dataGridViewCellStyle34.NullValue = null;
            this.TotalMasIva.DefaultCellStyle = dataGridViewCellStyle34;
            this.TotalMasIva.HeaderText = "Valor + Iva";
            this.TotalMasIva.Name = "TotalMasIva";
            this.TotalMasIva.ReadOnly = true;
            this.TotalMasIva.Width = 120;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Valor";
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "C2";
            dataGridViewCellStyle35.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle35;
            this.Total.HeaderText = "Valor Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Width = 130;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(7, 22);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(124, 31);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "TOTAL :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTotal);
            this.groupBox1.Controls.Add(this.lblPesosTotal);
            this.groupBox1.Controls.Add(this.lblTotal);
            this.groupBox1.Location = new System.Drawing.Point(828, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 127);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(30, 66);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(186, 38);
            this.txtTotal.TabIndex = 2;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPesosTotal
            // 
            this.lblPesosTotal.AutoSize = true;
            this.lblPesosTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.lblPesosTotal.Location = new System.Drawing.Point(2, 69);
            this.lblPesosTotal.Name = "lblPesosTotal";
            this.lblPesosTotal.Size = new System.Drawing.Size(29, 31);
            this.lblPesosTotal.TabIndex = 1;
            this.lblPesosTotal.Text = "$";
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.lblInfo);
            this.gbInfo.Location = new System.Drawing.Point(828, 31);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(223, 57);
            this.gbInfo.TabIndex = 13;
            this.gbInfo.TabStop = false;
            this.gbInfo.Text = "Información";
            this.gbInfo.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.Location = new System.Drawing.Point(10, 22);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(196, 18);
            this.lblInfo.TabIndex = 0;
            this.lblInfo.Text = "Devolución de Remisión.";
            this.lblInfo.Visible = false;
            // 
            // FrmDevolucionRemision
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1063, 587);
            this.Controls.Add(this.gbInfo);
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
            this.Name = "FrmDevolucionRemision";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Devolución de Remisión";
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
            this.gbInfo.ResumeLayout(false);
            this.gbInfo.PerformLayout();
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
        private Factura.DataGridViewPlus dgvListaArticulos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Button btnFactura;
        private System.Windows.Forms.ToolStripButton tsBtnBuscarProducto;
        private System.Windows.Forms.ToolStripButton tsBtnCambiarPrecio;
        private System.Windows.Forms.ToolStripButton tsBtnRetiro;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnResetear;
        private System.Windows.Forms.GroupBox gbInfo;
        public System.Windows.Forms.Label lblInfo;

    }
}