namespace Aplicacion.Compras.PreIngreso
{
    partial class FrmPreIngresoCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPreIngresoCompra));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosFactura = new System.Windows.Forms.GroupBox();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantUltCompra = new System.Windows.Forms.TextBox();
            this.txtCantPreingreso = new System.Windows.Forms.TextBox();
            this.txtCantInventario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCostoMasIvaInfo = new System.Windows.Forms.TextBox();
            this.txtIvaInfo = new System.Windows.Forms.TextBox();
            this.txtCostoBaseInfo = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtDescuento2 = new System.Windows.Forms.TextBox();
            this.txtDescuento1 = new System.Windows.Forms.TextBox();
            this.txtCostoMasIva = new System.Windows.Forms.TextBox();
            this.txtCostoBase = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.D2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsMenu.SuspendLayout();
            this.gbDatosFactura.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            this.panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardar,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(916, 25);
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
            // gbDatosFactura
            // 
            this.gbDatosFactura.Controls.Add(this.btnTallaYcolor);
            this.gbDatosFactura.Controls.Add(this.lblFecha);
            this.gbDatosFactura.Controls.Add(this.dtpFecha);
            this.gbDatosFactura.Controls.Add(this.lblNombreProveedor);
            this.gbDatosFactura.Controls.Add(this.txtCodigoProveedor);
            this.gbDatosFactura.Controls.Add(this.btnBuscarProveedor);
            this.gbDatosFactura.Controls.Add(this.txtNombreProveedor);
            this.gbDatosFactura.Controls.Add(this.lblNumeroFactura);
            this.gbDatosFactura.Controls.Add(this.txtNumeroFactura);
            this.gbDatosFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosFactura.Location = new System.Drawing.Point(6, 32);
            this.gbDatosFactura.Name = "gbDatosFactura";
            this.gbDatosFactura.Size = new System.Drawing.Size(903, 87);
            this.gbDatosFactura.TabIndex = 0;
            this.gbDatosFactura.TabStop = false;
            // 
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(480, 51);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 19;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Visible = false;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(327, 55);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(46, 16);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha";
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(385, 52);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha.TabIndex = 4;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNombreProveedor.Location = new System.Drawing.Point(10, 22);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(72, 16);
            this.lblNombreProveedor.TabIndex = 9;
            this.lblNombreProveedor.Text = "Proveedor";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProveedor.Location = new System.Drawing.Point(139, 19);
            this.txtCodigoProveedor.MaxLength = 50;
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(129, 22);
            this.txtCodigoProveedor.TabIndex = 0;
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(274, 19);
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
            this.txtNombreProveedor.Location = new System.Drawing.Point(305, 19);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(564, 22);
            this.txtNombreProveedor.TabIndex = 2;
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(10, 52);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(123, 16);
            this.lblNumeroFactura.TabIndex = 10;
            this.lblNumeroFactura.Text = "Número de Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(139, 52);
            this.txtNumeroFactura.MaxLength = 20;
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(161, 22);
            this.txtNumeroFactura.TabIndex = 3;
            this.txtNumeroFactura.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumeroFactura_KeyPress);
            this.txtNumeroFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFactura_Validating);
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.label9);
            this.gbListadoArticulos.Controls.Add(this.txtTotal);
            this.gbListadoArticulos.Controls.Add(this.label6);
            this.gbListadoArticulos.Controls.Add(this.label7);
            this.gbListadoArticulos.Controls.Add(this.label8);
            this.gbListadoArticulos.Controls.Add(this.txtCantUltCompra);
            this.gbListadoArticulos.Controls.Add(this.txtCantPreingreso);
            this.gbListadoArticulos.Controls.Add(this.txtCantInventario);
            this.gbListadoArticulos.Controls.Add(this.label3);
            this.gbListadoArticulos.Controls.Add(this.label4);
            this.gbListadoArticulos.Controls.Add(this.label5);
            this.gbListadoArticulos.Controls.Add(this.txtCostoMasIvaInfo);
            this.gbListadoArticulos.Controls.Add(this.txtIvaInfo);
            this.gbListadoArticulos.Controls.Add(this.txtCostoBaseInfo);
            this.gbListadoArticulos.Controls.Add(this.btnAgregar);
            this.gbListadoArticulos.Controls.Add(this.label11);
            this.gbListadoArticulos.Controls.Add(this.label10);
            this.gbListadoArticulos.Controls.Add(this.label2);
            this.gbListadoArticulos.Controls.Add(this.label1);
            this.gbListadoArticulos.Controls.Add(this.lblCantidad);
            this.gbListadoArticulos.Controls.Add(this.txtDescuento2);
            this.gbListadoArticulos.Controls.Add(this.txtDescuento1);
            this.gbListadoArticulos.Controls.Add(this.txtCostoMasIva);
            this.gbListadoArticulos.Controls.Add(this.txtCostoBase);
            this.gbListadoArticulos.Controls.Add(this.txtCantidad);
            this.gbListadoArticulos.Controls.Add(this.lblProducto);
            this.gbListadoArticulos.Controls.Add(this.txtCodigoArticulo);
            this.gbListadoArticulos.Controls.Add(this.panelProducto);
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Controls.Add(this.panelMenuGrid);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(6, 122);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(903, 417);
            this.gbListadoArticulos.TabIndex = 1;
            this.gbListadoArticulos.TabStop = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label9.Location = new System.Drawing.Point(689, 391);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 16);
            this.label9.TabIndex = 32;
            this.label9.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtTotal.Location = new System.Drawing.Point(744, 388);
            this.txtTotal.MaxLength = 20;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(125, 22);
            this.txtTotal.TabIndex = 31;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label6.Location = new System.Drawing.Point(737, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cant. Ult. Compra";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label7.Location = new System.Drawing.Point(607, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 16);
            this.label7.TabIndex = 29;
            this.label7.Text = "Cant. Preingreso";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label8.Location = new System.Drawing.Point(488, 112);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Cant. Inventario";
            // 
            // txtCantUltCompra
            // 
            this.txtCantUltCompra.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtCantUltCompra.Location = new System.Drawing.Point(739, 130);
            this.txtCantUltCompra.MaxLength = 20;
            this.txtCantUltCompra.Name = "txtCantUltCompra";
            this.txtCantUltCompra.ReadOnly = true;
            this.txtCantUltCompra.Size = new System.Drawing.Size(120, 22);
            this.txtCantUltCompra.TabIndex = 26;
            this.txtCantUltCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCantPreingreso
            // 
            this.txtCantPreingreso.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtCantPreingreso.Location = new System.Drawing.Point(608, 130);
            this.txtCantPreingreso.MaxLength = 20;
            this.txtCantPreingreso.Name = "txtCantPreingreso";
            this.txtCantPreingreso.ReadOnly = true;
            this.txtCantPreingreso.Size = new System.Drawing.Size(116, 22);
            this.txtCantPreingreso.TabIndex = 25;
            this.txtCantPreingreso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCantInventario
            // 
            this.txtCantInventario.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txtCantInventario.Location = new System.Drawing.Point(489, 130);
            this.txtCantInventario.MaxLength = 20;
            this.txtCantInventario.Name = "txtCantInventario";
            this.txtCantInventario.ReadOnly = true;
            this.txtCantInventario.Size = new System.Drawing.Size(106, 22);
            this.txtCantInventario.TabIndex = 27;
            this.txtCantInventario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label3.Location = new System.Drawing.Point(201, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Costo + Iva";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label4.Location = new System.Drawing.Point(134, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 16);
            this.label4.TabIndex = 23;
            this.label4.Text = "Iva";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label5.Location = new System.Drawing.Point(15, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 16);
            this.label5.TabIndex = 24;
            this.label5.Text = "Costo base";
            // 
            // txtCostoMasIvaInfo
            // 
            this.txtCostoMasIvaInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtCostoMasIvaInfo.Location = new System.Drawing.Point(203, 130);
            this.txtCostoMasIvaInfo.MaxLength = 20;
            this.txtCostoMasIvaInfo.Name = "txtCostoMasIvaInfo";
            this.txtCostoMasIvaInfo.ReadOnly = true;
            this.txtCostoMasIvaInfo.Size = new System.Drawing.Size(106, 22);
            this.txtCostoMasIvaInfo.TabIndex = 20;
            this.txtCostoMasIvaInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIvaInfo
            // 
            this.txtIvaInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtIvaInfo.Location = new System.Drawing.Point(134, 130);
            this.txtIvaInfo.MaxLength = 20;
            this.txtIvaInfo.Name = "txtIvaInfo";
            this.txtIvaInfo.ReadOnly = true;
            this.txtIvaInfo.Size = new System.Drawing.Size(49, 22);
            this.txtIvaInfo.TabIndex = 19;
            this.txtIvaInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtCostoBaseInfo
            // 
            this.txtCostoBaseInfo.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.txtCostoBaseInfo.Location = new System.Drawing.Point(17, 130);
            this.txtCostoBaseInfo.MaxLength = 20;
            this.txtCostoBaseInfo.Name = "txtCostoBaseInfo";
            this.txtCostoBaseInfo.ReadOnly = true;
            this.txtCostoBaseInfo.Size = new System.Drawing.Size(102, 22);
            this.txtCostoBaseInfo.TabIndex = 21;
            this.txtCostoBaseInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(775, 74);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(84, 24);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label11.Location = new System.Drawing.Point(811, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 16);
            this.label11.TabIndex = 18;
            this.label11.Text = "D-2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label10.Location = new System.Drawing.Point(758, 19);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "D-1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label2.Location = new System.Drawing.Point(642, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 18;
            this.label2.Text = "Costo + Iva";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(526, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Costo base";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantidad.Location = new System.Drawing.Point(427, 20);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 18;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtDescuento2
            // 
            this.txtDescuento2.Location = new System.Drawing.Point(812, 38);
            this.txtDescuento2.MaxLength = 20;
            this.txtDescuento2.Name = "txtDescuento2";
            this.txtDescuento2.Size = new System.Drawing.Size(47, 22);
            this.txtDescuento2.TabIndex = 1;
            this.txtDescuento2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento2_KeyPress);
            this.txtDescuento2.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuento2_Validating);
            // 
            // txtDescuento1
            // 
            this.txtDescuento1.Location = new System.Drawing.Point(759, 38);
            this.txtDescuento1.MaxLength = 20;
            this.txtDescuento1.Name = "txtDescuento1";
            this.txtDescuento1.Size = new System.Drawing.Size(47, 22);
            this.txtDescuento1.TabIndex = 1;
            this.txtDescuento1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDescuento1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuento1_KeyPress);
            this.txtDescuento1.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuento1_Validating);
            // 
            // txtCostoMasIva
            // 
            this.txtCostoMasIva.Location = new System.Drawing.Point(644, 38);
            this.txtCostoMasIva.MaxLength = 20;
            this.txtCostoMasIva.Name = "txtCostoMasIva";
            this.txtCostoMasIva.Size = new System.Drawing.Size(106, 22);
            this.txtCostoMasIva.TabIndex = 1;
            this.txtCostoMasIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostoMasIva.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoMasIva_KeyPress);
            this.txtCostoMasIva.Validating += new System.ComponentModel.CancelEventHandler(this.txtCostoMasIva_Validating);
            // 
            // txtCostoBase
            // 
            this.txtCostoBase.Location = new System.Drawing.Point(526, 38);
            this.txtCostoBase.MaxLength = 20;
            this.txtCostoBase.Name = "txtCostoBase";
            this.txtCostoBase.Size = new System.Drawing.Size(106, 22);
            this.txtCostoBase.TabIndex = 1;
            this.txtCostoBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCostoBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCostoBase_KeyPress);
            this.txtCostoBase.Validating += new System.ComponentModel.CancelEventHandler(this.txtCostoBase_Validating);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(429, 38);
            this.txtCantidad.MaxLength = 20;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(85, 22);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblProducto.Location = new System.Drawing.Point(14, 16);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(52, 16);
            this.lblProducto.TabIndex = 15;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(14, 38);
            this.txtCodigoArticulo.MaxLength = 100;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(403, 22);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(14, 72);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(755, 27);
            this.panelProducto.TabIndex = 16;
            // 
            // lblDatosProducto
            // 
            this.lblDatosProducto.AutoSize = true;
            this.lblDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblDatosProducto.Location = new System.Drawing.Point(8, 6);
            this.lblDatosProducto.Name = "lblDatosProducto";
            this.lblDatosProducto.Size = new System.Drawing.Size(0, 16);
            this.lblDatosProducto.TabIndex = 0;
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
            this.Cantidad,
            this.D1,
            this.D2,
            this.ValorUnitario,
            this.ValorTotal});
            this.dgvListaArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListaArticulos.Location = new System.Drawing.Point(4, 167);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.RowHeadersVisible = false;
            this.dgvListaArticulos.Size = new System.Drawing.Size(865, 215);
            this.dgvListaArticulos.TabIndex = 3;
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
            this.Codigo.Width = 90;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Producto";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Width = 400;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N1";
            dataGridViewCellStyle6.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle6;
            this.Cantidad.HeaderText = "Cant.";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 80;
            // 
            // D1
            // 
            this.D1.DataPropertyName = "Descuento";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N2";
            dataGridViewCellStyle7.NullValue = null;
            this.D1.DefaultCellStyle = dataGridViewCellStyle7;
            this.D1.HeaderText = "D1";
            this.D1.Name = "D1";
            this.D1.Width = 50;
            // 
            // D2
            // 
            this.D2.DataPropertyName = "Descuento2";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.D2.DefaultCellStyle = dataGridViewCellStyle8;
            this.D2.HeaderText = "D2";
            this.D2.Name = "D2";
            this.D2.Width = 50;
            // 
            // ValorUnitario
            // 
            this.ValorUnitario.DataPropertyName = "ValorUnitario";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            dataGridViewCellStyle9.NullValue = null;
            this.ValorUnitario.DefaultCellStyle = dataGridViewCellStyle9;
            this.ValorUnitario.HeaderText = "Val. Unit.";
            this.ValorUnitario.Name = "ValorUnitario";
            this.ValorUnitario.Width = 90;
            // 
            // ValorTotal
            // 
            this.ValorTotal.DataPropertyName = "Total";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.ValorTotal.DefaultCellStyle = dataGridViewCellStyle10;
            this.ValorTotal.HeaderText = "Val. Total";
            this.ValorTotal.Name = "ValorTotal";
            this.ValorTotal.Width = 90;
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(868, 167);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(30, 215);
            this.panelMenuGrid.TabIndex = 1;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnEditar,
            this.tsEliminar});
            this.tsMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGrid.Location = new System.Drawing.Point(0, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(28, 57);
            this.tsMenuGrid.TabIndex = 0;
            this.tsMenuGrid.Text = "Menu de Registro";
            // 
            // tsBtnEditar
            // 
            this.tsBtnEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsBtnEditar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnEditar.Image")));
            this.tsBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnEditar.Name = "tsBtnEditar";
            this.tsBtnEditar.Size = new System.Drawing.Size(26, 20);
            this.tsBtnEditar.Text = "Editar articulo [F4]";
            this.tsBtnEditar.Click += new System.EventHandler(this.tsBtnEditar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(25, 20);
            this.tsEliminar.Text = "Eliminar Registro";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // FrmPreIngresoCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(916, 550);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbDatosFactura);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPreIngresoCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ingreso de compras";
            this.Load += new System.EventHandler(this.FrmPreIngresoCompra_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPreIngresoCompra_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbDatosFactura.ResumeLayout(false);
            this.gbDatosFactura.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            this.gbListadoArticulos.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsGuardar;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.GroupBox gbDatosFactura;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsEliminar;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.TextBox txtCostoBase;
        private System.Windows.Forms.TextBox txtCostoMasIva;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCostoMasIvaInfo;
        private System.Windows.Forms.TextBox txtIvaInfo;
        private System.Windows.Forms.TextBox txtCostoBaseInfo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantUltCompra;
        private System.Windows.Forms.TextBox txtCantPreingreso;
        private System.Windows.Forms.TextBox txtCantInventario;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolStripButton tsBtnEditar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDescuento2;
        private System.Windows.Forms.TextBox txtDescuento1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn D1;
        private System.Windows.Forms.DataGridViewTextBoxColumn D2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorTotal;
    }
}