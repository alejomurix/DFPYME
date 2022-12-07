namespace Aplicacion.Compras.IngresarCompra.ConsultaRemision
{
    partial class FrmModificarCompra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModificarCompra));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbDatosFactura = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFechaFactura = new System.Windows.Forms.TextBox();
            this.dtpFechaFactura = new System.Windows.Forms.DateTimePicker();
            this.btnEditarFecha = new System.Windows.Forms.Button();
            this.btnDesEditarFecha = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtAjuste = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.usuario = new System.Windows.Forms.Label();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.txtFormaPago = new System.Windows.Forms.TextBox();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.btnEditarFormaPago = new System.Windows.Forms.Button();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.txtFechaLimite = new System.Windows.Forms.TextBox();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.btnEditarFechaLimite = new System.Windows.Forms.Button();
            this.btnDeshacerFechaLimite = new System.Windows.Forms.Button();
            this.rbtnDesctoProducto = new System.Windows.Forms.RadioButton();
            this.pbProducto = new System.Windows.Forms.PictureBox();
            this.lblDescuentoFactura = new System.Windows.Forms.Label();
            this.rbtnDesctoFactura = new System.Windows.Forms.RadioButton();
            this.pbFactura = new System.Windows.Forms.PictureBox();
            this.txtDescuentoFactura = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rBtnActiva = new System.Windows.Forms.RadioButton();
            this.rBtnAnulada = new System.Windows.Forms.RadioButton();
            this.tsMenu.SuspendLayout();
            this.gbDatosFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFactura)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnGuardar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(753, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnGuardar
            // 
            this.tsBtnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnGuardar.Image")));
            this.tsBtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnGuardar.Name = "tsBtnGuardar";
            this.tsBtnGuardar.Size = new System.Drawing.Size(76, 22);
            this.tsBtnGuardar.Text = "Guardar";
            this.tsBtnGuardar.Click += new System.EventHandler(this.tsBtnGuardar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(53, 22);
            this.tsBtnSalir.Text = "Salir";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbDatosFactura
            // 
            this.gbDatosFactura.Controls.Add(this.label1);
            this.gbDatosFactura.Controls.Add(this.txtFechaFactura);
            this.gbDatosFactura.Controls.Add(this.dtpFechaFactura);
            this.gbDatosFactura.Controls.Add(this.btnEditarFecha);
            this.gbDatosFactura.Controls.Add(this.btnDesEditarFecha);
            this.gbDatosFactura.Controls.Add(this.label7);
            this.gbDatosFactura.Controls.Add(this.label8);
            this.gbDatosFactura.Controls.Add(this.txtAjuste);
            this.gbDatosFactura.Controls.Add(this.lblFecha);
            this.gbDatosFactura.Controls.Add(this.lblFechaIngreso);
            this.gbDatosFactura.Controls.Add(this.lblUsuario);
            this.gbDatosFactura.Controls.Add(this.usuario);
            this.gbDatosFactura.Controls.Add(this.lblNumeroFactura);
            this.gbDatosFactura.Controls.Add(this.txtNumeroFactura);
            this.gbDatosFactura.Controls.Add(this.lblFormaPago);
            this.gbDatosFactura.Controls.Add(this.txtFormaPago);
            this.gbDatosFactura.Controls.Add(this.cbFormaPago);
            this.gbDatosFactura.Controls.Add(this.btnEditarFormaPago);
            this.gbDatosFactura.Controls.Add(this.lblNombreProveedor);
            this.gbDatosFactura.Controls.Add(this.txtCodigoProveedor);
            this.gbDatosFactura.Controls.Add(this.btnBuscarProveedor);
            this.gbDatosFactura.Controls.Add(this.txtNombreProveedor);
            this.gbDatosFactura.Controls.Add(this.lblFechaLimite);
            this.gbDatosFactura.Controls.Add(this.txtFechaLimite);
            this.gbDatosFactura.Controls.Add(this.dtpFechaLimite);
            this.gbDatosFactura.Controls.Add(this.btnEditarFechaLimite);
            this.gbDatosFactura.Controls.Add(this.btnDeshacerFechaLimite);
            this.gbDatosFactura.Controls.Add(this.rbtnDesctoProducto);
            this.gbDatosFactura.Controls.Add(this.pbProducto);
            this.gbDatosFactura.Controls.Add(this.lblDescuentoFactura);
            this.gbDatosFactura.Controls.Add(this.rbtnDesctoFactura);
            this.gbDatosFactura.Controls.Add(this.pbFactura);
            this.gbDatosFactura.Controls.Add(this.txtDescuentoFactura);
            this.gbDatosFactura.Controls.Add(this.panel1);
            this.gbDatosFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbDatosFactura.Location = new System.Drawing.Point(10, 31);
            this.gbDatosFactura.Name = "gbDatosFactura";
            this.gbDatosFactura.Size = new System.Drawing.Size(726, 281);
            this.gbDatosFactura.TabIndex = 1;
            this.gbDatosFactura.TabStop = false;
            this.gbDatosFactura.Text = "Datos de Remisión";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(18, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 16);
            this.label1.TabIndex = 57;
            this.label1.Text = "Fecha Factura";
            // 
            // txtFechaFactura
            // 
            this.txtFechaFactura.Enabled = false;
            this.txtFechaFactura.Location = new System.Drawing.Point(144, 80);
            this.txtFechaFactura.Name = "txtFechaFactura";
            this.txtFechaFactura.Size = new System.Drawing.Size(84, 22);
            this.txtFechaFactura.TabIndex = 53;
            // 
            // dtpFechaFactura
            // 
            this.dtpFechaFactura.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaFactura.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaFactura.Location = new System.Drawing.Point(144, 80);
            this.dtpFechaFactura.Name = "dtpFechaFactura";
            this.dtpFechaFactura.Size = new System.Drawing.Size(84, 22);
            this.dtpFechaFactura.TabIndex = 54;
            this.dtpFechaFactura.Visible = false;
            // 
            // btnEditarFecha
            // 
            this.btnEditarFecha.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarFecha.Image")));
            this.btnEditarFecha.Location = new System.Drawing.Point(237, 80);
            this.btnEditarFecha.Name = "btnEditarFecha";
            this.btnEditarFecha.Size = new System.Drawing.Size(25, 22);
            this.btnEditarFecha.TabIndex = 55;
            this.btnEditarFecha.UseVisualStyleBackColor = true;
            this.btnEditarFecha.Click += new System.EventHandler(this.btnEditarFecha_Click);
            // 
            // btnDesEditarFecha
            // 
            this.btnDesEditarFecha.Image = ((System.Drawing.Image)(resources.GetObject("btnDesEditarFecha.Image")));
            this.btnDesEditarFecha.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDesEditarFecha.Location = new System.Drawing.Point(237, 80);
            this.btnDesEditarFecha.Name = "btnDesEditarFecha";
            this.btnDesEditarFecha.Size = new System.Drawing.Size(25, 22);
            this.btnDesEditarFecha.TabIndex = 56;
            this.btnDesEditarFecha.UseVisualStyleBackColor = true;
            this.btnDesEditarFecha.Visible = false;
            this.btnDesEditarFecha.Click += new System.EventHandler(this.btnDesEditarFecha_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label7.Location = new System.Drawing.Point(314, 230);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 16);
            this.label7.TabIndex = 50;
            this.label7.Text = "Ajuste : ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(368, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(15, 16);
            this.label8.TabIndex = 51;
            this.label8.Text = "$";
            // 
            // txtAjuste
            // 
            this.txtAjuste.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.txtAjuste.Location = new System.Drawing.Point(389, 226);
            this.txtAjuste.Name = "txtAjuste";
            this.txtAjuste.Size = new System.Drawing.Size(105, 22);
            this.txtAjuste.TabIndex = 52;
            this.txtAjuste.Text = "0";
            this.txtAjuste.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtAjuste.Validating += new System.ComponentModel.CancelEventHandler(this.txtAjuste_Validating);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFecha.Location = new System.Drawing.Point(17, 35);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(122, 16);
            this.lblFecha.TabIndex = 11;
            this.lblFecha.Text = "Fecha de Ingreso : ";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaIngreso.Location = new System.Drawing.Point(141, 35);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(117, 16);
            this.lblFechaIngreso.TabIndex = 12;
            this.lblFechaIngreso.Text = "08 de Mar de 2013";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(301, 35);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(64, 16);
            this.lblUsuario.TabIndex = 13;
            this.lblUsuario.Text = "Usuario : ";
            // 
            // usuario
            // 
            this.usuario.AutoSize = true;
            this.usuario.Location = new System.Drawing.Point(377, 35);
            this.usuario.Name = "usuario";
            this.usuario.Size = new System.Drawing.Size(0, 16);
            this.usuario.TabIndex = 14;
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(17, 132);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(135, 16);
            this.lblNumeroFactura.TabIndex = 15;
            this.lblNumeroFactura.Text = "Número de Remisión";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(159, 129);
            this.txtNumeroFactura.MaxLength = 15;
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(163, 22);
            this.txtNumeroFactura.TabIndex = 0;
            this.txtNumeroFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroFactura_Validating);
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFormaPago.Location = new System.Drawing.Point(411, 132);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(102, 16);
            this.lblFormaPago.TabIndex = 16;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // txtFormaPago
            // 
            this.txtFormaPago.Enabled = false;
            this.txtFormaPago.Location = new System.Drawing.Point(549, 130);
            this.txtFormaPago.Name = "txtFormaPago";
            this.txtFormaPago.Size = new System.Drawing.Size(104, 22);
            this.txtFormaPago.TabIndex = 2;
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DisplayMember = "descripcionestado";
            this.cbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(549, 129);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(104, 24);
            this.cbFormaPago.TabIndex = 4;
            this.cbFormaPago.ValueMember = "idestado";
            this.cbFormaPago.Visible = false;
            // 
            // btnEditarFormaPago
            // 
            this.btnEditarFormaPago.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarFormaPago.Image")));
            this.btnEditarFormaPago.Location = new System.Drawing.Point(675, 129);
            this.btnEditarFormaPago.Name = "btnEditarFormaPago";
            this.btnEditarFormaPago.Size = new System.Drawing.Size(25, 22);
            this.btnEditarFormaPago.TabIndex = 1;
            this.btnEditarFormaPago.UseVisualStyleBackColor = true;
            this.btnEditarFormaPago.Click += new System.EventHandler(this.btnEditarFormaPago_Click);
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNombreProveedor.Location = new System.Drawing.Point(18, 183);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(72, 16);
            this.lblNombreProveedor.TabIndex = 17;
            this.lblNombreProveedor.Text = "Proveedor";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodigoProveedor.Location = new System.Drawing.Point(101, 180);
            this.txtCodigoProveedor.MaxLength = 10;
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(104, 22);
            this.txtCodigoProveedor.TabIndex = 3;
            this.txtCodigoProveedor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoProveedor_KeyPress);
            this.txtCodigoProveedor.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoProveedor_Validating);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(208, 180);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(25, 22);
            this.btnBuscarProveedor.TabIndex = 4;
            this.btnBuscarProveedor.Text = "...";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreProveedor.Location = new System.Drawing.Point(245, 180);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(456, 22);
            this.txtNombreProveedor.TabIndex = 18;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaLimite.Location = new System.Drawing.Point(322, 83);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(84, 16);
            this.lblFechaLimite.TabIndex = 19;
            this.lblFechaLimite.Text = "Fecha Limite";
            // 
            // txtFechaLimite
            // 
            this.txtFechaLimite.Enabled = false;
            this.txtFechaLimite.Location = new System.Drawing.Point(429, 80);
            this.txtFechaLimite.Name = "txtFechaLimite";
            this.txtFechaLimite.Size = new System.Drawing.Size(84, 22);
            this.txtFechaLimite.TabIndex = 5;
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLimite.Location = new System.Drawing.Point(429, 80);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(84, 22);
            this.dtpFechaLimite.TabIndex = 5;
            this.dtpFechaLimite.Visible = false;
            this.dtpFechaLimite.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaLimite_Validating);
            // 
            // btnEditarFechaLimite
            // 
            this.btnEditarFechaLimite.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarFechaLimite.Image")));
            this.btnEditarFechaLimite.Location = new System.Drawing.Point(522, 80);
            this.btnEditarFechaLimite.Name = "btnEditarFechaLimite";
            this.btnEditarFechaLimite.Size = new System.Drawing.Size(25, 22);
            this.btnEditarFechaLimite.TabIndex = 6;
            this.btnEditarFechaLimite.UseVisualStyleBackColor = true;
            this.btnEditarFechaLimite.Click += new System.EventHandler(this.btnEditarFechaLimite_Click);
            // 
            // btnDeshacerFechaLimite
            // 
            this.btnDeshacerFechaLimite.Image = ((System.Drawing.Image)(resources.GetObject("btnDeshacerFechaLimite.Image")));
            this.btnDeshacerFechaLimite.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDeshacerFechaLimite.Location = new System.Drawing.Point(522, 80);
            this.btnDeshacerFechaLimite.Name = "btnDeshacerFechaLimite";
            this.btnDeshacerFechaLimite.Size = new System.Drawing.Size(25, 22);
            this.btnDeshacerFechaLimite.TabIndex = 7;
            this.btnDeshacerFechaLimite.UseVisualStyleBackColor = true;
            this.btnDeshacerFechaLimite.Visible = false;
            this.btnDeshacerFechaLimite.Click += new System.EventHandler(this.btnDeshacerFechaLimite_Click);
            // 
            // rbtnDesctoProducto
            // 
            this.rbtnDesctoProducto.AutoSize = true;
            this.rbtnDesctoProducto.Location = new System.Drawing.Point(20, 230);
            this.rbtnDesctoProducto.Name = "rbtnDesctoProducto";
            this.rbtnDesctoProducto.Size = new System.Drawing.Size(14, 13);
            this.rbtnDesctoProducto.TabIndex = 8;
            this.rbtnDesctoProducto.UseVisualStyleBackColor = true;
            this.rbtnDesctoProducto.Click += new System.EventHandler(this.rbtnDesctoProducto_Click);
            // 
            // pbProducto
            // 
            this.pbProducto.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbProducto.BackgroundImage")));
            this.pbProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbProducto.InitialImage = null;
            this.pbProducto.Location = new System.Drawing.Point(40, 225);
            this.pbProducto.Name = "pbProducto";
            this.pbProducto.Size = new System.Drawing.Size(24, 24);
            this.pbProducto.TabIndex = 28;
            this.pbProducto.TabStop = false;
            this.pbProducto.Tag = "";
            // 
            // lblDescuentoFactura
            // 
            this.lblDescuentoFactura.AutoSize = true;
            this.lblDescuentoFactura.Location = new System.Drawing.Point(156, 230);
            this.lblDescuentoFactura.Name = "lblDescuentoFactura";
            this.lblDescuentoFactura.Size = new System.Drawing.Size(81, 16);
            this.lblDescuentoFactura.TabIndex = 20;
            this.lblDescuentoFactura.Text = "Descto/Fact";
            // 
            // rbtnDesctoFactura
            // 
            this.rbtnDesctoFactura.AutoSize = true;
            this.rbtnDesctoFactura.Location = new System.Drawing.Point(89, 230);
            this.rbtnDesctoFactura.Name = "rbtnDesctoFactura";
            this.rbtnDesctoFactura.Size = new System.Drawing.Size(14, 13);
            this.rbtnDesctoFactura.TabIndex = 9;
            this.rbtnDesctoFactura.UseVisualStyleBackColor = true;
            this.rbtnDesctoFactura.Click += new System.EventHandler(this.rbtnDesctoFactura_Click);
            // 
            // pbFactura
            // 
            this.pbFactura.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbFactura.BackgroundImage")));
            this.pbFactura.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbFactura.InitialImage = null;
            this.pbFactura.Location = new System.Drawing.Point(109, 225);
            this.pbFactura.Name = "pbFactura";
            this.pbFactura.Size = new System.Drawing.Size(24, 24);
            this.pbFactura.TabIndex = 29;
            this.pbFactura.TabStop = false;
            this.pbFactura.Tag = "";
            // 
            // txtDescuentoFactura
            // 
            this.txtDescuentoFactura.Enabled = false;
            this.txtDescuentoFactura.Location = new System.Drawing.Point(249, 227);
            this.txtDescuentoFactura.MaxLength = 5;
            this.txtDescuentoFactura.Name = "txtDescuentoFactura";
            this.txtDescuentoFactura.Size = new System.Drawing.Size(44, 22);
            this.txtDescuentoFactura.TabIndex = 10;
            this.txtDescuentoFactura.Text = "0";
            this.txtDescuentoFactura.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuento_Validating);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rBtnActiva);
            this.panel1.Controls.Add(this.rBtnAnulada);
            this.panel1.Location = new System.Drawing.Point(501, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 33);
            this.panel1.TabIndex = 21;
            // 
            // rBtnActiva
            // 
            this.rBtnActiva.AutoSize = true;
            this.rBtnActiva.Location = new System.Drawing.Point(24, 7);
            this.rBtnActiva.Name = "rBtnActiva";
            this.rBtnActiva.Size = new System.Drawing.Size(63, 20);
            this.rBtnActiva.TabIndex = 0;
            this.rBtnActiva.Text = "Activa";
            this.rBtnActiva.UseVisualStyleBackColor = true;
            // 
            // rBtnAnulada
            // 
            this.rBtnAnulada.AutoSize = true;
            this.rBtnAnulada.Location = new System.Drawing.Point(110, 7);
            this.rBtnAnulada.Name = "rBtnAnulada";
            this.rBtnAnulada.Size = new System.Drawing.Size(76, 20);
            this.rBtnAnulada.TabIndex = 1;
            this.rBtnAnulada.Text = "Anulada";
            this.rBtnAnulada.UseVisualStyleBackColor = true;
            // 
            // FrmModificarCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(753, 328);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbDatosFactura);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModificarCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Remisión de Compra";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmModificarCompra_FormClosing);
            this.Load += new System.EventHandler(this.FrmModificarCompra_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbDatosFactura.ResumeLayout(false);
            this.gbDatosFactura.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbProducto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFactura)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbDatosFactura;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.Button btnEditarFechaLimite;
        private System.Windows.Forms.Button btnEditarFormaPago;
        private System.Windows.Forms.TextBox txtFechaLimite;
        private System.Windows.Forms.TextBox txtFormaPago;
        private System.Windows.Forms.ToolStripButton tsBtnGuardar;
        private System.Windows.Forms.Button btnDeshacerFechaLimite;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.RadioButton rBtnAnulada;
        private System.Windows.Forms.RadioButton rBtnActiva;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label usuario;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblDescuentoFactura;
        private System.Windows.Forms.TextBox txtDescuentoFactura;
        private System.Windows.Forms.RadioButton rbtnDesctoFactura;
        private System.Windows.Forms.PictureBox pbFactura;
        private System.Windows.Forms.RadioButton rbtnDesctoProducto;
        private System.Windows.Forms.PictureBox pbProducto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtAjuste;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFechaFactura;
        private System.Windows.Forms.DateTimePicker dtpFechaFactura;
        private System.Windows.Forms.Button btnEditarFecha;
        private System.Windows.Forms.Button btnDesEditarFecha;
    }
}