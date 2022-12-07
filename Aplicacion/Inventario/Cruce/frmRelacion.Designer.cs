namespace Aplicacion.Inventario.Cruce
{
    partial class frmRelacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelacion));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbInventario = new System.Windows.Forms.GroupBox();
            this.btnEditarCantidad = new System.Windows.Forms.Button();
            this.statusGridInventario = new System.Windows.Forms.StatusStrip();
            this.btnInicioRowInventario = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnteriorRowInventario = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusPaginaInventario = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguienteRowInventario = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFinRowInventario = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.Inventario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fisico = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Diferencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbProducto = new System.Windows.Forms.GroupBox();
            this.statusGridProducto = new System.Windows.Forms.StatusStrip();
            this.btnInicioRowProducto = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnteriorRowProducto = new System.Windows.Forms.ToolStripDropDownButton();
            this.statusPaginaProducto = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguienteRowProducto = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFinRowProducto = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenuInventario = new System.Windows.Forms.ToolStrip();
            this.tsbtnCorteRealizar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCorteGeneral = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbtnCudrarInventario = new System.Windows.Forms.ToolStripButton();
            this.tsBtnResultado = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnHistorial = new System.Windows.Forms.ToolStripButton();
            this.tsBtnActualizar = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbConsultaProducto = new System.Windows.Forms.GroupBox();
            this.lblFechaActual = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.cbCriterioCategoria = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.gBConsultarInventario = new System.Windows.Forms.GroupBox();
            this.cbCriterioConsulta = new System.Windows.Forms.ComboBox();
            this.btnBuscaInventario = new System.Windows.Forms.Button();
            this.dtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.cbConsultaInventario = new System.Windows.Forms.ComboBox();
            this.dtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.gbInventario.SuspendLayout();
            this.statusGridInventario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).BeginInit();
            this.gbProducto.SuspendLayout();
            this.statusGridProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.tsMenuInventario.SuspendLayout();
            this.gbConsultaProducto.SuspendLayout();
            this.gBConsultarInventario.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbInventario
            // 
            this.gbInventario.Controls.Add(this.btnEditarCantidad);
            this.gbInventario.Controls.Add(this.statusGridInventario);
            this.gbInventario.Controls.Add(this.dgvInventario);
            this.gbInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbInventario.Location = new System.Drawing.Point(508, 144);
            this.gbInventario.Name = "gbInventario";
            this.gbInventario.Size = new System.Drawing.Size(475, 347);
            this.gbInventario.TabIndex = 3;
            this.gbInventario.TabStop = false;
            this.gbInventario.Text = "Inventario";
            // 
            // btnEditarCantidad
            // 
            this.btnEditarCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.5F);
            this.btnEditarCantidad.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCantidad.Image")));
            this.btnEditarCantidad.Location = new System.Drawing.Point(437, 12);
            this.btnEditarCantidad.Name = "btnEditarCantidad";
            this.btnEditarCantidad.Size = new System.Drawing.Size(27, 22);
            this.btnEditarCantidad.TabIndex = 50;
            this.btnEditarCantidad.UseVisualStyleBackColor = true;
            this.btnEditarCantidad.Click += new System.EventHandler(this.btnEditarCantidad_Click);
            // 
            // statusGridInventario
            // 
            this.statusGridInventario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusGridInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicioRowInventario,
            this.btnAnteriorRowInventario,
            this.statusPaginaInventario,
            this.btnSiguienteRowInventario,
            this.btnFinRowInventario});
            this.statusGridInventario.Location = new System.Drawing.Point(3, 322);
            this.statusGridInventario.Name = "statusGridInventario";
            this.statusGridInventario.Size = new System.Drawing.Size(469, 22);
            this.statusGridInventario.TabIndex = 0;
            this.statusGridInventario.Text = "statusStrip1";
            // 
            // btnInicioRowInventario
            // 
            this.btnInicioRowInventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicioRowInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnInicioRowInventario.Image")));
            this.btnInicioRowInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicioRowInventario.Name = "btnInicioRowInventario";
            this.btnInicioRowInventario.ShowDropDownArrow = false;
            this.btnInicioRowInventario.Size = new System.Drawing.Size(20, 20);
            this.btnInicioRowInventario.Click += new System.EventHandler(this.btnInicioRowInventario_Click);
            // 
            // btnAnteriorRowInventario
            // 
            this.btnAnteriorRowInventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnteriorRowInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnAnteriorRowInventario.Image")));
            this.btnAnteriorRowInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnteriorRowInventario.Name = "btnAnteriorRowInventario";
            this.btnAnteriorRowInventario.ShowDropDownArrow = false;
            this.btnAnteriorRowInventario.Size = new System.Drawing.Size(20, 20);
            this.btnAnteriorRowInventario.Click += new System.EventHandler(this.btnAnteriorRowInventario_Click);
            // 
            // statusPaginaInventario
            // 
            this.statusPaginaInventario.Name = "statusPaginaInventario";
            this.statusPaginaInventario.Size = new System.Drawing.Size(30, 17);
            this.statusPaginaInventario.Text = "0 / 0";
            // 
            // btnSiguienteRowInventario
            // 
            this.btnSiguienteRowInventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguienteRowInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguienteRowInventario.Image")));
            this.btnSiguienteRowInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguienteRowInventario.Name = "btnSiguienteRowInventario";
            this.btnSiguienteRowInventario.ShowDropDownArrow = false;
            this.btnSiguienteRowInventario.Size = new System.Drawing.Size(20, 20);
            this.btnSiguienteRowInventario.Click += new System.EventHandler(this.btnSiguienteRowInventario_Click);
            // 
            // btnFinRowInventario
            // 
            this.btnFinRowInventario.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFinRowInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnFinRowInventario.Image")));
            this.btnFinRowInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinRowInventario.Name = "btnFinRowInventario";
            this.btnFinRowInventario.ShowDropDownArrow = false;
            this.btnFinRowInventario.Size = new System.Drawing.Size(20, 20);
            this.btnFinRowInventario.Click += new System.EventHandler(this.btnFinRowInventario_Click);
            // 
            // dgvInventario
            // 
            this.dgvInventario.AllowUserToAddRows = false;
            this.dgvInventario.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Id,
            this.Fecha,
            this.Unidad,
            this.Medida,
            this.Color,
            this.Inventario,
            this.Fisico,
            this.Diferencia});
            this.dgvInventario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventario.Location = new System.Drawing.Point(10, 38);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(454, 281);
            this.dgvInventario.TabIndex = 0;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            this.Codigo.Width = 58;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.Width = 110;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Visible = false;
            this.Unidad.Width = 77;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Visible = false;
            this.Medida.Width = 79;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Color.Visible = false;
            this.Color.Width = 65;
            // 
            // Inventario
            // 
            this.Inventario.DataPropertyName = "Inventario";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Inventario.DefaultCellStyle = dataGridViewCellStyle1;
            this.Inventario.HeaderText = "Inventario";
            this.Inventario.Name = "Inventario";
            this.Inventario.Width = 110;
            // 
            // Fisico
            // 
            this.Fisico.DataPropertyName = "Fisico";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Fisico.DefaultCellStyle = dataGridViewCellStyle2;
            this.Fisico.HeaderText = "Fisico";
            this.Fisico.Name = "Fisico";
            this.Fisico.Width = 110;
            // 
            // Diferencia
            // 
            this.Diferencia.DataPropertyName = "Diferencia";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Diferencia.DefaultCellStyle = dataGridViewCellStyle3;
            this.Diferencia.HeaderText = "Diferencia";
            this.Diferencia.Name = "Diferencia";
            this.Diferencia.Width = 110;
            // 
            // gbProducto
            // 
            this.gbProducto.Controls.Add(this.statusGridProducto);
            this.gbProducto.Controls.Add(this.dgvProductos);
            this.gbProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbProducto.Location = new System.Drawing.Point(12, 144);
            this.gbProducto.Name = "gbProducto";
            this.gbProducto.Size = new System.Drawing.Size(490, 347);
            this.gbProducto.TabIndex = 2;
            this.gbProducto.TabStop = false;
            this.gbProducto.Text = "Producto";
            // 
            // statusGridProducto
            // 
            this.statusGridProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.statusGridProducto.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicioRowProducto,
            this.btnAnteriorRowProducto,
            this.statusPaginaProducto,
            this.btnSiguienteRowProducto,
            this.btnFinRowProducto});
            this.statusGridProducto.Location = new System.Drawing.Point(3, 322);
            this.statusGridProducto.Name = "statusGridProducto";
            this.statusGridProducto.Size = new System.Drawing.Size(484, 22);
            this.statusGridProducto.TabIndex = 0;
            this.statusGridProducto.Text = "Paginas de Documento";
            // 
            // btnInicioRowProducto
            // 
            this.btnInicioRowProducto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnInicioRowProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnInicioRowProducto.Image")));
            this.btnInicioRowProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnInicioRowProducto.Name = "btnInicioRowProducto";
            this.btnInicioRowProducto.ShowDropDownArrow = false;
            this.btnInicioRowProducto.Size = new System.Drawing.Size(20, 20);
            this.btnInicioRowProducto.Click += new System.EventHandler(this.btnInicioRowProducto_Click);
            // 
            // btnAnteriorRowProducto
            // 
            this.btnAnteriorRowProducto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAnteriorRowProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnAnteriorRowProducto.Image")));
            this.btnAnteriorRowProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAnteriorRowProducto.Name = "btnAnteriorRowProducto";
            this.btnAnteriorRowProducto.ShowDropDownArrow = false;
            this.btnAnteriorRowProducto.Size = new System.Drawing.Size(20, 20);
            this.btnAnteriorRowProducto.Click += new System.EventHandler(this.btnAnteriorRowProducto_Click);
            // 
            // statusPaginaProducto
            // 
            this.statusPaginaProducto.Name = "statusPaginaProducto";
            this.statusPaginaProducto.Size = new System.Drawing.Size(36, 17);
            this.statusPaginaProducto.Text = " 0 / 0 ";
            // 
            // btnSiguienteRowProducto
            // 
            this.btnSiguienteRowProducto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSiguienteRowProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnSiguienteRowProducto.Image")));
            this.btnSiguienteRowProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSiguienteRowProducto.Name = "btnSiguienteRowProducto";
            this.btnSiguienteRowProducto.ShowDropDownArrow = false;
            this.btnSiguienteRowProducto.Size = new System.Drawing.Size(20, 20);
            this.btnSiguienteRowProducto.Text = "toolStripDropDownButton3";
            this.btnSiguienteRowProducto.Click += new System.EventHandler(this.btnSiguienteRowProducto_Click);
            // 
            // btnFinRowProducto
            // 
            this.btnFinRowProducto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnFinRowProducto.Image = ((System.Drawing.Image)(resources.GetObject("btnFinRowProducto.Image")));
            this.btnFinRowProducto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFinRowProducto.Name = "btnFinRowProducto";
            this.btnFinRowProducto.ShowDropDownArrow = false;
            this.btnFinRowProducto.Size = new System.Drawing.Size(20, 20);
            this.btnFinRowProducto.Text = "toolStripDropDownButton4";
            this.btnFinRowProducto.Click += new System.EventHandler(this.btnFinRowProducto_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.AllowUserToAddRows = false;
            this.dgvProductos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvProductos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductos.GridColor = System.Drawing.SystemColors.InfoText;
            this.dgvProductos.Location = new System.Drawing.Point(7, 23);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvProductos.RowHeadersVisible = false;
            this.dgvProductos.Size = new System.Drawing.Size(476, 296);
            this.dgvProductos.TabIndex = 3;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            this.dgvProductos.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dgvProductos_KeyUp);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "codigointernoproducto";
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "codigobarrasproducto";
            this.Column2.FillWeight = 210F;
            this.Column2.HeaderText = "Codigo de Barras";
            this.Column2.Name = "Column2";
            this.Column2.Visible = false;
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "nombreproducto";
            this.Column3.HeaderText = "Producto";
            this.Column3.Name = "Column3";
            this.Column3.Width = 350;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "nombremarca";
            this.Column4.HeaderText = "Marca";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            this.Column4.Width = 67;
            // 
            // tsMenuInventario
            // 
            this.tsMenuInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnCorteRealizar,
            this.tsBtnCorteGeneral,
            this.toolStripSeparator1,
            this.tsbtnCudrarInventario,
            this.tsBtnResultado,
            this.toolStripSeparator2,
            this.tsBtnHistorial,
            this.tsBtnActualizar,
            this.toolStripSeparator3,
            this.tsBtnSalir});
            this.tsMenuInventario.Location = new System.Drawing.Point(0, 0);
            this.tsMenuInventario.Name = "tsMenuInventario";
            this.tsMenuInventario.Size = new System.Drawing.Size(998, 25);
            this.tsMenuInventario.TabIndex = 4;
            this.tsMenuInventario.Text = "Menu Inventario";
            // 
            // tsbtnCorteRealizar
            // 
            this.tsbtnCorteRealizar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnCorteRealizar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCorteRealizar.Image")));
            this.tsbtnCorteRealizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCorteRealizar.Name = "tsbtnCorteRealizar";
            this.tsbtnCorteRealizar.Size = new System.Drawing.Size(118, 22);
            this.tsbtnCorteRealizar.Text = "Corte a realizar";
            this.tsbtnCorteRealizar.Click += new System.EventHandler(this.tsbtnCorteRealizar_Click);
            // 
            // tsBtnCorteGeneral
            // 
            this.tsBtnCorteGeneral.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCorteGeneral.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCorteGeneral.Image")));
            this.tsBtnCorteGeneral.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCorteGeneral.Name = "tsBtnCorteGeneral";
            this.tsBtnCorteGeneral.Size = new System.Drawing.Size(109, 22);
            this.tsBtnCorteGeneral.Text = "Corte General";
            this.tsBtnCorteGeneral.Click += new System.EventHandler(this.tsBtnCorteGeneral_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbtnCudrarInventario
            // 
            this.tsbtnCudrarInventario.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnCudrarInventario.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnCudrarInventario.Image")));
            this.tsbtnCudrarInventario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnCudrarInventario.Name = "tsbtnCudrarInventario";
            this.tsbtnCudrarInventario.Size = new System.Drawing.Size(127, 22);
            this.tsbtnCudrarInventario.Text = "Cruzar Inventario";
            this.tsbtnCudrarInventario.Click += new System.EventHandler(this.tsbtnCudrarInventario_Click);
            // 
            // tsBtnResultado
            // 
            this.tsBtnResultado.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnResultado.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnResultado.Image")));
            this.tsBtnResultado.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnResultado.Name = "tsBtnResultado";
            this.tsBtnResultado.Size = new System.Drawing.Size(166, 22);
            this.tsBtnResultado.Text = "Resultado de Inventario";
            this.tsBtnResultado.Click += new System.EventHandler(this.tsBtnResultado_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnHistorial
            // 
            this.tsBtnHistorial.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnHistorial.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnHistorial.Image")));
            this.tsBtnHistorial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnHistorial.Name = "tsBtnHistorial";
            this.tsBtnHistorial.Size = new System.Drawing.Size(198, 22);
            this.tsBtnHistorial.Text = "Historial de Último Inventario";
            this.tsBtnHistorial.Visible = false;
            this.tsBtnHistorial.Click += new System.EventHandler(this.tsBtnHistorial_Click);
            // 
            // tsBtnActualizar
            // 
            this.tsBtnActualizar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnActualizar.Image")));
            this.tsBtnActualizar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnActualizar.Name = "tsBtnActualizar";
            this.tsBtnActualizar.Size = new System.Drawing.Size(145, 22);
            this.tsBtnActualizar.Text = "Actualizar Inventario";
            this.tsBtnActualizar.Visible = false;
            this.tsBtnActualizar.Click += new System.EventHandler(this.tsBtnActualizar_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Padding = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsBtnSalir
            // 
            this.tsBtnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnSalir.Image")));
            this.tsBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnSalir.Name = "tsBtnSalir";
            this.tsBtnSalir.Size = new System.Drawing.Size(84, 22);
            this.tsBtnSalir.Text = "Salir [Esc]";
            this.tsBtnSalir.Click += new System.EventHandler(this.tsBtnSalir_Click);
            // 
            // gbConsultaProducto
            // 
            this.gbConsultaProducto.Controls.Add(this.lblFechaActual);
            this.gbConsultaProducto.Controls.Add(this.lblFecha);
            this.gbConsultaProducto.Controls.Add(this.cbCriterioCategoria);
            this.gbConsultaProducto.Controls.Add(this.btnBuscar);
            this.gbConsultaProducto.Controls.Add(this.txtCodigo);
            this.gbConsultaProducto.Controls.Add(this.cbCriterio);
            this.gbConsultaProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbConsultaProducto.Location = new System.Drawing.Point(12, 31);
            this.gbConsultaProducto.Name = "gbConsultaProducto";
            this.gbConsultaProducto.Size = new System.Drawing.Size(387, 107);
            this.gbConsultaProducto.TabIndex = 0;
            this.gbConsultaProducto.TabStop = false;
            this.gbConsultaProducto.Text = "Consulta de Producto";
            // 
            // lblFechaActual
            // 
            this.lblFechaActual.AutoSize = true;
            this.lblFechaActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaActual.Location = new System.Drawing.Point(79, 25);
            this.lblFechaActual.Name = "lblFechaActual";
            this.lblFechaActual.Size = new System.Drawing.Size(0, 16);
            this.lblFechaActual.TabIndex = 5;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(14, 22);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(55, 16);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha : ";
            // 
            // cbCriterioCategoria
            // 
            this.cbCriterioCategoria.DisplayMember = "NombreCategoria";
            this.cbCriterioCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterioCategoria.Enabled = false;
            this.cbCriterioCategoria.FormattingEnabled = true;
            this.cbCriterioCategoria.Location = new System.Drawing.Point(199, 47);
            this.cbCriterioCategoria.Name = "cbCriterioCategoria";
            this.cbCriterioCategoria.Size = new System.Drawing.Size(148, 24);
            this.cbCriterioCategoria.TabIndex = 3;
            this.cbCriterioCategoria.ValueMember = "CodigoCategoria";
            this.cbCriterioCategoria.SelectionChangeCommitted += new System.EventHandler(this.cbCriterioCategoria_SelectionChangeCommitted);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(321, 74);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(15, 75);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(287, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(15, 47);
            this.cbCriterio.Name = "cbCriterio";
            this.cbCriterio.Size = new System.Drawing.Size(173, 24);
            this.cbCriterio.TabIndex = 2;
            this.cbCriterio.ValueMember = "Id";
            this.cbCriterio.SelectionChangeCommitted += new System.EventHandler(this.cbCriterio_SelectionChangeCommitted);
            // 
            // gBConsultarInventario
            // 
            this.gBConsultarInventario.Controls.Add(this.cbCriterioConsulta);
            this.gBConsultarInventario.Controls.Add(this.btnBuscaInventario);
            this.gBConsultarInventario.Controls.Add(this.dtFecha1);
            this.gBConsultarInventario.Controls.Add(this.cbConsultaInventario);
            this.gBConsultarInventario.Controls.Add(this.dtFecha2);
            this.gBConsultarInventario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gBConsultarInventario.Location = new System.Drawing.Point(418, 30);
            this.gBConsultarInventario.Name = "gBConsultarInventario";
            this.gBConsultarInventario.Size = new System.Drawing.Size(565, 108);
            this.gBConsultarInventario.TabIndex = 1;
            this.gBConsultarInventario.TabStop = false;
            this.gBConsultarInventario.Text = "Consulta de Inventario";
            // 
            // cbCriterioConsulta
            // 
            this.cbCriterioConsulta.DisplayMember = "Nombre";
            this.cbCriterioConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterioConsulta.Enabled = false;
            this.cbCriterioConsulta.FormattingEnabled = true;
            this.cbCriterioConsulta.Location = new System.Drawing.Point(167, 35);
            this.cbCriterioConsulta.Name = "cbCriterioConsulta";
            this.cbCriterioConsulta.Size = new System.Drawing.Size(144, 24);
            this.cbCriterioConsulta.TabIndex = 1;
            this.cbCriterioConsulta.ValueMember = "Id";
            this.cbCriterioConsulta.SelectionChangeCommitted += new System.EventHandler(this.cbCriterioConsulta_SelectionChangeCommitted);
            // 
            // btnBuscaInventario
            // 
            this.btnBuscaInventario.Enabled = false;
            this.btnBuscaInventario.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscaInventario.Image")));
            this.btnBuscaInventario.Location = new System.Drawing.Point(531, 34);
            this.btnBuscaInventario.Name = "btnBuscaInventario";
            this.btnBuscaInventario.Size = new System.Drawing.Size(27, 23);
            this.btnBuscaInventario.TabIndex = 4;
            this.btnBuscaInventario.UseVisualStyleBackColor = true;
            this.btnBuscaInventario.Click += new System.EventHandler(this.btnBuscaInventario_Click);
            // 
            // dtFecha1
            // 
            this.dtFecha1.Enabled = false;
            this.dtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha1.Location = new System.Drawing.Point(320, 35);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.Size = new System.Drawing.Size(97, 22);
            this.dtFecha1.TabIndex = 2;
            // 
            // cbConsultaInventario
            // 
            this.cbConsultaInventario.DisplayMember = "Nombre";
            this.cbConsultaInventario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbConsultaInventario.Enabled = false;
            this.cbConsultaInventario.FormattingEnabled = true;
            this.cbConsultaInventario.Location = new System.Drawing.Point(11, 35);
            this.cbConsultaInventario.Name = "cbConsultaInventario";
            this.cbConsultaInventario.Size = new System.Drawing.Size(150, 24);
            this.cbConsultaInventario.TabIndex = 0;
            this.cbConsultaInventario.ValueMember = "Id";
            this.cbConsultaInventario.SelectionChangeCommitted += new System.EventHandler(this.cbConsultaInventario_SelectionChangeCommitted);
            // 
            // dtFecha2
            // 
            this.dtFecha2.Enabled = false;
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(426, 35);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.Size = new System.Drawing.Size(98, 22);
            this.dtFecha2.TabIndex = 3;
            // 
            // frmRelacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(998, 504);
            this.Controls.Add(this.tsMenuInventario);
            this.Controls.Add(this.gbConsultaProducto);
            this.Controls.Add(this.gBConsultarInventario);
            this.Controls.Add(this.gbProducto);
            this.Controls.Add(this.gbInventario);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRelacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cruce y Revisión de Inventario";
            this.Load += new System.EventHandler(this.frmRelacion_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmRelacion_KeyDown);
            this.gbInventario.ResumeLayout(false);
            this.gbInventario.PerformLayout();
            this.statusGridInventario.ResumeLayout(false);
            this.statusGridInventario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.gbProducto.ResumeLayout(false);
            this.gbProducto.PerformLayout();
            this.statusGridProducto.ResumeLayout(false);
            this.statusGridProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.tsMenuInventario.ResumeLayout(false);
            this.tsMenuInventario.PerformLayout();
            this.gbConsultaProducto.ResumeLayout(false);
            this.gbConsultaProducto.PerformLayout();
            this.gBConsultarInventario.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInventario;
        private System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.GroupBox gbProducto;
        private System.Windows.Forms.ToolStrip tsMenuInventario;
        private System.Windows.Forms.ToolStripButton tsbtnCorteRealizar;
        private System.Windows.Forms.GroupBox gbConsultaProducto;
        private System.Windows.Forms.ComboBox cbCriterio;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox gBConsultarInventario;
        private System.Windows.Forms.DateTimePicker dtFecha2;
        private System.Windows.Forms.DateTimePicker dtFecha1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cbCriterioCategoria;
        private System.Windows.Forms.ComboBox cbConsultaInventario;
        private System.Windows.Forms.Button btnBuscaInventario;
        private System.Windows.Forms.StatusStrip statusGridProducto;
        private System.Windows.Forms.ToolStripDropDownButton btnInicioRowProducto;
        private System.Windows.Forms.ToolStripDropDownButton btnAnteriorRowProducto;
        private System.Windows.Forms.ToolStripStatusLabel statusPaginaProducto;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguienteRowProducto;
        private System.Windows.Forms.ToolStripDropDownButton btnFinRowProducto;
        private System.Windows.Forms.ComboBox cbCriterioConsulta;
        private System.Windows.Forms.StatusStrip statusGridInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnInicioRowInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnAnteriorRowInventario;
        private System.Windows.Forms.ToolStripStatusLabel statusPaginaInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguienteRowInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnFinRowInventario;
        private System.Windows.Forms.ToolStripButton tsbtnCudrarInventario;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblFechaActual;
        private System.Windows.Forms.ToolStripButton tsBtnCorteGeneral;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        private System.Windows.Forms.ToolStripButton tsBtnResultado;
        private System.Windows.Forms.ToolStripButton tsBtnHistorial;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsBtnActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnEditarCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Inventario;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fisico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Diferencia;
    }
}