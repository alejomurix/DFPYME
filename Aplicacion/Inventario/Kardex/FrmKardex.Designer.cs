namespace Aplicacion.Inventario.Kardex
{
    partial class FrmKardex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKardex));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbCriterio = new System.Windows.Forms.GroupBox();
            this.panelProducto = new System.Windows.Forms.Panel();
            this.lblDatosProducto = new System.Windows.Forms.Label();
            this.txtProducto = new System.Windows.Forms.TextBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.cbFecha = new System.Windows.Forms.ComboBox();
            this.cbMovimiento = new System.Windows.Forms.ComboBox();
            this.gbMovimientos = new System.Windows.Forms.GroupBox();
            this.StatusKardex = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
            this.txtDocumento = new System.Windows.Forms.TextBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsConsultarProducto = new System.Windows.Forms.ToolStripButton();
            this.tsVerResumen = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelecionaGrid = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.dgvKardex = new Aplicacion.Ventas.Factura.DataGridViewPlus();
            this.NoDocumento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdConcepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IconoOperacion = new System.Windows.Forms.DataGridViewImageColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.gbCriterio.SuspendLayout();
            this.panelProducto.SuspendLayout();
            this.gbMovimientos.SuspendLayout();
            this.StatusKardex.SuspendLayout();
            this.tsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).BeginInit();
            this.SuspendLayout();
            // 
            // gbCriterio
            // 
            this.gbCriterio.Controls.Add(this.panelProducto);
            this.gbCriterio.Controls.Add(this.txtProducto);
            this.gbCriterio.Controls.Add(this.dtpFecha1);
            this.gbCriterio.Controls.Add(this.dtpFecha2);
            this.gbCriterio.Controls.Add(this.cbFecha);
            this.gbCriterio.Controls.Add(this.cbMovimiento);
            this.gbCriterio.Location = new System.Drawing.Point(12, 29);
            this.gbCriterio.Name = "gbCriterio";
            this.gbCriterio.Size = new System.Drawing.Size(1003, 113);
            this.gbCriterio.TabIndex = 0;
            this.gbCriterio.TabStop = false;
            this.gbCriterio.Text = "Consultar";
            // 
            // panelProducto
            // 
            this.panelProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panelProducto.Controls.Add(this.lblDatosProducto);
            this.panelProducto.Location = new System.Drawing.Point(13, 60);
            this.panelProducto.Name = "panelProducto";
            this.panelProducto.Size = new System.Drawing.Size(681, 34);
            this.panelProducto.TabIndex = 12;
            // 
            // lblDatosProducto
            // 
            this.lblDatosProducto.AutoSize = true;
            this.lblDatosProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.lblDatosProducto.Location = new System.Drawing.Point(5, 7);
            this.lblDatosProducto.Name = "lblDatosProducto";
            this.lblDatosProducto.Size = new System.Drawing.Size(0, 18);
            this.lblDatosProducto.TabIndex = 0;
            // 
            // txtProducto
            // 
            this.txtProducto.Location = new System.Drawing.Point(466, 25);
            this.txtProducto.Name = "txtProducto";
            this.txtProducto.Size = new System.Drawing.Size(228, 22);
            this.txtProducto.TabIndex = 11;
            this.txtProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtProducto_KeyPress);
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(286, 25);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 9;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Enabled = false;
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(376, 25);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 10;
            // 
            // cbFecha
            // 
            this.cbFecha.DisplayMember = "Nombre";
            this.cbFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFecha.FormattingEnabled = true;
            this.cbFecha.Location = new System.Drawing.Point(180, 24);
            this.cbFecha.Name = "cbFecha";
            this.cbFecha.Size = new System.Drawing.Size(100, 24);
            this.cbFecha.TabIndex = 6;
            this.cbFecha.ValueMember = "Id";
            this.cbFecha.SelectionChangeCommitted += new System.EventHandler(this.cbFecha_SelectionChangeCommitted);
            // 
            // cbMovimiento
            // 
            this.cbMovimiento.DisplayMember = "Nombre";
            this.cbMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMovimiento.FormattingEnabled = true;
            this.cbMovimiento.Location = new System.Drawing.Point(13, 24);
            this.cbMovimiento.Name = "cbMovimiento";
            this.cbMovimiento.Size = new System.Drawing.Size(149, 24);
            this.cbMovimiento.TabIndex = 5;
            this.cbMovimiento.ValueMember = "Id";
            // 
            // gbMovimientos
            // 
            this.gbMovimientos.Controls.Add(this.StatusKardex);
            this.gbMovimientos.Controls.Add(this.dgvKardex);
            this.gbMovimientos.Location = new System.Drawing.Point(12, 144);
            this.gbMovimientos.Name = "gbMovimientos";
            this.gbMovimientos.Size = new System.Drawing.Size(1003, 408);
            this.gbMovimientos.TabIndex = 2;
            this.gbMovimientos.TabStop = false;
            this.gbMovimientos.Text = "Movimientos";
            // 
            // StatusKardex
            // 
            this.StatusKardex.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusKardex.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatus,
            this.btnSiguiente,
            this.btnFin});
            this.StatusKardex.Location = new System.Drawing.Point(3, 383);
            this.StatusKardex.Name = "StatusKardex";
            this.StatusKardex.Size = new System.Drawing.Size(997, 22);
            this.StatusKardex.TabIndex = 2;
            this.StatusKardex.Text = "Status de Kardex";
            // 
            // btnInicio
            // 
            this.btnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.ShowDropDownArrow = false;
            this.btnInicio.Size = new System.Drawing.Size(20, 20);
            this.btnInicio.Text = "Inicio";
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = ((System.Drawing.Image)(resources.GetObject("btnAnterior.Image")));
            this.btnAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.ShowDropDownArrow = false;
            this.btnAnterior.Size = new System.Drawing.Size(43, 20);
            this.btnAnterior.Text = " (-)";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(30, 17);
            this.lblStatus.Text = "0 / 0";
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguiente.Image")));
            this.btnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.ShowDropDownArrow = false;
            this.btnSiguiente.Size = new System.Drawing.Size(46, 20);
            this.btnSiguiente.Text = " (+)";
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnFin
            // 
            this.btnFin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFin.Image = ((System.Drawing.Image)(resources.GetObject("btnFin.Image")));
            this.btnFin.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFin.Name = "btnFin";
            this.btnFin.ShowDropDownArrow = false;
            this.btnFin.Size = new System.Drawing.Size(20, 20);
            this.btnFin.Text = "Fin";
            this.btnFin.Click += new System.EventHandler(this.btnFin_Click);
            // 
            // txtDocumento
            // 
            this.txtDocumento.BackColor = System.Drawing.Color.LightSteelBlue;
            this.txtDocumento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumento.Location = new System.Drawing.Point(12, 561);
            this.txtDocumento.Name = "txtDocumento";
            this.txtDocumento.ReadOnly = true;
            this.txtDocumento.Size = new System.Drawing.Size(282, 22);
            this.txtDocumento.TabIndex = 15;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConsultarProducto,
            this.tsVerResumen,
            this.tsBtnSelecionaGrid,
            this.tsBtnImprimir,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1027, 25);
            this.tsMenu.TabIndex = 16;
            this.tsMenu.Text = "Menu";
            // 
            // tsConsultarProducto
            // 
            this.tsConsultarProducto.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultarProducto.Image")));
            this.tsConsultarProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConsultarProducto.Name = "tsConsultarProducto";
            this.tsConsultarProducto.Size = new System.Drawing.Size(158, 22);
            this.tsConsultarProducto.Text = "Consultar Productos [F3]";
            this.tsConsultarProducto.ToolTipText = "Consultar Producto";
            this.tsConsultarProducto.Click += new System.EventHandler(this.tsConsultarProducto_Click);
            // 
            // tsVerResumen
            // 
            this.tsVerResumen.Image = ((System.Drawing.Image)(resources.GetObject("tsVerResumen.Image")));
            this.tsVerResumen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerResumen.Name = "tsVerResumen";
            this.tsVerResumen.Size = new System.Drawing.Size(137, 22);
            this.tsVerResumen.Text = "Resumen Kardex [F5]";
            this.tsVerResumen.ToolTipText = "Ver Resumen";
            this.tsVerResumen.Click += new System.EventHandler(this.tsVerResumen_Click);
            // 
            // tsBtnSelecionaGrid
            // 
            this.tsBtnSelecionaGrid.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSelecionaGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSelecionaGrid.Image")));
            this.tsBtnSelecionaGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelecionaGrid.Name = "tsBtnSelecionaGrid";
            this.tsBtnSelecionaGrid.Size = new System.Drawing.Size(148, 22);
            this.tsBtnSelecionaGrid.Text = "Seleccionar Grid [F7]";
            this.tsBtnSelecionaGrid.Click += new System.EventHandler(this.tsBtnSelecionaGrid_Click);
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
            // dgvKardex
            // 
            this.dgvKardex.AllowUserToAddRows = false;
            this.dgvKardex.AllowUserToResizeColumns = false;
            this.dgvKardex.AllowUserToResizeRows = false;
            this.dgvKardex.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvKardex.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKardex.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NoDocumento,
            this.Fecha,
            this.Hora,
            this.IdConcepto,
            this.Articulo,
            this.IconoOperacion,
            this.Cantidad,
            this.Valor,
            this.Usuario});
            this.dgvKardex.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvKardex.Location = new System.Drawing.Point(3, 23);
            this.dgvKardex.Name = "dgvKardex";
            this.dgvKardex.RowHeadersVisible = false;
            this.dgvKardex.Size = new System.Drawing.Size(996, 359);
            this.dgvKardex.TabIndex = 1;
            this.dgvKardex.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKardex_CellClick);
            this.dgvKardex.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvKardex_KeyUp);
            // 
            // NoDocumento
            // 
            this.NoDocumento.DataPropertyName = "NoDocumento";
            this.NoDocumento.HeaderText = "NoDocumento";
            this.NoDocumento.Name = "NoDocumento";
            this.NoDocumento.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle6.Format = "d";
            dataGridViewCellStyle6.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle6;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // Hora
            // 
            this.Hora.DataPropertyName = "Hora";
            dataGridViewCellStyle7.Format = "T";
            dataGridViewCellStyle7.NullValue = null;
            this.Hora.DefaultCellStyle = dataGridViewCellStyle7;
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            // 
            // IdConcepto
            // 
            this.IdConcepto.DataPropertyName = "IdConcepto";
            this.IdConcepto.HeaderText = "IdConcepto";
            this.IdConcepto.Name = "IdConcepto";
            this.IdConcepto.Visible = false;
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Concepto";
            this.Articulo.HeaderText = "Concepto";
            this.Articulo.Name = "Articulo";
            this.Articulo.ReadOnly = true;
            this.Articulo.Width = 300;
            // 
            // IconoOperacion
            // 
            this.IconoOperacion.DataPropertyName = "Imagen";
            this.IconoOperacion.HeaderText = "";
            this.IconoOperacion.Name = "IconoOperacion";
            this.IconoOperacion.ReadOnly = true;
            this.IconoOperacion.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IconoOperacion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IconoOperacion.Width = 78;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N2";
            dataGridViewCellStyle8.NullValue = null;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle8;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C0";
            dataGridViewCellStyle9.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle9;
            this.Valor.HeaderText = "Valor Unit.";
            this.Valor.Name = "Valor";
            this.Valor.Width = 112;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.NullValue = null;
            this.Usuario.DefaultCellStyle = dataGridViewCellStyle10;
            this.Usuario.HeaderText = "Usuario";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            this.Usuario.Width = 200;
            // 
            // tsBtnImprimir
            // 
            this.tsBtnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimir.Image")));
            this.tsBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimir.Name = "tsBtnImprimir";
            this.tsBtnImprimir.Size = new System.Drawing.Size(109, 22);
            this.tsBtnImprimir.Text = "Imprimir [F10]";
            this.tsBtnImprimir.Click += new System.EventHandler(this.tsBtnImprimir_Click);
            // 
            // FrmKardex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1027, 593);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.txtDocumento);
            this.Controls.Add(this.gbMovimientos);
            this.Controls.Add(this.gbCriterio);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmKardex";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kardex";
            this.Load += new System.EventHandler(this.FrmKardex_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmKardex_KeyDown);
            this.gbCriterio.ResumeLayout(false);
            this.gbCriterio.PerformLayout();
            this.panelProducto.ResumeLayout(false);
            this.panelProducto.PerformLayout();
            this.gbMovimientos.ResumeLayout(false);
            this.gbMovimientos.PerformLayout();
            this.StatusKardex.ResumeLayout(false);
            this.StatusKardex.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKardex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCriterio;
        private System.Windows.Forms.ComboBox cbFecha;
        private System.Windows.Forms.ComboBox cbMovimiento;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
        private System.Windows.Forms.TextBox txtProducto;
        private Ventas.Factura.DataGridViewPlus dgvKardex;
        private System.Windows.Forms.GroupBox gbMovimientos;
        private System.Windows.Forms.StatusStrip StatusKardex;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.TextBox txtDocumento;
        private System.Windows.Forms.Panel panelProducto;
        private System.Windows.Forms.Label lblDatosProducto;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.ToolStripButton tsVerResumen;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoDocumento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdConcepto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewImageColumn IconoOperacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.ToolStripButton tsBtnSelecionaGrid;
        private System.Windows.Forms.ToolStripButton tsConsultarProducto;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
    }
}