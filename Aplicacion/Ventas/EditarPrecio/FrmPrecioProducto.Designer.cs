namespace Aplicacion.Ventas.EditarPrecio
{
    partial class FrmPrecioProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrecioProducto));
            this.gbCargaProducto = new System.Windows.Forms.GroupBox();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.gbPrecio = new System.Windows.Forms.GroupBox();
            this.btnInfoCosto = new System.Windows.Forms.Button();
            this.btnEditarCosto = new System.Windows.Forms.Button();
            this.lblPrecioDistribuidor = new System.Windows.Forms.Label();
            this.lblPrecioPorMayor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDesctoDistribuidor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDesctoMayor = new System.Windows.Forms.TextBox();
            this.lblValorIva = new System.Windows.Forms.Label();
            this.btnEditarIva = new System.Windows.Forms.Button();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.cbIvaEditar = new System.Windows.Forms.ComboBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.lblCostoPromedo = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.lblUtilidad = new System.Windows.Forms.Label();
            this.txtUtilidad = new System.Windows.Forms.TextBox();
            this.lblPrecioSugerido = new System.Windows.Forms.Label();
            this.txtPrecioSugerido = new System.Windows.Forms.TextBox();
            this.lblPrecioAprox = new System.Windows.Forms.Label();
            this.txtPrecioAprox = new System.Windows.Forms.TextBox();
            this.lblPrecioVenta = new System.Windows.Forms.Label();
            this.txtPrecioVenta = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.lblValores = new System.Windows.Forms.Label();
            this.lblValorCosto = new System.Windows.Forms.Label();
            this.lblVUtilidad = new System.Windows.Forms.Label();
            this.lblValorSugerido = new System.Windows.Forms.Label();
            this.lblValorAprox = new System.Windows.Forms.Label();
            this.lblValorVenta = new System.Windows.Forms.Label();
            this.tsBusquedas = new System.Windows.Forms.ToolStrip();
            this.tsConsultaProducto = new System.Windows.Forms.ToolStripButton();
            this.tsEditar = new System.Windows.Forms.ToolStripButton();
            this.tsbSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCargaProducto.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.gbPrecio.SuspendLayout();
            this.tsBusquedas.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCargaProducto
            // 
            this.gbCargaProducto.Controls.Add(this.btnTallaYcolor);
            this.gbCargaProducto.Controls.Add(this.lblProducto);
            this.gbCargaProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbCargaProducto.Controls.Add(this.panelProducto);
            this.gbCargaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCargaProducto.Location = new System.Drawing.Point(12, 31);
            this.gbCargaProducto.Name = "gbCargaProducto";
            this.gbCargaProducto.Size = new System.Drawing.Size(497, 80);
            this.gbCargaProducto.TabIndex = 0;
            this.gbCargaProducto.TabStop = false;
            this.gbCargaProducto.Text = "Cargar Producto";
            // 
            // btnTallaYcolor
            // 
            this.btnTallaYcolor.Enabled = false;
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(466, 13);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 8;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Visible = false;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblProducto.Location = new System.Drawing.Point(8, 19);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(52, 16);
            this.lblProducto.TabIndex = 2;
            this.lblProducto.Text = "Articulo";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(84, 16);
            this.txtCodigoArticulo.MaxLength = 100;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.Size = new System.Drawing.Size(378, 22);
            this.txtCodigoArticulo.TabIndex = 0;
            this.txtCodigoArticulo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoArticulo_KeyPress);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(9, 45);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(453, 27);
            this.panelProducto.TabIndex = 3;
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
            // gbPrecio
            // 
            this.gbPrecio.BackColor = System.Drawing.SystemColors.Window;
            this.gbPrecio.Controls.Add(this.btnInfoCosto);
            this.gbPrecio.Controls.Add(this.btnEditarCosto);
            this.gbPrecio.Controls.Add(this.lblPrecioDistribuidor);
            this.gbPrecio.Controls.Add(this.lblPrecioPorMayor);
            this.gbPrecio.Controls.Add(this.label2);
            this.gbPrecio.Controls.Add(this.txtDesctoDistribuidor);
            this.gbPrecio.Controls.Add(this.label1);
            this.gbPrecio.Controls.Add(this.txtDesctoMayor);
            this.gbPrecio.Controls.Add(this.lblValorIva);
            this.gbPrecio.Controls.Add(this.btnEditarIva);
            this.gbPrecio.Controls.Add(this.txtIva);
            this.gbPrecio.Controls.Add(this.cbIvaEditar);
            this.gbPrecio.Controls.Add(this.lblIva);
            this.gbPrecio.Controls.Add(this.lblCostoPromedo);
            this.gbPrecio.Controls.Add(this.txtCosto);
            this.gbPrecio.Controls.Add(this.lblUtilidad);
            this.gbPrecio.Controls.Add(this.txtUtilidad);
            this.gbPrecio.Controls.Add(this.lblPrecioSugerido);
            this.gbPrecio.Controls.Add(this.txtPrecioSugerido);
            this.gbPrecio.Controls.Add(this.lblPrecioAprox);
            this.gbPrecio.Controls.Add(this.txtPrecioAprox);
            this.gbPrecio.Controls.Add(this.lblPrecioVenta);
            this.gbPrecio.Controls.Add(this.txtPrecioVenta);
            this.gbPrecio.Controls.Add(this.btnActualizar);
            this.gbPrecio.Controls.Add(this.lblValores);
            this.gbPrecio.Controls.Add(this.lblValorCosto);
            this.gbPrecio.Controls.Add(this.lblVUtilidad);
            this.gbPrecio.Controls.Add(this.lblValorSugerido);
            this.gbPrecio.Controls.Add(this.lblValorAprox);
            this.gbPrecio.Controls.Add(this.lblValorVenta);
            this.gbPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbPrecio.Location = new System.Drawing.Point(12, 120);
            this.gbPrecio.Name = "gbPrecio";
            this.gbPrecio.Size = new System.Drawing.Size(497, 381);
            this.gbPrecio.TabIndex = 1;
            this.gbPrecio.TabStop = false;
            this.gbPrecio.Text = "Información de costo y venta.";
            // 
            // btnInfoCosto
            // 
            this.btnInfoCosto.Enabled = false;
            this.btnInfoCosto.FlatAppearance.BorderSize = 0;
            this.btnInfoCosto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfoCosto.Image = ((System.Drawing.Image)(resources.GetObject("btnInfoCosto.Image")));
            this.btnInfoCosto.Location = new System.Drawing.Point(279, 39);
            this.btnInfoCosto.Name = "btnInfoCosto";
            this.btnInfoCosto.Size = new System.Drawing.Size(25, 23);
            this.btnInfoCosto.TabIndex = 53;
            this.btnInfoCosto.UseVisualStyleBackColor = true;
            // 
            // btnEditarCosto
            // 
            this.btnEditarCosto.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCosto.Image")));
            this.btnEditarCosto.Location = new System.Drawing.Point(249, 40);
            this.btnEditarCosto.Name = "btnEditarCosto";
            this.btnEditarCosto.Size = new System.Drawing.Size(27, 22);
            this.btnEditarCosto.TabIndex = 52;
            this.btnEditarCosto.UseVisualStyleBackColor = true;
            this.btnEditarCosto.Visible = false;
            this.btnEditarCosto.Click += new System.EventHandler(this.btnEditarCosto_Click);
            // 
            // lblPrecioDistribuidor
            // 
            this.lblPrecioDistribuidor.AutoSize = true;
            this.lblPrecioDistribuidor.Location = new System.Drawing.Point(306, 318);
            this.lblPrecioDistribuidor.Name = "lblPrecioDistribuidor";
            this.lblPrecioDistribuidor.Size = new System.Drawing.Size(15, 16);
            this.lblPrecioDistribuidor.TabIndex = 51;
            this.lblPrecioDistribuidor.Text = "0";
            // 
            // lblPrecioPorMayor
            // 
            this.lblPrecioPorMayor.AutoSize = true;
            this.lblPrecioPorMayor.Location = new System.Drawing.Point(306, 278);
            this.lblPrecioPorMayor.Name = "lblPrecioPorMayor";
            this.lblPrecioPorMayor.Size = new System.Drawing.Size(15, 16);
            this.lblPrecioPorMayor.TabIndex = 50;
            this.lblPrecioPorMayor.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 316);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Desto Distrib.";
            // 
            // txtDesctoDistribuidor
            // 
            this.txtDesctoDistribuidor.Location = new System.Drawing.Point(120, 313);
            this.txtDesctoDistribuidor.Name = "txtDesctoDistribuidor";
            this.txtDesctoDistribuidor.Size = new System.Drawing.Size(124, 22);
            this.txtDesctoDistribuidor.TabIndex = 48;
            this.txtDesctoDistribuidor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesctoDistribuidor_KeyPress);
            this.txtDesctoDistribuidor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDesctoDistribuidor_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Desto X mayor";
            // 
            // txtDesctoMayor
            // 
            this.txtDesctoMayor.Location = new System.Drawing.Point(120, 273);
            this.txtDesctoMayor.Name = "txtDesctoMayor";
            this.txtDesctoMayor.Size = new System.Drawing.Size(124, 22);
            this.txtDesctoMayor.TabIndex = 46;
            this.txtDesctoMayor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDesctoMayor_KeyPress);
            this.txtDesctoMayor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtDesctoMayor_KeyUp);
            // 
            // lblValorIva
            // 
            this.lblValorIva.AutoSize = true;
            this.lblValorIva.Location = new System.Drawing.Point(306, 117);
            this.lblValorIva.Name = "lblValorIva";
            this.lblValorIva.Size = new System.Drawing.Size(15, 16);
            this.lblValorIva.TabIndex = 44;
            this.lblValorIva.Text = "0";
            // 
            // btnEditarIva
            // 
            this.btnEditarIva.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarIva.Image")));
            this.btnEditarIva.Location = new System.Drawing.Point(250, 114);
            this.btnEditarIva.Name = "btnEditarIva";
            this.btnEditarIva.Size = new System.Drawing.Size(27, 22);
            this.btnEditarIva.TabIndex = 43;
            this.btnEditarIva.UseVisualStyleBackColor = true;
            this.btnEditarIva.Click += new System.EventHandler(this.btnEditarIva_Click);
            // 
            // txtIva
            // 
            this.txtIva.BackColor = System.Drawing.SystemColors.Window;
            this.txtIva.Location = new System.Drawing.Point(120, 114);
            this.txtIva.MaxLength = 20;
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(124, 22);
            this.txtIva.TabIndex = 42;
            // 
            // cbIvaEditar
            // 
            this.cbIvaEditar.DisplayMember = "PorcentajeIva";
            this.cbIvaEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIvaEditar.FormattingEnabled = true;
            this.cbIvaEditar.Location = new System.Drawing.Point(120, 113);
            this.cbIvaEditar.Margin = new System.Windows.Forms.Padding(4);
            this.cbIvaEditar.Name = "cbIvaEditar";
            this.cbIvaEditar.Size = new System.Drawing.Size(124, 24);
            this.cbIvaEditar.TabIndex = 45;
            this.cbIvaEditar.ValueMember = "IdIva";
            this.cbIvaEditar.Visible = false;
            this.cbIvaEditar.SelectedIndexChanged += new System.EventHandler(this.cbIvaEditar_SelectedIndexChanged);
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Location = new System.Drawing.Point(12, 117);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(44, 16);
            this.lblIva.TabIndex = 41;
            this.lblIva.Text = "IVA %";
            // 
            // lblCostoPromedo
            // 
            this.lblCostoPromedo.AutoSize = true;
            this.lblCostoPromedo.Location = new System.Drawing.Point(6, 43);
            this.lblCostoPromedo.Name = "lblCostoPromedo";
            this.lblCostoPromedo.Size = new System.Drawing.Size(105, 16);
            this.lblCostoPromedo.TabIndex = 17;
            this.lblCostoPromedo.Text = "Costo Promedio";
            // 
            // txtCosto
            // 
            this.txtCosto.BackColor = System.Drawing.SystemColors.Window;
            this.txtCosto.Location = new System.Drawing.Point(120, 40);
            this.txtCosto.MaxLength = 20;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(124, 22);
            this.txtCosto.TabIndex = 16;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCosto_KeyPress);
            this.txtCosto.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtCosto_KeyUp);
            // 
            // lblUtilidad
            // 
            this.lblUtilidad.AutoSize = true;
            this.lblUtilidad.Location = new System.Drawing.Point(9, 81);
            this.lblUtilidad.Name = "lblUtilidad";
            this.lblUtilidad.Size = new System.Drawing.Size(69, 16);
            this.lblUtilidad.TabIndex = 15;
            this.lblUtilidad.Text = "Utilidad %";
            // 
            // txtUtilidad
            // 
            this.txtUtilidad.Location = new System.Drawing.Point(120, 78);
            this.txtUtilidad.Name = "txtUtilidad";
            this.txtUtilidad.Size = new System.Drawing.Size(124, 22);
            this.txtUtilidad.TabIndex = 0;
            this.txtUtilidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUtilidad_KeyPress);
            this.txtUtilidad.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUtilidad_KeyUp);
            // 
            // lblPrecioSugerido
            // 
            this.lblPrecioSugerido.AutoSize = true;
            this.lblPrecioSugerido.Location = new System.Drawing.Point(9, 157);
            this.lblPrecioSugerido.Name = "lblPrecioSugerido";
            this.lblPrecioSugerido.Size = new System.Drawing.Size(105, 16);
            this.lblPrecioSugerido.TabIndex = 13;
            this.lblPrecioSugerido.Text = "Precio Sugerido";
            // 
            // txtPrecioSugerido
            // 
            this.txtPrecioSugerido.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioSugerido.Enabled = false;
            this.txtPrecioSugerido.Location = new System.Drawing.Point(120, 154);
            this.txtPrecioSugerido.Name = "txtPrecioSugerido";
            this.txtPrecioSugerido.ReadOnly = true;
            this.txtPrecioSugerido.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioSugerido.TabIndex = 12;
            // 
            // lblPrecioAprox
            // 
            this.lblPrecioAprox.AutoSize = true;
            this.lblPrecioAprox.Location = new System.Drawing.Point(9, 197);
            this.lblPrecioAprox.Name = "lblPrecioAprox";
            this.lblPrecioAprox.Size = new System.Drawing.Size(88, 16);
            this.lblPrecioAprox.TabIndex = 34;
            this.lblPrecioAprox.Text = "Precio Aprox.";
            // 
            // txtPrecioAprox
            // 
            this.txtPrecioAprox.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrecioAprox.Enabled = false;
            this.txtPrecioAprox.Location = new System.Drawing.Point(120, 194);
            this.txtPrecioAprox.Name = "txtPrecioAprox";
            this.txtPrecioAprox.ReadOnly = true;
            this.txtPrecioAprox.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioAprox.TabIndex = 33;
            // 
            // lblPrecioVenta
            // 
            this.lblPrecioVenta.AutoSize = true;
            this.lblPrecioVenta.Location = new System.Drawing.Point(12, 238);
            this.lblPrecioVenta.Name = "lblPrecioVenta";
            this.lblPrecioVenta.Size = new System.Drawing.Size(104, 16);
            this.lblPrecioVenta.TabIndex = 11;
            this.lblPrecioVenta.Text = "Precio de Venta";
            // 
            // txtPrecioVenta
            // 
            this.txtPrecioVenta.Location = new System.Drawing.Point(120, 235);
            this.txtPrecioVenta.Name = "txtPrecioVenta";
            this.txtPrecioVenta.Size = new System.Drawing.Size(124, 22);
            this.txtPrecioVenta.TabIndex = 1;
            this.txtPrecioVenta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioVenta_KeyPress);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new System.Drawing.Point(151, 349);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(93, 24);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // lblValores
            // 
            this.lblValores.AutoSize = true;
            this.lblValores.Location = new System.Drawing.Point(306, 18);
            this.lblValores.Name = "lblValores";
            this.lblValores.Size = new System.Drawing.Size(107, 16);
            this.lblValores.TabIndex = 40;
            this.lblValores.Text = "Valores iniciales";
            // 
            // lblValorCosto
            // 
            this.lblValorCosto.AutoSize = true;
            this.lblValorCosto.Location = new System.Drawing.Point(306, 46);
            this.lblValorCosto.Name = "lblValorCosto";
            this.lblValorCosto.Size = new System.Drawing.Size(15, 16);
            this.lblValorCosto.TabIndex = 35;
            this.lblValorCosto.Text = "0";
            // 
            // lblVUtilidad
            // 
            this.lblVUtilidad.AutoSize = true;
            this.lblVUtilidad.Location = new System.Drawing.Point(306, 84);
            this.lblVUtilidad.Name = "lblVUtilidad";
            this.lblVUtilidad.Size = new System.Drawing.Size(15, 16);
            this.lblVUtilidad.TabIndex = 36;
            this.lblVUtilidad.Text = "0";
            // 
            // lblValorSugerido
            // 
            this.lblValorSugerido.AutoSize = true;
            this.lblValorSugerido.Location = new System.Drawing.Point(306, 160);
            this.lblValorSugerido.Name = "lblValorSugerido";
            this.lblValorSugerido.Size = new System.Drawing.Size(15, 16);
            this.lblValorSugerido.TabIndex = 38;
            this.lblValorSugerido.Text = "0";
            // 
            // lblValorAprox
            // 
            this.lblValorAprox.AutoSize = true;
            this.lblValorAprox.Location = new System.Drawing.Point(306, 200);
            this.lblValorAprox.Name = "lblValorAprox";
            this.lblValorAprox.Size = new System.Drawing.Size(15, 16);
            this.lblValorAprox.TabIndex = 39;
            this.lblValorAprox.Text = "0";
            // 
            // lblValorVenta
            // 
            this.lblValorVenta.AutoSize = true;
            this.lblValorVenta.Location = new System.Drawing.Point(306, 239);
            this.lblValorVenta.Name = "lblValorVenta";
            this.lblValorVenta.Size = new System.Drawing.Size(15, 16);
            this.lblValorVenta.TabIndex = 37;
            this.lblValorVenta.Text = "0";
            // 
            // tsBusquedas
            // 
            this.tsBusquedas.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsBusquedas.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConsultaProducto,
            this.tsEditar,
            this.tsbSalir});
            this.tsBusquedas.Location = new System.Drawing.Point(0, 0);
            this.tsBusquedas.Name = "tsBusquedas";
            this.tsBusquedas.Size = new System.Drawing.Size(522, 25);
            this.tsBusquedas.TabIndex = 2;
            this.tsBusquedas.Text = "Busquedas";
            // 
            // tsConsultaProducto
            // 
            this.tsConsultaProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultaProducto.Image")));
            this.tsConsultaProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConsultaProducto.Name = "tsConsultaProducto";
            this.tsConsultaProducto.Size = new System.Drawing.Size(170, 22);
            this.tsConsultaProducto.Text = "Consultar Productos [F3]";
            this.tsConsultaProducto.ToolTipText = "Consultar Producto";
            this.tsConsultaProducto.Click += new System.EventHandler(this.tsConsultaProducto_Click);
            // 
            // tsEditar
            // 
            this.tsEditar.Image = ((System.Drawing.Image)(resources.GetObject("tsEditar.Image")));
            this.tsEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEditar.Name = "tsEditar";
            this.tsEditar.Size = new System.Drawing.Size(89, 22);
            this.tsEditar.Text = "Editar [F2]";
            this.tsEditar.Click += new System.EventHandler(this.tsEditar_Click);
            // 
            // tsbSalir
            // 
            this.tsbSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalir.Image")));
            this.tsbSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalir.Name = "tsbSalir";
            this.tsbSalir.Size = new System.Drawing.Size(91, 22);
            this.tsbSalir.Text = "Salir [ESC]";
            this.tsbSalir.Click += new System.EventHandler(this.tsbSalir_Click);
            // 
            // FrmPrecioProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(522, 511);
            this.Controls.Add(this.tsBusquedas);
            this.Controls.Add(this.gbPrecio);
            this.Controls.Add(this.gbCargaProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrecioProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Precio de productos";
            this.Load += new System.EventHandler(this.FrmPrecioProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPrecioProducto_KeyDown);
            this.gbCargaProducto.ResumeLayout(false);
            this.gbCargaProducto.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.gbPrecio.ResumeLayout(false);
            this.gbPrecio.PerformLayout();
            this.tsBusquedas.ResumeLayout(false);
            this.tsBusquedas.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCargaProducto;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.GroupBox gbPrecio;
        private System.Windows.Forms.Label lblCostoPromedo;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label lblUtilidad;
        private System.Windows.Forms.TextBox txtUtilidad;
        private System.Windows.Forms.Label lblPrecioSugerido;
        private System.Windows.Forms.TextBox txtPrecioSugerido;
        private System.Windows.Forms.Label lblPrecioAprox;
        private System.Windows.Forms.TextBox txtPrecioAprox;
        private System.Windows.Forms.Label lblPrecioVenta;
        private System.Windows.Forms.TextBox txtPrecioVenta;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Label lblValores;
        private System.Windows.Forms.Label lblValorCosto;
        private System.Windows.Forms.Label lblVUtilidad;
        private System.Windows.Forms.Label lblValorSugerido;
        private System.Windows.Forms.Label lblValorAprox;
        private System.Windows.Forms.Label lblValorVenta;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Button btnEditarIva;
        private System.Windows.Forms.Label lblValorIva;
        private System.Windows.Forms.ComboBox cbIvaEditar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDesctoDistribuidor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDesctoMayor;
        private System.Windows.Forms.Label lblPrecioDistribuidor;
        private System.Windows.Forms.Label lblPrecioPorMayor;
        private System.Windows.Forms.Button btnEditarCosto;
        private System.Windows.Forms.ToolStrip tsBusquedas;
        private System.Windows.Forms.ToolStripButton tsEditar;
        private System.Windows.Forms.ToolStripButton tsbSalir;
        private System.Windows.Forms.Button btnInfoCosto;
        private System.Windows.Forms.ToolStripButton tsConsultaProducto;
    }
}