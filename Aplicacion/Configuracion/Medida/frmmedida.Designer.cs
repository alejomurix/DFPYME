namespace Aplicacion.Configuracion.Medida
{
    partial class frmmedida
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
            new System.ComponentModel.ComponentResourceManager(typeof(frmmedida));

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmmedida));
            this.tcMedida = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.gbValorUnidadMedida = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgbValorUnidadMedida = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtValorMedida = new System.Windows.Forms.TextBox();
            this.btnEliminarValorUnidadMedida = new System.Windows.Forms.Button();
            this.btnGuardarValorMedida = new System.Windows.Forms.Button();
            this.gbUnidadMedida = new System.Windows.Forms.GroupBox();
            this.lblUnidadMedida = new System.Windows.Forms.Label();
            this.txtUnidadMedida = new System.Windows.Forms.TextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbtnguardar = new System.Windows.Forms.ToolStripButton();
            this.tsMedidaSalir = new System.Windows.Forms.ToolStripButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.tsConsultaSalir = new System.Windows.Forms.ToolStripButton();
            this.gbListaValorUnidadMedida = new System.Windows.Forms.GroupBox();
            this.btnAgregarMedida = new System.Windows.Forms.Button();
            this.txModificaValorMedida = new System.Windows.Forms.TextBox();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificarValorMedida = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardarModificarValorMedida = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminarValorMedida = new System.Windows.Forms.ToolStripButton();
            this.dgvValorMedida = new System.Windows.Forms.DataGridView();
            this.IdM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdU_M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbListaUnidadMedida = new System.Windows.Forms.GroupBox();
            this.txModificaUnidadMedida = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbtnModificarUnidadMedida = new System.Windows.Forms.ToolStripButton();
            this.tsbtnGuardarModificarUnidadMedida = new System.Windows.Forms.ToolStripButton();
            this.tsbtnEliminarUnidadMedida = new System.Windows.Forms.ToolStripButton();
            this.dgvUnidadMedida = new System.Windows.Forms.DataGridView();
            this.IdU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreU = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsBtnMedida = new System.Windows.Forms.ToolStripButton();
            this.tsBtnUnidad = new System.Windows.Forms.ToolStripButton();
            this.recurso = new System.Windows.Forms.ToolStripButton();
            this.tcMedida.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.gbValorUnidadMedida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbValorUnidadMedida)).BeginInit();
            this.gbUnidadMedida.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.gbListaValorUnidadMedida.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValorMedida)).BeginInit();
            this.gbListaUnidadMedida.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadMedida)).BeginInit();
            this.SuspendLayout();
            // 
            // tcMedida
            // 
            this.tcMedida.Controls.Add(this.tabPage1);
            this.tcMedida.Controls.Add(this.tabPage2);
            this.tcMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.tcMedida.Location = new System.Drawing.Point(2, 0);
            this.tcMedida.Name = "tcMedida";
            this.tcMedida.SelectedIndex = 0;
            this.tcMedida.Size = new System.Drawing.Size(534, 439);
            this.tcMedida.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.gbValorUnidadMedida);
            this.tabPage1.Controls.Add(this.gbUnidadMedida);
            this.tabPage1.Controls.Add(this.toolStrip1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(526, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Medidas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // gbValorUnidadMedida
            // 
            this.gbValorUnidadMedida.Controls.Add(this.label1);
            this.gbValorUnidadMedida.Controls.Add(this.dgbValorUnidadMedida);
            this.gbValorUnidadMedida.Controls.Add(this.txtValorMedida);
            this.gbValorUnidadMedida.Controls.Add(this.btnEliminarValorUnidadMedida);
            this.gbValorUnidadMedida.Controls.Add(this.btnGuardarValorMedida);
            this.gbValorUnidadMedida.Location = new System.Drawing.Point(15, 105);
            this.gbValorUnidadMedida.Name = "gbValorUnidadMedida";
            this.gbValorUnidadMedida.Size = new System.Drawing.Size(493, 295);
            this.gbValorUnidadMedida.TabIndex = 1;
            this.gbValorUnidadMedida.TabStop = false;
            this.gbValorUnidadMedida.Text = "Unidad(es) de Medida";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Unidad";
            // 
            // dgbValorUnidadMedida
            // 
            this.dgbValorUnidadMedida.AllowUserToAddRows = false;
            this.dgbValorUnidadMedida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgbValorUnidadMedida.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgbValorUnidadMedida.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.dgbValorUnidadMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbValorUnidadMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dgbValorUnidadMedida.GridColor = System.Drawing.SystemColors.Window;
            this.dgbValorUnidadMedida.Location = new System.Drawing.Point(121, 71);
            this.dgbValorUnidadMedida.Name = "dgbValorUnidadMedida";
            this.dgbValorUnidadMedida.Size = new System.Drawing.Size(239, 206);
            this.dgbValorUnidadMedida.TabIndex = 3;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "descripcionunidad_medida";
            this.Column1.HeaderText = "Unidad de Medida";
            this.Column1.Name = "Column1";
            // 
            // txtValorMedida
            // 
            this.txtValorMedida.Location = new System.Drawing.Point(121, 30);
            this.txtValorMedida.Name = "txtValorMedida";
            this.txtValorMedida.Size = new System.Drawing.Size(239, 22);
            this.txtValorMedida.TabIndex = 2;
            this.txtValorMedida.Validating += new System.ComponentModel.CancelEventHandler(this.txtValorMedida_Validating);
            // 
            // btnEliminarValorUnidadMedida
            // 
            this.btnEliminarValorUnidadMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarValorUnidadMedida.Image")));
            this.btnEliminarValorUnidadMedida.Location = new System.Drawing.Point(359, 70);
            this.btnEliminarValorUnidadMedida.Name = "btnEliminarValorUnidadMedida";
            this.btnEliminarValorUnidadMedida.Size = new System.Drawing.Size(25, 24);
            this.btnEliminarValorUnidadMedida.TabIndex = 1;
            this.btnEliminarValorUnidadMedida.UseVisualStyleBackColor = true;
            this.btnEliminarValorUnidadMedida.Click += new System.EventHandler(this.btnEliminarValorUnidadMedida_Click);
            // 
            // btnGuardarValorMedida
            // 
            this.btnGuardarValorMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarValorMedida.Image")));
            this.btnGuardarValorMedida.Location = new System.Drawing.Point(367, 29);
            this.btnGuardarValorMedida.Name = "btnGuardarValorMedida";
            this.btnGuardarValorMedida.Size = new System.Drawing.Size(25, 24);
            this.btnGuardarValorMedida.TabIndex = 0;
            this.btnGuardarValorMedida.UseVisualStyleBackColor = true;
            this.btnGuardarValorMedida.Click += new System.EventHandler(this.btnGuardarValorMedida_Click);
            // 
            // gbUnidadMedida
            // 
            this.gbUnidadMedida.Controls.Add(this.lblUnidadMedida);
            this.gbUnidadMedida.Controls.Add(this.txtUnidadMedida);
            this.gbUnidadMedida.Location = new System.Drawing.Point(15, 33);
            this.gbUnidadMedida.Name = "gbUnidadMedida";
            this.gbUnidadMedida.Size = new System.Drawing.Size(493, 62);
            this.gbUnidadMedida.TabIndex = 0;
            this.gbUnidadMedida.TabStop = false;
            this.gbUnidadMedida.Text = "Medida";
            // 
            // lblUnidadMedida
            // 
            this.lblUnidadMedida.AutoSize = true;
            this.lblUnidadMedida.Location = new System.Drawing.Point(49, 28);
            this.lblUnidadMedida.Name = "lblUnidadMedida";
            this.lblUnidadMedida.Size = new System.Drawing.Size(54, 16);
            this.lblUnidadMedida.TabIndex = 1;
            this.lblUnidadMedida.Text = "Medida";
            // 
            // txtUnidadMedida
            // 
            this.txtUnidadMedida.Location = new System.Drawing.Point(121, 25);
            this.txtUnidadMedida.Name = "txtUnidadMedida";
            this.txtUnidadMedida.Size = new System.Drawing.Size(271, 22);
            this.txtUnidadMedida.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnguardar,
            this.tsMedidaSalir});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(520, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbtnguardar
            // 
            this.tsbtnguardar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnguardar.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnguardar.Image")));
            this.tsbtnguardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnguardar.Name = "tsbtnguardar";
            this.tsbtnguardar.Size = new System.Drawing.Size(76, 22);
            this.tsbtnguardar.Text = "Guardar";
            this.tsbtnguardar.Click += new System.EventHandler(this.tsbtnguardar_Click);
            // 
            // tsMedidaSalir
            // 
            this.tsMedidaSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsMedidaSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsMedidaSalir.Image")));
            this.tsMedidaSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsMedidaSalir.Name = "tsMedidaSalir";
            this.tsMedidaSalir.Size = new System.Drawing.Size(53, 22);
            this.tsMedidaSalir.Text = "Salir";
            this.tsMedidaSalir.Click += new System.EventHandler(this.tsMedidaSalir_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.toolStrip4);
            this.tabPage2.Controls.Add(this.gbListaValorUnidadMedida);
            this.tabPage2.Controls.Add(this.gbListaUnidadMedida);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(526, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultas";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnMedida,
            this.tsBtnUnidad,
            this.tsConsultaSalir,
            this.recurso});
            this.toolStrip4.Location = new System.Drawing.Point(3, 3);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(520, 25);
            this.toolStrip4.TabIndex = 4;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // tsConsultaSalir
            // 
            this.tsConsultaSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsConsultaSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsConsultaSalir.Image")));
            this.tsConsultaSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsConsultaSalir.Name = "tsConsultaSalir";
            this.tsConsultaSalir.Size = new System.Drawing.Size(53, 22);
            this.tsConsultaSalir.Text = "Salir";
            this.tsConsultaSalir.Click += new System.EventHandler(this.tsConsultaSalir_Click);
            // 
            // gbListaValorUnidadMedida
            // 
            this.gbListaValorUnidadMedida.Controls.Add(this.btnAgregarMedida);
            this.gbListaValorUnidadMedida.Controls.Add(this.txModificaValorMedida);
            this.gbListaValorUnidadMedida.Controls.Add(this.toolStrip3);
            this.gbListaValorUnidadMedida.Controls.Add(this.dgvValorMedida);
            this.gbListaValorUnidadMedida.Enabled = false;
            this.gbListaValorUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListaValorUnidadMedida.Location = new System.Drawing.Point(266, 31);
            this.gbListaValorUnidadMedida.Name = "gbListaValorUnidadMedida";
            this.gbListaValorUnidadMedida.Size = new System.Drawing.Size(254, 367);
            this.gbListaValorUnidadMedida.TabIndex = 3;
            this.gbListaValorUnidadMedida.TabStop = false;
            this.gbListaValorUnidadMedida.Text = "Unidad(es) de Medida";
            // 
            // btnAgregarMedida
            // 
            this.btnAgregarMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarMedida.Image")));
            this.btnAgregarMedida.Location = new System.Drawing.Point(224, 77);
            this.btnAgregarMedida.Name = "btnAgregarMedida";
            this.btnAgregarMedida.Size = new System.Drawing.Size(25, 24);
            this.btnAgregarMedida.TabIndex = 4;
            this.btnAgregarMedida.UseVisualStyleBackColor = true;
            this.btnAgregarMedida.Click += new System.EventHandler(this.btnAgregarMedida_Click);
            // 
            // txModificaValorMedida
            // 
            this.txModificaValorMedida.Location = new System.Drawing.Point(31, 50);
            this.txModificaValorMedida.Name = "txModificaValorMedida";
            this.txModificaValorMedida.Size = new System.Drawing.Size(193, 22);
            this.txModificaValorMedida.TabIndex = 3;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificarValorMedida,
            this.tsbtnGuardarModificarValorMedida,
            this.tsbtnEliminarValorMedida});
            this.toolStrip3.Location = new System.Drawing.Point(3, 18);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(248, 25);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbtnModificarValorMedida
            // 
            this.tsbtnModificarValorMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnModificarValorMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificarValorMedida.Image")));
            this.tsbtnModificarValorMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificarValorMedida.Name = "tsbtnModificarValorMedida";
            this.tsbtnModificarValorMedida.Size = new System.Drawing.Size(84, 22);
            this.tsbtnModificarValorMedida.Text = "Modificar";
            this.tsbtnModificarValorMedida.Click += new System.EventHandler(this.tsbtnModificarValorMedida_Click);
            // 
            // tsbtnGuardarModificarValorMedida
            // 
            this.tsbtnGuardarModificarValorMedida.Enabled = false;
            this.tsbtnGuardarModificarValorMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnGuardarModificarValorMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarModificarValorMedida.Image")));
            this.tsbtnGuardarModificarValorMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarModificarValorMedida.Name = "tsbtnGuardarModificarValorMedida";
            this.tsbtnGuardarModificarValorMedida.Size = new System.Drawing.Size(76, 22);
            this.tsbtnGuardarModificarValorMedida.Text = "Guardar";
            this.tsbtnGuardarModificarValorMedida.Click += new System.EventHandler(this.tsbtnGuardarModificarValorMedida_Click);
            // 
            // tsbtnEliminarValorMedida
            // 
            this.tsbtnEliminarValorMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnEliminarValorMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminarValorMedida.Image")));
            this.tsbtnEliminarValorMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminarValorMedida.Name = "tsbtnEliminarValorMedida";
            this.tsbtnEliminarValorMedida.Size = new System.Drawing.Size(74, 22);
            this.tsbtnEliminarValorMedida.Text = "Eliminar";
            this.tsbtnEliminarValorMedida.Click += new System.EventHandler(this.tsbtnEliminarValorMedida_Click);
            // 
            // dgvValorMedida
            // 
            this.dgvValorMedida.AllowUserToAddRows = false;
            this.dgvValorMedida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvValorMedida.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvValorMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValorMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdM,
            this.IdU_M,
            this.NombreM});
            this.dgvValorMedida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvValorMedida.Location = new System.Drawing.Point(31, 78);
            this.dgvValorMedida.Name = "dgvValorMedida";
            this.dgvValorMedida.Size = new System.Drawing.Size(193, 270);
            this.dgvValorMedida.TabIndex = 1;
            // 
            // IdM
            // 
            this.IdM.DataPropertyName = "idvalor_unidad_medida";
            this.IdM.HeaderText = "Id";
            this.IdM.Name = "IdM";
            this.IdM.Visible = false;
            // 
            // IdU_M
            // 
            this.IdU_M.DataPropertyName = "idunidad_medida";
            this.IdU_M.HeaderText = "Id";
            this.IdU_M.Name = "IdU_M";
            this.IdU_M.Visible = false;
            // 
            // NombreM
            // 
            this.NombreM.DataPropertyName = "descripcionvalor_unidad_medida";
            this.NombreM.HeaderText = "Nombre";
            this.NombreM.Name = "NombreM";
            // 
            // gbListaUnidadMedida
            // 
            this.gbListaUnidadMedida.Controls.Add(this.txModificaUnidadMedida);
            this.gbListaUnidadMedida.Controls.Add(this.toolStrip2);
            this.gbListaUnidadMedida.Controls.Add(this.dgvUnidadMedida);
            this.gbListaUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbListaUnidadMedida.Location = new System.Drawing.Point(6, 31);
            this.gbListaUnidadMedida.Name = "gbListaUnidadMedida";
            this.gbListaUnidadMedida.Size = new System.Drawing.Size(254, 367);
            this.gbListaUnidadMedida.TabIndex = 2;
            this.gbListaUnidadMedida.TabStop = false;
            this.gbListaUnidadMedida.Text = "Medidas";
            // 
            // txModificaUnidadMedida
            // 
            this.txModificaUnidadMedida.Location = new System.Drawing.Point(28, 50);
            this.txModificaUnidadMedida.Name = "txModificaUnidadMedida";
            this.txModificaUnidadMedida.Size = new System.Drawing.Size(196, 22);
            this.txModificaUnidadMedida.TabIndex = 2;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbtnModificarUnidadMedida,
            this.tsbtnGuardarModificarUnidadMedida,
            this.tsbtnEliminarUnidadMedida});
            this.toolStrip2.Location = new System.Drawing.Point(3, 18);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(248, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbtnModificarUnidadMedida
            // 
            this.tsbtnModificarUnidadMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnModificarUnidadMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnModificarUnidadMedida.Image")));
            this.tsbtnModificarUnidadMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnModificarUnidadMedida.Name = "tsbtnModificarUnidadMedida";
            this.tsbtnModificarUnidadMedida.Size = new System.Drawing.Size(84, 22);
            this.tsbtnModificarUnidadMedida.Text = "Modificar";
            this.tsbtnModificarUnidadMedida.Click += new System.EventHandler(this.tsbtnModificarUnidadMedida_Click);
            // 
            // tsbtnGuardarModificarUnidadMedida
            // 
            this.tsbtnGuardarModificarUnidadMedida.Enabled = false;
            this.tsbtnGuardarModificarUnidadMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnGuardarModificarUnidadMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnGuardarModificarUnidadMedida.Image")));
            this.tsbtnGuardarModificarUnidadMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnGuardarModificarUnidadMedida.Name = "tsbtnGuardarModificarUnidadMedida";
            this.tsbtnGuardarModificarUnidadMedida.Size = new System.Drawing.Size(76, 22);
            this.tsbtnGuardarModificarUnidadMedida.Text = "Guardar";
            this.tsbtnGuardarModificarUnidadMedida.Click += new System.EventHandler(this.tsbtnGuardarModificarUnidadMedida_Click);
            // 
            // tsbtnEliminarUnidadMedida
            // 
            this.tsbtnEliminarUnidadMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsbtnEliminarUnidadMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsbtnEliminarUnidadMedida.Image")));
            this.tsbtnEliminarUnidadMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbtnEliminarUnidadMedida.Name = "tsbtnEliminarUnidadMedida";
            this.tsbtnEliminarUnidadMedida.Size = new System.Drawing.Size(74, 22);
            this.tsbtnEliminarUnidadMedida.Text = "Eliminar";
            this.tsbtnEliminarUnidadMedida.Click += new System.EventHandler(this.tsbtnEliminarUnidadMedida_Click);
            // 
            // dgvUnidadMedida
            // 
            this.dgvUnidadMedida.AllowUserToAddRows = false;
            this.dgvUnidadMedida.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUnidadMedida.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUnidadMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnidadMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdU,
            this.NombreU});
            this.dgvUnidadMedida.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvUnidadMedida.Location = new System.Drawing.Point(28, 78);
            this.dgvUnidadMedida.Name = "dgvUnidadMedida";
            this.dgvUnidadMedida.Size = new System.Drawing.Size(196, 270);
            this.dgvUnidadMedida.TabIndex = 0;
            // 
            // IdU
            // 
            this.IdU.DataPropertyName = "idunidad_medida";
            this.IdU.HeaderText = "Id";
            this.IdU.Name = "IdU";
            this.IdU.Visible = false;
            // 
            // NombreU
            // 
            this.NombreU.DataPropertyName = "descripcionunidad_medida";
            this.NombreU.HeaderText = "Nombre";
            this.NombreU.Name = "NombreU";
            // 
            // tsBtnMedida
            // 
            this.tsBtnMedida.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnMedida.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnMedida.Image")));
            this.tsBtnMedida.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnMedida.Name = "tsBtnMedida";
            this.tsBtnMedida.Size = new System.Drawing.Size(73, 22);
            this.tsBtnMedida.Text = "Medida";
            this.tsBtnMedida.Click += new System.EventHandler(this.tsBtnMedida_Click);
            // 
            // tsBtnUnidad
            // 
            this.tsBtnUnidad.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnUnidad.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnUnidad.Image")));
            this.tsBtnUnidad.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnUnidad.Name = "tsBtnUnidad";
            this.tsBtnUnidad.Size = new System.Drawing.Size(70, 22);
            this.tsBtnUnidad.Text = "Unidad";
            this.tsBtnUnidad.Click += new System.EventHandler(this.tsBtnUnidad_Click);
            // 
            // recurso
            // 
            this.recurso.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.recurso.Image = ((System.Drawing.Image)(resources.GetObject("recurso.Image")));
            this.recurso.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.recurso.Name = "recurso";
            this.recurso.Size = new System.Drawing.Size(23, 22);
            this.recurso.Text = "toolStripButton1";
            this.recurso.Visible = false;
            // 
            // frmmedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(536, 437);
            this.Controls.Add(this.tcMedida);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmmedida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unidades de Medida";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmmedida_FormClosing);
            this.Load += new System.EventHandler(this.frmmedida_Load);
            this.tcMedida.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.gbValorUnidadMedida.ResumeLayout(false);
            this.gbValorUnidadMedida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbValorUnidadMedida)).EndInit();
            this.gbUnidadMedida.ResumeLayout(false);
            this.gbUnidadMedida.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.gbListaValorUnidadMedida.ResumeLayout(false);
            this.gbListaValorUnidadMedida.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValorMedida)).EndInit();
            this.gbListaUnidadMedida.ResumeLayout(false);
            this.gbListaUnidadMedida.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnidadMedida)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcMedida;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbValorUnidadMedida;
        private System.Windows.Forms.DataGridView dgbValorUnidadMedida;
        private System.Windows.Forms.TextBox txtValorMedida;
        private System.Windows.Forms.Button btnEliminarValorUnidadMedida;
        private System.Windows.Forms.Button btnGuardarValorMedida;
        private System.Windows.Forms.GroupBox gbUnidadMedida;
        private System.Windows.Forms.Label lblUnidadMedida;
        private System.Windows.Forms.TextBox txtUnidadMedida;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbtnguardar;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox gbListaValorUnidadMedida;
        private System.Windows.Forms.DataGridView dgvValorMedida;
        private System.Windows.Forms.GroupBox gbListaUnidadMedida;
        private System.Windows.Forms.DataGridView dgvUnidadMedida;
        private System.Windows.Forms.TextBox txModificaValorMedida;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbtnModificarValorMedida;
        private System.Windows.Forms.ToolStripButton tsbtnEliminarValorMedida;
        private System.Windows.Forms.TextBox txModificaUnidadMedida;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbtnModificarUnidadMedida;
        private System.Windows.Forms.ToolStripButton tsbtnEliminarUnidadMedida;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarModificarValorMedida;
        private System.Windows.Forms.ToolStripButton tsbtnGuardarModificarUnidadMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdU;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreU;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdM;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdU_M;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreM;
        private System.Windows.Forms.Button btnAgregarMedida;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripButton tsConsultaSalir;
        private System.Windows.Forms.ToolStripButton tsMedidaSalir;
        private System.Windows.Forms.ToolStripButton tsBtnMedida;
        private System.Windows.Forms.ToolStripButton tsBtnUnidad;
        private System.Windows.Forms.ToolStripButton recurso;

    }
}