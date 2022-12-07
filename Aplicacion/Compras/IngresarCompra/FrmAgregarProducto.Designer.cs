namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmAgregarProducto
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

        private System.ComponentModel.ComponentResourceManager miResources =
            new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarProducto));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lkbGenerarLote = new System.Windows.Forms.LinkLabel();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.btnBuscarArticulo = new System.Windows.Forms.Button();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTallaColor = new System.Windows.Forms.Label();
            this.lblDesctoProducto = new System.Windows.Forms.Label();
            this.txtDescuentoProducto = new System.Windows.Forms.TextBox();
            this.dgvListaArticulos = new System.Windows.Forms.DataGridView();
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
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsVerMedida = new System.Windows.Forms.ToolStripButton();
            this.tsVerColor = new System.Windows.Forms.ToolStripButton();
            this.tsVerLote = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.gbListadoArticulos = new System.Windows.Forms.GroupBox();
            this.tsGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.gbTributario = new System.Windows.Forms.GroupBox();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.lblPesoDescuento = new System.Windows.Forms.Label();
            this.txtDescuento = new System.Windows.Forms.TextBox();
            this.panelTributario = new System.Windows.Forms.Panel();
            this.panelDivision = new System.Windows.Forms.Panel();
            this.panelGrabado = new System.Windows.Forms.Panel();
            this.lblGrabado = new System.Windows.Forms.Label();
            this.panelTotal = new System.Windows.Forms.Panel();
            this.lblIvaTotal = new System.Windows.Forms.Label();
            this.lblSubtotal = new System.Windows.Forms.Label();
            this.lblPesosSubTotal = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblPesosIva = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblPesosTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.chkIva = new System.Windows.Forms.CheckBox();
            this.panelProducto.SuspendLayout();
            this.gbCargaProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).BeginInit();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            this.gbListadoArticulos.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbTributario.SuspendLayout();
            this.panelTributario.SuspendLayout();
            this.panelGrabado.SuspendLayout();
            this.panelTotal.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new System.Drawing.Point(1093, 56);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(102, 24);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lkbGenerarLote
            // 
            this.lkbGenerarLote.AutoSize = true;
            this.lkbGenerarLote.Location = new System.Drawing.Point(817, 61);
            this.lkbGenerarLote.Name = "lkbGenerarLote";
            this.lkbGenerarLote.Size = new System.Drawing.Size(119, 16);
            this.lkbGenerarLote.TabIndex = 6;
            this.lkbGenerarLote.TabStop = true;
            this.lkbGenerarLote.Text = "Generar Lote [F12]";
            this.lkbGenerarLote.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbGenerarLote_LinkClicked);
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(660, 58);
            this.txtLote.MaxLength = 15;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(153, 22);
            this.txtLote.TabIndex = 5;
            this.txtLote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLote_KeyPress);
            this.txtLote.Validating += new System.ComponentModel.CancelEventHandler(this.txtLote_Validating);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(26, 57);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(434, 27);
            this.panelProducto.TabIndex = 13;
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
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(1046, 56);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 7;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(857, 23);
            this.txtValorUnitario.MaxLength = 12;
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(147, 22);
            this.txtValorUnitario.TabIndex = 3;
            this.txtValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorUnitario_KeyPress);
            this.txtValorUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorUnitario_Validating);
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblValorUnitario.Location = new System.Drawing.Point(763, 26);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(89, 16);
            this.lblValorUnitario.TabIndex = 11;
            this.lblValorUnitario.Text = "Valor Unitario";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(557, 24);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(163, 22);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantidad.Location = new System.Drawing.Point(489, 26);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 10;
            this.lblCantidad.Text = "Cantidad";
            // 
            // btnBuscarArticulo
            // 
            this.btnBuscarArticulo.Location = new System.Drawing.Point(1189, 21);
            this.btnBuscarArticulo.Name = "btnBuscarArticulo";
            this.btnBuscarArticulo.Size = new System.Drawing.Size(25, 22);
            this.btnBuscarArticulo.TabIndex = 1;
            this.btnBuscarArticulo.Text = "...";
            this.btnBuscarArticulo.UseVisualStyleBackColor = true;
            this.btnBuscarArticulo.Visible = false;
            this.btnBuscarArticulo.Click += new System.EventHandler(this.btnBuscarArticulo_Click);
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(107, 23);
            this.txtCodigoArticulo.MaxLength = 100;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(353, 22);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            this.txtCodigoArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoArticulo_Validating);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblProducto.Location = new System.Drawing.Point(25, 26);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(52, 16);
            this.lblProducto.TabIndex = 9;
            this.lblProducto.Text = "Articulo";
            // 
            // gbCargaProducto
            // 
            this.gbCargaProducto.Controls.Add(this.chkIva);
            this.gbCargaProducto.Controls.Add(this.label1);
            this.gbCargaProducto.Controls.Add(this.lblTallaColor);
            this.gbCargaProducto.Controls.Add(this.lblDesctoProducto);
            this.gbCargaProducto.Controls.Add(this.txtDescuentoProducto);
            this.gbCargaProducto.Controls.Add(this.lblProducto);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.btnBuscarArticulo);
            this.gbCargaProducto.Controls.Add(this.lblCantidad);
            this.gbCargaProducto.Controls.Add(this.txtCantidad);
            this.gbCargaProducto.Controls.Add(this.lblValorUnitario);
            this.gbCargaProducto.Controls.Add(this.txtValorUnitario);
            this.gbCargaProducto.Controls.Add(this.btnTallaYcolor);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Controls.Add(this.txtLote);
            this.gbCargaProducto.Controls.Add(this.lkbGenerarLote);
            this.gbCargaProducto.Controls.Add(this.btnAgregar);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(8, 32);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(1220, 99);
            this.gbCargaProducto.TabIndex = 1;
            this.gbCargaProducto.TabStop = false;
            this.gbCargaProducto.Text = "Cargar Producto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.label1.Location = new System.Drawing.Point(615, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 14;
            this.label1.Text = "Lote";
            // 
            // lblTallaColor
            // 
            this.lblTallaColor.AutoSize = true;
            this.lblTallaColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblTallaColor.Location = new System.Drawing.Point(950, 61);
            this.lblTallaColor.Name = "lblTallaColor";
            this.lblTallaColor.Size = new System.Drawing.Size(96, 16);
            this.lblTallaColor.TabIndex = 15;
            this.lblTallaColor.Text = "Talla y/o Color";
            // 
            // lblDesctoProducto
            // 
            this.lblDesctoProducto.AutoSize = true;
            this.lblDesctoProducto.Location = new System.Drawing.Point(489, 61);
            this.lblDesctoProducto.Name = "lblDesctoProducto";
            this.lblDesctoProducto.Size = new System.Drawing.Size(51, 16);
            this.lblDesctoProducto.TabIndex = 12;
            this.lblDesctoProducto.Text = "Descto";
            // 
            // txtDescuentoProducto
            // 
            this.txtDescuentoProducto.Location = new System.Drawing.Point(557, 58);
            this.txtDescuentoProducto.MaxLength = 5;
            this.txtDescuentoProducto.Name = "txtDescuentoProducto";
            this.txtDescuentoProducto.Size = new System.Drawing.Size(44, 22);
            this.txtDescuentoProducto.TabIndex = 4;
            this.txtDescuentoProducto.Text = "0";
            this.txtDescuentoProducto.Click += new System.EventHandler(this.txtDescuentoProducto_Click);
            this.txtDescuentoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuentoProducto_KeyPress);
            this.txtDescuentoProducto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuentoProducto_Validating);
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
            this.dgvListaArticulos.Location = new System.Drawing.Point(2, 40);
            this.dgvListaArticulos.Name = "dgvListaArticulos";
            this.dgvListaArticulos.Size = new System.Drawing.Size(1215, 215);
            this.dgvListaArticulos.TabIndex = 0;
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
            this.Codigo.Width = 80;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Articulo";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            this.Articulo.Width = 405;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
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
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "ValorUnitario";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle9;
            this.Valor.HeaderText = "Valor Unitario";
            this.Valor.Name = "Valor";
            this.Valor.Width = 120;
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Descuento.DefaultCellStyle = dataGridViewCellStyle10;
            this.Descuento.HeaderText = "Descto";
            this.Descuento.Name = "Descuento";
            this.Descuento.Width = 57;
            // 
            // ValorMenosDescto
            // 
            this.ValorMenosDescto.DataPropertyName = "ValorMenosDescto";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N2";
            dataGridViewCellStyle11.NullValue = null;
            this.ValorMenosDescto.DefaultCellStyle = dataGridViewCellStyle11;
            this.ValorMenosDescto.HeaderText = "Valor - Descto";
            this.ValorMenosDescto.Name = "ValorMenosDescto";
            this.ValorMenosDescto.Width = 116;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "Iva";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle12;
            this.Iva.HeaderText = "Iva";
            this.Iva.Name = "Iva";
            this.Iva.Width = 43;
            // 
            // TotalMasIva
            // 
            this.TotalMasIva.DataPropertyName = "TotalMasIva";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "N2";
            dataGridViewCellStyle13.NullValue = null;
            this.TotalMasIva.DefaultCellStyle = dataGridViewCellStyle13;
            this.TotalMasIva.HeaderText = "Total + Iva";
            this.TotalMasIva.Name = "TotalMasIva";
            this.TotalMasIva.Width = 120;
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Valor";
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle14.Format = "N2";
            dataGridViewCellStyle14.NullValue = null;
            this.Total.DefaultCellStyle = dataGridViewCellStyle14;
            this.Total.HeaderText = "Valor  Total";
            this.Total.Name = "Total";
            this.Total.Width = 130;
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(1046, 11);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(171, 30);
            this.panelMenuGrid.TabIndex = 1;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerMedida,
            this.tsVerColor,
            this.tsVerLote,
            this.tsSeparador,
            this.tsEditar,
            this.tsEliminar});
            this.tsMenuGrid.Location = new System.Drawing.Point(0, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(169, 25);
            this.tsMenuGrid.TabIndex = 0;
            this.tsMenuGrid.Text = "Menu de Registro";
            // 
            // tsVerMedida
            // 
            this.tsVerMedida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVerMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsVerMedida.Image")));
            this.tsVerMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerMedida.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsVerMedida.Name = "tsVerMedida";
            this.tsVerMedida.Size = new System.Drawing.Size(23, 22);
            this.tsVerMedida.Text = "Mostrar Unidad de Medida";
            this.tsVerMedida.Click += new System.EventHandler(this.tsVerMedida_Click);
            // 
            // tsVerColor
            // 
            this.tsVerColor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVerColor.Image = ((System.Drawing.Image)(resources.GetObject("tsVerColor.Image")));
            this.tsVerColor.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerColor.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsVerColor.Name = "tsVerColor";
            this.tsVerColor.Size = new System.Drawing.Size(23, 22);
            this.tsVerColor.Text = "Mostrar Color";
            this.tsVerColor.Click += new System.EventHandler(this.tsVerColor_Click);
            // 
            // tsVerLote
            // 
            this.tsVerLote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVerLote.Image = ((System.Drawing.Image)(resources.GetObject("tsVerLote.Image")));
            this.tsVerLote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerLote.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsVerLote.Name = "tsVerLote";
            this.tsVerLote.Size = new System.Drawing.Size(23, 22);
            this.tsVerLote.Text = "Mostrar Lote";
            this.tsVerLote.Click += new System.EventHandler(this.tsVerLote_Click);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(6, 25);
            // 
            // tsEditar
            // 
            this.tsEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsEditar.Image")));
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(23, 22);
            this.tsEditar.Text = "Editar Registro";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsEliminar
            // 
            this.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(23, 22);
            this.tsEliminar.Text = "Eliminar Registro";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click);
            // 
            // gbListadoArticulos
            // 
            this.gbListadoArticulos.Controls.Add(this.panelMenuGrid);
            this.gbListadoArticulos.Controls.Add(this.dgvListaArticulos);
            this.gbListadoArticulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListadoArticulos.Location = new System.Drawing.Point(8, 141);
            this.gbListadoArticulos.Name = "gbListadoArticulos";
            this.gbListadoArticulos.Size = new System.Drawing.Size(1220, 262);
            this.gbListadoArticulos.TabIndex = 2;
            this.gbListadoArticulos.TabStop = false;
            this.gbListadoArticulos.Text = "Listado de Articulos";
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
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardar,
            this.tsSalir});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1236, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // gbTributario
            // 
            this.gbTributario.Controls.Add(this.lblDescuento);
            this.gbTributario.Controls.Add(this.lblPesoDescuento);
            this.gbTributario.Controls.Add(this.txtDescuento);
            this.gbTributario.Controls.Add(this.panelTributario);
            this.gbTributario.Controls.Add(this.lblSubtotal);
            this.gbTributario.Controls.Add(this.lblPesosSubTotal);
            this.gbTributario.Controls.Add(this.txtSubTotal);
            this.gbTributario.Controls.Add(this.lblIva);
            this.gbTributario.Controls.Add(this.lblPesosIva);
            this.gbTributario.Controls.Add(this.txtIva);
            this.gbTributario.Controls.Add(this.lblTotal);
            this.gbTributario.Controls.Add(this.lblPesosTotal);
            this.gbTributario.Controls.Add(this.txtTotal);
            this.gbTributario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbTributario.Location = new System.Drawing.Point(8, 409);
            this.gbTributario.Name = "gbTributario";
            this.gbTributario.Size = new System.Drawing.Size(1220, 146);
            this.gbTributario.TabIndex = 3;
            this.gbTributario.TabStop = false;
            this.gbTributario.Text = "Información Tributaria";
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescuento.Location = new System.Drawing.Point(559, 100);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(106, 16);
            this.lblDescuento.TabIndex = 7;
            this.lblDescuento.Text = "DESCUENTO:";
            // 
            // lblPesoDescuento
            // 
            this.lblPesoDescuento.AutoSize = true;
            this.lblPesoDescuento.Location = new System.Drawing.Point(663, 100);
            this.lblPesoDescuento.Name = "lblPesoDescuento";
            this.lblPesoDescuento.Size = new System.Drawing.Size(15, 16);
            this.lblPesoDescuento.TabIndex = 8;
            this.lblPesoDescuento.Text = "$";
            // 
            // txtDescuento
            // 
            this.txtDescuento.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescuento.Location = new System.Drawing.Point(680, 97);
            this.txtDescuento.MaxLength = 10;
            this.txtDescuento.Name = "txtDescuento";
            this.txtDescuento.ReadOnly = true;
            this.txtDescuento.Size = new System.Drawing.Size(186, 22);
            this.txtDescuento.TabIndex = 9;
            this.txtDescuento.Text = "0";
            this.txtDescuento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelTributario
            // 
            this.panelTributario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTributario.Controls.Add(this.panelDivision);
            this.panelTributario.Controls.Add(this.panelGrabado);
            this.panelTributario.Controls.Add(this.panelTotal);
            this.panelTributario.Location = new System.Drawing.Point(18, 29);
            this.panelTributario.Name = "panelTributario";
            this.panelTributario.Size = new System.Drawing.Size(448, 98);
            this.panelTributario.TabIndex = 0;
            // 
            // panelDivision
            // 
            this.panelDivision.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDivision.Location = new System.Drawing.Point(14, 8);
            this.panelDivision.Name = "panelDivision";
            this.panelDivision.Size = new System.Drawing.Size(68, 25);
            this.panelDivision.TabIndex = 0;
            // 
            // panelGrabado
            // 
            this.panelGrabado.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelGrabado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrabado.Controls.Add(this.lblGrabado);
            this.panelGrabado.Location = new System.Drawing.Point(14, 32);
            this.panelGrabado.Name = "panelGrabado";
            this.panelGrabado.Size = new System.Drawing.Size(68, 22);
            this.panelGrabado.TabIndex = 1;
            // 
            // lblGrabado
            // 
            this.lblGrabado.AutoSize = true;
            this.lblGrabado.Location = new System.Drawing.Point(2, 2);
            this.lblGrabado.Name = "lblGrabado";
            this.lblGrabado.Size = new System.Drawing.Size(62, 16);
            this.lblGrabado.TabIndex = 0;
            this.lblGrabado.Text = "Grabado";
            // 
            // panelTotal
            // 
            this.panelTotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTotal.Controls.Add(this.lblIvaTotal);
            this.panelTotal.Location = new System.Drawing.Point(14, 53);
            this.panelTotal.Name = "panelTotal";
            this.panelTotal.Size = new System.Drawing.Size(68, 22);
            this.panelTotal.TabIndex = 2;
            // 
            // lblIvaTotal
            // 
            this.lblIvaTotal.AutoSize = true;
            this.lblIvaTotal.Location = new System.Drawing.Point(2, 2);
            this.lblIvaTotal.Name = "lblIvaTotal";
            this.lblIvaTotal.Size = new System.Drawing.Size(39, 16);
            this.lblIvaTotal.TabIndex = 0;
            this.lblIvaTotal.Text = "Total";
            // 
            // lblSubtotal
            // 
            this.lblSubtotal.AutoSize = true;
            this.lblSubtotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtotal.Location = new System.Drawing.Point(559, 44);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(96, 16);
            this.lblSubtotal.TabIndex = 1;
            this.lblSubtotal.Text = "SUBTOTAL :";
            // 
            // lblPesosSubTotal
            // 
            this.lblPesosSubTotal.AutoSize = true;
            this.lblPesosSubTotal.Location = new System.Drawing.Point(663, 44);
            this.lblPesosSubTotal.Name = "lblPesosSubTotal";
            this.lblPesosSubTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosSubTotal.TabIndex = 2;
            this.lblPesosSubTotal.Text = "$";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(680, 41);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(186, 22);
            this.txtSubTotal.TabIndex = 3;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(883, 44);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(44, 16);
            this.lblIva.TabIndex = 4;
            this.lblIva.Text = "IVA : ";
            // 
            // lblPesosIva
            // 
            this.lblPesosIva.AutoSize = true;
            this.lblPesosIva.Location = new System.Drawing.Point(986, 45);
            this.lblPesosIva.Name = "lblPesosIva";
            this.lblPesosIva.Size = new System.Drawing.Size(15, 16);
            this.lblPesosIva.TabIndex = 5;
            this.lblPesosIva.Text = "$";
            // 
            // txtIva
            // 
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(1003, 41);
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(186, 22);
            this.txtIva.TabIndex = 6;
            this.txtIva.Text = "0";
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(882, 100);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(69, 16);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "TOTAL : ";
            // 
            // lblPesosTotal
            // 
            this.lblPesosTotal.AutoSize = true;
            this.lblPesosTotal.Location = new System.Drawing.Point(986, 100);
            this.lblPesosTotal.Name = "lblPesosTotal";
            this.lblPesosTotal.Size = new System.Drawing.Size(15, 16);
            this.lblPesosTotal.TabIndex = 11;
            this.lblPesosTotal.Text = "$";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1003, 97);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(186, 22);
            this.txtTotal.TabIndex = 12;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // chkIva
            // 
            this.chkIva.AutoSize = true;
            this.chkIva.Location = new System.Drawing.Point(1056, 25);
            this.chkIva.Name = "chkIva";
            this.chkIva.Size = new System.Drawing.Size(93, 20);
            this.chkIva.TabIndex = 17;
            this.chkIva.Text = "Incluye IVA";
            this.chkIva.UseVisualStyleBackColor = true;
            // 
            // FrmAgregarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1236, 567);
            this.Controls.Add(this.gbTributario);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.gbListadoArticulos);
            this.Controls.Add(this.gbCargaProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAgregarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Producto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmAgregarProducto_FormClosing);
            this.Load += new System.EventHandler(this.FrmAgregarProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAgregarProducto_KeyDown);
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.gbCargaProducto.ResumeLayout(false);
            this.gbCargaProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListaArticulos)).EndInit();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            this.gbListadoArticulos.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbTributario.ResumeLayout(false);
            this.gbTributario.PerformLayout();
            this.panelTributario.ResumeLayout(false);
            this.panelGrabado.ResumeLayout(false);
            this.panelGrabado.PerformLayout();
            this.panelTotal.ResumeLayout(false);
            this.panelTotal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.LinkLabel lkbGenerarLote;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Button btnBuscarArticulo;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.GroupBox gbCargaProducto;
        private System.Windows.Forms.DataGridView dgvListaArticulos;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsVerMedida;
        private System.Windows.Forms.ToolStripButton tsVerColor;
        private System.Windows.Forms.ToolStripButton tsVerLote;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private System.Windows.Forms.ToolStripButton tsEliminar;
        private System.Windows.Forms.GroupBox gbListadoArticulos;
        private System.Windows.Forms.ToolStripButton tsGuardar;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox gbTributario;
        private System.Windows.Forms.Panel panelTributario;
        private System.Windows.Forms.Panel panelDivision;
        private System.Windows.Forms.Panel panelGrabado;
        private System.Windows.Forms.Label lblGrabado;
        private System.Windows.Forms.Panel panelTotal;
        private System.Windows.Forms.Label lblIvaTotal;
        private System.Windows.Forms.Label lblSubtotal;
        private System.Windows.Forms.Label lblPesosSubTotal;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.Label lblPesosIva;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblPesosTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblDesctoProducto;
        private System.Windows.Forms.TextBox txtDescuentoProducto;
        private System.Windows.Forms.Label lblTallaColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.Label lblPesoDescuento;
        private System.Windows.Forms.TextBox txtDescuento;
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
        private System.Windows.Forms.CheckBox chkIva;

    }
}