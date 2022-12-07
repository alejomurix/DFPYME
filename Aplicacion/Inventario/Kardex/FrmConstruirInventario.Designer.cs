namespace Aplicacion.Inventario.Kardex
{
    partial class FrmConstruirInventario
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
            new System.ComponentModel.ComponentResourceManager(typeof(FrmConstruirInventario));

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConstruirInventario));
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.CodigoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolVentas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ventas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DevolCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InventarioCalulado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Invetario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbConsultas = new System.Windows.Forms.GroupBox();
            this.dtpFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtpFecha2 = new System.Windows.Forms.DateTimePicker();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtCodigoNombre = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnListarTodos = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSelecionaGrid = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCriterio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeleccionarCriterio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNuevoArticulo = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImprimirConsulta = new System.Windows.Forms.ToolStripButton();
            this.tsBtnImprimir = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.gbConsultas.SuspendLayout();
            this.gbResultado.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodigoCategoria,
            this.Categoria,
            this.Codigo,
            this.Producto,
            this.Compras,
            this.DevolVentas,
            this.Ventas,
            this.DevolCompra,
            this.InventarioCalulado,
            this.Invetario});
            this.dgvInventario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventario.Location = new System.Drawing.Point(6, 12);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(1171, 514);
            this.dgvInventario.TabIndex = 0;
            this.dgvInventario.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellClick);
            this.dgvInventario.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInventario_CellDoubleClick);
            this.dgvInventario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvInventario_KeyPress);
            // 
            // CodigoCategoria
            // 
            this.CodigoCategoria.DataPropertyName = "codcategoria";
            this.CodigoCategoria.HeaderText = "Cod Categoria";
            this.CodigoCategoria.Name = "CodigoCategoria";
            this.CodigoCategoria.Visible = false;
            this.CodigoCategoria.Width = 110;
            // 
            // Categoria
            // 
            this.Categoria.DataPropertyName = "categoria";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 160;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "producto";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 325;
            // 
            // Compras
            // 
            this.Compras.DataPropertyName = "compra";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Compras.DefaultCellStyle = dataGridViewCellStyle7;
            this.Compras.HeaderText = "Compras";
            this.Compras.Name = "Compras";
            this.Compras.Width = 85;
            // 
            // DevolVentas
            // 
            this.DevolVentas.DataPropertyName = "devolventa";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N0";
            dataGridViewCellStyle8.NullValue = null;
            this.DevolVentas.DefaultCellStyle = dataGridViewCellStyle8;
            this.DevolVentas.HeaderText = "D. Venta";
            this.DevolVentas.Name = "DevolVentas";
            // 
            // Ventas
            // 
            this.Ventas.DataPropertyName = "venta";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N0";
            dataGridViewCellStyle9.NullValue = null;
            this.Ventas.DefaultCellStyle = dataGridViewCellStyle9;
            this.Ventas.HeaderText = "Ventas";
            this.Ventas.Name = "Ventas";
            // 
            // DevolCompra
            // 
            this.DevolCompra.DataPropertyName = "devolcompra";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "N0";
            dataGridViewCellStyle10.NullValue = null;
            this.DevolCompra.DefaultCellStyle = dataGridViewCellStyle10;
            this.DevolCompra.HeaderText = "D. Compra";
            this.DevolCompra.Name = "DevolCompra";
            // 
            // InventarioCalulado
            // 
            this.InventarioCalulado.DataPropertyName = "inventario_cal";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "N0";
            dataGridViewCellStyle11.NullValue = null;
            this.InventarioCalulado.DefaultCellStyle = dataGridViewCellStyle11;
            this.InventarioCalulado.HeaderText = "Inv. Cal.";
            this.InventarioCalulado.Name = "InventarioCalulado";
            // 
            // Invetario
            // 
            this.Invetario.DataPropertyName = "inventario";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "N0";
            dataGridViewCellStyle12.NullValue = null;
            this.Invetario.DefaultCellStyle = dataGridViewCellStyle12;
            this.Invetario.HeaderText = "Invetario";
            this.Invetario.Name = "Invetario";
            // 
            // gbConsultas
            // 
            this.gbConsultas.Controls.Add(this.dtpFecha1);
            this.gbConsultas.Controls.Add(this.dtpFecha2);
            this.gbConsultas.Controls.Add(this.cbCriterio);
            this.gbConsultas.Controls.Add(this.txtCodigoNombre);
            this.gbConsultas.Controls.Add(this.btnConsultar);
            this.gbConsultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbConsultas.Location = new System.Drawing.Point(7, 4);
            this.gbConsultas.Name = "gbConsultas";
            this.gbConsultas.Size = new System.Drawing.Size(758, 52);
            this.gbConsultas.TabIndex = 0;
            this.gbConsultas.TabStop = false;
            // 
            // dtpFecha1
            // 
            this.dtpFecha1.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha1.Location = new System.Drawing.Point(541, 17);
            this.dtpFecha1.Name = "dtpFecha1";
            this.dtpFecha1.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha1.TabIndex = 11;
            // 
            // dtpFecha2
            // 
            this.dtpFecha2.CustomFormat = "dd/MM/yyyy";
            this.dtpFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha2.Location = new System.Drawing.Point(631, 17);
            this.dtpFecha2.Name = "dtpFecha2";
            this.dtpFecha2.Size = new System.Drawing.Size(84, 22);
            this.dtpFecha2.TabIndex = 12;
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(10, 16);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(121, 24);
            this.cbCriterio.TabIndex = 3;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            this.cbCriterio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCriterio_KeyPress);
            // 
            // txtCodigoNombre
            // 
            this.txtCodigoNombre.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoNombre.Location = new System.Drawing.Point(137, 17);
            this.txtCodigoNombre.Name = "txtCodigoNombre";
            this.txtCodigoNombre.Size = new System.Drawing.Size(395, 22);
            this.txtCodigoNombre.TabIndex = 0;
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(722, 15);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(24, 24);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.dgvInventario);
            this.gbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbResultado.Location = new System.Drawing.Point(7, 60);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(1187, 532);
            this.gbResultado.TabIndex = 1;
            this.gbResultado.TabStop = false;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnListarTodos,
            this.tsBtnSelecionaGrid,
            this.tsBtnCriterio,
            this.tsBtnSeleccionarCriterio,
            this.tsBtnNuevoArticulo,
            this.tsBtnImprimirConsulta,
            this.tsBtnImprimir,
            this.tsBtnSeleccionar,
            this.tsBtnSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(1193, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "toolStrip1";
            this.tsMenu.Visible = false;
            // 
            // tsBtnListarTodos
            // 
            this.tsBtnListarTodos.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnListarTodos.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnListarTodos.Image")));
            this.tsBtnListarTodos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnListarTodos.Name = "tsBtnListarTodos";
            this.tsBtnListarTodos.Size = new System.Drawing.Size(125, 22);
            this.tsBtnListarTodos.Text = "Listar Todos [F5]";
            this.tsBtnListarTodos.Click += new System.EventHandler(this.tsBtnListarTodos_Click);
            // 
            // tsBtnSelecionaGrid
            // 
            this.tsBtnSelecionaGrid.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSelecionaGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSelecionaGrid.Image")));
            this.tsBtnSelecionaGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSelecionaGrid.Name = "tsBtnSelecionaGrid";
            this.tsBtnSelecionaGrid.Size = new System.Drawing.Size(171, 22);
            this.tsBtnSelecionaGrid.Text = "Seleccionar consulta [F7]";
            this.tsBtnSelecionaGrid.Click += new System.EventHandler(this.tsBtnSelecionaGrid_Click);
            // 
            // tsBtnCriterio
            // 
            this.tsBtnCriterio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCriterio.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCriterio.Image")));
            this.tsBtnCriterio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCriterio.Name = "tsBtnCriterio";
            this.tsBtnCriterio.Size = new System.Drawing.Size(96, 22);
            this.tsBtnCriterio.Text = "Criterio [F4]";
            this.tsBtnCriterio.Visible = false;
            this.tsBtnCriterio.Click += new System.EventHandler(this.tsBtnCriterio_Click);
            // 
            // tsBtnSeleccionarCriterio
            // 
            this.tsBtnSeleccionarCriterio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSeleccionarCriterio.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSeleccionarCriterio.Image")));
            this.tsBtnSeleccionarCriterio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSeleccionarCriterio.Name = "tsBtnSeleccionarCriterio";
            this.tsBtnSeleccionarCriterio.Size = new System.Drawing.Size(164, 22);
            this.tsBtnSeleccionarCriterio.Text = "Seleccionar criterio [F5]";
            this.tsBtnSeleccionarCriterio.Visible = false;
            this.tsBtnSeleccionarCriterio.Click += new System.EventHandler(this.tsBtnSeleccionarCriterio_Click);
            // 
            // tsBtnNuevoArticulo
            // 
            this.tsBtnNuevoArticulo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnNuevoArticulo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNuevoArticulo.Image")));
            this.tsBtnNuevoArticulo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNuevoArticulo.Name = "tsBtnNuevoArticulo";
            this.tsBtnNuevoArticulo.Size = new System.Drawing.Size(139, 22);
            this.tsBtnNuevoArticulo.Text = "Nuevo Articulo [F9]";
            this.tsBtnNuevoArticulo.Click += new System.EventHandler(this.tsBtnNuevoArticulo_Click);
            // 
            // tsBtnImprimirConsulta
            // 
            this.tsBtnImprimirConsulta.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimirConsulta.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimirConsulta.Image")));
            this.tsBtnImprimirConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimirConsulta.Name = "tsBtnImprimirConsulta";
            this.tsBtnImprimirConsulta.Size = new System.Drawing.Size(161, 22);
            this.tsBtnImprimirConsulta.Text = "Imprimir consulta [F10]";
            this.tsBtnImprimirConsulta.Click += new System.EventHandler(this.tsBtnImprimirConsulta_Click);
            // 
            // tsBtnImprimir
            // 
            this.tsBtnImprimir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnImprimir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnImprimir.Image")));
            this.tsBtnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnImprimir.Name = "tsBtnImprimir";
            this.tsBtnImprimir.Size = new System.Drawing.Size(173, 22);
            this.tsBtnImprimir.Text = "Imprimir productos [F11]";
            this.tsBtnImprimir.Click += new System.EventHandler(this.tsBtnImprimir_Click);
            // 
            // tsBtnSeleccionar
            // 
            this.tsBtnSeleccionar.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsBtnSeleccionar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSeleccionar.Image")));
            this.tsBtnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSeleccionar.Name = "tsBtnSeleccionar";
            this.tsBtnSeleccionar.Size = new System.Drawing.Size(129, 22);
            this.tsBtnSeleccionar.Text = "Seleccionar [F12]";
            this.tsBtnSeleccionar.ToolTipText = "Seleccionar [F12]";
            this.tsBtnSeleccionar.Visible = false;
            this.tsBtnSeleccionar.Click += new System.EventHandler(this.tsBtnSeleccionar_Click);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(87, 21);
            this.tsBtnSalir.Text = "Salir [ESC]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // FrmConstruirInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1201, 604);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbConsultas);
            this.Controls.Add(this.gbResultado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConstruirInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsultaInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsultaInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaInventario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.gbConsultas.ResumeLayout(false);
            this.gbConsultas.PerformLayout();
            this.gbResultado.ResumeLayout(false);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbConsultas;
        private System.Windows.Forms.GroupBox gbResultado;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnListarTodos;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        public System.Windows.Forms.TextBox txtCodigoNombre;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
        public System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.ToolStripButton tsBtnNuevoArticulo;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnSelecionaGrid;
        private System.Windows.Forms.ToolStripButton tsBtnCriterio;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionarCriterio;
        private System.Windows.Forms.ToolStripButton tsBtnImprimirConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compras;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ventas;
        private System.Windows.Forms.DataGridViewTextBoxColumn DevolCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn InventarioCalulado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invetario;
        private System.Windows.Forms.DateTimePicker dtpFecha1;
        private System.Windows.Forms.DateTimePicker dtpFecha2;
    }
}