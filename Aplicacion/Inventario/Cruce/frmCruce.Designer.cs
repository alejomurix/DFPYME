namespace Aplicacion.Inventario.Cruce
{
    partial class frmCruce
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCruce));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenuInventario = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsConsultarProducto = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNuevoArticulo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbSelecionarColor = new System.Windows.Forms.GroupBox();
            this.btnAgregarColor = new System.Windows.Forms.Button();
            this.btnElegirColor = new System.Windows.Forms.Button();
            this.btnCancelarColor = new System.Windows.Forms.Button();
            this.dgvListaColor = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewImageColumn();
            this.gbDatosInventario = new System.Windows.Forms.GroupBox();
            this.btnBuscarProducto = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.lblCodigoProducto = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblTalla = new System.Windows.Forms.Label();
            this.cbTalla = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.btnSelecionarColor = new System.Windows.Forms.Button();
            this.btnLimpiarColor = new System.Windows.Forms.Button();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Costo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuInventario.SuspendLayout();
            this.gbSelecionarColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaColor)).BeginInit();
            this.gbDatosInventario.SuspendLayout();
            this.panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.gbProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenuInventario
            // 
            this.tsMenuInventario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMenuInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsConsultarProducto,
            this.tsbtnEliminar,
            this.tsBtnNuevoArticulo,
            this.tsBtnSalir});
            this.tsMenuInventario.Location = new System.Drawing.Point(0, 0);
            this.tsMenuInventario.Name = "tsMenuInventario";
            this.tsMenuInventario.Size = new System.Drawing.Size(1110, 25);
            this.tsMenuInventario.TabIndex = 33;
            this.tsMenuInventario.Text = "Menu Principal";
            // 
            // tsBtnGuardar
            // 
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
            this.tsConsultarProducto.Size = new System.Drawing.Size(171, 22);
            this.tsConsultarProducto.Text = "Consultar Productos [F3]";
            this.tsConsultarProducto.ToolTipText = "Consultar Producto";
            this.tsConsultarProducto.Click += new System.EventHandler(this.tsConsultarProducto_Click);
            // 
            // tsbtnEliminar
            // 
            this.tsbtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminar.Image")));
            this.tsbtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminar.Name = "tsbtnEliminar";
            this.tsbtnEliminar.Size = new System.Drawing.Size(99, 22);
            this.tsbtnEliminar.Text = "Eliminar [F4]";
            this.tsbtnEliminar.Click += new System.EventHandler(this.tsbtnEliminar_Click);
            // 
            // tsBtnNuevoArticulo
            // 
            this.tsBtnNuevoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNuevoArticulo.Image")));
            this.tsBtnNuevoArticulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNuevoArticulo.Name = "tsBtnNuevoArticulo";
            this.tsBtnNuevoArticulo.Size = new System.Drawing.Size(139, 22);
            this.tsBtnNuevoArticulo.Text = "Nuevo Articulo [F5]";
            this.tsBtnNuevoArticulo.Click += new System.EventHandler(this.tsBtnNuevoArticulo_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 22);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbSelecionarColor
            // 
            this.gbSelecionarColor.Controls.Add(this.btnAgregarColor);
            this.gbSelecionarColor.Controls.Add(this.btnElegirColor);
            this.gbSelecionarColor.Controls.Add(this.btnCancelarColor);
            this.gbSelecionarColor.Controls.Add(this.dgvListaColor);
            this.gbSelecionarColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbSelecionarColor.Location = new System.Drawing.Point(204, 41);
            this.gbSelecionarColor.Name = "gbSelecionarColor";
            this.gbSelecionarColor.Size = new System.Drawing.Size(133, 271);
            this.gbSelecionarColor.TabIndex = 32;
            this.gbSelecionarColor.TabStop = false;
            this.gbSelecionarColor.Text = "Seleccionar Color";
            this.gbSelecionarColor.Visible = false;
            // 
            // btnAgregarColor
            // 
            this.btnAgregarColor.FlatAppearance.BorderSize = 0;
            this.btnAgregarColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarColor.Image")));
            this.btnAgregarColor.Location = new System.Drawing.Point(19, 23);
            this.btnAgregarColor.Name = "btnAgregarColor";
            this.btnAgregarColor.Size = new System.Drawing.Size(19, 18);
            this.btnAgregarColor.TabIndex = 1;
            this.btnAgregarColor.UseVisualStyleBackColor = true;
            this.btnAgregarColor.Click += new System.EventHandler(this.btnAgregarColor_Click);
            // 
            // btnElegirColor
            // 
            this.btnElegirColor.FlatAppearance.BorderSize = 0;
            this.btnElegirColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnElegirColor.Image = ((System.Drawing.Image)(resources.GetObject("btnElegirColor.Image")));
            this.btnElegirColor.Location = new System.Drawing.Point(56, 23);
            this.btnElegirColor.Name = "btnElegirColor";
            this.btnElegirColor.Size = new System.Drawing.Size(19, 18);
            this.btnElegirColor.TabIndex = 2;
            this.btnElegirColor.UseVisualStyleBackColor = true;
            this.btnElegirColor.Click += new System.EventHandler(this.btnElegirColor_Click);
            // 
            // btnCancelarColor
            // 
            this.btnCancelarColor.FlatAppearance.BorderSize = 0;
            this.btnCancelarColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelarColor.Image")));
            this.btnCancelarColor.Location = new System.Drawing.Point(91, 23);
            this.btnCancelarColor.Name = "btnCancelarColor";
            this.btnCancelarColor.Size = new System.Drawing.Size(19, 18);
            this.btnCancelarColor.TabIndex = 3;
            this.btnCancelarColor.UseVisualStyleBackColor = true;
            this.btnCancelarColor.Click += new System.EventHandler(this.btnCancelarColor_Click);
            // 
            // dgvListaColor
            // 
            this.dgvListaColor.AllowUserToAddRows = false;
            this.dgvListaColor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListaColor.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedHeaders;
            this.dgvListaColor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListaColor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListaColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListaColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column11});
            this.dgvListaColor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaColor.Location = new System.Drawing.Point(8, 50);
            this.dgvListaColor.MultiSelect = false;
            this.dgvListaColor.Name = "dgvListaColor";
            this.dgvListaColor.Size = new System.Drawing.Size(114, 210);
            this.dgvListaColor.TabIndex = 0;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "IdColor";
            this.Column10.HeaderText = "Id";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "ImagenBit";
            this.Column11.HeaderText = "Color";
            this.Column11.Name = "Column11";
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // gbDatosInventario
            // 
            this.gbDatosInventario.Controls.Add(this.btnBuscarProducto);
            this.gbDatosInventario.Controls.Add(this.lblFecha);
            this.gbDatosInventario.Controls.Add(this.lblFechaActual);
            this.gbDatosInventario.Controls.Add(this.lblCodigoProducto);
            this.gbDatosInventario.Controls.Add(this.txtCodigo);
            this.gbDatosInventario.Controls.Add(this.lblTalla);
            this.gbDatosInventario.Controls.Add(this.cbTalla);
            this.gbDatosInventario.Controls.Add(this.lblCantidad);
            this.gbDatosInventario.Controls.Add(this.txtCantidad);
            this.gbDatosInventario.Controls.Add(this.btnAgregar);
            this.gbDatosInventario.Controls.Add(this.panelProducto);
            this.gbDatosInventario.Controls.Add(this.lblColor);
            this.gbDatosInventario.Controls.Add(this.pbColor);
            this.gbDatosInventario.Controls.Add(this.btnSelecionarColor);
            this.gbDatosInventario.Controls.Add(this.btnLimpiarColor);
            this.gbDatosInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosInventario.Location = new System.Drawing.Point(16, 41);
            this.gbDatosInventario.Name = "gbDatosInventario";
            this.gbDatosInventario.Size = new System.Drawing.Size(846, 136);
            this.gbDatosInventario.TabIndex = 30;
            this.gbDatosInventario.TabStop = false;
            this.gbDatosInventario.Text = "Datos de Inventario";
            // 
            // btnBuscarProducto
            // 
            this.btnBuscarProducto.Location = new System.Drawing.Point(385, 54);
            this.btnBuscarProducto.Name = "btnBuscarProducto";
            this.btnBuscarProducto.Size = new System.Drawing.Size(25, 24);
            this.btnBuscarProducto.TabIndex = 38;
            this.btnBuscarProducto.Text = "...";
            this.btnBuscarProducto.UseVisualStyleBackColor = true;
            this.btnBuscarProducto.Click += new System.EventHandler(this.btnBuscarProducto_Click);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(11, 25);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(49, 16);
            this.lblFecha.TabIndex = 33;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaActual.Location = new System.Drawing.Point(81, 25);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(0, 16);
            this.lblFechaActual.TabIndex = 34;
            // 
            // lblCodigoProducto
            // 
            this.lblCodigoProducto.AutoSize = true;
            this.lblCodigoProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoProducto.Location = new System.Drawing.Point(13, 58);
            this.lblCodigoProducto.Name = "lblCodigoProducto";
            this.lblCodigoProducto.Size = new System.Drawing.Size(70, 16);
            this.lblCodigoProducto.TabIndex = 37;
            this.lblCodigoProducto.Text = "Producto";
            // 
            // txtCodigo
            // 
            this.txtCodigo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCodigo.Location = new System.Drawing.Point(114, 55);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(264, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // lblTalla
            // 
            this.lblTalla.AutoSize = true;
            this.lblTalla.Enabled = false;
            this.lblTalla.Location = new System.Drawing.Point(442, 57);
            this.lblTalla.Name = "lblTalla";
            this.lblTalla.Size = new System.Drawing.Size(39, 16);
            this.lblTalla.TabIndex = 31;
            this.lblTalla.Text = "Talla";
            // 
            // cbTalla
            // 
            this.cbTalla.DisplayMember = "descripcionvalor_unidad_medida";
            this.cbTalla.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTalla.Enabled = false;
            this.cbTalla.FormattingEnabled = true;
            this.cbTalla.Location = new System.Drawing.Point(498, 53);
            this.cbTalla.Name = "cbTalla";
            this.cbTalla.Size = new System.Drawing.Size(77, 24);
            this.cbTalla.TabIndex = 1;
            this.cbTalla.ValueMember = "idvalor_unidad_medida";
            this.cbTalla.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbTalla_KeyPress);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(605, 56);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtCantidad.Location = new System.Drawing.Point(677, 53);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(123, 22);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(808, 51);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(25, 24);
            this.btnAgregar.TabIndex = 5;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblProducto);
            this.panelProducto.Location = new System.Drawing.Point(14, 96);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(396, 27);
            this.panelProducto.TabIndex = 36;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblProducto.Location = new System.Drawing.Point(8, 6);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(0, 16);
            this.lblProducto.TabIndex = 35;
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Enabled = false;
            this.lblColor.Location = new System.Drawing.Point(442, 99);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(40, 16);
            this.lblColor.TabIndex = 2;
            this.lblColor.Text = "Color";
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.White;
            this.pbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColor.Enabled = false;
            this.pbColor.Location = new System.Drawing.Point(499, 99);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(49, 16);
            this.pbColor.TabIndex = 26;
            this.pbColor.TabStop = false;
            // 
            // btnSelecionarColor
            // 
            this.btnSelecionarColor.Enabled = false;
            this.btnSelecionarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnSelecionarColor.Image")));
            this.btnSelecionarColor.Location = new System.Drawing.Point(547, 98);
            this.btnSelecionarColor.Name = "btnSelecionarColor";
            this.btnSelecionarColor.Size = new System.Drawing.Size(25, 18);
            this.btnSelecionarColor.TabIndex = 3;
            this.btnSelecionarColor.Text = "...";
            this.btnSelecionarColor.UseVisualStyleBackColor = true;
            this.btnSelecionarColor.Click += new System.EventHandler(this.btnSelecionarColor_Click);
            // 
            // btnLimpiarColor
            // 
            this.btnLimpiarColor.Enabled = false;
            this.btnLimpiarColor.FlatAppearance.BorderSize = 0;
            this.btnLimpiarColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiarColor.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiarColor.Image")));
            this.btnLimpiarColor.Location = new System.Drawing.Point(572, 100);
            this.btnLimpiarColor.Name = "btnLimpiarColor";
            this.btnLimpiarColor.Size = new System.Drawing.Size(17, 15);
            this.btnLimpiarColor.TabIndex = 32;
            this.btnLimpiarColor.UseVisualStyleBackColor = true;
            this.btnLimpiarColor.Click += new System.EventHandler(this.btnLimpiarColor_Click);
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.dgvProductos);
            this.gbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbProducto.Location = new System.Drawing.Point(13, 194);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(1085, 388);
            this.gbProducto.TabIndex = 34;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Producto";
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column12,
            this.Column9,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column13,
            this.Column5,
            this.Column6,
            this.Costo,
            this.Precio,
            this.Column7});
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.InfoText;
            this.dgvProductos.Location = new System.Drawing.Point(13, 21);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(1062, 361);
            this.dgvProductos.TabIndex = 2;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Id";
            this.Column8.HeaderText = "Id";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "IdColor";
            this.Column12.HeaderText = "IdColor";
            this.Column12.Name = "Column12";
            this.Column12.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "IdMedida";
            this.Column9.HeaderText = "IdMedida";
            this.Column9.Name = "Column9";
            this.Column9.Visible = false;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Codigo";
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Codigo de Barras";
            this.Column2.HeaderText = "Codigo de Barras";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Producto";
            this.Column3.HeaderText = "Producto";
            this.Column3.Name = "Column3";
            this.Column3.Width = 443;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "Marca";
            this.Column4.HeaderText = "Marca";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            this.Column4.Width = 80;
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "Unidad";
            this.Column13.HeaderText = "Unidad";
            this.Column13.Name = "Column13";
            this.Column13.Width = 120;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "Medida";
            this.Column5.HeaderText = "Medida";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            this.Column5.Width = 80;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "Color";
            this.Column6.HeaderText = "Color";
            this.Column6.Name = "Column6";
            this.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column6.Visible = false;
            this.Column6.Width = 80;
            // 
            // Costo
            // 
            this.Costo.DataPropertyName = "Costo";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.Costo.DefaultCellStyle = dataGridViewCellStyle1;
            this.Costo.HeaderText = "Costo";
            this.Costo.Name = "Costo";
            this.Costo.Width = 120;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "ValorVenta";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle2;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.Width = 120;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "Cantidad";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.Column7.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column7.HeaderText = "Cantidad";
            this.Column7.Name = "Column7";
            this.Column7.Width = 120;
            // 
            // frmCruce
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1110, 594);
            this.Controls.Add(this.tsMenuInventario);
            this.Controls.Add(this.gbSelecionarColor);
            this.Controls.Add(this.gbDatosInventario);
            this.Controls.Add(this.gbProducto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCruce";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingresar Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCruce_FormClosing);
            this.Load += new System.EventHandler(this.frmCruce_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCruce_KeyDown);
            this.tsMenuInventario.ResumeLayout(false);
            this.tsMenuInventario.PerformLayout();
            this.gbSelecionarColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaColor)).EndInit();
            this.gbDatosInventario.ResumeLayout(false);
            this.gbDatosInventario.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.gbProducto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSelecionarColor;
        private System.Windows.Forms.Button btnCancelarColor;
        private System.Windows.Forms.Button btnElegirColor;
        private System.Windows.Forms.Button btnAgregarColor;
        private System.Windows.Forms.DataGridView dgvListaColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewImageColumn Column11;
        private System.Windows.Forms.GroupBox gbDatosInventario;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Button btnLimpiarColor;
        private System.Windows.Forms.Label lblTalla;
        private System.Windows.Forms.ComboBox cbTalla;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.Button btnSelecionarColor;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.ToolStrip tsMenuInventario;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnEliminar;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Label lblCodigoProducto;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.Button btnBuscarProducto;
        private System.Windows.Forms.ToolStripButton tsBtnNuevoArticulo;
        private System.Windows.Forms.ToolStripButton tsConsultarProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Costo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}