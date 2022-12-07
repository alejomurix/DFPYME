namespace Aplicacion.Inventario.Consulta
{
    partial class FrmConsultaInventario
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
            new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaInventario));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaInventario));
            this.dgvInventario = new System.Windows.Forms.DataGridView();
            this.CodigoCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Venta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PMayor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PDistribuidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestoMayor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DestoDistri = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DesctoPrecio4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbConsultas = new System.Windows.Forms.GroupBox();
            this.cbCriterio = new System.Windows.Forms.ComboBox();
            this.txtCodigoNombre = new System.Windows.Forms.TextBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cbCriterio1 = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbResultado = new System.Windows.Forms.GroupBox();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsVerCosto = new System.Windows.Forms.ToolStripButton();
            this.tsVerPrecioDistri = new System.Windows.Forms.ToolStripButton();
            this.StatusInventario = new System.Windows.Forms.StatusStrip();
            this.btnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.lblStatusInventario = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnFin = new System.Windows.Forms.ToolStripDropDownButton();
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
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            this.StatusInventario.SuspendLayout();
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
            this.Unidad,
            this.Medida,
            this.Color,
            this.Cantidad,
            this.Valor,
            this.Venta,
            this.PMayor,
            this.PDistribuidor,
            this.Precio4,
            this.DestoMayor,
            this.DestoDistri,
            this.DesctoPrecio4});
            this.dgvInventario.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvInventario.Location = new System.Drawing.Point(6, 39);
            this.dgvInventario.Name = "dgvInventario";
            this.dgvInventario.RowHeadersVisible = false;
            this.dgvInventario.Size = new System.Drawing.Size(1160, 366);
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
            this.Categoria.DataPropertyName = "Marca";
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.Width = 160;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 80;
            // 
            // Producto
            // 
            this.Producto.DataPropertyName = "Nombre";
            this.Producto.HeaderText = "Producto";
            this.Producto.Name = "Producto";
            this.Producto.Width = 325;
            // 
            // Unidad
            // 
            this.Unidad.DataPropertyName = "Unidad";
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.Name = "Unidad";
            this.Unidad.Visible = false;
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Visible = false;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "Color";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Color.Visible = false;
            this.Color.Width = 70;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Inventario";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Cantidad.DefaultCellStyle = dataGridViewCellStyle1;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 85;
            // 
            // Valor
            // 
            this.Valor.DataPropertyName = "Valor";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.Valor.DefaultCellStyle = dataGridViewCellStyle2;
            this.Valor.HeaderText = "Costo";
            this.Valor.Name = "Valor";
            // 
            // Venta
            // 
            this.Venta.DataPropertyName = "venta";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.Venta.DefaultCellStyle = dataGridViewCellStyle3;
            this.Venta.HeaderText = "Venta (1)";
            this.Venta.Name = "Venta";
            // 
            // PMayor
            // 
            this.PMayor.DataPropertyName = "mayorista";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.PMayor.DefaultCellStyle = dataGridViewCellStyle4;
            this.PMayor.HeaderText = "P. mayor(2)";
            this.PMayor.Name = "PMayor";
            // 
            // PDistribuidor
            // 
            this.PDistribuidor.DataPropertyName = "distribuidor";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.PDistribuidor.DefaultCellStyle = dataGridViewCellStyle5;
            this.PDistribuidor.HeaderText = "P. Distr. (3)";
            this.PDistribuidor.Name = "PDistribuidor";
            // 
            // Precio4
            // 
            this.Precio4.DataPropertyName = "Precio4";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            dataGridViewCellStyle6.NullValue = null;
            this.Precio4.DefaultCellStyle = dataGridViewCellStyle6;
            this.Precio4.HeaderText = "Precio 4";
            this.Precio4.Name = "Precio4";
            // 
            // DestoMayor
            // 
            this.DestoMayor.DataPropertyName = "DestoMayor";
            this.DestoMayor.HeaderText = "DestoMayor";
            this.DestoMayor.Name = "DestoMayor";
            this.DestoMayor.Visible = false;
            // 
            // DestoDistri
            // 
            this.DestoDistri.DataPropertyName = "DestoDistri";
            this.DestoDistri.HeaderText = "DestoDistri";
            this.DestoDistri.Name = "DestoDistri";
            this.DestoDistri.Visible = false;
            // 
            // DesctoPrecio4
            // 
            this.DesctoPrecio4.DataPropertyName = "Desto3";
            this.DesctoPrecio4.HeaderText = "DesctoPrecio4";
            this.DesctoPrecio4.Name = "DesctoPrecio4";
            this.DesctoPrecio4.Visible = false;
            // 
            // gbConsultas
            // 
            this.gbConsultas.Controls.Add(this.cbCriterio);
            this.gbConsultas.Controls.Add(this.txtCodigoNombre);
            this.gbConsultas.Controls.Add(this.btnConsultar);
            this.gbConsultas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbConsultas.Location = new System.Drawing.Point(12, 28);
            this.gbConsultas.Name = "gbConsultas";
            this.gbConsultas.Size = new System.Drawing.Size(571, 71);
            this.gbConsultas.TabIndex = 0;
            this.gbConsultas.TabStop = false;
            this.gbConsultas.Text = "Consultas";
            // 
            // cbCriterio
            // 
            this.cbCriterio.DisplayMember = "Nombre";
            this.cbCriterio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio.FormattingEnabled = true;
            this.cbCriterio.Location = new System.Drawing.Point(6, 31);
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
            this.txtCodigoNombre.Location = new System.Drawing.Point(133, 32);
            this.txtCodigoNombre.Name = "txtCodigoNombre";
            this.txtCodigoNombre.Size = new System.Drawing.Size(395, 22);
            this.txtCodigoNombre.TabIndex = 0;
            this.txtCodigoNombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoNombre_KeyPress);
            // 
            // btnConsultar
            // 
            this.btnConsultar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnConsultar.BackgroundImage")));
            this.btnConsultar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConsultar.Location = new System.Drawing.Point(534, 31);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(24, 24);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cbCriterio1
            // 
            this.cbCriterio1.DisplayMember = "Nombre";
            this.cbCriterio1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCriterio1.FormattingEnabled = true;
            this.cbCriterio1.Location = new System.Drawing.Point(598, 59);
            this.cbCriterio1.Name = "cbCriterio1";
            this.cbCriterio1.Size = new System.Drawing.Size(134, 21);
            this.cbCriterio1.TabIndex = 4;
            this.cbCriterio1.ValueMember = "Id";
            this.cbCriterio1.Visible = false;
            this.cbCriterio1.SelectedIndexChanged += new System.EventHandler(this.cbCriterio1_SelectedIndexChanged);
            this.cbCriterio1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbCriterio1_KeyPress);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(757, 61);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(27, 23);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "...";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Visible = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbResultado
            // 
            this.gbResultado.Controls.Add(this.panelMenuGrid);
            this.gbResultado.Controls.Add(this.dgvInventario);
            this.gbResultado.Controls.Add(this.StatusInventario);
            this.gbResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbResultado.Location = new System.Drawing.Point(12, 105);
            this.gbResultado.Name = "gbResultado";
            this.gbResultado.Size = new System.Drawing.Size(1171, 433);
            this.gbResultado.TabIndex = 1;
            this.gbResultado.TabStop = false;
            this.gbResultado.Text = "Resultado de la Consulta";
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(1074, 9);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(91, 30);
            this.panelMenuGrid.TabIndex = 2;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerCosto,
            this.tsVerPrecioDistri});
            this.tsMenuGrid.Location = new System.Drawing.Point(0, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(89, 25);
            this.tsMenuGrid.TabIndex = 0;
            this.tsMenuGrid.Text = "Menu de Registro";
            // 
            // tsVerCosto
            // 
            this.tsVerCosto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVerCosto.Enabled = false;
            this.tsVerCosto.Image = ((System.Drawing.Image)(resources.GetObject("tsVerCosto.Image")));
            this.tsVerCosto.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerCosto.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsVerCosto.Name = "tsVerCosto";
            this.tsVerCosto.Size = new System.Drawing.Size(23, 22);
            this.tsVerCosto.Text = "Mostrar Costo";
            this.tsVerCosto.Click += new System.EventHandler(this.tsVerCosto_Click);
            // 
            // tsVerPrecioDistri
            // 
            this.tsVerPrecioDistri.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVerPrecioDistri.Image = ((System.Drawing.Image)(resources.GetObject("tsVerPrecioDistri.Image")));
            this.tsVerPrecioDistri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerPrecioDistri.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsVerPrecioDistri.Name = "tsVerPrecioDistri";
            this.tsVerPrecioDistri.Size = new System.Drawing.Size(23, 22);
            this.tsVerPrecioDistri.Text = "Mostrar P. Distribuidor";
            this.tsVerPrecioDistri.Visible = false;
            this.tsVerPrecioDistri.Click += new System.EventHandler(this.tsVerPrecioDistri_Click);
            // 
            // StatusInventario
            // 
            this.StatusInventario.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusInventario.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnInicio,
            this.btnAnterior,
            this.lblStatusInventario,
            this.btnSiguiente,
            this.btnFin});
            this.StatusInventario.Location = new System.Drawing.Point(3, 408);
            this.StatusInventario.Name = "StatusInventario";
            this.StatusInventario.Size = new System.Drawing.Size(1165, 22);
            this.StatusInventario.TabIndex = 1;
            this.StatusInventario.Text = "Status de Factura";
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
            this.btnAnterior.Size = new System.Drawing.Size(42, 20);
            this.btnAnterior.Text = " (-)";
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // lblStatusInventario
            // 
            this.lblStatusInventario.Name = "lblStatusInventario";
            this.lblStatusInventario.Size = new System.Drawing.Size(29, 17);
            this.lblStatusInventario.Text = "0 / 0";
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
            // FrmConsultaInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1193, 548);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.cbCriterio1);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.gbConsultas);
            this.Controls.Add(this.gbResultado);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaInventario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta de Inventario";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmConsultaInventario_FormClosing);
            this.Load += new System.EventHandler(this.FrmConsultaInventario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaInventario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInventario)).EndInit();
            this.gbConsultas.ResumeLayout(false);
            this.gbConsultas.PerformLayout();
            this.gbResultado.ResumeLayout(false);
            this.gbResultado.PerformLayout();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            this.StatusInventario.ResumeLayout(false);
            this.StatusInventario.PerformLayout();
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
        private System.Windows.Forms.ComboBox cbCriterio1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.StatusStrip StatusInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnInicio;
        private System.Windows.Forms.ToolStripDropDownButton btnAnterior;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInventario;
        private System.Windows.Forms.ToolStripDropDownButton btnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton btnFin;
        private System.Windows.Forms.ToolStripButton tsBtnSalir;
        public System.Windows.Forms.TextBox txtCodigoNombre;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
        public System.Windows.Forms.DataGridView dgvInventario;
        private System.Windows.Forms.ToolStripButton tsBtnNuevoArticulo;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsVerCosto;
        private System.Windows.Forms.ToolStripButton tsBtnImprimir;
        private System.Windows.Forms.ToolStripButton tsBtnSelecionaGrid;
        private System.Windows.Forms.ToolStripButton tsBtnCriterio;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionarCriterio;
        private System.Windows.Forms.ToolStripButton tsVerPrecioDistri;
        private System.Windows.Forms.ToolStripButton tsBtnImprimirConsulta;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Venta;
        private System.Windows.Forms.DataGridViewTextBoxColumn PMayor;
        private System.Windows.Forms.DataGridViewTextBoxColumn PDistribuidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio4;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestoMayor;
        private System.Windows.Forms.DataGridViewTextBoxColumn DestoDistri;
        private System.Windows.Forms.DataGridViewTextBoxColumn DesctoPrecio4;
    }
}