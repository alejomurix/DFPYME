namespace Aplicacion.Compras.IngresarCompra
{
    partial class FrmConsultaDeCompras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaDeCompras));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImprimirResumen = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbCartera = new System.Windows.Forms.GroupBox();
            this.dgvCartera = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Limite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Saldo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.lblIva = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtIva = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.btnBuscarProveedor = new System.Windows.Forms.Button();
            this.cbCodigo = new System.Windows.Forms.ComboBox();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.txtConsulta = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvIva = new System.Windows.Forms.DataGridView();
            this.Gravado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Base = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.gbCartera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartera)).BeginInit();
            this.gbCriterio.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnImprimir,
            this.tsBtnImprimirResumen,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1194, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsBtnImprimir
            // 
            this.tsBtnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimir.Image")));
            this.tsBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimir.Name = "tsBtnImprimir";
            this.tsBtnImprimir.Size = new System.Drawing.Size(77, 22);
            this.tsBtnImprimir.Text = "Imprimir";
            this.tsBtnImprimir.Click += new System.EventHandler(this.tsBtnImprimir_Click);
            // 
            // tsBtnImprimirResumen
            // 
            this.tsBtnImprimirResumen.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimirResumen.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimirResumen.Image")));
            this.tsBtnImprimirResumen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimirResumen.Name = "tsBtnImprimirResumen";
            this.tsBtnImprimirResumen.Size = new System.Drawing.Size(176, 22);
            this.tsBtnImprimirResumen.Text = "Imprimir resumen cartera";
            this.tsBtnImprimirResumen.Visible = false;
            this.tsBtnImprimirResumen.Click += new System.EventHandler(this.tsBtnImprimirResumen_Click);
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
            // gbCartera
            // 
            this.gbCartera.Controls.Add(this.dgvCartera);
            this.gbCartera.Location = new System.Drawing.Point(12, 99);
            this.gbCartera.Name = "gbCartera";
            this.gbCartera.Size = new System.Drawing.Size(1170, 389);
            this.gbCartera.TabIndex = 1;
            this.gbCartera.TabStop = false;
            // 
            // dgvCartera
            // 
            this.dgvCartera.AllowUserToAddRows = false;
            this.dgvCartera.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCartera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nit,
            this.Nombre,
            this.Factura,
            this.Fecha,
            this.Limite,
            this.Valor,
            this.Abono,
            this.Saldo});
            this.dgvCartera.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCartera.Location = new System.Drawing.Point(4, 11);
            this.dgvCartera.Name = "dgvCartera";
            this.dgvCartera.RowHeadersVisible = false;
            this.dgvCartera.Size = new System.Drawing.Size(1160, 373);
            this.dgvCartera.TabIndex = 0;
            this.dgvCartera.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCartera_CellClick);
            this.dgvCartera.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCartera_ColumnHeaderMouseClick);
            this.dgvCartera.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvCartera_KeyUp);
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Nit
            // 
            this.Nit.DataPropertyName = "Cedula";
            this.Nit.HeaderText = "Nit";
            this.Nit.Name = "Nit";
            this.Nit.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Proveedor";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 280;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Factura";
            this.Factura.HeaderText = "No. Factura";
            this.Factura.Name = "Factura";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle21.Format = "d";
            dataGridViewCellStyle21.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle21;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // Limite
            // 
            this.Limite.DataPropertyName = "Limite";
            dataGridViewCellStyle22.Format = "d";
            dataGridViewCellStyle22.NullValue = null;
            this.Limite.DefaultCellStyle = dataGridViewCellStyle22;
            this.Limite.HeaderText = "Limite";
            this.Limite.Name = "Limite";
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "N0";
            dataGridViewCellStyle23.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle23;
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Abono
            // 
            this.Abono.DataPropertyName = "Abonos";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "N0";
            dataGridViewCellStyle24.NullValue = null;
            this.Abono.DefaultCellStyle = dataGridViewCellStyle24;
            this.Abono.HeaderText = "Abonos";
            this.Abono.Name = "Abono";
            // 
            // Saldo
            // 
            this.Saldo.DataPropertyName = "Saldo";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "N0";
            dataGridViewCellStyle25.NullValue = null;
            this.Saldo.DefaultCellStyle = dataGridViewCellStyle25;
            this.Saldo.HeaderText = "Saldo";
            this.Saldo.Name = "Saldo";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(1013, 507);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(46, 18);
            this.lblSubTotal.TabIndex = 6;
            this.lblSubTotal.Text = "Base";
            // 
            // lblIva
            // 
            this.lblIva.AutoSize = true;
            this.lblIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIva.Location = new System.Drawing.Point(1027, 552);
            this.lblIva.Name = "lblIva";
            this.lblIva.Size = new System.Drawing.Size(32, 18);
            this.lblIva.TabIndex = 5;
            this.lblIva.Text = "IVA";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSubTotal.Location = new System.Drawing.Point(1065, 504);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(111, 24);
            this.txtSubTotal.TabIndex = 4;
            this.txtSubTotal.Text = "0";
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIva
            // 
            this.txtIva.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIva.Location = new System.Drawing.Point(1065, 549);
            this.txtIva.Name = "txtIva";
            this.txtIva.ReadOnly = true;
            this.txtIva.Size = new System.Drawing.Size(111, 24);
            this.txtIva.TabIndex = 3;
            this.txtIva.Text = "0";
            this.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(998, 599);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(60, 18);
            this.lblTotal.TabIndex = 2;
            this.lblTotal.Text = "TOTAL";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(1065, 595);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(111, 24);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "0";
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.dtpFecha1);
            this.gbCriterio.Controls.Add(this.dtpFecha2);
            this.gbCriterio.Controls.Add(this.cbFecha);
            this.gbCriterio.Controls.Add(this.btnBuscarProveedor);
            this.gbCriterio.Controls.Add(this.cbCodigo);
            this.gbCriterio.Controls.Add(this.cbProveedor);
            this.gbCriterio.Controls.Add(this.txtConsulta);
            this.gbCriterio.Controls.Add(this.btnBuscar);
            this.gbCriterio.Location = new System.Drawing.Point(12, 30);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Size = new System.Drawing.Size(1045, 71);
            this.gbCriterio.TabIndex = 0;
            this.gbCriterio.TabStop = false;
            this.gbCriterio.Text = "Criterios de consulta";
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(805, 27);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 26;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Enabled = false;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(901, 27);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 27;
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(655, 26);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(138, 24);
            this.cbFecha.TabIndex = 25;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // btnBuscarProveedor
            // 
            this.btnBuscarProveedor.Location = new System.Drawing.Point(615, 26);
            this.btnBuscarProveedor.Name = "btnBuscarProveedor";
            this.btnBuscarProveedor.Size = new System.Drawing.Size(25, 23);
            this.btnBuscarProveedor.TabIndex = 24;
            this.btnBuscarProveedor.Text = "...";
            this.btnBuscarProveedor.UseVisualStyleBackColor = true;
            this.btnBuscarProveedor.Click += new System.EventHandler(this.btnBuscarProveedor_Click);
            // 
            // cbCodigo
            // 
            this.cbCodigo.DisplayMember = "Nombre";
            this.cbCodigo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCodigo.Enabled = false;
            this.cbCodigo.FormattingEnabled = true;
            this.cbCodigo.Location = new System.Drawing.Point(182, 25);
            this.cbCodigo.Name = "cbCodigo";
            this.cbCodigo.Size = new System.Drawing.Size(107, 24);
            this.cbCodigo.TabIndex = 23;
            this.cbCodigo.ValueMember = "Id";
            // 
            // cbProveedor
            // 
            this.cbProveedor.DisplayMember = "Nombre";
            this.cbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(10, 25);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(166, 24);
            this.cbProveedor.TabIndex = 22;
            this.cbProveedor.ValueMember = "Id";
            this.cbProveedor.SelectedIndexChanged += new System.EventHandler(this.cbContado_SelectedIndexChanged);
            // 
            // txtConsulta
            // 
            this.txtConsulta.Location = new System.Drawing.Point(299, 27);
            this.txtConsulta.Name = "txtConsulta";
            this.txtConsulta.Size = new System.Drawing.Size(310, 22);
            this.txtConsulta.TabIndex = 0;
            this.txtConsulta.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtConsulta_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(996, 27);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(25, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvIva);
            this.groupBox1.Location = new System.Drawing.Point(510, 492);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(450, 137);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // dgvIva
            // 
            this.dgvIva.AllowUserToAddRows = false;
            this.dgvIva.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIva.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIva.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Gravado,
            this.Base,
            this.Iva,
            this.SubTotal});
            this.dgvIva.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvIva.Location = new System.Drawing.Point(7, 12);
            this.dgvIva.Name = "dgvIva";
            this.dgvIva.RowHeadersVisible = false;
            this.dgvIva.Size = new System.Drawing.Size(436, 115);
            this.dgvIva.TabIndex = 0;
            // 
            // Gravado
            // 
            this.Gravado.DataPropertyName = "ConceptoIva";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.Format = "N1";
            dataGridViewCellStyle27.NullValue = null;
            this.Gravado.DefaultCellStyle = dataGridViewCellStyle27;
            this.Gravado.HeaderText = "Gravado %";
            this.Gravado.Name = "Gravado";
            this.Gravado.Width = 110;
            // 
            // Base
            // 
            this.Base.DataPropertyName = "BaseI";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle28.Format = "N0";
            dataGridViewCellStyle28.NullValue = null;
            this.Base.DefaultCellStyle = dataGridViewCellStyle28;
            this.Base.HeaderText = "Base";
            this.Base.Name = "Base";
            this.Base.Width = 110;
            // 
            // Iva
            // 
            this.Iva.DataPropertyName = "ValorIva";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "N0";
            dataGridViewCellStyle29.NullValue = null;
            this.Iva.DefaultCellStyle = dataGridViewCellStyle29;
            this.Iva.HeaderText = "IVA";
            this.Iva.Name = "Iva";
            this.Iva.Width = 110;
            // 
            // SubTotal
            // 
            this.SubTotal.DataPropertyName = "Total";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "N0";
            dataGridViewCellStyle30.NullValue = null;
            this.SubTotal.DefaultCellStyle = dataGridViewCellStyle30;
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            // 
            // FrmConsultaDeCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1194, 638);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblIva);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.lblSubTotal);
            this.Controls.Add(this.txtIva);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbCriterio);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.gbCartera);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaDeCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Revision de Compras";
            this.Load += new System.EventHandler(this.FrmCartera_Load);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCartera.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCartera)).EndInit();
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.GroupBox gbCartera;
        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.DataGridView dgvCartera;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.TextBox txtConsulta;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnImprimirResumen;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtIva;
        private System.Windows.Forms.Label lblIva;
        private System.Windows.Forms.ComboBox cbCodigo;
        private System.Windows.Forms.Button btnBuscarProveedor;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Limite;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abono;
        private System.Windows.Forms.DataGridViewTextBoxColumn Saldo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvIva;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gravado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Base;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
    }
}