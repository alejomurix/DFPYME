namespace Aplicacion.Inventario.Bodega
{
    partial class frmBodega
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBodega));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpIngresarBodega = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUbicacionBodega = new System.Windows.Forms.TextBox();
            this.txtNombreBodega = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardarBodega = new System.Windows.Forms.ToolStripButton();
            this.tpConsultarBodega = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsListabodega = new System.Windows.Forms.ToolStripButton();
            this.tsbEditarBodega = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminarBodega = new System.Windows.Forms.ToolStripButton();
            this.gbModificaBodega = new System.Windows.Forms.GroupBox();
            this.lblModificaUbicacion = new System.Windows.Forms.Label();
            this.lblModificaBodega = new System.Windows.Forms.Label();
            this.txtModificarUbicacion = new System.Windows.Forms.TextBox();
            this.txtModificarBodega = new System.Windows.Forms.TextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsGuardaBodega = new System.Windows.Forms.ToolStripButton();
            this.gbBuscarBodegaNombre = new System.Windows.Forms.GroupBox();
            this.btnBuscarBodegaNombre = new System.Windows.Forms.Button();
            this.txtBusquedaNombreBodega = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grillabodega = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tpIngresarBodega.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tpConsultarBodega.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.gbModificaBodega.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.gbBuscarBodegaNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillabodega)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpIngresarBodega);
            this.tabControl1.Controls.Add(this.tpConsultarBodega);
            this.tabControl1.Location = new System.Drawing.Point(0, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(519, 456);
            this.tabControl1.TabIndex = 0;
            // 
            // tpIngresarBodega
            // 
            this.tpIngresarBodega.Controls.Add(this.groupBox1);
            this.tpIngresarBodega.Controls.Add(this.toolStrip1);
            this.tpIngresarBodega.Location = new System.Drawing.Point(4, 25);
            this.tpIngresarBodega.Name = "tpIngresarBodega";
            this.tpIngresarBodega.Padding = new System.Windows.Forms.Padding(3);
            this.tpIngresarBodega.Size = new System.Drawing.Size(511, 427);
            this.tpIngresarBodega.TabIndex = 0;
            this.tpIngresarBodega.Text = "Ingresar Bodega";
            this.tpIngresarBodega.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtUbicacionBodega);
            this.groupBox1.Controls.Add(this.txtNombreBodega);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(19, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 118);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Bodega";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre";
            // 
            // txtUbicacionBodega
            // 
            this.txtUbicacionBodega.Location = new System.Drawing.Point(103, 76);
            this.txtUbicacionBodega.Name = "txtUbicacionBodega";
            this.txtUbicacionBodega.Size = new System.Drawing.Size(274, 22);
            this.txtUbicacionBodega.TabIndex = 4;
            this.txtUbicacionBodega.Validating += new System.ComponentModel.CancelEventHandler(this.txtUbicacionBodega_Validating);
            // 
            // txtNombreBodega
            // 
            this.txtNombreBodega.Location = new System.Drawing.Point(103, 40);
            this.txtNombreBodega.Name = "txtNombreBodega";
            this.txtNombreBodega.Size = new System.Drawing.Size(274, 22);
            this.txtNombreBodega.TabIndex = 1;
            this.txtNombreBodega.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreBodega_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ubicación";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardarBodega});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(505, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardarBodega
            // 
            this.tsbGuardarBodega.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardarBodega.Image")));
            this.tsbGuardarBodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarBodega.Name = "tsbGuardarBodega";
            this.tsbGuardarBodega.Size = new System.Drawing.Size(74, 22);
            this.tsbGuardarBodega.Text = "Guardar";
            this.tsbGuardarBodega.Click += new System.EventHandler(this.tsbGuardarBodega_Click);
            // 
            // tpConsultarBodega
            // 
            this.tpConsultarBodega.BackColor = System.Drawing.SystemColors.Window;
            this.tpConsultarBodega.Controls.Add(this.toolStrip3);
            this.tpConsultarBodega.Controls.Add(this.gbModificaBodega);
            this.tpConsultarBodega.Controls.Add(this.gbBuscarBodegaNombre);
            this.tpConsultarBodega.Controls.Add(this.grillabodega);
            this.tpConsultarBodega.Location = new System.Drawing.Point(4, 25);
            this.tpConsultarBodega.Name = "tpConsultarBodega";
            this.tpConsultarBodega.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultarBodega.Size = new System.Drawing.Size(511, 427);
            this.tpConsultarBodega.TabIndex = 1;
            this.tpConsultarBodega.Text = "Consultar Bodega";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsListabodega,
            this.tsbEditarBodega,
            this.tsbEliminarBodega});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(505, 25);
            this.toolStrip3.TabIndex = 2;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsListabodega
            // 
            this.tsListabodega.Image = ((System.Drawing.Image)(resources.GetObject("tsListabodega.Image")));
            this.tsListabodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsListabodega.Name = "tsListabodega";
            this.tsListabodega.Size = new System.Drawing.Size(111, 22);
            this.tsListabodega.Text = "Listar bodegas";
            this.tsListabodega.Click += new System.EventHandler(this.tsbListarBodegas_Click);
            // 
            // tsbEditarBodega
            // 
            this.tsbEditarBodega.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditarBodega.Image")));
            this.tsbEditarBodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditarBodega.Name = "tsbEditarBodega";
            this.tsbEditarBodega.Size = new System.Drawing.Size(61, 22);
            this.tsbEditarBodega.Text = "Editar";
            this.tsbEditarBodega.Click += new System.EventHandler(this.tsbEditarBodega_Click);
            // 
            // tsbEliminarBodega
            // 
            this.tsbEliminarBodega.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminarBodega.Image")));
            this.tsbEliminarBodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminarBodega.Name = "tsbEliminarBodega";
            this.tsbEliminarBodega.Size = new System.Drawing.Size(74, 22);
            this.tsbEliminarBodega.Text = "Eliminar";
            this.tsbEliminarBodega.Click += new System.EventHandler(this.tsbEliminarBodega_Click);
            // 
            // gbModificaBodega
            // 
            this.gbModificaBodega.Controls.Add(this.lblModificaUbicacion);
            this.gbModificaBodega.Controls.Add(this.lblModificaBodega);
            this.gbModificaBodega.Controls.Add(this.txtModificarUbicacion);
            this.gbModificaBodega.Controls.Add(this.txtModificarBodega);
            this.gbModificaBodega.Controls.Add(this.toolStrip2);
            this.gbModificaBodega.Enabled = false;
            this.gbModificaBodega.Location = new System.Drawing.Point(253, 40);
            this.gbModificaBodega.Name = "gbModificaBodega";
            this.gbModificaBodega.Size = new System.Drawing.Size(251, 129);
            this.gbModificaBodega.TabIndex = 4;
            this.gbModificaBodega.TabStop = false;
            this.gbModificaBodega.Text = "Modificaar bodega ";
            // 
            // lblModificaUbicacion
            // 
            this.lblModificaUbicacion.AutoSize = true;
            this.lblModificaUbicacion.Location = new System.Drawing.Point(6, 92);
            this.lblModificaUbicacion.Name = "lblModificaUbicacion";
            this.lblModificaUbicacion.Size = new System.Drawing.Size(69, 16);
            this.lblModificaUbicacion.TabIndex = 4;
            this.lblModificaUbicacion.Text = "Ubicaciòn";
            // 
            // lblModificaBodega
            // 
            this.lblModificaBodega.AutoSize = true;
            this.lblModificaBodega.Location = new System.Drawing.Point(6, 58);
            this.lblModificaBodega.Name = "lblModificaBodega";
            this.lblModificaBodega.Size = new System.Drawing.Size(57, 16);
            this.lblModificaBodega.TabIndex = 3;
            this.lblModificaBodega.Text = "Nombre";
            // 
            // txtModificarUbicacion
            // 
            this.txtModificarUbicacion.Location = new System.Drawing.Point(77, 89);
            this.txtModificarUbicacion.Name = "txtModificarUbicacion";
            this.txtModificarUbicacion.Size = new System.Drawing.Size(149, 22);
            this.txtModificarUbicacion.TabIndex = 2;
            this.txtModificarUbicacion.Validating += new System.ComponentModel.CancelEventHandler(this.txtModificarUbicacion_Validating);
            // 
            // txtModificarBodega
            // 
            this.txtModificarBodega.Location = new System.Drawing.Point(75, 58);
            this.txtModificarBodega.Name = "txtModificarBodega";
            this.txtModificarBodega.Size = new System.Drawing.Size(149, 22);
            this.txtModificarBodega.TabIndex = 1;
            this.txtModificarBodega.Validating += new System.ComponentModel.CancelEventHandler(this.txtModificarBodega_Validating);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsGuardaBodega});
            this.toolStrip2.Location = new System.Drawing.Point(3, 18);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(245, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsGuardaBodega
            // 
            this.tsGuardaBodega.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsGuardaBodega.Image = ((System.Drawing.Image)(resources.GetObject("tsGuardaBodega.Image")));
            this.tsGuardaBodega.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsGuardaBodega.Name = "tsGuardaBodega";
            this.tsGuardaBodega.Size = new System.Drawing.Size(23, 22);
            this.tsGuardaBodega.Text = "tsModificaGuardaBodega";
            this.tsGuardaBodega.Click += new System.EventHandler(this.tsGuardaBodega_Click);
            // 
            // gbBuscarBodegaNombre
            // 
            this.gbBuscarBodegaNombre.Controls.Add(this.btnBuscarBodegaNombre);
            this.gbBuscarBodegaNombre.Controls.Add(this.txtBusquedaNombreBodega);
            this.gbBuscarBodegaNombre.Controls.Add(this.label3);
            this.gbBuscarBodegaNombre.Location = new System.Drawing.Point(15, 40);
            this.gbBuscarBodegaNombre.Name = "gbBuscarBodegaNombre";
            this.gbBuscarBodegaNombre.Size = new System.Drawing.Size(232, 129);
            this.gbBuscarBodegaNombre.TabIndex = 3;
            this.gbBuscarBodegaNombre.TabStop = false;
            this.gbBuscarBodegaNombre.Text = "Buscar Bodega";
            // 
            // btnBuscarBodegaNombre
            // 
            this.btnBuscarBodegaNombre.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscarBodegaNombre.Image")));
            this.btnBuscarBodegaNombre.Location = new System.Drawing.Point(190, 67);
            this.btnBuscarBodegaNombre.Name = "btnBuscarBodegaNombre";
            this.btnBuscarBodegaNombre.Size = new System.Drawing.Size(33, 22);
            this.btnBuscarBodegaNombre.TabIndex = 2;
            this.btnBuscarBodegaNombre.UseVisualStyleBackColor = true;
            this.btnBuscarBodegaNombre.Click += new System.EventHandler(this.btnBuscarBodegaNombre_Click);
            // 
            // txtBusquedaNombreBodega
            // 
            this.txtBusquedaNombreBodega.Location = new System.Drawing.Point(6, 67);
            this.txtBusquedaNombreBodega.Name = "txtBusquedaNombreBodega";
            this.txtBusquedaNombreBodega.Size = new System.Drawing.Size(164, 22);
            this.txtBusquedaNombreBodega.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Por Nombre";
            // 
            // grillabodega
            // 
            this.grillabodega.AllowUserToAddRows = false;
            this.grillabodega.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grillabodega.BackgroundColor = System.Drawing.SystemColors.Window;
            this.grillabodega.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.grillabodega.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grillabodega.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3});
            this.grillabodega.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grillabodega.GridColor = System.Drawing.SystemColors.Window;
            this.grillabodega.Location = new System.Drawing.Point(3, 195);
            this.grillabodega.Name = "grillabodega";
            this.grillabodega.Size = new System.Drawing.Size(501, 212);
            this.grillabodega.TabIndex = 1;
            this.grillabodega.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grillabodega_CellContentDoubleClick);
            this.grillabodega.Click += new System.EventHandler(this.grillabodega_Click);
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "NombreBodega";
            this.Column2.HeaderText = "Nombre Bodega";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "LugarBodega";
            this.Column3.HeaderText = "Ubicación Bodega";
            this.Column3.Name = "Column3";
            // 
            // frmBodega
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 470);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmBodega";
            this.Text = "Bodega";
            this.Load += new System.EventHandler(this.frmBodega_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpIngresarBodega.ResumeLayout(false);
            this.tpIngresarBodega.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tpConsultarBodega.ResumeLayout(false);
            this.tpConsultarBodega.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.gbModificaBodega.ResumeLayout(false);
            this.gbModificaBodega.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.gbBuscarBodegaNombre.ResumeLayout(false);
            this.gbBuscarBodegaNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grillabodega)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpIngresarBodega;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabPage tpConsultarBodega;
        private System.Windows.Forms.TextBox txtUbicacionBodega;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombreBodega;
        private System.Windows.Forms.ToolStripButton tsbGuardarBodega;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbEditarBodega;
        private System.Windows.Forms.DataGridView grillabodega;
        private System.Windows.Forms.ToolStripButton tsbEliminarBodega;
        private System.Windows.Forms.GroupBox gbBuscarBodegaNombre;
        private System.Windows.Forms.Button btnBuscarBodegaNombre;
        private System.Windows.Forms.TextBox txtBusquedaNombreBodega;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStripButton tsListabodega;
        private System.Windows.Forms.GroupBox gbModificaBodega;
        private System.Windows.Forms.Label lblModificaUbicacion;
        private System.Windows.Forms.Label lblModificaBodega;
        private System.Windows.Forms.TextBox txtModificarUbicacion;
        private System.Windows.Forms.TextBox txtModificarBodega;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsGuardaBodega;
    }
}