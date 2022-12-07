namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmCompraSimple
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCompraSimple));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbResultadoConsulta = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.dgvProductos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kilogramo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Arroba = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbDatosFactura = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsConsulta = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTotalDescuento = new System.Windows.Forms.TextBox();
            this.dgvDescuentos = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.IdDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblGranTotal = new System.Windows.Forms.Label();
            this.txtGranTotal = new System.Windows.Forms.TextBox();
            this.lblTotalDescuento = new System.Windows.Forms.Label();
            this.txtTotalDesc = new System.Windows.Forms.TextBox();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.lblResumen = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPago = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.gbResultadoConsulta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbDatosFactura.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbResultadoConsulta
            // 
            this.gbResultadoConsulta.Controls.Add(this.label4);
            this.gbResultadoConsulta.Controls.Add(this.label2);
            this.gbResultadoConsulta.Controls.Add(this.txtTotal);
            this.gbResultadoConsulta.Controls.Add(this.dgvProductos);
            this.gbResultadoConsulta.Location = new System.Drawing.Point(5, 127);
            this.gbResultadoConsulta.Margin = new System.Windows.Forms.Padding(5);
            this.gbResultadoConsulta.Name = "gbResultadoConsulta";
            this.gbResultadoConsulta.Padding = new System.Windows.Forms.Padding(5);
            this.gbResultadoConsulta.Size = new System.Drawing.Size(808, 531);
            this.gbResultadoConsulta.TabIndex = 1;
            this.gbResultadoConsulta.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label4.Location = new System.Drawing.Point(7, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 22);
            this.label4.TabIndex = 5;
            this.label4.Text = "Productos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(523, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 31);
            this.label2.TabIndex = 14;
            this.label2.Text = "TOTAL :";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(659, 485);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(141, 38);
            this.txtTotal.TabIndex = 13;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.AllowUserToResizeColumns = false;
            this.dgvProductos.AllowUserToResizeRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Producto,
            this.Precio,
            this.Kilogramo,
            this.Arroba,
            this.Valor,
            this.Cantidad});
            this.dgvProductos.Location = new System.Drawing.Point(6, 20);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(795, 459);
            this.dgvProductos.TabIndex = 1;
            this.dgvProductos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvProductos_CellValidating);
            this.dgvProductos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvProductos_CurrentCellDirtyStateChanged);
            this.dgvProductos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvProductos_DataError);
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
            this.Codigo.Visible = false;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.ReadOnly = true;
            this.Producto.Width = 340;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N0";
            dataGridViewCellStyle7.NullValue = "0";
            this.Precio.DefaultCellStyle = dataGridViewCellStyle7;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.Width = 112;
            // 
            // Kilogramo
            // 
            this.Kilogramo.DataPropertyName = "Kilogramo";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Kilogramo.DefaultCellStyle = dataGridViewCellStyle8;
            this.Kilogramo.HeaderText = "Kilo";
            this.Kilogramo.Name = "Kilogramo";
            // 
            // Arroba
            // 
            this.Arroba.DataPropertyName = "Arroba";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.Arroba.DefaultCellStyle = dataGridViewCellStyle9;
            this.Arroba.HeaderText = "Arroba";
            this.Arroba.Name = "Arroba";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            this.Valor.DefaultCellStyle = dataGridViewCellStyle10;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            this.Valor.ReadOnly = true;
            this.Valor.Width = 120;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N1";
            dataGridViewCellStyle11.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle11;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Visible = false;
            this.Cantidad.Width = 120;
            // 
            // gbDatosFactura
            // 
            this.gbDatosFactura.Controls.Add(this.label5);
            this.gbDatosFactura.Controls.Add(this.lblFecha);
            this.gbDatosFactura.Controls.Add(this.dtpFecha);
            this.gbDatosFactura.Controls.Add(this.lblNombreProveedor);
            this.gbDatosFactura.Controls.Add(this.txtCodigoProveedor);
            this.gbDatosFactura.Controls.Add(this.btnBuscarProveedor);
            this.gbDatosFactura.Controls.Add(this.txtNombreProveedor);
            this.gbDatosFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosFactura.Location = new System.Drawing.Point(5, 27);
            this.gbDatosFactura.Name = "gbDatosFactura";
            this.gbDatosFactura.Size = new System.Drawing.Size(820, 96);
            this.gbDatosFactura.TabIndex = 0;
            this.gbDatosFactura.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label5.Location = new System.Drawing.Point(7, -3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(131, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Datos de compra";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(10, 60);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(54, 20);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(100, 57);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(108, 26);
            this.dtpFecha.TabIndex = 18;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreProveedor.Location = new System.Drawing.Point(10, 26);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(81, 20);
            this.lblNombreProveedor.TabIndex = 9;
            this.lblNombreProveedor.Text = "Proveedor";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProveedor.Location = new System.Drawing.Point(100, 24);
            this.txtCodigoProveedor.MaxLength = 50;
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(108, 26);
            this.txtCodigoProveedor.TabIndex = 0;
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarProveedor.Location = new System.Drawing.Point(213, 24);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(30, 26);
            this.btnBuscarProveedor.TabIndex = 1;
            this.btnBuscarProveedor.Text = "...";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProveedor.Location = new System.Drawing.Point(249, 24);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(551, 26);
            this.txtNombreProveedor.TabIndex = 2;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardar,
            this.tsConsulta,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1222, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "Menu";
            // 
            // tsGuardar
            // 
            this.tsGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardar.Image")));
            this.tsGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGuardar.Name = "tsGuardar";
            this.tsGuardar.Size = new System.Drawing.Size(101, 22);
            this.tsGuardar.Text = "Guardar [F2]";
            this.tsGuardar.Click += new System.EventHandler(this.tsGuardar_Click);
            // 
            // tsConsulta
            // 
            this.tsConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsConsulta.Image")));
            this.tsConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConsulta.Name = "tsConsulta";
            this.tsConsulta.Size = new System.Drawing.Size(109, 22);
            this.tsConsulta.Text = "Consultas [F3]";
            this.tsConsulta.ToolTipText = "Consultas [F3]";
            this.tsConsulta.Click += new System.EventHandler(this.tsConsulta_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(87, 22);
            this.tsSalir.Text = "Salir [ESC]";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtTotalDescuento);
            this.groupBox1.Controls.Add(this.dgvDescuentos);
            this.groupBox1.Location = new System.Drawing.Point(819, 127);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(396, 244);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.label3.Location = new System.Drawing.Point(6, -3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Descuentos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(123, 196);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 31);
            this.label1.TabIndex = 14;
            this.label1.Text = "TOTAL :";
            // 
            // txtTotalDescuento
            // 
            this.txtTotalDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.txtTotalDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDescuento.Location = new System.Drawing.Point(250, 193);
            this.txtTotalDescuento.Name = "txtTotalDescuento";
            this.txtTotalDescuento.ReadOnly = true;
            this.txtTotalDescuento.Size = new System.Drawing.Size(141, 38);
            this.txtTotalDescuento.TabIndex = 13;
            this.txtTotalDescuento.Text = "0";
            this.txtTotalDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgvDescuentos
            // 
            this.dgvDescuentos.AllowUserToAddRows = false;
            this.dgvDescuentos.AllowUserToResizeColumns = false;
            this.dgvDescuentos.AllowUserToResizeRows = false;
            this.dgvDescuentos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDescuentos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDescuento,
            this.Nombre,
            this.ValorDescuento});
            this.dgvDescuentos.Location = new System.Drawing.Point(5, 21);
            this.dgvDescuentos.Name = "dgvDescuentos";
            this.dgvDescuentos.RowHeadersVisible = false;
            this.dgvDescuentos.Size = new System.Drawing.Size(386, 165);
            this.dgvDescuentos.TabIndex = 1;
            this.dgvDescuentos.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvDescuentos_CellValidating);
            this.dgvDescuentos.CurrentCellDirtyStateChanged += new System.EventHandler(this.dgvDescuentos_CurrentCellDirtyStateChanged);
            // 
            // IdDescuento
            // 
            this.IdDescuento.DataPropertyName = "Id";
            this.IdDescuento.HeaderText = "Id";
            this.IdDescuento.Name = "IdDescuento";
            this.IdDescuento.Visible = false;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Descuento";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 260;
            // 
            // ValorDescuento
            // 
            this.ValorDescuento.DataPropertyName = "Valor";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = "0";
            this.ValorDescuento.DefaultCellStyle = dataGridViewCellStyle12;
            this.ValorDescuento.HeaderText = "Valor";
            this.ValorDescuento.Name = "ValorDescuento";
            this.ValorDescuento.Width = 120;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Menu;
            this.groupBox2.Controls.Add(this.lblGranTotal);
            this.groupBox2.Controls.Add(this.txtGranTotal);
            this.groupBox2.Controls.Add(this.lblTotalDescuento);
            this.groupBox2.Controls.Add(this.txtTotalDesc);
            this.groupBox2.Controls.Add(this.lblSubTotal);
            this.groupBox2.Controls.Add(this.txtSubtotal);
            this.groupBox2.Controls.Add(this.lblResumen);
            this.groupBox2.Location = new System.Drawing.Point(819, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(396, 155);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            // 
            // lblGranTotal
            // 
            this.lblGranTotal.AutoSize = true;
            this.lblGranTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGranTotal.Location = new System.Drawing.Point(116, 112);
            this.lblGranTotal.Name = "lblGranTotal";
            this.lblGranTotal.Size = new System.Drawing.Size(124, 31);
            this.lblGranTotal.TabIndex = 20;
            this.lblGranTotal.Text = "TOTAL :";
            // 
            // txtGranTotal
            // 
            this.txtGranTotal.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtGranTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGranTotal.Location = new System.Drawing.Point(250, 109);
            this.txtGranTotal.Name = "txtGranTotal";
            this.txtGranTotal.ReadOnly = true;
            this.txtGranTotal.Size = new System.Drawing.Size(141, 38);
            this.txtGranTotal.TabIndex = 19;
            this.txtGranTotal.Text = "0";
            this.txtGranTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotalDescuento
            // 
            this.lblTotalDescuento.AutoSize = true;
            this.lblTotalDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDescuento.Location = new System.Drawing.Point(19, 69);
            this.lblTotalDescuento.Name = "lblTotalDescuento";
            this.lblTotalDescuento.Size = new System.Drawing.Size(221, 31);
            this.lblTotalDescuento.TabIndex = 18;
            this.lblTotalDescuento.Text = "TOTAL DESC. :";
            // 
            // txtTotalDesc
            // 
            this.txtTotalDesc.BackColor = System.Drawing.Color.Lavender;
            this.txtTotalDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalDesc.Location = new System.Drawing.Point(250, 66);
            this.txtTotalDesc.Name = "txtTotalDesc";
            this.txtTotalDesc.ReadOnly = true;
            this.txtTotalDesc.Size = new System.Drawing.Size(141, 38);
            this.txtTotalDesc.TabIndex = 17;
            this.txtTotalDesc.Text = "0";
            this.txtTotalDesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(47, 26);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(193, 31);
            this.lblSubTotal.TabIndex = 16;
            this.lblSubTotal.Text = "SUB-TOTAL :";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.txtSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubtotal.Location = new System.Drawing.Point(250, 23);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(141, 38);
            this.txtSubtotal.TabIndex = 15;
            this.txtSubtotal.Text = "0";
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.lblResumen.Location = new System.Drawing.Point(5, 2);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(86, 22);
            this.lblResumen.TabIndex = 0;
            this.lblResumen.Text = "Resumen";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txtPago);
            this.groupBox3.Location = new System.Drawing.Point(819, 530);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(396, 66);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(69, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(173, 31);
            this.label6.TabIndex = 22;
            this.label6.Text = "PAGO [F5] :";
            // 
            // txtPago
            // 
            this.txtPago.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPago.Location = new System.Drawing.Point(249, 21);
            this.txtPago.Name = "txtPago";
            this.txtPago.Size = new System.Drawing.Size(141, 38);
            this.txtPago.TabIndex = 21;
            this.txtPago.Text = "0";
            this.txtPago.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPago.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPago_KeyPress);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnGuardar);
            this.groupBox4.Location = new System.Drawing.Point(819, 596);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(396, 62);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(287, 19);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(103, 32);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // FrmCompraSimple
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1222, 666);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbDatosFactura);
            this.Controls.Add(this.gbResultadoConsulta);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCompraSimple";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.FrmCompraSimple_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCompraSimple_KeyDown);
            this.gbResultadoConsulta.ResumeLayout(false);
            this.gbResultadoConsulta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbDatosFactura.ResumeLayout(false);
            this.gbDatosFactura.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDescuentos)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbResultadoConsulta;
        private Ventas.Factura.DataGridViewPlus dgvProductos;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbDatosFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsGuardar;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.ToolStripButton tsConsulta;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTotalDescuento;
        private Ventas.Factura.DataGridViewPlus dgvDescuentos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblResumen;
        private System.Windows.Forms.Label lblGranTotal;
        private System.Windows.Forms.TextBox txtGranTotal;
        private System.Windows.Forms.Label lblTotalDescuento;
        private System.Windows.Forms.TextBox txtTotalDesc;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorDescuento;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPago;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kilogramo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Arroba;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.Button btnBuscarProveedor;


    }
}