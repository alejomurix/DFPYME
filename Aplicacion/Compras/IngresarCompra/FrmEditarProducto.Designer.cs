namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmEditarProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarProducto));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.lkbGenerarLote = new System.Windows.Forms.LinkLabel();
            this.txtLote = new System.Windows.Forms.TextBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.btnTallaYcolor = new System.Windows.Forms.Button();
            this.txtValorUnitario = new System.Windows.Forms.TextBox();
            this.lblValorUnitario = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCodigoArticulo = new System.Windows.Forms.TextBox();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblLote = new System.Windows.Forms.Label();
            this.txtMedida = new System.Windows.Forms.TextBox();
            this.lblMedida = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.pbColor = new System.Windows.Forms.PictureBox();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.cbIvaEditar = new System.Windows.Forms.ComboBox();
            this.btnEditarIva = new System.Windows.Forms.Button();
            this.lblDescuento = new System.Windows.Forms.Label();
            this.txtDescuentoProducto = new System.Windows.Forms.TextBox();
            this.chkIva = new System.Windows.Forms.CheckBox();
            this.tsMenu.SuspendLayout();
            this.panelProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).BeginInit();
            this.gbProducto.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardar,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(389, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Menu Principal";
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
            // lkbGenerarLote
            // 
            this.lkbGenerarLote.AutoSize = true;
            this.lkbGenerarLote.Location = new System.Drawing.Point(241, 264);
            this.lkbGenerarLote.Name = "lkbGenerarLote";
            this.lkbGenerarLote.Size = new System.Drawing.Size(86, 16);
            this.lkbGenerarLote.TabIndex = 4;
            this.lkbGenerarLote.TabStop = true;
            this.lkbGenerarLote.Text = "Generar Lote";
            this.lkbGenerarLote.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbGenerarLote_LinkClicked);
            // 
            // txtLote
            // 
            this.txtLote.Location = new System.Drawing.Point(86, 261);
            this.txtLote.MaxLength = 15;
            this.txtLote.Name = "txtLote";
            this.txtLote.Size = new System.Drawing.Size(154, 22);
            this.txtLote.TabIndex = 3;
            this.txtLote.Validating += new System.ComponentModel.CancelEventHandler(this.txtLote_Validating);
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(25, 70);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(303, 27);
            this.panelProducto.TabIndex = 8;
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
            this.btnTallaYcolor.Enabled = false;
            this.btnTallaYcolor.FlatAppearance.BorderSize = 0;
            this.btnTallaYcolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaYcolor.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaYcolor.Image")));
            this.btnTallaYcolor.Location = new System.Drawing.Point(302, 116);
            this.btnTallaYcolor.Name = "btnTallaYcolor";
            this.btnTallaYcolor.Size = new System.Drawing.Size(25, 25);
            this.btnTallaYcolor.TabIndex = 0;
            this.btnTallaYcolor.UseVisualStyleBackColor = true;
            this.btnTallaYcolor.Click += new System.EventHandler(this.btnTallaYcolor_Click);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.Location = new System.Drawing.Point(86, 200);
            this.txtValorUnitario.MaxLength = 12;
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(241, 22);
            this.txtValorUnitario.TabIndex = 2;
            this.txtValorUnitario.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorUnitario_Validating);
            // 
            // lblValorUnitario
            // 
            this.lblValorUnitario.AutoSize = true;
            this.lblValorUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblValorUnitario.Location = new System.Drawing.Point(24, 203);
            this.lblValorUnitario.Name = "lblValorUnitario";
            this.lblValorUnitario.Size = new System.Drawing.Size(40, 16);
            this.lblValorUnitario.TabIndex = 13;
            this.lblValorUnitario.Text = "Valor";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(86, 158);
            this.txtCantidad.MaxLength = 10;
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(241, 22);
            this.txtCantidad.TabIndex = 1;
            this.txtCantidad.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidad_Validating);
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCantidad.Location = new System.Drawing.Point(22, 161);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(62, 16);
            this.lblCantidad.TabIndex = 12;
            this.lblCantidad.Text = "Cantidad";
            // 
            // txtCodigoArticulo
            // 
            this.txtCodigoArticulo.Location = new System.Drawing.Point(86, 36);
            this.txtCodigoArticulo.MaxLength = 10;
            this.txtCodigoArticulo.Name = "txtCodigoArticulo";
            this.txtCodigoArticulo.ReadOnly = true;
            this.txtCodigoArticulo.Size = new System.Drawing.Size(242, 22);
            this.txtCodigoArticulo.TabIndex = 7;
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblProducto.Location = new System.Drawing.Point(24, 39);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(52, 16);
            this.lblProducto.TabIndex = 6;
            this.lblProducto.Text = "Articulo";
            // 
            // lblLote
            // 
            this.lblLote.AutoSize = true;
            this.lblLote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblLote.Location = new System.Drawing.Point(24, 267);
            this.lblLote.Name = "lblLote";
            this.lblLote.Size = new System.Drawing.Size(34, 16);
            this.lblLote.TabIndex = 14;
            this.lblLote.Text = "Lote";
            // 
            // txtMedida
            // 
            this.txtMedida.Enabled = false;
            this.txtMedida.Location = new System.Drawing.Point(86, 119);
            this.txtMedida.MaxLength = 10;
            this.txtMedida.Name = "txtMedida";
            this.txtMedida.Size = new System.Drawing.Size(119, 22);
            this.txtMedida.TabIndex = 10;
            // 
            // lblMedida
            // 
            this.lblMedida.AutoSize = true;
            this.lblMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblMedida.Location = new System.Drawing.Point(22, 122);
            this.lblMedida.Name = "lblMedida";
            this.lblMedida.Size = new System.Drawing.Size(54, 16);
            this.lblMedida.TabIndex = 9;
            this.lblMedida.Text = "Medida";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblColor.Location = new System.Drawing.Point(208, 122);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(40, 16);
            this.lblColor.TabIndex = 11;
            this.lblColor.Text = "Color";
            // 
            // pbColor
            // 
            this.pbColor.BackColor = System.Drawing.Color.White;
            this.pbColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbColor.Enabled = false;
            this.pbColor.Location = new System.Drawing.Point(251, 122);
            this.pbColor.Name = "pbColor";
            this.pbColor.Size = new System.Drawing.Size(49, 16);
            this.pbColor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbColor.TabIndex = 29;
            this.pbColor.TabStop = false;
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.chkIva);
            this.gbProducto.Controls.Add(this.lblIva);
            this.gbProducto.Controls.Add(this.txtIva);
            this.gbProducto.Controls.Add(this.cbIvaEditar);
            this.gbProducto.Controls.Add(this.btnEditarIva);
            this.gbProducto.Controls.Add(this.lblProducto);
            this.gbProducto.Controls.Add(this.txtCodigoArticulo);
            this.gbProducto.Controls.Add(this.panelProducto);
            this.gbProducto.Controls.Add(this.lblMedida);
            this.gbProducto.Controls.Add(this.txtMedida);
            this.gbProducto.Controls.Add(this.lblColor);
            this.gbProducto.Controls.Add(this.pbColor);
            this.gbProducto.Controls.Add(this.btnTallaYcolor);
            this.gbProducto.Controls.Add(this.lblCantidad);
            this.gbProducto.Controls.Add(this.txtCantidad);
            this.gbProducto.Controls.Add(this.lblValorUnitario);
            this.gbProducto.Controls.Add(this.txtValorUnitario);
            this.gbProducto.Controls.Add(this.lblLote);
            this.gbProducto.Controls.Add(this.txtLote);
            this.gbProducto.Controls.Add(this.lkbGenerarLote);
            this.gbProducto.Controls.Add(this.lblDescuento);
            this.gbProducto.Controls.Add(this.txtDescuentoProducto);
            this.gbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbProducto.Location = new System.Drawing.Point(12, 37);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(360, 385);
            this.gbProducto.TabIndex = 1;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Datos de Producto";
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblIva.Location = new System.Drawing.Point(22, 348);
            this.lblIva.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(52, 16);
            this.lblIva.TabIndex = 33;
            this.lblIva.Text = "IVA (%)";
            this.lblIva.Visible = false;
            // 
            // txtIva
            // 
            this.txtIva.Enabled = false;
            this.txtIva.Location = new System.Drawing.Point(84, 345);
            this.txtIva.Name = "txtIva";
            this.txtIva.Size = new System.Drawing.Size(47, 22);
            this.txtIva.TabIndex = 31;
            this.txtIva.Visible = false;
            // 
            // cbIvaEditar
            // 
            this.cbIvaEditar.DisplayMember = "PorcentajeIva";
            this.cbIvaEditar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIvaEditar.FormattingEnabled = true;
            this.cbIvaEditar.Location = new System.Drawing.Point(83, 344);
            this.cbIvaEditar.Margin = new System.Windows.Forms.Padding(4);
            this.cbIvaEditar.Name = "cbIvaEditar";
            this.cbIvaEditar.Size = new System.Drawing.Size(52, 24);
            this.cbIvaEditar.TabIndex = 32;
            this.cbIvaEditar.ValueMember = "IdIva";
            this.cbIvaEditar.Visible = false;
            // 
            // btnEditarIva
            // 
            this.btnEditarIva.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarIva.Image")));
            this.btnEditarIva.Location = new System.Drawing.Point(138, 345);
            this.btnEditarIva.Name = "btnEditarIva";
            this.btnEditarIva.Size = new System.Drawing.Size(27, 22);
            this.btnEditarIva.TabIndex = 30;
            this.btnEditarIva.UseVisualStyleBackColor = true;
            this.btnEditarIva.Visible = false;
            // 
            // lblDescuento
            // 
            this.lblDescuento.AutoSize = true;
            this.lblDescuento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblDescuento.Location = new System.Drawing.Point(24, 307);
            this.lblDescuento.Name = "lblDescuento";
            this.lblDescuento.Size = new System.Drawing.Size(51, 16);
            this.lblDescuento.TabIndex = 15;
            this.lblDescuento.Text = "Descto";
            // 
            // txtDescuentoProducto
            // 
            this.txtDescuentoProducto.Location = new System.Drawing.Point(86, 304);
            this.txtDescuentoProducto.MaxLength = 5;
            this.txtDescuentoProducto.Name = "txtDescuentoProducto";
            this.txtDescuentoProducto.Size = new System.Drawing.Size(44, 22);
            this.txtDescuentoProducto.TabIndex = 5;
            this.txtDescuentoProducto.Text = "0";
            this.txtDescuentoProducto.Click += new System.EventHandler(this.txtDescuentoProducto_Click);
            this.txtDescuentoProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDescuentoProducto_KeyPress);
            this.txtDescuentoProducto.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescuentoProducto_Validating);
            // 
            // chkIva
            // 
            this.chkIva.AutoSize = true;
            this.chkIva.Location = new System.Drawing.Point(86, 232);
            this.chkIva.Name = "chkIva";
            this.chkIva.Size = new System.Drawing.Size(93, 20);
            this.chkIva.TabIndex = 34;
            this.chkIva.Text = "Incluye IVA";
            this.chkIva.UseVisualStyleBackColor = true;
            // 
            // FrmEditarProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(389, 436);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbProducto);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEditarProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar Producto de Factura";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmEditarProducto_FormClosing);
            this.Load += new System.EventHandler(this.FrmEditarProducto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmEditarProducto_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbColor)).EndInit();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.LinkLabel lkbGenerarLote;
        private System.Windows.Forms.TextBox txtLote;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.Button btnTallaYcolor;
        private System.Windows.Forms.TextBox txtValorUnitario;
        private System.Windows.Forms.Label lblValorUnitario;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCodigoArticulo;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblLote;
        private System.Windows.Forms.TextBox txtMedida;
        private System.Windows.Forms.Label lblMedida;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.PictureBox pbColor;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.ToolStripButton tsGuardar;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.Label lblDescuento;
        private System.Windows.Forms.TextBox txtDescuentoProducto;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.ComboBox cbIvaEditar;
        private System.Windows.Forms.Button btnEditarIva;
        private System.Windows.Forms.CheckBox chkIva;
    }
}