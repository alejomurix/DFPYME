namespace Aplicacion.Administracion.Promocion
{
    partial class frmdescuento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdescuento));
            this.tcInsertarPromocion = new System.Windows.Forms.TabControl();
            this.tpInsertar = new System.Windows.Forms.TabPage();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnGuardarPromocion = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminarRegistro = new System.Windows.Forms.ToolStripButton();
            this.tsbtnsalir = new System.Windows.Forms.ToolStripButton();
            this.gbxconfiguracionPromocion = new System.Windows.Forms.GroupBox();
            this.lblTipodePromocion = new System.Windows.Forms.Label();
            this.cbxTipodePromocion = new System.Windows.Forms.ComboBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblCategoriamarcaProducto = new System.Windows.Forms.Label();
            this.txtagregarMarcaCategoriaProducto = new System.Windows.Forms.TextBox();
            this.pinsertarMarcacategoriaProducto = new System.Windows.Forms.Panel();
            this.lblMarcaCategoriaProducto = new System.Windows.Forms.Label();
            this.btnBuscarMarcaCategoriaProducto = new System.Windows.Forms.Button();
            this.lblListaDescuento = new System.Windows.Forms.Label();
            this.lbxDescuento = new System.Windows.Forms.ListBox();
            this.lblAPromocionar = new System.Windows.Forms.Label();
            this.txtAPromocionar = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.gbxseleccionoCategoriaproductoMarca = new System.Windows.Forms.GroupBox();
            this.dgvPromocion = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaFin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpConsulta = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnsal = new System.Windows.Forms.ToolStripButton();
            this.gbxResultadoBusquda = new System.Windows.Forms.GroupBox();
            this.cbxTipo = new System.Windows.Forms.ComboBox();
            this.cbxListarTodo = new System.Windows.Forms.CheckBox();
            this.txtListarPromocionCategoriaPoductoMarca = new System.Windows.Forms.TextBox();
            this.pListar = new System.Windows.Forms.Panel();
            this.lblListarMarcaCategoriaProducto = new System.Windows.Forms.Label();
            this.btnBuscarListar = new System.Windows.Forms.Button();
            this.cbxCriterioFecha = new System.Windows.Forms.ComboBox();
            this.dtpfechaIni = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaFi = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gbxResultado = new System.Windows.Forms.GroupBox();
            this.dgvResultado = new System.Windows.Forms.DataGridView();
            this.idPromocion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cant = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.des = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaIni = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDescuento = new System.Windows.Forms.StatusStrip();
            this.tsbtnInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnAtras = new System.Windows.Forms.ToolStripDropDownButton();
            this.tslblConteo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbtnSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsbtnFinal = new System.Windows.Forms.ToolStripDropDownButton();
            this.tcInsertarPromocion.SuspendLayout();
            this.tpInsertar.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbxconfiguracionPromocion.SuspendLayout();
            this.pinsertarMarcacategoriaProducto.SuspendLayout();
            this.gbxseleccionoCategoriaproductoMarca.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromocion)).BeginInit();
            this.tpConsulta.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbxResultadoBusquda.SuspendLayout();
            this.pListar.SuspendLayout();
            this.gbxResultado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).BeginInit();
            this.statusDescuento.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcInsertarPromocion
            // 
            this.tcInsertarPromocion.Controls.Add(this.tpInsertar);
            this.tcInsertarPromocion.Controls.Add(this.tpConsulta);
            this.tcInsertarPromocion.Location = new System.Drawing.Point(7, 1);
            this.tcInsertarPromocion.Name = "tcInsertarPromocion";
            this.tcInsertarPromocion.SelectedIndex = 0;
            this.tcInsertarPromocion.Size = new System.Drawing.Size(782, 437);
            this.tcInsertarPromocion.TabIndex = 0;
            // 
            // tpInsertar
            // 
            this.tpInsertar.Controls.Add(this.tsMenu);
            this.tpInsertar.Controls.Add(this.gbxconfiguracionPromocion);
            this.tpInsertar.Controls.Add(this.gbxseleccionoCategoriaproductoMarca);
            this.tpInsertar.Location = new System.Drawing.Point(4, 25);
            this.tpInsertar.Name = "tpInsertar";
            this.tpInsertar.Padding = new System.Windows.Forms.Padding(3);
            this.tpInsertar.Size = new System.Drawing.Size(774, 408);
            this.tpInsertar.TabIndex = 0;
            this.tpInsertar.Text = "Promoción";
            this.tpInsertar.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnGuardarPromocion,
            this.tsbtnEliminarRegistro,
            this.tsbtnsalir});
            this.tsMenu.Location = new System.Drawing.Point(3, 3);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(768, 25);
            this.tsMenu.TabIndex = 2;
            this.tsMenu.Text = "toolStrip1";
            // 
            // tsbtnGuardarPromocion
            // 
            this.tsbtnGuardarPromocion.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarPromocion.Image")));
            this.tsbtnGuardarPromocion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarPromocion.Name = "tsbtnGuardarPromocion";
            this.tsbtnGuardarPromocion.Size = new System.Drawing.Size(69, 22);
            this.tsbtnGuardarPromocion.Text = "Guardar";
            this.tsbtnGuardarPromocion.Click += new System.EventHandler(this.tsbtnGuardarPromocion_Click);
            // 
            // tsbtnEliminarRegistro
            // 
            this.tsbtnEliminarRegistro.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminarRegistro.Image")));
            this.tsbtnEliminarRegistro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminarRegistro.Name = "tsbtnEliminarRegistro";
            this.tsbtnEliminarRegistro.Size = new System.Drawing.Size(113, 22);
            this.tsbtnEliminarRegistro.Text = "Eliminar registro";
            this.tsbtnEliminarRegistro.Click += new System.EventHandler(this.tsbtnEliminarRegistro_Click);
            // 
            // tsbtnsalir
            // 
            this.tsbtnsalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnsalir.Image")));
            this.tsbtnsalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnsalir.Name = "tsbtnsalir";
            this.tsbtnsalir.Size = new System.Drawing.Size(49, 22);
            this.tsbtnsalir.Text = "Salir";
            this.tsbtnsalir.Click += new System.EventHandler(this.tsbtnsalir_Click);
            // 
            // gbxconfiguracionPromocion
            // 
            this.gbxconfiguracionPromocion.Controls.Add(this.lblTipodePromocion);
            this.gbxconfiguracionPromocion.Controls.Add(this.cbxTipodePromocion);
            this.gbxconfiguracionPromocion.Controls.Add(this.lblFechaInicio);
            this.gbxconfiguracionPromocion.Controls.Add(this.dtpFechaInicio);
            this.gbxconfiguracionPromocion.Controls.Add(this.lblFechaFin);
            this.gbxconfiguracionPromocion.Controls.Add(this.dtpFechaFin);
            this.gbxconfiguracionPromocion.Controls.Add(this.lblCategoriamarcaProducto);
            this.gbxconfiguracionPromocion.Controls.Add(this.txtagregarMarcaCategoriaProducto);
            this.gbxconfiguracionPromocion.Controls.Add(this.pinsertarMarcacategoriaProducto);
            this.gbxconfiguracionPromocion.Controls.Add(this.btnBuscarMarcaCategoriaProducto);
            this.gbxconfiguracionPromocion.Controls.Add(this.lblListaDescuento);
            this.gbxconfiguracionPromocion.Controls.Add(this.lbxDescuento);
            this.gbxconfiguracionPromocion.Controls.Add(this.lblAPromocionar);
            this.gbxconfiguracionPromocion.Controls.Add(this.txtAPromocionar);
            this.gbxconfiguracionPromocion.Controls.Add(this.btnAgregar);
            this.gbxconfiguracionPromocion.Location = new System.Drawing.Point(6, 32);
            this.gbxconfiguracionPromocion.Name = "gbxconfiguracionPromocion";
            this.gbxconfiguracionPromocion.Size = new System.Drawing.Size(763, 175);
            this.gbxconfiguracionPromocion.TabIndex = 0;
            this.gbxconfiguracionPromocion.TabStop = false;
            this.gbxconfiguracionPromocion.Text = "Configuracion de promoción";
            // 
            // lblTipodePromocion
            // 
            this.lblTipodePromocion.AutoSize = true;
            this.lblTipodePromocion.Location = new System.Drawing.Point(8, 40);
            this.lblTipodePromocion.Name = "lblTipodePromocion";
            this.lblTipodePromocion.Size = new System.Drawing.Size(122, 16);
            this.lblTipodePromocion.TabIndex = 2;
            this.lblTipodePromocion.Text = "Tipo de promocion";
            // 
            // cbxTipodePromocion
            // 
            this.cbxTipodePromocion.DisplayMember = "nombretipo_sorteo";
            this.cbxTipodePromocion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipodePromocion.FormattingEnabled = true;
            this.cbxTipodePromocion.Location = new System.Drawing.Point(136, 35);
            this.cbxTipodePromocion.Name = "cbxTipodePromocion";
            this.cbxTipodePromocion.Size = new System.Drawing.Size(162, 24);
            this.cbxTipodePromocion.TabIndex = 3;
            this.cbxTipodePromocion.ValueMember = "idtipo_sorteo";
            this.cbxTipodePromocion.SelectionChangeCommitted += new System.EventHandler(this.cbxTipodePromocion_SelectionChangeCommitted);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(317, 40);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(99, 16);
            this.lblFechaInicio.TabIndex = 0;
            this.lblFechaInicio.Text = "Fecha de inicio";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(422, 35);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(104, 22);
            this.dtpFechaInicio.TabIndex = 4;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(551, 40);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(62, 16);
            this.lblFechaFin.TabIndex = 1;
            this.lblFechaFin.Text = "Fecha fin";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(619, 35);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(128, 22);
            this.dtpFechaFin.TabIndex = 5;
            this.dtpFechaFin.Validating += new System.ComponentModel.CancelEventHandler(this.dtpFechaFin_Validating);
            // 
            // lblCategoriamarcaProducto
            // 
            this.lblCategoriamarcaProducto.AutoSize = true;
            this.lblCategoriamarcaProducto.Location = new System.Drawing.Point(14, 72);
            this.lblCategoriamarcaProducto.Name = "lblCategoriamarcaProducto";
            this.lblCategoriamarcaProducto.Size = new System.Drawing.Size(0, 16);
            this.lblCategoriamarcaProducto.TabIndex = 13;
            // 
            // txtagregarMarcaCategoriaProducto
            // 
            this.txtagregarMarcaCategoriaProducto.Enabled = false;
            this.txtagregarMarcaCategoriaProducto.Location = new System.Drawing.Point(11, 99);
            this.txtagregarMarcaCategoriaProducto.MaxLength = 50;
            this.txtagregarMarcaCategoriaProducto.Name = "txtagregarMarcaCategoriaProducto";
            this.txtagregarMarcaCategoriaProducto.Size = new System.Drawing.Size(228, 22);
            this.txtagregarMarcaCategoriaProducto.TabIndex = 0;
            this.txtagregarMarcaCategoriaProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtagregarMarcaCategoriaProducto_KeyPress);
            this.txtagregarMarcaCategoriaProducto.Validating += new System.ComponentModel.CancelEventHandler(this.txtagregarMarcaCategoriaProducto_Validating);
            // 
            // pinsertarMarcacategoriaProducto
            // 
            this.pinsertarMarcacategoriaProducto.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pinsertarMarcacategoriaProducto.Controls.Add(this.lblMarcaCategoriaProducto);
            this.pinsertarMarcacategoriaProducto.Location = new System.Drawing.Point(11, 133);
            this.pinsertarMarcacategoriaProducto.Name = "pinsertarMarcacategoriaProducto";
            this.pinsertarMarcacategoriaProducto.Size = new System.Drawing.Size(289, 26);
            this.pinsertarMarcacategoriaProducto.TabIndex = 11;
            // 
            // lblMarcaCategoriaProducto
            // 
            this.lblMarcaCategoriaProducto.AutoSize = true;
            this.lblMarcaCategoriaProducto.Location = new System.Drawing.Point(3, 5);
            this.lblMarcaCategoriaProducto.Name = "lblMarcaCategoriaProducto";
            this.lblMarcaCategoriaProducto.Size = new System.Drawing.Size(0, 16);
            this.lblMarcaCategoriaProducto.TabIndex = 0;
            // 
            // btnBuscarMarcaCategoriaProducto
            // 
            this.btnBuscarMarcaCategoriaProducto.Location = new System.Drawing.Point(266, 98);
            this.btnBuscarMarcaCategoriaProducto.Name = "btnBuscarMarcaCategoriaProducto";
            this.btnBuscarMarcaCategoriaProducto.Size = new System.Drawing.Size(32, 23);
            this.btnBuscarMarcaCategoriaProducto.TabIndex = 2;
            this.btnBuscarMarcaCategoriaProducto.Text = ". . .";
            this.btnBuscarMarcaCategoriaProducto.UseVisualStyleBackColor = true;
            this.btnBuscarMarcaCategoriaProducto.Click += new System.EventHandler(this.btnBuscarMarcaCategoriaProducto_Click);
            // 
            // lblListaDescuento
            // 
            this.lblListaDescuento.AutoSize = true;
            this.lblListaDescuento.Location = new System.Drawing.Point(317, 72);
            this.lblListaDescuento.Name = "lblListaDescuento";
            this.lblListaDescuento.Size = new System.Drawing.Size(88, 16);
            this.lblListaDescuento.TabIndex = 10;
            this.lblListaDescuento.Text = "Descuento %";
            // 
            // lbxDescuento
            // 
            this.lbxDescuento.DisplayMember = "valordescuento";
            this.lbxDescuento.FormattingEnabled = true;
            this.lbxDescuento.ItemHeight = 16;
            this.lbxDescuento.Location = new System.Drawing.Point(320, 99);
            this.lbxDescuento.Name = "lbxDescuento";
            this.lbxDescuento.Size = new System.Drawing.Size(206, 68);
            this.lbxDescuento.TabIndex = 9;
            this.lbxDescuento.ValueMember = "iddescuento";
            // 
            // lblAPromocionar
            // 
            this.lblAPromocionar.AutoSize = true;
            this.lblAPromocionar.Location = new System.Drawing.Point(551, 72);
            this.lblAPromocionar.Name = "lblAPromocionar";
            this.lblAPromocionar.Size = new System.Drawing.Size(165, 16);
            this.lblAPromocionar.TabIndex = 8;
            this.lblAPromocionar.Text = "N° articulos a promocionar";
            // 
            // txtAPromocionar
            // 
            this.txtAPromocionar.Enabled = false;
            this.txtAPromocionar.Location = new System.Drawing.Point(554, 100);
            this.txtAPromocionar.MaxLength = 100000;
            this.txtAPromocionar.Name = "txtAPromocionar";
            this.txtAPromocionar.Size = new System.Drawing.Size(193, 22);
            this.txtAPromocionar.TabIndex = 6;
            this.txtAPromocionar.Validating += new System.ComponentModel.CancelEventHandler(this.txtAPromocionar_Validating);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregar.Image")));
            this.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAgregar.Location = new System.Drawing.Point(554, 136);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(193, 29);
            this.btnAgregar.TabIndex = 12;
            this.btnAgregar.Text = "Agregar promoción";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // gbxseleccionoCategoriaproductoMarca
            // 
            this.gbxseleccionoCategoriaproductoMarca.Controls.Add(this.dgvPromocion);
            this.gbxseleccionoCategoriaproductoMarca.Location = new System.Drawing.Point(6, 213);
            this.gbxseleccionoCategoriaproductoMarca.Name = "gbxseleccionoCategoriaproductoMarca";
            this.gbxseleccionoCategoriaproductoMarca.Size = new System.Drawing.Size(763, 186);
            this.gbxseleccionoCategoriaproductoMarca.TabIndex = 1;
            this.gbxseleccionoCategoriaproductoMarca.TabStop = false;
            // 
            // dgvPromocion
            // 
            this.dgvPromocion.AllowUserToAddRows = false;
            this.dgvPromocion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPromocion.BackgroundColor = System.Drawing.Color.White;
            this.dgvPromocion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvPromocion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPromocion.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Tipo,
            this.Codigo,
            this.Nombre,
            this.FechaInicio,
            this.FechaFin,
            this.Descuento,
            this.Cantidad});
            this.dgvPromocion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPromocion.GridColor = System.Drawing.SystemColors.Window;
            this.dgvPromocion.Location = new System.Drawing.Point(13, 21);
            this.dgvPromocion.Name = "dgvPromocion";
            this.dgvPromocion.Size = new System.Drawing.Size(736, 159);
            this.dgvPromocion.TabIndex = 4;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "nombre";
            this.Nombre.Name = "Nombre";
            // 
            // FechaInicio
            // 
            this.FechaInicio.DataPropertyName = "FechaInicio";
            this.FechaInicio.HeaderText = "Fecha Inicio";
            this.FechaInicio.Name = "FechaInicio";
            // 
            // FechaFin
            // 
            this.FechaFin.DataPropertyName = "FechaFin";
            this.FechaFin.HeaderText = "Fecha Fin";
            this.FechaFin.Name = "FechaFin";
            // 
            // Descuento
            // 
            this.Descuento.DataPropertyName = "Descuento";
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // tpConsulta
            // 
            this.tpConsulta.Controls.Add(this.toolStrip2);
            this.tpConsulta.Controls.Add(this.gbxResultadoBusquda);
            this.tpConsulta.Controls.Add(this.gbxResultado);
            this.tpConsulta.Location = new System.Drawing.Point(4, 25);
            this.tpConsulta.Name = "tpConsulta";
            this.tpConsulta.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsulta.Size = new System.Drawing.Size(774, 408);
            this.tpConsulta.TabIndex = 1;
            this.tpConsulta.Text = "Consultar";
            this.tpConsulta.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificar,
            this.tsbtnEliminar,
            this.tsbtnsal});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(768, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnModificar
            // 
            this.tsbtnModificar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificar.Image")));
            this.tsbtnModificar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificar.Name = "tsbtnModificar";
            this.tsbtnModificar.Size = new System.Drawing.Size(78, 22);
            this.tsbtnModificar.Text = "Modificar";
            this.tsbtnModificar.Click += new System.EventHandler(this.tsbtnModificar_Click);
            // 
            // tsbtnEliminar
            // 
            this.tsbtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminar.Image")));
            this.tsbtnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminar.Name = "tsbtnEliminar";
            this.tsbtnEliminar.Size = new System.Drawing.Size(70, 22);
            this.tsbtnEliminar.Text = "Eliminar";
            this.tsbtnEliminar.Click += new System.EventHandler(this.tsbtnEliminar_Click);
            // 
            // tsbtnsal
            // 
            this.tsbtnsal.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnsal.Image")));
            this.tsbtnsal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnsal.Name = "tsbtnsal";
            this.tsbtnsal.Size = new System.Drawing.Size(49, 22);
            this.tsbtnsal.Text = "Salir";
            this.tsbtnsal.Click += new System.EventHandler(this.tsbtnsal_Click);
            // 
            // gbxResultadoBusquda
            // 
            this.gbxResultadoBusquda.Controls.Add(this.cbxTipo);
            this.gbxResultadoBusquda.Controls.Add(this.cbxListarTodo);
            this.gbxResultadoBusquda.Controls.Add(this.txtListarPromocionCategoriaPoductoMarca);
            this.gbxResultadoBusquda.Controls.Add(this.pListar);
            this.gbxResultadoBusquda.Controls.Add(this.btnBuscarListar);
            this.gbxResultadoBusquda.Controls.Add(this.cbxCriterioFecha);
            this.gbxResultadoBusquda.Controls.Add(this.dtpfechaIni);
            this.gbxResultadoBusquda.Controls.Add(this.dtpFechaFi);
            this.gbxResultadoBusquda.Controls.Add(this.btnBuscar);
            this.gbxResultadoBusquda.Location = new System.Drawing.Point(6, 32);
            this.gbxResultadoBusquda.Name = "gbxResultadoBusquda";
            this.gbxResultadoBusquda.Size = new System.Drawing.Size(762, 100);
            this.gbxResultadoBusquda.TabIndex = 1;
            this.gbxResultadoBusquda.TabStop = false;
            this.gbxResultadoBusquda.Text = "Criterios de busquda";
            // 
            // cbxTipo
            // 
            this.cbxTipo.DisplayMember = "nombretipo_sorteo";
            this.cbxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxTipo.FormattingEnabled = true;
            this.cbxTipo.Location = new System.Drawing.Point(12, 30);
            this.cbxTipo.Name = "cbxTipo";
            this.cbxTipo.Size = new System.Drawing.Size(148, 24);
            this.cbxTipo.TabIndex = 0;
            this.cbxTipo.ValueMember = "idtipo_sorteo";
            this.cbxTipo.SelectionChangeCommitted += new System.EventHandler(this.cbxTipo_SelectionChangeCommitted);
            // 
            // cbxListarTodo
            // 
            this.cbxListarTodo.AutoSize = true;
            this.cbxListarTodo.Location = new System.Drawing.Point(17, 65);
            this.cbxListarTodo.Name = "cbxListarTodo";
            this.cbxListarTodo.Size = new System.Drawing.Size(84, 17);
            this.cbxListarTodo.TabIndex = 1;
            this.cbxListarTodo.Text = "Listar Todos";
            this.cbxListarTodo.UseVisualStyleBackColor = true;
            this.cbxListarTodo.Click += new System.EventHandler(this.cbxListarTodo_Click);
            // 
            // txtListarPromocionCategoriaPoductoMarca
            // 
            this.txtListarPromocionCategoriaPoductoMarca.Location = new System.Drawing.Point(188, 30);
            this.txtListarPromocionCategoriaPoductoMarca.Name = "txtListarPromocionCategoriaPoductoMarca";
            this.txtListarPromocionCategoriaPoductoMarca.Size = new System.Drawing.Size(155, 22);
            this.txtListarPromocionCategoriaPoductoMarca.TabIndex = 3;
            this.txtListarPromocionCategoriaPoductoMarca.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtListarPromocionCategoriaPoductoMarca_KeyPress);
            this.txtListarPromocionCategoriaPoductoMarca.Validating += new System.ComponentModel.CancelEventHandler(this.txtListarPromocionCategoriaPoductoMarca_Validating);
            // 
            // pListar
            // 
            this.pListar.BackColor = System.Drawing.Color.LightSteelBlue;
            this.pListar.Controls.Add(this.lblListarMarcaCategoriaProducto);
            this.pListar.Location = new System.Drawing.Point(187, 60);
            this.pListar.Name = "pListar";
            this.pListar.Size = new System.Drawing.Size(156, 25);
            this.pListar.TabIndex = 8;
            // 
            // lblListarMarcaCategoriaProducto
            // 
            this.lblListarMarcaCategoriaProducto.AutoSize = true;
            this.lblListarMarcaCategoriaProducto.Location = new System.Drawing.Point(3, 5);
            this.lblListarMarcaCategoriaProducto.Name = "lblListarMarcaCategoriaProducto";
            this.lblListarMarcaCategoriaProducto.Size = new System.Drawing.Size(0, 16);
            this.lblListarMarcaCategoriaProducto.TabIndex = 0;
            // 
            // btnBuscarListar
            // 
            this.btnBuscarListar.Location = new System.Drawing.Point(354, 30);
            this.btnBuscarListar.Name = "btnBuscarListar";
            this.btnBuscarListar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscarListar.TabIndex = 2;
            this.btnBuscarListar.Text = ". . .";
            this.btnBuscarListar.UseVisualStyleBackColor = true;
            this.btnBuscarListar.Click += new System.EventHandler(this.btnBuscarListar_Click);
            // 
            // cbxCriterioFecha
            // 
            this.cbxCriterioFecha.DisplayMember = "nombre";
            this.cbxCriterioFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCriterioFecha.FormattingEnabled = true;
            this.cbxCriterioFecha.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cbxCriterioFecha.Location = new System.Drawing.Point(410, 30);
            this.cbxCriterioFecha.Name = "cbxCriterioFecha";
            this.cbxCriterioFecha.Size = new System.Drawing.Size(86, 24);
            this.cbxCriterioFecha.TabIndex = 4;
            this.cbxCriterioFecha.ValueMember = "id";
            this.cbxCriterioFecha.SelectionChangeCommitted += new System.EventHandler(this.cbxCriterioFecha_SelectionChangeCommitted);
            // 
            // dtpfechaIni
            // 
            this.dtpfechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpfechaIni.Location = new System.Drawing.Point(502, 30);
            this.dtpfechaIni.Name = "dtpfechaIni";
            this.dtpfechaIni.Size = new System.Drawing.Size(96, 22);
            this.dtpfechaIni.TabIndex = 5;
            // 
            // dtpFechaFi
            // 
            this.dtpFechaFi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFi.Location = new System.Drawing.Point(604, 30);
            this.dtpFechaFi.Name = "dtpFechaFi";
            this.dtpFechaFi.Size = new System.Drawing.Size(89, 22);
            this.dtpFechaFi.TabIndex = 6;
            this.dtpFechaFi.Visible = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.Location = new System.Drawing.Point(705, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 23);
            this.btnBuscar.TabIndex = 7;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gbxResultado
            // 
            this.gbxResultado.Controls.Add(this.dgvResultado);
            this.gbxResultado.Controls.Add(this.statusDescuento);
            this.gbxResultado.Location = new System.Drawing.Point(6, 138);
            this.gbxResultado.Name = "gbxResultado";
            this.gbxResultado.Size = new System.Drawing.Size(762, 264);
            this.gbxResultado.TabIndex = 2;
            this.gbxResultado.TabStop = false;
            this.gbxResultado.Text = "Resultado";
            // 
            // dgvResultado
            // 
            this.dgvResultado.AllowUserToAddRows = false;
            this.dgvResultado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvResultado.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvResultado.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResultado.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idPromocion,
            this.idTipo,
            this.Tip,
            this.cod,
            this.nom,
            this.Cant,
            this.idDes,
            this.des,
            this.fechaIni,
            this.fechaFi});
            this.dgvResultado.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvResultado.GridColor = System.Drawing.SystemColors.Window;
            this.dgvResultado.Location = new System.Drawing.Point(12, 21);
            this.dgvResultado.Name = "dgvResultado";
            this.dgvResultado.Size = new System.Drawing.Size(740, 211);
            this.dgvResultado.TabIndex = 0;
            // 
            // idPromocion
            // 
            this.idPromocion.DataPropertyName = "idpromocion";
            this.idPromocion.HeaderText = "idPromocion";
            this.idPromocion.Name = "idPromocion";
            this.idPromocion.Visible = false;
            // 
            // idTipo
            // 
            this.idTipo.DataPropertyName = "idtipo_sorteo";
            this.idTipo.HeaderText = "idTipo";
            this.idTipo.Name = "idTipo";
            this.idTipo.Visible = false;
            // 
            // Tip
            // 
            this.Tip.DataPropertyName = "nombretipo_sorteo";
            this.Tip.HeaderText = "Tipo";
            this.Tip.Name = "Tip";
            // 
            // cod
            // 
            this.cod.DataPropertyName = "codigo";
            this.cod.HeaderText = "Codigo";
            this.cod.Name = "cod";
            // 
            // nom
            // 
            this.nom.DataPropertyName = "nombre";
            this.nom.HeaderText = "Nombre";
            this.nom.Name = "nom";
            // 
            // Cant
            // 
            this.Cant.DataPropertyName = "cantidad";
            this.Cant.HeaderText = "Cantidad";
            this.Cant.Name = "Cant";
            this.Cant.Visible = false;
            // 
            // idDes
            // 
            this.idDes.DataPropertyName = "iddescuento";
            this.idDes.HeaderText = "idDes";
            this.idDes.Name = "idDes";
            this.idDes.Visible = false;
            // 
            // des
            // 
            this.des.DataPropertyName = "valordescuento";
            this.des.HeaderText = "Descuento";
            this.des.Name = "des";
            // 
            // fechaIni
            // 
            this.fechaIni.DataPropertyName = "fechainicio";
            this.fechaIni.HeaderText = "Fecha Inicio";
            this.fechaIni.Name = "fechaIni";
            // 
            // fechaFi
            // 
            this.fechaFi.DataPropertyName = "fechafin";
            this.fechaFi.HeaderText = "Fecha fin";
            this.fechaFi.Name = "fechaFi";
            // 
            // statusDescuento
            // 
            this.statusDescuento.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnInicio,
            this.tsbtnAtras,
            this.tslblConteo,
            this.tsbtnSiguiente,
            this.tsbtnFinal});
            this.statusDescuento.Location = new System.Drawing.Point(3, 239);
            this.statusDescuento.Name = "statusDescuento";
            this.statusDescuento.Size = new System.Drawing.Size(756, 22);
            this.statusDescuento.TabIndex = 1;
            this.statusDescuento.Text = "statusStrip1";
            // 
            // tsbtnInicio
            // 
            this.tsbtnInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnInicio.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnInicio.Image")));
            this.tsbtnInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnInicio.Name = "tsbtnInicio";
            this.tsbtnInicio.ShowDropDownArrow = false;
            this.tsbtnInicio.Size = new System.Drawing.Size(20, 20);
            this.tsbtnInicio.Text = "Inicio";
            this.tsbtnInicio.Click += new System.EventHandler(this.tsbtnInicio_Click);
            // 
            // tsbtnAtras
            // 
            this.tsbtnAtras.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnAtras.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnAtras.Image")));
            this.tsbtnAtras.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnAtras.Name = "tsbtnAtras";
            this.tsbtnAtras.ShowDropDownArrow = false;
            this.tsbtnAtras.Size = new System.Drawing.Size(20, 20);
            this.tsbtnAtras.Text = "Atras";
            this.tsbtnAtras.Click += new System.EventHandler(this.tsbtnAtras_Click);
            // 
            // tslblConteo
            // 
            this.tslblConteo.Name = "tslblConteo";
            this.tslblConteo.Size = new System.Drawing.Size(33, 17);
            this.tslblConteo.Text = " 0 / 0";
            // 
            // tsbtnSiguiente
            // 
            this.tsbtnSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSiguiente.Image")));
            this.tsbtnSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSiguiente.Name = "tsbtnSiguiente";
            this.tsbtnSiguiente.ShowDropDownArrow = false;
            this.tsbtnSiguiente.Size = new System.Drawing.Size(20, 20);
            this.tsbtnSiguiente.Text = "Siguiente";
            this.tsbtnSiguiente.Click += new System.EventHandler(this.tsbtnSiguiente_Click);
            // 
            // tsbtnFinal
            // 
            this.tsbtnFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbtnFinal.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnFinal.Image")));
            this.tsbtnFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnFinal.Name = "tsbtnFinal";
            this.tsbtnFinal.ShowDropDownArrow = false;
            this.tsbtnFinal.Size = new System.Drawing.Size(20, 20);
            this.tsbtnFinal.Click += new System.EventHandler(this.tsbtnFinal_Click);
            // 
            // frmdescuento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 446);
            this.Controls.Add(this.tcInsertarPromocion);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmdescuento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Promoción";
            this.Load += new System.EventHandler(this.frmdescuento_Load);
            this.tcInsertarPromocion.ResumeLayout(false);
            this.tpInsertar.ResumeLayout(false);
            this.tpInsertar.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbxconfiguracionPromocion.ResumeLayout(false);
            this.gbxconfiguracionPromocion.PerformLayout();
            this.pinsertarMarcacategoriaProducto.ResumeLayout(false);
            this.pinsertarMarcacategoriaProducto.PerformLayout();
            this.gbxseleccionoCategoriaproductoMarca.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPromocion)).EndInit();
            this.tpConsulta.ResumeLayout(false);
            this.tpConsulta.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbxResultadoBusquda.ResumeLayout(false);
            this.gbxResultadoBusquda.PerformLayout();
            this.pListar.ResumeLayout(false);
            this.pListar.PerformLayout();
            this.gbxResultado.ResumeLayout(false);
            this.gbxResultado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResultado)).EndInit();
            this.statusDescuento.ResumeLayout(false);
            this.statusDescuento.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcInsertarPromocion;
        private System.Windows.Forms.TabPage tpInsertar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarPromocion;
        private System.Windows.Forms.GroupBox gbxseleccionoCategoriaproductoMarca;
        private System.Windows.Forms.Label lblListaDescuento;
        private System.Windows.Forms.ListBox lbxDescuento;
        private System.Windows.Forms.Label lblAPromocionar;
        private System.Windows.Forms.TextBox txtAPromocionar;
        private System.Windows.Forms.DataGridView dgvPromocion;
        private System.Windows.Forms.Button btnBuscarMarcaCategoriaProducto;
        private System.Windows.Forms.TextBox txtagregarMarcaCategoriaProducto;
        private System.Windows.Forms.GroupBox gbxconfiguracionPromocion;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.ComboBox cbxTipodePromocion;
        private System.Windows.Forms.Label lblTipodePromocion;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.TabPage tpConsulta;
        private System.Windows.Forms.Panel pinsertarMarcacategoriaProducto;
        private System.Windows.Forms.Label lblMarcaCategoriaProducto;
        private System.Windows.Forms.ToolStripButton tsbtnsalir;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ToolStripButton tsbtnEliminarRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaFin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.GroupBox gbxResultado;
        private System.Windows.Forms.DataGridView dgvResultado;
        private System.Windows.Forms.GroupBox gbxResultadoBusquda;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpfechaIni;
        private System.Windows.Forms.DateTimePicker dtpFechaFi;
        private System.Windows.Forms.ComboBox cbxTipo;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnsal;
        private System.Windows.Forms.ToolStripButton tsbtnModificar;
        private System.Windows.Forms.Label lblCategoriamarcaProducto;
        private System.Windows.Forms.ToolStripButton tsbtnEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPromocion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tip;
        private System.Windows.Forms.DataGridViewTextBoxColumn cod;
        private System.Windows.Forms.DataGridViewTextBoxColumn nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cant;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDes;
        private System.Windows.Forms.DataGridViewTextBoxColumn des;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaIni;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFi;
        private System.Windows.Forms.ComboBox cbxCriterioFecha;
        private System.Windows.Forms.Panel pListar;
        private System.Windows.Forms.Label lblListarMarcaCategoriaProducto;
        private System.Windows.Forms.Button btnBuscarListar;
        private System.Windows.Forms.TextBox txtListarPromocionCategoriaPoductoMarca;
        private System.Windows.Forms.CheckBox cbxListarTodo;
        private System.Windows.Forms.StatusStrip statusDescuento;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnInicio;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnAtras;
        private System.Windows.Forms.ToolStripStatusLabel tslblConteo;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton tsbtnFinal;
    }
}