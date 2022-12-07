namespace Aplicacion.Compras.IngresarCompra
{
    partial class IngresarCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IngresarCompras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDatosCompras = new System.Windows.Forms.DataGridView();
            this.pDatos = new System.Windows.Forms.Panel();
            this.panelIngresarCompra = new System.Windows.Forms.Panel();
            this.panelFechaIngreso = new System.Windows.Forms.Panel();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.dtpFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.panelNumeroFactura = new System.Windows.Forms.Panel();
            this.lblNumeroFactura = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.panelProveedor = new System.Windows.Forms.Panel();
            this.lblNombreProveedor = new System.Windows.Forms.Label();
            this.txtCodigoProveedor = new System.Windows.Forms.TextBox();
            this.txtNombreProveedor = new System.Windows.Forms.TextBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.panelFormaPago = new System.Windows.Forms.Panel();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.cbFormaPago = new System.Windows.Forms.ComboBox();
            this.panelFechaLimite = new System.Windows.Forms.Panel();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.chbCodigoInterno = new System.Windows.Forms.CheckBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.panelLote = new System.Windows.Forms.Panel();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.lkbGenerarLote = new System.Windows.Forms.LinkLabel();
            this.panelZona = new System.Windows.Forms.Panel();
            this.lblZona = new System.Windows.Forms.Label();
            this.txtZona = new System.Windows.Forms.TextBox();
            this.btnBuscarZona = new System.Windows.Forms.Button();
            this.menuIngresarCompras = new System.Windows.Forms.ToolStrip();
            this.btnBuscar = new System.Windows.Forms.ToolStripButton();
            this.dtpFechaLimite = new System.Windows.Forms.DateTimePicker();
            this.lblFechaLimite = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCompras)).BeginInit();
            this.pDatos.SuspendLayout();
            this.panelIngresarCompra.SuspendLayout();
            this.panelFechaIngreso.SuspendLayout();
            this.panelNumeroFactura.SuspendLayout();
            this.panelProveedor.SuspendLayout();
            this.panelFormaPago.SuspendLayout();
            this.panelFechaLimite.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.panelLote.SuspendLayout();
            this.panelZona.SuspendLayout();
            this.menuIngresarCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDatosCompras
            // 
            this.dgvDatosCompras.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvDatosCompras.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvDatosCompras.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dgvDatosCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatosCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column7,
            this.Column2,
            this.Column3,
            this.Column5,
            this.Column4,
            this.Column6});
            this.dgvDatosCompras.GridColor = System.Drawing.SystemColors.Window;
            this.dgvDatosCompras.Location = new System.Drawing.Point(-1, 3);
            this.dgvDatosCompras.Name = "dgvDatosCompras";
            this.dgvDatosCompras.Size = new System.Drawing.Size(582, 202);
            this.dgvDatosCompras.TabIndex = 0;
            // 
            // pDatos
            // 
            this.pDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pDatos.Controls.Add(this.dgvDatosCompras);
            this.pDatos.Location = new System.Drawing.Point(18, 341);
            this.pDatos.Name = "pDatos";
            this.pDatos.Size = new System.Drawing.Size(582, 205);
            this.pDatos.TabIndex = 1;
            // 
            // panelIngresarCompra
            // 
            this.panelIngresarCompra.AccessibleName = "";
            this.panelIngresarCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelIngresarCompra.Controls.Add(this.panelFechaIngreso);
            this.panelIngresarCompra.Controls.Add(this.panelNumeroFactura);
            this.panelIngresarCompra.Controls.Add(this.panelProveedor);
            this.panelIngresarCompra.Controls.Add(this.panelFormaPago);
            this.panelIngresarCompra.Controls.Add(this.panelFechaLimite);
            this.panelIngresarCompra.Controls.Add(this.panelProducto);
            this.panelIngresarCompra.Controls.Add(this.panelLote);
            this.panelIngresarCompra.Controls.Add(this.panelZona);
            this.panelIngresarCompra.Location = new System.Drawing.Point(18, 49);
            this.panelIngresarCompra.Name = "panelIngresarCompra";
            this.panelIngresarCompra.Size = new System.Drawing.Size(957, 200);
            this.panelIngresarCompra.TabIndex = 2;
            // 
            // panelFechaIngreso
            // 
            this.panelFechaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFechaIngreso.Controls.Add(this.lblFechaIngreso);
            this.panelFechaIngreso.Controls.Add(this.dtpFechaIngreso);
            this.panelFechaIngreso.Location = new System.Drawing.Point(8, 9);
            this.panelFechaIngreso.Name = "panelFechaIngreso";
            this.panelFechaIngreso.Size = new System.Drawing.Size(222, 38);
            this.panelFechaIngreso.TabIndex = 2;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.AutoSize = true;
            this.lblFechaIngreso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaIngreso.Location = new System.Drawing.Point(3, 9);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(113, 16);
            this.lblFechaIngreso.TabIndex = 0;
            this.lblFechaIngreso.Text = "Fecha de Ingreso";
            // 
            // dtpFechaIngreso
            // 
            this.dtpFechaIngreso.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaIngreso.Location = new System.Drawing.Point(122, 9);
            this.dtpFechaIngreso.Name = "dtpFechaIngreso";
            this.dtpFechaIngreso.Size = new System.Drawing.Size(88, 20);
            this.dtpFechaIngreso.TabIndex = 1;
            // 
            // panelNumeroFactura
            // 
            this.panelNumeroFactura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelNumeroFactura.Controls.Add(this.lblNumeroFactura);
            this.panelNumeroFactura.Controls.Add(this.txtNumeroFactura);
            this.panelNumeroFactura.Location = new System.Drawing.Point(236, 9);
            this.panelNumeroFactura.Name = "panelNumeroFactura";
            this.panelNumeroFactura.Size = new System.Drawing.Size(251, 38);
            this.panelNumeroFactura.TabIndex = 3;
            // 
            // lblNumeroFactura
            // 
            this.lblNumeroFactura.AutoSize = true;
            this.lblNumeroFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNumeroFactura.Location = new System.Drawing.Point(3, 9);
            this.lblNumeroFactura.Name = "lblNumeroFactura";
            this.lblNumeroFactura.Size = new System.Drawing.Size(123, 16);
            this.lblNumeroFactura.TabIndex = 0;
            this.lblNumeroFactura.Text = "Número de Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(132, 10);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.Size = new System.Drawing.Size(107, 20);
            this.txtNumeroFactura.TabIndex = 1;
            // 
            // panelProveedor
            // 
            this.panelProveedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProveedor.Controls.Add(this.lblNombreProveedor);
            this.panelProveedor.Controls.Add(this.txtCodigoProveedor);
            this.panelProveedor.Controls.Add(this.txtNombreProveedor);
            this.panelProveedor.Controls.Add(this.btnBuscarProveedor);
            this.panelProveedor.Location = new System.Drawing.Point(493, 9);
            this.panelProveedor.Name = "panelProveedor";
            this.panelProveedor.Size = new System.Drawing.Size(451, 38);
            this.panelProveedor.TabIndex = 4;
            // 
            // lblNombreProveedor
            // 
            this.lblNombreProveedor.AutoSize = true;
            this.lblNombreProveedor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblNombreProveedor.Location = new System.Drawing.Point(3, 9);
            this.lblNombreProveedor.Name = "lblNombreProveedor";
            this.lblNombreProveedor.Size = new System.Drawing.Size(72, 16);
            this.lblNombreProveedor.TabIndex = 0;
            this.lblNombreProveedor.Text = "Proveedor";
            // 
            // txtCodigoProveedor
            // 
            this.txtCodigoProveedor.Enabled = false;
            this.txtCodigoProveedor.Location = new System.Drawing.Point(81, 11);
            this.txtCodigoProveedor.Name = "txtCodigoProveedor";
            this.txtCodigoProveedor.Size = new System.Drawing.Size(165, 20);
            this.txtCodigoProveedor.TabIndex = 1;
            // 
            // txtNombreProveedor
            // 
            this.txtNombreProveedor.Enabled = false;
            this.txtNombreProveedor.Location = new System.Drawing.Point(243, 11);
            this.txtNombreProveedor.Name = "txtNombreProveedor";
            this.txtNombreProveedor.Size = new System.Drawing.Size(147, 20);
            this.txtNombreProveedor.TabIndex = 2;
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarProveedor.Image")));
            this.btnBuscarProveedor.Location = new System.Drawing.Point(405, 7);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(32, 23);
            this.btnBuscarProveedor.TabIndex = 3;
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // panelFormaPago
            // 
            this.panelFormaPago.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFormaPago.Controls.Add(this.lblFormaPago);
            this.panelFormaPago.Controls.Add(this.cbFormaPago);
            this.panelFormaPago.Location = new System.Drawing.Point(8, 53);
            this.panelFormaPago.Name = "panelFormaPago";
            this.panelFormaPago.Size = new System.Drawing.Size(222, 38);
            this.panelFormaPago.TabIndex = 5;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFormaPago.Location = new System.Drawing.Point(3, 9);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(102, 16);
            this.lblFormaPago.TabIndex = 1;
            this.lblFormaPago.Text = "Forma de Pago";
            // 
            // cbFormaPago
            // 
            this.cbFormaPago.DisplayMember = "Descripcion";
            this.cbFormaPago.FormattingEnabled = true;
            this.cbFormaPago.Location = new System.Drawing.Point(113, 7);
            this.cbFormaPago.Name = "cbFormaPago";
            this.cbFormaPago.Size = new System.Drawing.Size(97, 21);
            this.cbFormaPago.TabIndex = 2;
            this.cbFormaPago.ValueMember = "Id";
            // 
            // panelFechaLimite
            // 
            this.panelFechaLimite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelFechaLimite.Controls.Add(this.lblFechaLimite);
            this.panelFechaLimite.Controls.Add(this.dtpFechaLimite);
            this.panelFechaLimite.Location = new System.Drawing.Point(237, 53);
            this.panelFechaLimite.Name = "panelFechaLimite";
            this.panelFechaLimite.Size = new System.Drawing.Size(200, 38);
            this.panelFechaLimite.TabIndex = 6;
            // 
            // panelProducto
            // 
            this.panelProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelProducto.Controls.Add(this.chbCodigoInterno);
            this.panelProducto.Controls.Add(this.lblArticulo);
            this.panelProducto.Controls.Add(this.txtCodigoArticulo);
            this.panelProducto.Controls.Add(this.btnBuscarArticulo);
            this.panelProducto.Controls.Add(this.lblCantidad);
            this.panelProducto.Controls.Add(this.txtCantidad);
            this.panelProducto.Controls.Add(this.lblValorUnitario);
            this.panelProducto.Controls.Add(this.txtValorUnitario);
            this.panelProducto.Controls.Add(this.btnAgregar);
            this.panelProducto.Location = new System.Drawing.Point(9, 99);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(731, 38);
            this.panelProducto.TabIndex = 7;
            // 
            // chbCodigoInterno
            // 
            this.chbCodigoInterno.AutoSize = true;
            this.chbCodigoInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.chbCodigoInterno.Location = new System.Drawing.Point(5, 9);
            this.chbCodigoInterno.Name = "chbCodigoInterno";
            this.chbCodigoInterno.Size = new System.Drawing.Size(114, 20);
            this.chbCodigoInterno.TabIndex = 5;
            this.chbCodigoInterno.Text = "Codigo Interno";
            this.chbCodigoInterno.UseVisualStyleBackColor = true;
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblArticulo.Location = new System.Drawing.Point(124, 9);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(52, 16);
            this.lblArticulo.TabIndex = 0;
            this.lblArticulo.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(178, 8);
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(152, 20);
            this.txtCodigoArticulo.TabIndex = 1;
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarArticulo.Image")));
            this.btnBuscarArticulo.Location = new System.Drawing.Point(336, 5);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(28, 25);
            this.btnBuscarArticulo.TabIndex = 2;
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantidad.Location = new System.Drawing.Point(367, 9);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(434, 8);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(40, 20);
            this.txtCantidad.TabIndex = 4;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Leave += new System.EventHandler(this.txtCantidad_Leave);
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblValorUnitario.Location = new System.Drawing.Point(482, 9);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(89, 16);
            this.lblValorUnitario.TabIndex = 7;
            this.lblValorUnitario.Text = "Valor Unitario";
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(573, 8);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(110, 20);
            this.txtValorUnitario.TabIndex = 8;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.Location = new System.Drawing.Point(694, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(27, 28);
            this.btnAgregar.TabIndex = 6;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panelLote
            // 
            this.panelLote.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLote.Controls.Add(this.lblLote);
            this.panelLote.Controls.Add(this.txtLote);
            this.panelLote.Controls.Add(this.lkbGenerarLote);
            this.panelLote.Location = new System.Drawing.Point(9, 146);
            this.panelLote.Name = "panelLote";
            this.panelLote.Size = new System.Drawing.Size(221, 38);
            this.panelLote.TabIndex = 5;
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblLote.Location = new System.Drawing.Point(3, 9);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(34, 16);
            this.lblLote.TabIndex = 0;
            this.lblLote.Text = "Lote";
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(42, 9);
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(100, 20);
            this.txtLote.TabIndex = 1;
            // 
            // lkbGenerarLote
            // 
            this.lkbGenerarLote.AutoSize = true;
            this.lkbGenerarLote.Location = new System.Drawing.Point(144, 12);
            this.lkbGenerarLote.Name = "lkbGenerarLote";
            this.lkbGenerarLote.Size = new System.Drawing.Size(69, 13);
            this.lkbGenerarLote.TabIndex = 2;
            this.lkbGenerarLote.TabStop = true;
            this.lkbGenerarLote.Text = "Generar Lote";
            this.lkbGenerarLote.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbGenerarLote_LinkClicked);
            // 
            // panelZona
            // 
            this.panelZona.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelZona.Controls.Add(this.lblZona);
            this.panelZona.Controls.Add(this.txtZona);
            this.panelZona.Controls.Add(this.btnBuscarZona);
            this.panelZona.Location = new System.Drawing.Point(238, 146);
            this.panelZona.Name = "panelZona";
            this.panelZona.Size = new System.Drawing.Size(200, 38);
            this.panelZona.TabIndex = 8;
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblZona.Location = new System.Drawing.Point(3, 9);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(39, 16);
            this.lblZona.TabIndex = 0;
            this.lblZona.Text = "Zona";
            // 
            // txtZona
            // 
            this.txtZona.Location = new System.Drawing.Point(44, 9);
            this.txtZona.Name = "txtZona";
            this.txtZona.Size = new System.Drawing.Size(100, 20);
            this.txtZona.TabIndex = 1;
            // 
            // btnBuscarZona
            // 
            this.btnBuscarZona.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarZona.Image")));
            this.btnBuscarZona.Location = new System.Drawing.Point(154, 6);
            this.btnBuscarZona.Name = "btnBuscarZona";
            this.btnBuscarZona.Size = new System.Drawing.Size(31, 23);
            this.btnBuscarZona.TabIndex = 2;
            this.btnBuscarZona.UseVisualStyleBackColor = true;
            // 
            // menuIngresarCompras
            // 
            this.menuIngresarCompras.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnBuscar});
            this.menuIngresarCompras.Location = new System.Drawing.Point(0, 0);
            this.menuIngresarCompras.Name = "menuIngresarCompras";
            this.menuIngresarCompras.Size = new System.Drawing.Size(994, 25);
            this.menuIngresarCompras.TabIndex = 3;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(108, 22);
            this.btnBuscar.Text = "Buscar Compra";
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // dtpFechaLimite
            // 
            this.dtpFechaLimite.CustomFormat = "dd/MM/yyyy";
            this.dtpFechaLimite.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFechaLimite.Location = new System.Drawing.Point(91, 8);
            this.dtpFechaLimite.Name = "dtpFechaLimite";
            this.dtpFechaLimite.Size = new System.Drawing.Size(84, 20);
            this.dtpFechaLimite.TabIndex = 1;
            // 
            // lblFechaLimite
            // 
            this.lblFechaLimite.AutoSize = true;
            this.lblFechaLimite.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblFechaLimite.Location = new System.Drawing.Point(3, 10);
            this.lblFechaLimite.Name = "lblFechaLimite";
            this.lblFechaLimite.Size = new System.Drawing.Size(84, 16);
            this.lblFechaLimite.TabIndex = 0;
            this.lblFechaLimite.Text = "Fecha Limite";
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "Codigo";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.Column1.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column1.Frozen = true;
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.Width = 120;
            // 
            // Column7
            // 
            this.Column7.Frozen = true;
            this.Column7.HeaderText = "Otro";
            this.Column7.Name = "Column7";
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "Producto";
            this.Column2.Frozen = true;
            this.Column2.HeaderText = "Articulo";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Valor";
            this.Column3.Frozen = true;
            this.Column3.HeaderText = "Cantidad";
            this.Column3.Name = "Column3";
            this.Column3.Width = 55;
            // 
            // Column5
            // 
            this.Column5.Frozen = true;
            this.Column5.HeaderText = "IVA %";
            this.Column5.Name = "Column5";
            this.Column5.Width = 60;
            // 
            // Column4
            // 
            this.Column4.Frozen = true;
            this.Column4.HeaderText = "Valor Unitario";
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "Valor Total";
            this.Column6.Name = "Column6";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8});
            this.dataGridView1.Location = new System.Drawing.Point(650, 341);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 4;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Column8";
            this.Column8.Name = "Column8";
            // 
            // IngresarCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 636);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuIngresarCompras);
            this.Controls.Add(this.panelIngresarCompra);
            this.Controls.Add(this.pDatos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "IngresarCompras";
            this.Text = "Ingresar Compras";
            this.Load += new System.EventHandler(this.IngresarCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatosCompras)).EndInit();
            this.pDatos.ResumeLayout(false);
            this.panelIngresarCompra.ResumeLayout(false);
            this.panelFechaIngreso.ResumeLayout(false);
            this.panelFechaIngreso.PerformLayout();
            this.panelNumeroFactura.ResumeLayout(false);
            this.panelNumeroFactura.PerformLayout();
            this.panelProveedor.ResumeLayout(false);
            this.panelProveedor.PerformLayout();
            this.panelFormaPago.ResumeLayout(false);
            this.panelFormaPago.PerformLayout();
            this.panelFechaLimite.ResumeLayout(false);
            this.panelFechaLimite.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.panelLote.ResumeLayout(false);
            this.panelLote.PerformLayout();
            this.panelZona.ResumeLayout(false);
            this.panelZona.PerformLayout();
            this.menuIngresarCompras.ResumeLayout(false);
            this.menuIngresarCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDatosCompras;
        private System.Windows.Forms.Panel pDatos;
        private System.Windows.Forms.Panel panelIngresarCompra;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.DateTimePicker dtpFechaIngreso;
        private System.Windows.Forms.Panel panelFechaIngreso;
        private System.Windows.Forms.Panel panelNumeroFactura;
        private System.Windows.Forms.Label lblNumeroFactura;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.Panel panelProveedor;
        private System.Windows.Forms.Label lblNombreProveedor;
        private System.Windows.Forms.TextBox txtCodigoProveedor;
        private System.Windows.Forms.TextBox txtNombreProveedor;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.Panel panelFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Panel panelFechaLimite;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.CheckBox chbCodigoInterno;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ToolStrip menuIngresarCompras;
        private System.Windows.Forms.ToolStripButton btnBuscar;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Panel panelLote;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.LinkLabel lkbGenerarLote;
        private System.Windows.Forms.Panel panelZona;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.TextBox txtZona;
        private System.Windows.Forms.Button btnBuscarZona;
        private System.Windows.Forms.ComboBox cbFormaPago;
        private System.Windows.Forms.Label lblFechaLimite;
        private System.Windows.Forms.DateTimePicker dtpFechaLimite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}