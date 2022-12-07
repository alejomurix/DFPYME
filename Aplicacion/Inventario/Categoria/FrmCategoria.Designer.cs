namespace Aplicacion.Inventario.Categoria
{
    partial class FrmCategoria
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

        /// <summary>
        /// Obtiene o Establece el valor del TabControl Principal.
        /// </summary>
        public System.Windows.Forms.TabControl TblCategoria
        {
            set { this.tblCategoria = value; }
            get { return this.tblCategoria; }
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCategoria));
            this.tblCategoria = new System.Windows.Forms.TabControl();
            this.tpCrearCategoria = new System.Windows.Forms.TabPage();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsbtnguardar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalirCrear = new System.Windows.Forms.ToolStripButton();
            this.gbCategoria = new System.Windows.Forms.GroupBox();
            this.lklblGenerarCodigoCategoria = new System.Windows.Forms.LinkLabel();
            this.lblCodigoCategoria = new System.Windows.Forms.Label();
            this.txtCodigoCategoria = new System.Windows.Forms.TextBox();
            this.lblNombreCategoria = new System.Windows.Forms.Label();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.lblDescripcionCategoria = new System.Windows.Forms.Label();
            this.txtDescripcionCategoria = new System.Windows.Forms.TextBox();
            this.tpConsultaCategoria = new System.Windows.Forms.TabPage();
            this.tsMenuConsulta = new System.Windows.Forms.ToolStrip();
            this.btnlistarcategoria = new System.Windows.Forms.ToolStripButton();
            this.btnmodificarcate = new System.Windows.Forms.ToolStripButton();
            this.btmeliminarcategoria = new System.Windows.Forms.ToolStripButton();
            this.tsBtnCriterio = new System.Windows.Forms.ToolStripButton();
            this.tsBtnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.tsbtnSalir = new System.Windows.Forms.ToolStripButton();
            this.gbbuscar = new System.Windows.Forms.GroupBox();
            this.cbxbuscar = new System.Windows.Forms.ComboBox();
            this.cbxbuscar2 = new System.Windows.Forms.ComboBox();
            this.txtbuscarporcategoria = new System.Windows.Forms.TextBox();
            this.btnbuscar = new System.Windows.Forms.Button();
            this.grbresultado = new System.Windows.Forms.GroupBox();
            this.StatusCategoria = new System.Windows.Forms.StatusStrip();
            this.rowInicio = new System.Windows.Forms.ToolStripDropDownButton();
            this.rowAnterior = new System.Windows.Forms.ToolStripDropDownButton();
            this.tslblPaginacion = new System.Windows.Forms.ToolStripStatusLabel();
            this.rowSiguiente = new System.Windows.Forms.ToolStripDropDownButton();
            this.rowFinal = new System.Windows.Forms.ToolStripDropDownButton();
            this.dgvListadocategoria = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tblCategoria.SuspendLayout();
            this.tpCrearCategoria.SuspendLayout();
            this.tsMenu.SuspendLayout();
            this.gbCategoria.SuspendLayout();
            this.tpConsultaCategoria.SuspendLayout();
            this.tsMenuConsulta.SuspendLayout();
            this.gbbuscar.SuspendLayout();
            this.grbresultado.SuspendLayout();
            this.StatusCategoria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadocategoria)).BeginInit();
            this.SuspendLayout();
            // 
            // tblCategoria
            // 
            this.tblCategoria.Controls.Add(this.tpCrearCategoria);
            this.tblCategoria.Controls.Add(this.tpConsultaCategoria);
            this.tblCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.tblCategoria.Location = new System.Drawing.Point(1, 2);
            this.tblCategoria.Name = "tblCategoria";
            this.tblCategoria.SelectedIndex = 0;
            this.tblCategoria.Size = new System.Drawing.Size(747, 386);
            this.tblCategoria.TabIndex = 3;
            // 
            // tpCrearCategoria
            // 
            this.tpCrearCategoria.Controls.Add(this.tsMenu);
            this.tpCrearCategoria.Controls.Add(this.gbCategoria);
            this.tpCrearCategoria.Location = new System.Drawing.Point(4, 25);
            this.tpCrearCategoria.Name = "tpCrearCategoria";
            this.tpCrearCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tpCrearCategoria.Size = new System.Drawing.Size(739, 357);
            this.tpCrearCategoria.TabIndex = 0;
            this.tpCrearCategoria.Text = "Crear Categoria";
            this.tpCrearCategoria.UseVisualStyleBackColor = true;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnguardar,
            this.tsbtnSalirCrear});
            this.tsMenu.Location = new System.Drawing.Point(3, 3);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(733, 25);
            this.tsMenu.TabIndex = 1;
            this.tsMenu.Text = "Menu";
            // 
            // tsbtnguardar
            // 
            this.tsbtnguardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnguardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnguardar.Image")));
            this.tsbtnguardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnguardar.Name = "tsbtnguardar";
            this.tsbtnguardar.Size = new System.Drawing.Size(76, 22);
            this.tsbtnguardar.Text = "Guardar";
            this.tsbtnguardar.Click += new System.EventHandler(this.btnguardacategoria_Click);
            // 
            // tsbtnSalirCrear
            // 
            this.tsbtnSalirCrear.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalirCrear.Image")));
            this.tsbtnSalirCrear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalirCrear.Name = "tsbtnSalirCrear";
            this.tsbtnSalirCrear.Size = new System.Drawing.Size(49, 22);
            this.tsbtnSalirCrear.Text = "Salir";
            this.tsbtnSalirCrear.Click += new System.EventHandler(this.tsbtnSalirCrear_Click);
            // 
            // gbCategoria
            // 
            this.gbCategoria.Controls.Add(this.lklblGenerarCodigoCategoria);
            this.gbCategoria.Controls.Add(this.lblCodigoCategoria);
            this.gbCategoria.Controls.Add(this.txtCodigoCategoria);
            this.gbCategoria.Controls.Add(this.lblNombreCategoria);
            this.gbCategoria.Controls.Add(this.txtNombreCategoria);
            this.gbCategoria.Controls.Add(this.lblDescripcionCategoria);
            this.gbCategoria.Controls.Add(this.txtDescripcionCategoria);
            this.gbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbCategoria.Location = new System.Drawing.Point(11, 39);
            this.gbCategoria.Name = "gbCategoria";
            this.gbCategoria.Size = new System.Drawing.Size(709, 295);
            this.gbCategoria.TabIndex = 0;
            this.gbCategoria.TabStop = false;
            this.gbCategoria.Text = "Datos de Categoria";
            // 
            // lklblGenerarCodigoCategoria
            // 
            this.lklblGenerarCodigoCategoria.AutoSize = true;
            this.lklblGenerarCodigoCategoria.Location = new System.Drawing.Point(610, 33);
            this.lklblGenerarCodigoCategoria.Name = "lklblGenerarCodigoCategoria";
            this.lklblGenerarCodigoCategoria.Size = new System.Drawing.Size(57, 16);
            this.lklblGenerarCodigoCategoria.TabIndex = 6;
            this.lklblGenerarCodigoCategoria.TabStop = true;
            this.lklblGenerarCodigoCategoria.Text = "Generar";
            this.lklblGenerarCodigoCategoria.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lklblGenerarCodigoCategoria_LinkClicked);
            // 
            // lblCodigoCategoria
            // 
            this.lblCodigoCategoria.AutoSize = true;
            this.lblCodigoCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.lblCodigoCategoria.Location = new System.Drawing.Point(35, 33);
            this.lblCodigoCategoria.Name = "lblCodigoCategoria";
            this.lblCodigoCategoria.Size = new System.Drawing.Size(55, 16);
            this.lblCodigoCategoria.TabIndex = 3;
            this.lblCodigoCategoria.Text = "Codigo ";
            // 
            // txtCodigoCategoria
            // 
            this.txtCodigoCategoria.Location = new System.Drawing.Point(122, 30);
            this.txtCodigoCategoria.MaxLength = 50;
            this.txtCodigoCategoria.Name = "txtCodigoCategoria";
            this.txtCodigoCategoria.Size = new System.Drawing.Size(466, 22);
            this.txtCodigoCategoria.TabIndex = 0;
            this.txtCodigoCategoria.Validating += new System.ComponentModel.CancelEventHandler(this.txtCodigoCategoria_Validating);
            // 
            // lblNombreCategoria
            // 
            this.lblNombreCategoria.AutoSize = true;
            this.lblNombreCategoria.Location = new System.Drawing.Point(35, 82);
            this.lblNombreCategoria.Name = "lblNombreCategoria";
            this.lblNombreCategoria.Size = new System.Drawing.Size(60, 16);
            this.lblNombreCategoria.TabIndex = 4;
            this.lblNombreCategoria.Text = "Nombre ";
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.Location = new System.Drawing.Point(122, 79);
            this.txtNombreCategoria.MaxLength = 50;
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(545, 22);
            this.txtNombreCategoria.TabIndex = 1;
            this.txtNombreCategoria.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreCategoria_Validating);
            // 
            // lblDescripcionCategoria
            // 
            this.lblDescripcionCategoria.AutoSize = true;
            this.lblDescripcionCategoria.Location = new System.Drawing.Point(35, 128);
            this.lblDescripcionCategoria.Name = "lblDescripcionCategoria";
            this.lblDescripcionCategoria.Size = new System.Drawing.Size(83, 16);
            this.lblDescripcionCategoria.TabIndex = 5;
            this.lblDescripcionCategoria.Text = "Descripción ";
            // 
            // txtDescripcionCategoria
            // 
            this.txtDescripcionCategoria.Location = new System.Drawing.Point(38, 154);
            this.txtDescripcionCategoria.MaxLength = 60;
            this.txtDescripcionCategoria.Multiline = true;
            this.txtDescripcionCategoria.Name = "txtDescripcionCategoria";
            this.txtDescripcionCategoria.Size = new System.Drawing.Size(629, 124);
            this.txtDescripcionCategoria.TabIndex = 2;
            this.txtDescripcionCategoria.Validating += new System.ComponentModel.CancelEventHandler(this.txtDescripcionCategoria_Validating);
            // 
            // tpConsultaCategoria
            // 
            this.tpConsultaCategoria.Controls.Add(this.tsMenuConsulta);
            this.tpConsultaCategoria.Controls.Add(this.gbbuscar);
            this.tpConsultaCategoria.Controls.Add(this.grbresultado);
            this.tpConsultaCategoria.Location = new System.Drawing.Point(4, 25);
            this.tpConsultaCategoria.Name = "tpConsultaCategoria";
            this.tpConsultaCategoria.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultaCategoria.Size = new System.Drawing.Size(739, 357);
            this.tpConsultaCategoria.TabIndex = 1;
            this.tpConsultaCategoria.Text = "Consulta(s) Categoria";
            this.tpConsultaCategoria.UseVisualStyleBackColor = true;
            // 
            // tsMenuConsulta
            // 
            this.tsMenuConsulta.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnlistarcategoria,
            this.btnmodificarcate,
            this.btmeliminarcategoria,
            this.tsBtnCriterio,
            this.tsBtnSeleccionar,
            this.tsbtnSalir});
            this.tsMenuConsulta.Location = new System.Drawing.Point(3, 3);
            this.tsMenuConsulta.Name = "tsMenuConsulta";
            this.tsMenuConsulta.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tsMenuConsulta.Size = new System.Drawing.Size(733, 25);
            this.tsMenuConsulta.TabIndex = 5;
            this.tsMenuConsulta.Text = "Menu";
            // 
            // btnlistarcategoria
            // 
            this.btnlistarcategoria.Image = ((System.Drawing.Image)(resources.GetObject("btnlistarcategoria.Image")));
            this.btnlistarcategoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnlistarcategoria.Name = "btnlistarcategoria";
            this.btnlistarcategoria.Size = new System.Drawing.Size(86, 22);
            this.btnlistarcategoria.Text = "Listar Todo";
            this.btnlistarcategoria.Click += new System.EventHandler(this.btnlistarcategoria_Click_1);
            // 
            // btnmodificarcate
            // 
            this.btnmodificarcate.Image = ((System.Drawing.Image)(resources.GetObject("btnmodificarcate.Image")));
            this.btnmodificarcate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnmodificarcate.Name = "btnmodificarcate";
            this.btnmodificarcate.Size = new System.Drawing.Size(132, 22);
            this.btnmodificarcate.Text = "Modificar Categoria";
            this.btnmodificarcate.Click += new System.EventHandler(this.btnmodificarcate_Click);
            // 
            // btmeliminarcategoria
            // 
            this.btmeliminarcategoria.Image = ((System.Drawing.Image)(resources.GetObject("btmeliminarcategoria.Image")));
            this.btmeliminarcategoria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btmeliminarcategoria.Name = "btmeliminarcategoria";
            this.btmeliminarcategoria.Size = new System.Drawing.Size(124, 22);
            this.btmeliminarcategoria.Text = "Eliminar Categoria";
            this.btmeliminarcategoria.Click += new System.EventHandler(this.btmeliminarcategoria_Click);
            // 
            // tsBtnCriterio
            // 
            this.tsBtnCriterio.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnCriterio.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnCriterio.Image")));
            this.tsBtnCriterio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnCriterio.Name = "tsBtnCriterio";
            this.tsBtnCriterio.Size = new System.Drawing.Size(96, 22);
            this.tsBtnCriterio.Text = "Criterio [F5]";
            this.tsBtnCriterio.Visible = false;
            this.tsBtnCriterio.Click += new System.EventHandler(this.tsBtnCriterio_Click);
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
            // tsbtnSalir
            // 
            this.tsbtnSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnSalir.Image")));
            this.tsbtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnSalir.Name = "tsbtnSalir";
            this.tsbtnSalir.Size = new System.Drawing.Size(49, 22);
            this.tsbtnSalir.Text = "Salir";
            this.tsbtnSalir.Click += new System.EventHandler(this.tsbtnSalir_Click);
            // 
            // gbbuscar
            // 
            this.gbbuscar.Controls.Add(this.cbxbuscar);
            this.gbbuscar.Controls.Add(this.cbxbuscar2);
            this.gbbuscar.Controls.Add(this.txtbuscarporcategoria);
            this.gbbuscar.Controls.Add(this.btnbuscar);
            this.gbbuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbbuscar.Location = new System.Drawing.Point(13, 35);
            this.gbbuscar.Name = "gbbuscar";
            this.gbbuscar.Size = new System.Drawing.Size(709, 70);
            this.gbbuscar.TabIndex = 4;
            this.gbbuscar.TabStop = false;
            this.gbbuscar.Text = "Buscar Categoria";
            // 
            // cbxbuscar
            // 
            this.cbxbuscar.DisplayMember = "Nombre1";
            this.cbxbuscar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxbuscar.FormattingEnabled = true;
            this.cbxbuscar.Location = new System.Drawing.Point(19, 28);
            this.cbxbuscar.Name = "cbxbuscar";
            this.cbxbuscar.Size = new System.Drawing.Size(121, 24);
            this.cbxbuscar.TabIndex = 13;
            this.cbxbuscar.ValueMember = "Id1";
            this.cbxbuscar.SelectionChangeCommitted += new System.EventHandler(this.cbxbuscar_SelectionChangeCommitted);
            // 
            // cbxbuscar2
            // 
            this.cbxbuscar2.DisplayMember = "Nombre2";
            this.cbxbuscar2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxbuscar2.Enabled = false;
            this.cbxbuscar2.FormattingEnabled = true;
            this.cbxbuscar2.Items.AddRange(new object[] {
            "Sea Igual",
            "Que Contenga"});
            this.cbxbuscar2.Location = new System.Drawing.Point(158, 28);
            this.cbxbuscar2.Name = "cbxbuscar2";
            this.cbxbuscar2.Size = new System.Drawing.Size(150, 24);
            this.cbxbuscar2.TabIndex = 14;
            this.cbxbuscar2.ValueMember = "Id2";
            // 
            // txtbuscarporcategoria
            // 
            this.txtbuscarporcategoria.Location = new System.Drawing.Point(328, 30);
            this.txtbuscarporcategoria.MaxLength = 50;
            this.txtbuscarporcategoria.Name = "txtbuscarporcategoria";
            this.txtbuscarporcategoria.Size = new System.Drawing.Size(316, 22);
            this.txtbuscarporcategoria.TabIndex = 5;
            this.txtbuscarporcategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbuscarporcategoria_KeyPress);
            // 
            // btnbuscar
            // 
            this.btnbuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnbuscar.Image")));
            this.btnbuscar.Location = new System.Drawing.Point(655, 29);
            this.btnbuscar.Name = "btnbuscar";
            this.btnbuscar.Size = new System.Drawing.Size(30, 23);
            this.btnbuscar.TabIndex = 11;
            this.btnbuscar.UseVisualStyleBackColor = true;
            this.btnbuscar.Click += new System.EventHandler(this.btnbuscar_Click);
            // 
            // grbresultado
            // 
            this.grbresultado.Controls.Add(this.StatusCategoria);
            this.grbresultado.Controls.Add(this.dgvListadocategoria);
            this.grbresultado.Location = new System.Drawing.Point(13, 115);
            this.grbresultado.Name = "grbresultado";
            this.grbresultado.Size = new System.Drawing.Size(709, 228);
            this.grbresultado.TabIndex = 12;
            this.grbresultado.TabStop = false;
            this.grbresultado.Text = "Resultado de la Busqueda";
            // 
            // StatusCategoria
            // 
            this.StatusCategoria.BackColor = System.Drawing.Color.LightSteelBlue;
            this.StatusCategoria.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rowInicio,
            this.rowAnterior,
            this.tslblPaginacion,
            this.rowSiguiente,
            this.rowFinal});
            this.StatusCategoria.Location = new System.Drawing.Point(3, 203);
            this.StatusCategoria.Name = "StatusCategoria";
            this.StatusCategoria.Size = new System.Drawing.Size(703, 22);
            this.StatusCategoria.TabIndex = 1;
            this.StatusCategoria.Text = "Estado Categoria";
            // 
            // rowInicio
            // 
            this.rowInicio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rowInicio.Image = ((System.Drawing.Image)(resources.GetObject("rowInicio.Image")));
            this.rowInicio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowInicio.Name = "rowInicio";
            this.rowInicio.ShowDropDownArrow = false;
            this.rowInicio.Size = new System.Drawing.Size(20, 20);
            this.rowInicio.Text = "Inicio";
            this.rowInicio.Click += new System.EventHandler(this.rowInicio_Click);
            // 
            // rowAnterior
            // 
            this.rowAnterior.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rowAnterior.Image = ((System.Drawing.Image)(resources.GetObject("rowAnterior.Image")));
            this.rowAnterior.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowAnterior.Name = "rowAnterior";
            this.rowAnterior.ShowDropDownArrow = false;
            this.rowAnterior.Size = new System.Drawing.Size(20, 20);
            this.rowAnterior.Text = "Anterior";
            this.rowAnterior.Click += new System.EventHandler(this.rowAnterior_Click);
            // 
            // tslblPaginacion
            // 
            this.tslblPaginacion.Name = "tslblPaginacion";
            this.tslblPaginacion.Size = new System.Drawing.Size(30, 17);
            this.tslblPaginacion.Text = "0 / 0";
            // 
            // rowSiguiente
            // 
            this.rowSiguiente.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rowSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("rowSiguiente.Image")));
            this.rowSiguiente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowSiguiente.Name = "rowSiguiente";
            this.rowSiguiente.ShowDropDownArrow = false;
            this.rowSiguiente.Size = new System.Drawing.Size(20, 20);
            this.rowSiguiente.Text = "Siguiente";
            this.rowSiguiente.Click += new System.EventHandler(this.rowSiguiente_Click);
            // 
            // rowFinal
            // 
            this.rowFinal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rowFinal.Image = ((System.Drawing.Image)(resources.GetObject("rowFinal.Image")));
            this.rowFinal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rowFinal.Name = "rowFinal";
            this.rowFinal.ShowDropDownArrow = false;
            this.rowFinal.Size = new System.Drawing.Size(20, 20);
            this.rowFinal.Text = "Final";
            this.rowFinal.Click += new System.EventHandler(this.rowFinal_Click);
            // 
            // dgvListadocategoria
            // 
            this.dgvListadocategoria.AllowUserToAddRows = false;
            this.dgvListadocategoria.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvListadocategoria.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgvListadocategoria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListadocategoria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvListadocategoria.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvListadocategoria.Location = new System.Drawing.Point(6, 21);
            this.dgvListadocategoria.Name = "dgvListadocategoria";
            this.dgvListadocategoria.Size = new System.Drawing.Size(697, 182);
            this.dgvListadocategoria.TabIndex = 0;
            this.dgvListadocategoria.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListadocategoria_CellDoubleClick);
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "CodigoCategoria";
            this.Column1.HeaderText = "Codigo";
            this.Column1.Name = "Column1";
            this.Column1.Width = 180;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreCategoria";
            this.Column2.HeaderText = "Nombre";
            this.Column2.Name = "Column2";
            this.Column2.Width = 180;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "DescripcionCategoria";
            this.Column3.HeaderText = "Descripcion";
            this.Column3.Name = "Column3";
            this.Column3.Width = 192;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TextoEstado";
            this.Column4.HeaderText = "Estado";
            this.Column4.Name = "Column4";
            // 
            // FrmCategoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(745, 385);
            this.Controls.Add(this.tblCategoria);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCategoria";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Categoria";
            this.Load += new System.EventHandler(this.FrmCategoria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCategoria_KeyDown);
            this.tblCategoria.ResumeLayout(false);
            this.tpCrearCategoria.ResumeLayout(false);
            this.tpCrearCategoria.PerformLayout();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbCategoria.ResumeLayout(false);
            this.gbCategoria.PerformLayout();
            this.tpConsultaCategoria.ResumeLayout(false);
            this.tpConsultaCategoria.PerformLayout();
            this.tsMenuConsulta.ResumeLayout(false);
            this.tsMenuConsulta.PerformLayout();
            this.gbbuscar.ResumeLayout(false);
            this.gbbuscar.PerformLayout();
            this.grbresultado.ResumeLayout(false);
            this.grbresultado.PerformLayout();
            this.StatusCategoria.ResumeLayout(false);
            this.StatusCategoria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListadocategoria)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tblCategoria;
        private System.Windows.Forms.TabPage tpCrearCategoria;
        private System.Windows.Forms.TabPage tpConsultaCategoria;
        private System.Windows.Forms.GroupBox gbbuscar;
        private System.Windows.Forms.Button btnbuscar;
        private System.Windows.Forms.ToolStrip tsMenuConsulta;
        private System.Windows.Forms.ToolStripButton btnlistarcategoria;
        private System.Windows.Forms.ToolStripButton btnmodificarcate;
        private System.Windows.Forms.ToolStripButton btmeliminarcategoria;
        private System.Windows.Forms.GroupBox grbresultado;
        private System.Windows.Forms.GroupBox gbCategoria;
        private System.Windows.Forms.Label lblCodigoCategoria;
        private System.Windows.Forms.TextBox txtDescripcionCategoria;
        private System.Windows.Forms.TextBox txtCodigoCategoria;
        private System.Windows.Forms.Label lblDescripcionCategoria;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.Label lblNombreCategoria;
        private System.Windows.Forms.ComboBox cbxbuscar2;
        private System.Windows.Forms.ComboBox cbxbuscar;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsbtnguardar;
        private System.Windows.Forms.ToolStripButton tsbtnSalirCrear;
        private System.Windows.Forms.ToolStripButton tsbtnSalir;
        private System.Windows.Forms.StatusStrip StatusCategoria;
        private System.Windows.Forms.ToolStripDropDownButton rowInicio;
        private System.Windows.Forms.ToolStripDropDownButton rowAnterior;
        private System.Windows.Forms.ToolStripStatusLabel tslblPaginacion;
        private System.Windows.Forms.ToolStripDropDownButton rowSiguiente;
        private System.Windows.Forms.ToolStripDropDownButton rowFinal;
        private System.Windows.Forms.LinkLabel lklblGenerarCodigoCategoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        public System.Windows.Forms.DataGridView dgvListadocategoria;
        public System.Windows.Forms.TextBox txtbuscarporcategoria;
        private System.Windows.Forms.ToolStripButton tsBtnSeleccionar;
        private System.Windows.Forms.ToolStripButton tsBtnCriterio;
    }
}