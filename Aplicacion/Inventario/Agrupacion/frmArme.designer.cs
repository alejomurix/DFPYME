namespace Aplicacion.Inventario.Arme
{
    partial class frmArme
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

        private System.ComponentModel.ComponentResourceManager miResources =
           new System.ComponentModel.ComponentResourceManager(typeof(frmArme));

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmArme));
            this.tsmenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbArticuloAAgrupar = new System.Windows.Forms.GroupBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnConsultarCodigo = new System.Windows.Forms.Button();
            this.btnTallaColorAgrupar = new System.Windows.Forms.Button();
            this.pArticulo = new System.Windows.Forms.Panel();
            this.lblArticuloCon = new System.Windows.Forms.Label();
            this.lblCantidadInventario = new System.Windows.Forms.Label();
            this.txtCantidadInventario = new System.Windows.Forms.TextBox();
            this.lblCantidadAgrupar = new System.Windows.Forms.Label();
            this.txtCantidadAgrupar = new System.Windows.Forms.TextBox();
            this.btnEditarCantidadAgrupar = new System.Windows.Forms.Button();
            this.gbProductoDesagrupado = new System.Windows.Forms.GroupBox();
            this.lblarticuloDesagrupado = new System.Windows.Forms.Label();
            this.txtCodigoDesagrupar = new System.Windows.Forms.TextBox();
            this.btnConsultarCodigoDesagrupar = new System.Windows.Forms.Button();
            this.btnTallaColorDesagrupar = new System.Windows.Forms.Button();
            this.pArticuloDesagrupado = new System.Windows.Forms.Panel();
            this.lblArticuloDesagrupar = new System.Windows.Forms.Label();
            this.lblCantidadInventarioDesagrupado = new System.Windows.Forms.Label();
            this.txtCantidadInventarioDesagrupada = new System.Windows.Forms.TextBox();
            this.lblCantidadADesagrupar = new System.Windows.Forms.Label();
            this.txtCantidadDesagrupar = new System.Windows.Forms.TextBox();
            this.btnAgregarArticulo = new System.Windows.Forms.Button();
            this.gbxListadoArticulos = new System.Windows.Forms.GroupBox();
            this.dgvListadoArticulos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Medida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelMenuGrid = new System.Windows.Forms.Panel();
            this.tsMenuGrid = new System.Windows.Forms.ToolStrip();
            this.tsVerMedida = new System.Windows.Forms.ToolStripButton();
            this.tsVerColor = new System.Windows.Forms.ToolStripButton();
            this.tsSeparador = new System.Windows.Forms.ToolStripSeparator();
            this.tsEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsmenu.SuspendLayout();
            this.gbArticuloAAgrupar.SuspendLayout();
            this.pArticulo.SuspendLayout();
            this.gbProductoDesagrupado.SuspendLayout();
            this.pArticuloDesagrupado.SuspendLayout();
            this.gbxListadoArticulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArticulos)).BeginInit();
            this.panelMenuGrid.SuspendLayout();
            this.tsMenuGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsmenu
            // 
            this.tsmenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardar,
            this.tsbtnSalir});
            this.tsmenu.Location = new System.Drawing.Point(0, 0);
            this.tsmenu.Name = "tsmenu";
            this.tsmenu.Size = new System.Drawing.Size(725, 25);
            this.tsmenu.TabIndex = 0;
            this.tsmenu.Text = "toolStrip1";
            // 
            // tsbtnGuardar
            // 
            this.tsbtnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardar.Image")));
            this.tsbtnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardar.Name = "tsbtnGuardar";
            this.tsbtnGuardar.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardar.Text = "Guardar";
            this.tsbtnGuardar.Click += new System.EventHandler(this.tsbtnGuardar_Click);
            // 
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsbtnSalir.Text = "Salir";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // gbArticuloAAgrupar
            // 
            this.gbArticuloAAgrupar.Controls.Add(this.lblArticulo);
            this.gbArticuloAAgrupar.Controls.Add(this.txtCodigo);
            this.gbArticuloAAgrupar.Controls.Add(this.btnConsultarCodigo);
            this.gbArticuloAAgrupar.Controls.Add(this.btnTallaColorAgrupar);
            this.gbArticuloAAgrupar.Controls.Add(this.pArticulo);
            this.gbArticuloAAgrupar.Controls.Add(this.lblCantidadInventario);
            this.gbArticuloAAgrupar.Controls.Add(this.txtCantidadInventario);
            this.gbArticuloAAgrupar.Controls.Add(this.lblCantidadAgrupar);
            this.gbArticuloAAgrupar.Controls.Add(this.txtCantidadAgrupar);
            this.gbArticuloAAgrupar.Controls.Add(this.btnEditarCantidadAgrupar);
            this.gbArticuloAAgrupar.Location = new System.Drawing.Point(13, 29);
            this.gbArticuloAAgrupar.Margin = new System.Windows.Forms.Padding(4);
            this.gbArticuloAAgrupar.Name = "gbArticuloAAgrupar";
            this.gbArticuloAAgrupar.Padding = new System.Windows.Forms.Padding(4);
            this.gbArticuloAAgrupar.Size = new System.Drawing.Size(704, 120);
            this.gbArticuloAAgrupar.TabIndex = 1;
            this.gbArticuloAAgrupar.TabStop = false;
            this.gbArticuloAAgrupar.Text = "Producto a agrupar";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(8, 51);
            this.lblArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(52, 16);
            this.lblArticulo.TabIndex = 7;
            this.lblArticulo.Text = "Articulo";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(63, 48);
            this.txtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigo.MaxLength = 20;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(240, 22);
            this.txtCodigo.TabIndex = 0;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            this.txtCodigo.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigo_Validating);
            // 
            // btnConsultarCodigo
            // 
            this.btnConsultarCodigo.Location = new System.Drawing.Point(316, 48);
            this.btnConsultarCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarCodigo.Name = "btnConsultarCodigo";
            this.btnConsultarCodigo.Size = new System.Drawing.Size(25, 22);
            this.btnConsultarCodigo.TabIndex = 1;
            this.btnConsultarCodigo.Text = "... ";
            this.btnConsultarCodigo.UseVisualStyleBackColor = true;
            this.btnConsultarCodigo.Click += new System.EventHandler(this.btnConsultarCodigo_Click);
            // 
            // btnTallaColorAgrupar
            // 
            this.btnTallaColorAgrupar.Enabled = false;
            this.btnTallaColorAgrupar.FlatAppearance.BorderSize = 0;
            this.btnTallaColorAgrupar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaColorAgrupar.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaColorAgrupar.Image")));
            this.btnTallaColorAgrupar.Location = new System.Drawing.Point(345, 47);
            this.btnTallaColorAgrupar.Name = "btnTallaColorAgrupar";
            this.btnTallaColorAgrupar.Size = new System.Drawing.Size(25, 25);
            this.btnTallaColorAgrupar.TabIndex = 2;
            this.btnTallaColorAgrupar.UseVisualStyleBackColor = true;
            this.btnTallaColorAgrupar.Click += new System.EventHandler(this.btnDesagruparTallaColor_Click);
            // 
            // pArticulo
            // 
            this.pArticulo.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pArticulo.Controls.Add(this.lblArticuloCon);
            this.pArticulo.Location = new System.Drawing.Point(11, 81);
            this.pArticulo.Margin = new System.Windows.Forms.Padding(4);
            this.pArticulo.Name = "pArticulo";
            this.pArticulo.Size = new System.Drawing.Size(359, 22);
            this.pArticulo.TabIndex = 6;
            // 
            // lblArticuloCon
            // 
            this.lblArticuloCon.AutoSize = true;
            this.lblArticuloCon.Location = new System.Drawing.Point(8, 3);
            this.lblArticuloCon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArticuloCon.Name = "lblArticuloCon";
            this.lblArticuloCon.Size = new System.Drawing.Size(0, 16);
            this.lblArticuloCon.TabIndex = 0;
            // 
            // lblCantidadInventario
            // 
            this.lblCantidadInventario.AutoSize = true;
            this.lblCantidadInventario.Location = new System.Drawing.Point(376, 25);
            this.lblCantidadInventario.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadInventario.Name = "lblCantidadInventario";
            this.lblCantidadInventario.Size = new System.Drawing.Size(123, 16);
            this.lblCantidadInventario.TabIndex = 8;
            this.lblCantidadInventario.Text = "Cantidad Inventario";
            // 
            // txtCantidadInventario
            // 
            this.txtCantidadInventario.Enabled = false;
            this.txtCantidadInventario.Location = new System.Drawing.Point(379, 48);
            this.txtCantidadInventario.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidadInventario.Name = "txtCantidadInventario";
            this.txtCantidadInventario.Size = new System.Drawing.Size(120, 22);
            this.txtCantidadInventario.TabIndex = 3;
            // 
            // lblCantidadAgrupar
            // 
            this.lblCantidadAgrupar.AutoSize = true;
            this.lblCantidadAgrupar.Location = new System.Drawing.Point(507, 25);
            this.lblCantidadAgrupar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadAgrupar.Name = "lblCantidadAgrupar";
            this.lblCantidadAgrupar.Size = new System.Drawing.Size(123, 16);
            this.lblCantidadAgrupar.TabIndex = 9;
            this.lblCantidadAgrupar.Text = "Cantidad a agrupar";
            // 
            // txtCantidadAgrupar
            // 
            this.txtCantidadAgrupar.Location = new System.Drawing.Point(505, 48);
            this.txtCantidadAgrupar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidadAgrupar.MaxLength = 20;
            this.txtCantidadAgrupar.Name = "txtCantidadAgrupar";
            this.txtCantidadAgrupar.Size = new System.Drawing.Size(144, 22);
            this.txtCantidadAgrupar.TabIndex = 4;
            this.txtCantidadAgrupar.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidadAgrupar_Validating);
            // 
            // btnEditarCantidadAgrupar
            // 
            this.btnEditarCantidadAgrupar.Enabled = false;
            this.btnEditarCantidadAgrupar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarCantidadAgrupar.Image")));
            this.btnEditarCantidadAgrupar.Location = new System.Drawing.Point(665, 47);
            this.btnEditarCantidadAgrupar.Name = "btnEditarCantidadAgrupar";
            this.btnEditarCantidadAgrupar.Size = new System.Drawing.Size(26, 23);
            this.btnEditarCantidadAgrupar.TabIndex = 5;
            this.btnEditarCantidadAgrupar.UseVisualStyleBackColor = true;
            this.btnEditarCantidadAgrupar.Click += new System.EventHandler(this.btnEditarCantidadAgrupar_Click);
            // 
            // gbProductoDesagrupado
            // 
            this.gbProductoDesagrupado.Controls.Add(this.lblarticuloDesagrupado);
            this.gbProductoDesagrupado.Controls.Add(this.txtCodigoDesagrupar);
            this.gbProductoDesagrupado.Controls.Add(this.btnConsultarCodigoDesagrupar);
            this.gbProductoDesagrupado.Controls.Add(this.btnTallaColorDesagrupar);
            this.gbProductoDesagrupado.Controls.Add(this.pArticuloDesagrupado);
            this.gbProductoDesagrupado.Controls.Add(this.lblCantidadInventarioDesagrupado);
            this.gbProductoDesagrupado.Controls.Add(this.txtCantidadInventarioDesagrupada);
            this.gbProductoDesagrupado.Controls.Add(this.lblCantidadADesagrupar);
            this.gbProductoDesagrupado.Controls.Add(this.txtCantidadDesagrupar);
            this.gbProductoDesagrupado.Controls.Add(this.btnAgregarArticulo);
            this.gbProductoDesagrupado.Location = new System.Drawing.Point(13, 156);
            this.gbProductoDesagrupado.Margin = new System.Windows.Forms.Padding(4);
            this.gbProductoDesagrupado.Name = "gbProductoDesagrupado";
            this.gbProductoDesagrupado.Padding = new System.Windows.Forms.Padding(4);
            this.gbProductoDesagrupado.Size = new System.Drawing.Size(704, 116);
            this.gbProductoDesagrupado.TabIndex = 2;
            this.gbProductoDesagrupado.TabStop = false;
            this.gbProductoDesagrupado.Text = "Producto desagrupado";
            // 
            // lblarticuloDesagrupado
            // 
            this.lblarticuloDesagrupado.AutoSize = true;
            this.lblarticuloDesagrupado.Location = new System.Drawing.Point(5, 53);
            this.lblarticuloDesagrupado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblarticuloDesagrupado.Name = "lblarticuloDesagrupado";
            this.lblarticuloDesagrupado.Size = new System.Drawing.Size(52, 16);
            this.lblarticuloDesagrupado.TabIndex = 2;
            this.lblarticuloDesagrupado.Text = "Articulo";
            // 
            // txtCodigoDesagrupar
            // 
            this.txtCodigoDesagrupar.Location = new System.Drawing.Point(63, 50);
            this.txtCodigoDesagrupar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoDesagrupar.MaxLength = 20;
            this.txtCodigoDesagrupar.Name = "txtCodigoDesagrupar";
            this.txtCodigoDesagrupar.Size = new System.Drawing.Size(240, 22);
            this.txtCodigoDesagrupar.TabIndex = 0;
            this.txtCodigoDesagrupar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigoDesagrupar_KeyPress);
            this.txtCodigoDesagrupar.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoDesagrupar_Validating);
            // 
            // btnConsultarCodigoDesagrupar
            // 
            this.btnConsultarCodigoDesagrupar.Location = new System.Drawing.Point(316, 49);
            this.btnConsultarCodigoDesagrupar.Margin = new System.Windows.Forms.Padding(4);
            this.btnConsultarCodigoDesagrupar.Name = "btnConsultarCodigoDesagrupar";
            this.btnConsultarCodigoDesagrupar.Size = new System.Drawing.Size(25, 22);
            this.btnConsultarCodigoDesagrupar.TabIndex = 6;
            this.btnConsultarCodigoDesagrupar.Text = "...";
            this.btnConsultarCodigoDesagrupar.UseVisualStyleBackColor = true;
            this.btnConsultarCodigoDesagrupar.Click += new System.EventHandler(this.btnConsultarCodigoDesagrupar_Click);
            // 
            // btnTallaColorDesagrupar
            // 
            this.btnTallaColorDesagrupar.Enabled = false;
            this.btnTallaColorDesagrupar.FlatAppearance.BorderSize = 0;
            this.btnTallaColorDesagrupar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTallaColorDesagrupar.Image = ((System.Drawing.Image)(resources.GetObject("btnTallaColorDesagrupar.Image")));
            this.btnTallaColorDesagrupar.Location = new System.Drawing.Point(345, 47);
            this.btnTallaColorDesagrupar.Name = "btnTallaColorDesagrupar";
            this.btnTallaColorDesagrupar.Size = new System.Drawing.Size(25, 25);
            this.btnTallaColorDesagrupar.TabIndex = 7;
            this.btnTallaColorDesagrupar.UseVisualStyleBackColor = true;
            this.btnTallaColorDesagrupar.Click += new System.EventHandler(this.btnTallaColorDesagrupar_Click);
            // 
            // pArticuloDesagrupado
            // 
            this.pArticuloDesagrupado.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pArticuloDesagrupado.Controls.Add(this.lblArticuloDesagrupar);
            this.pArticuloDesagrupado.Location = new System.Drawing.Point(8, 79);
            this.pArticuloDesagrupado.Margin = new System.Windows.Forms.Padding(4);
            this.pArticuloDesagrupado.Name = "pArticuloDesagrupado";
            this.pArticuloDesagrupado.Size = new System.Drawing.Size(362, 22);
            this.pArticuloDesagrupado.TabIndex = 8;
            // 
            // lblArticuloDesagrupar
            // 
            this.lblArticuloDesagrupar.AutoSize = true;
            this.lblArticuloDesagrupar.Location = new System.Drawing.Point(8, 3);
            this.lblArticuloDesagrupar.Name = "lblArticuloDesagrupar";
            this.lblArticuloDesagrupar.Size = new System.Drawing.Size(0, 16);
            this.lblArticuloDesagrupar.TabIndex = 0;
            // 
            // lblCantidadInventarioDesagrupado
            // 
            this.lblCantidadInventarioDesagrupado.AutoSize = true;
            this.lblCantidadInventarioDesagrupado.Location = new System.Drawing.Point(376, 30);
            this.lblCantidadInventarioDesagrupado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadInventarioDesagrupado.Name = "lblCantidadInventarioDesagrupado";
            this.lblCantidadInventarioDesagrupado.Size = new System.Drawing.Size(123, 16);
            this.lblCantidadInventarioDesagrupado.TabIndex = 3;
            this.lblCantidadInventarioDesagrupado.Text = "Cantidad Invantario";
            // 
            // txtCantidadInventarioDesagrupada
            // 
            this.txtCantidadInventarioDesagrupada.Enabled = false;
            this.txtCantidadInventarioDesagrupada.Location = new System.Drawing.Point(379, 50);
            this.txtCantidadInventarioDesagrupada.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidadInventarioDesagrupada.Name = "txtCantidadInventarioDesagrupada";
            this.txtCantidadInventarioDesagrupada.Size = new System.Drawing.Size(120, 22);
            this.txtCantidadInventarioDesagrupada.TabIndex = 1;
            // 
            // lblCantidadADesagrupar
            // 
            this.lblCantidadADesagrupar.AutoSize = true;
            this.lblCantidadADesagrupar.Location = new System.Drawing.Point(507, 30);
            this.lblCantidadADesagrupar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidadADesagrupar.Name = "lblCantidadADesagrupar";
            this.lblCantidadADesagrupar.Size = new System.Drawing.Size(123, 16);
            this.lblCantidadADesagrupar.TabIndex = 4;
            this.lblCantidadADesagrupar.Text = "Cantidad a agrupar";
            // 
            // txtCantidadDesagrupar
            // 
            this.txtCantidadDesagrupar.Location = new System.Drawing.Point(505, 50);
            this.txtCantidadDesagrupar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidadDesagrupar.MaxLength = 20;
            this.txtCantidadDesagrupar.Name = "txtCantidadDesagrupar";
            this.txtCantidadDesagrupar.Size = new System.Drawing.Size(144, 22);
            this.txtCantidadDesagrupar.TabIndex = 1;
            this.txtCantidadDesagrupar.Validating += new System.ComponentModel.CancelEventHandler(this.txtCantidadDesagrupar_Validating);
            // 
            // btnAgregarArticulo
            // 
            this.btnAgregarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarArticulo.Image")));
            this.btnAgregarArticulo.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnAgregarArticulo.Location = new System.Drawing.Point(505, 82);
            this.btnAgregarArticulo.Name = "btnAgregarArticulo";
            this.btnAgregarArticulo.Size = new System.Drawing.Size(144, 24);
            this.btnAgregarArticulo.TabIndex = 5;
            this.btnAgregarArticulo.Text = " Agregar";
            this.btnAgregarArticulo.UseVisualStyleBackColor = true;
            this.btnAgregarArticulo.Click += new System.EventHandler(this.btnAgregarArticulo_Click);
            // 
            // gbxListadoArticulos
            // 
            this.gbxListadoArticulos.Controls.Add(this.dgvListadoArticulos);
            this.gbxListadoArticulos.Controls.Add(this.panelMenuGrid);
            this.gbxListadoArticulos.Location = new System.Drawing.Point(13, 280);
            this.gbxListadoArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.gbxListadoArticulos.Name = "gbxListadoArticulos";
            this.gbxListadoArticulos.Padding = new System.Windows.Forms.Padding(4);
            this.gbxListadoArticulos.Size = new System.Drawing.Size(704, 229);
            this.gbxListadoArticulos.TabIndex = 3;
            this.gbxListadoArticulos.TabStop = false;
            this.gbxListadoArticulos.Text = "Listado de articulos";
            // 
            // dgvListadoArticulos
            // 
            this.dgvListadoArticulos.AllowUserToAddRows = false;
            this.dgvListadoArticulos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListadoArticulos.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListadoArticulos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListadoArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadoArticulos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Articulo,
            this.Cantidad,
            this.Medida,
            this.Color});
            this.dgvListadoArticulos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListadoArticulos.GridColor = System.Drawing.SystemColors.Window;
            this.dgvListadoArticulos.Location = new System.Drawing.Point(22, 23);
            this.dgvListadoArticulos.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListadoArticulos.Name = "dgvListadoArticulos";
            this.dgvListadoArticulos.Size = new System.Drawing.Size(627, 198);
            this.dgvListadoArticulos.TabIndex = 0;
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
            // 
            // Articulo
            // 
            this.Articulo.DataPropertyName = "Articulo";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Medida
            // 
            this.Medida.DataPropertyName = "Medida";
            this.Medida.HeaderText = "Medida";
            this.Medida.Name = "Medida";
            this.Medida.Resizable = System.Windows.Forms.DataGridViewTriState.True;
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
            // 
            // panelMenuGrid
            // 
            this.panelMenuGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelMenuGrid.Controls.Add(this.tsMenuGrid);
            this.panelMenuGrid.Location = new System.Drawing.Point(648, 23);
            this.panelMenuGrid.Name = "panelMenuGrid";
            this.panelMenuGrid.Size = new System.Drawing.Size(45, 198);
            this.panelMenuGrid.TabIndex = 2;
            // 
            // tsMenuGrid
            // 
            this.tsMenuGrid.Dock = System.Windows.Forms.DockStyle.Right;
            this.tsMenuGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsVerMedida,
            this.tsVerColor,
            this.tsSeparador,
            this.tsEliminar});
            this.tsMenuGrid.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.tsMenuGrid.Location = new System.Drawing.Point(14, 0);
            this.tsMenuGrid.Name = "tsMenuGrid";
            this.tsMenuGrid.Size = new System.Drawing.Size(29, 196);
            this.tsMenuGrid.TabIndex = 0;
            this.tsMenuGrid.Text = "Menu de Registro";
            // 
            // tsVerMedida
            // 
            this.tsVerMedida.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsVerMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsVerMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsVerMedida.Image")));
            this.tsVerMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsVerMedida.Margin = new System.Windows.Forms.Padding(0, 1, 5, 2);
            this.tsVerMedida.Name = "tsVerMedida";
            this.tsVerMedida.Size = new System.Drawing.Size(21, 20);
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
            this.tsVerColor.Size = new System.Drawing.Size(21, 20);
            this.tsVerColor.Text = "Mostrar Color";
            this.tsVerColor.Click += new System.EventHandler(this.tsVerColor_Click);
            // 
            // tsSeparador
            // 
            this.tsSeparador.Margin = new System.Windows.Forms.Padding(0, 0, 5, 0);
            this.tsSeparador.Name = "tsSeparador";
            this.tsSeparador.Size = new System.Drawing.Size(21, 6);
            // 
            // tsEliminar
            // 
            this.tsEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsEliminar.Image")));
            this.tsEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsEliminar.Margin = new System.Windows.Forms.Padding(1, 1, 0, 2);
            this.tsEliminar.Name = "tsEliminar";
            this.tsEliminar.Size = new System.Drawing.Size(25, 20);
            this.tsEliminar.Text = "Eliminar Registro";
            this.tsEliminar.Click += new System.EventHandler(this.tsEliminar_Click_1);
            // 
            // frmArme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(725, 514);
            this.Controls.Add(this.tsmenu);
            this.Controls.Add(this.gbArticuloAAgrupar);
            this.Controls.Add(this.gbProductoDesagrupado);
            this.Controls.Add(this.gbxListadoArticulos);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmArme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmArme_Load);
            this.tsmenu.ResumeLayout(false);
            this.tsmenu.PerformLayout();
            this.gbArticuloAAgrupar.ResumeLayout(false);
            this.gbArticuloAAgrupar.PerformLayout();
            this.pArticulo.ResumeLayout(false);
            this.pArticulo.PerformLayout();
            this.gbProductoDesagrupado.ResumeLayout(false);
            this.gbProductoDesagrupado.PerformLayout();
            this.pArticuloDesagrupado.ResumeLayout(false);
            this.pArticuloDesagrupado.PerformLayout();
            this.gbxListadoArticulos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadoArticulos)).EndInit();
            this.panelMenuGrid.ResumeLayout(false);
            this.panelMenuGrid.PerformLayout();
            this.tsMenuGrid.ResumeLayout(false);
            this.tsMenuGrid.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsmenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.GroupBox gbArticuloAAgrupar;
        private System.Windows.Forms.Label lblCantidadAgrupar;
        private System.Windows.Forms.Label lblCantidadInventario;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.Button btnConsultarCodigo;
        private System.Windows.Forms.TextBox txtCantidadAgrupar;
        private System.Windows.Forms.TextBox txtCantidadInventario;
        private System.Windows.Forms.Panel pArticulo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.GroupBox gbProductoDesagrupado;
        private System.Windows.Forms.Label lblCantidadADesagrupar;
        private System.Windows.Forms.Label lblCantidadInventarioDesagrupado;
        private System.Windows.Forms.Label lblarticuloDesagrupado;
        private System.Windows.Forms.Button btnConsultarCodigoDesagrupar;
        private System.Windows.Forms.TextBox txtCantidadDesagrupar;
        private System.Windows.Forms.TextBox txtCantidadInventarioDesagrupada;
        private System.Windows.Forms.Panel pArticuloDesagrupado;
        private System.Windows.Forms.TextBox txtCodigoDesagrupar;
        private System.Windows.Forms.GroupBox gbxListadoArticulos;
        private System.Windows.Forms.DataGridView dgvListadoArticulos;
        private System.Windows.Forms.Label lblArticuloCon;
        private System.Windows.Forms.Label lblArticuloDesagrupar;
        private System.Windows.Forms.Button btnAgregarArticulo;
        private System.Windows.Forms.Button btnTallaColorDesagrupar;
        private System.Windows.Forms.Button btnTallaColorAgrupar;
        private System.Windows.Forms.Button btnEditarCantidadAgrupar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Medida;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.Panel panelMenuGrid;
        private System.Windows.Forms.ToolStrip tsMenuGrid;
        private System.Windows.Forms.ToolStripButton tsVerMedida;
        private System.Windows.Forms.ToolStripButton tsVerColor;
        private System.Windows.Forms.ToolStripSeparator tsSeparador;
        private System.Windows.Forms.ToolStripButton tsEliminar;
    }
}