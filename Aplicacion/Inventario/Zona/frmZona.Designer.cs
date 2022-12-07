namespace Aplicacion.Inventario.Zona
{
    partial class frmZona
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmZona));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpIngresarZona = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUbicacionBodega = new System.Windows.Forms.TextBox();
            this.txtNombreBodega = new System.Windows.Forms.TextBox();
            this.btnAgregarBodegaZona = new System.Windows.Forms.Button();
            this.gbInfoZona = new System.Windows.Forms.GroupBox();
            this.txtCapacidadZona = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNumeroZona = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreZona = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbGuardarZona = new System.Windows.Forms.ToolStripButton();
            this.tpConsultarZona = new System.Windows.Forms.TabPage();
            this.gbBuscarZonaNombre = new System.Windows.Forms.GroupBox();
            this.cbxBusquedaZona = new System.Windows.Forms.ComboBox();
            this.txtBuscarZona = new System.Windows.Forms.TextBox();
            this.btnListarZona = new System.Windows.Forms.Button();
            this.dgbZona = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbbtnListarZona = new System.Windows.Forms.ToolStripButton();
            this.tsbEditarZona = new System.Windows.Forms.ToolStripButton();
            this.tsbEliminarZona = new System.Windows.Forms.ToolStripButton();
            this.tsbSalirConsultarZona = new System.Windows.Forms.ToolStripButton();
            this.tsbbtnsalir = new System.Windows.Forms.ToolStripButton();
            this.tabControl1.SuspendLayout();
            this.tpIngresarZona.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbInfoZona.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tpConsultarZona.SuspendLayout();
            this.gbBuscarZonaNombre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbZona)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpIngresarZona);
            this.tabControl1.Controls.Add(this.tpConsultarZona);
            this.tabControl1.Location = new System.Drawing.Point(2, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(564, 318);
            this.tabControl1.TabIndex = 0;
            // 
            // tpIngresarZona
            // 
            this.tpIngresarZona.Controls.Add(this.groupBox1);
            this.tpIngresarZona.Controls.Add(this.gbInfoZona);
            this.tpIngresarZona.Controls.Add(this.toolStrip1);
            this.tpIngresarZona.Location = new System.Drawing.Point(4, 25);
            this.tpIngresarZona.Name = "tpIngresarZona";
            this.tpIngresarZona.Padding = new System.Windows.Forms.Padding(3);
            this.tpIngresarZona.Size = new System.Drawing.Size(556, 289);
            this.tpIngresarZona.TabIndex = 0;
            this.tpIngresarZona.Text = "Ingresar Zona";
            this.tpIngresarZona.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtUbicacionBodega);
            this.groupBox1.Controls.Add(this.txtNombreBodega);
            this.groupBox1.Controls.Add(this.btnAgregarBodegaZona);
            this.groupBox1.Location = new System.Drawing.Point(20, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 81);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Información Bodega";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Ubicación";
            // 
            // txtUbicacionBodega
            // 
            this.txtUbicacionBodega.Enabled = false;
            this.txtUbicacionBodega.Location = new System.Drawing.Point(271, 43);
            this.txtUbicacionBodega.Name = "txtUbicacionBodega";
            this.txtUbicacionBodega.Size = new System.Drawing.Size(100, 22);
            this.txtUbicacionBodega.TabIndex = 3;
            // 
            // txtNombreBodega
            // 
            this.txtNombreBodega.Enabled = false;
            this.txtNombreBodega.Location = new System.Drawing.Point(78, 40);
            this.txtNombreBodega.Name = "txtNombreBodega";
            this.txtNombreBodega.Size = new System.Drawing.Size(100, 22);
            this.txtNombreBodega.TabIndex = 2;
            this.txtNombreBodega.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreBodega_Validating);
            // 
            // btnAgregarBodegaZona
            // 
            this.btnAgregarBodegaZona.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarBodegaZona.Image")));
            this.btnAgregarBodegaZona.Location = new System.Drawing.Point(387, 39);
            this.btnAgregarBodegaZona.Name = "btnAgregarBodegaZona";
            this.btnAgregarBodegaZona.Size = new System.Drawing.Size(31, 30);
            this.btnAgregarBodegaZona.TabIndex = 0;
            this.btnAgregarBodegaZona.UseVisualStyleBackColor = true;
            this.btnAgregarBodegaZona.Click += new System.EventHandler(this.btnAgregarBodegaZona_Click);
            // 
            // gbInfoZona
            // 
            this.gbInfoZona.Controls.Add(this.txtCapacidadZona);
            this.gbInfoZona.Controls.Add(this.label3);
            this.gbInfoZona.Controls.Add(this.txtNumeroZona);
            this.gbInfoZona.Controls.Add(this.label2);
            this.gbInfoZona.Controls.Add(this.txtNombreZona);
            this.gbInfoZona.Controls.Add(this.label1);
            this.gbInfoZona.Location = new System.Drawing.Point(20, 50);
            this.gbInfoZona.Name = "gbInfoZona";
            this.gbInfoZona.Size = new System.Drawing.Size(530, 81);
            this.gbInfoZona.TabIndex = 2;
            this.gbInfoZona.TabStop = false;
            this.gbInfoZona.Text = "Información Zona";
            // 
            // txtCapacidadZona
            // 
            this.txtCapacidadZona.Location = new System.Drawing.Point(406, 33);
            this.txtCapacidadZona.Name = "txtCapacidadZona";
            this.txtCapacidadZona.Size = new System.Drawing.Size(103, 22);
            this.txtCapacidadZona.TabIndex = 6;
            this.txtCapacidadZona.Validating += new System.ComponentModel.CancelEventHandler(this.txtCapacidadZona_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(332, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "Capacidad";
            // 
            // txtNumeroZona
            // 
            this.txtNumeroZona.Location = new System.Drawing.Point(250, 30);
            this.txtNumeroZona.Name = "txtNumeroZona";
            this.txtNumeroZona.Size = new System.Drawing.Size(57, 22);
            this.txtNumeroZona.TabIndex = 3;
            this.txtNumeroZona.Validating += new System.ComponentModel.CancelEventHandler(this.txtNumeroZona_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Numero ";
            // 
            // txtNombreZona
            // 
            this.txtNombreZona.Location = new System.Drawing.Point(78, 30);
            this.txtNombreZona.Name = "txtNombreZona";
            this.txtNombreZona.Size = new System.Drawing.Size(100, 22);
            this.txtNombreZona.TabIndex = 1;
            this.txtNombreZona.Validating += new System.ComponentModel.CancelEventHandler(this.txtNombreZona_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre ";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbGuardarZona,
            this.tsbbtnsalir});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(550, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbGuardarZona
            // 
            this.tsbGuardarZona.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsbGuardarZona.Image = ((System.Drawing.Image)(resources.GetObject("tsbGuardarZona.Image")));
            this.tsbGuardarZona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbGuardarZona.Name = "tsbGuardarZona";
            this.tsbGuardarZona.Size = new System.Drawing.Size(74, 22);
            this.tsbGuardarZona.Text = "Guardar";
            this.tsbGuardarZona.Click += new System.EventHandler(this.tsbGuardarZona_Click);
            // 
            // tpConsultarZona
            // 
            this.tpConsultarZona.Controls.Add(this.gbBuscarZonaNombre);
            this.tpConsultarZona.Controls.Add(this.dgbZona);
            this.tpConsultarZona.Controls.Add(this.toolStrip3);
            this.tpConsultarZona.Location = new System.Drawing.Point(4, 25);
            this.tpConsultarZona.Name = "tpConsultarZona";
            this.tpConsultarZona.Padding = new System.Windows.Forms.Padding(3);
            this.tpConsultarZona.Size = new System.Drawing.Size(545, 289);
            this.tpConsultarZona.TabIndex = 1;
            this.tpConsultarZona.Text = "Consultar Zona";
            this.tpConsultarZona.UseVisualStyleBackColor = true;
            // 
            // gbBuscarZonaNombre
            // 
            this.gbBuscarZonaNombre.Controls.Add(this.cbxBusquedaZona);
            this.gbBuscarZonaNombre.Controls.Add(this.txtBuscarZona);
            this.gbBuscarZonaNombre.Controls.Add(this.btnListarZona);
            this.gbBuscarZonaNombre.Location = new System.Drawing.Point(8, 56);
            this.gbBuscarZonaNombre.Name = "gbBuscarZonaNombre";
            this.gbBuscarZonaNombre.Size = new System.Drawing.Size(526, 67);
            this.gbBuscarZonaNombre.TabIndex = 3;
            this.gbBuscarZonaNombre.TabStop = false;
            this.gbBuscarZonaNombre.Text = "Buscar Zona";
            // 
            // cbxBusquedaZona
            // 
            this.cbxBusquedaZona.DisplayMember = "Nombre";
            this.cbxBusquedaZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBusquedaZona.FormattingEnabled = true;
            this.cbxBusquedaZona.Location = new System.Drawing.Point(22, 21);
            this.cbxBusquedaZona.Name = "cbxBusquedaZona";
            this.cbxBusquedaZona.Size = new System.Drawing.Size(168, 24);
            this.cbxBusquedaZona.TabIndex = 4;
            this.cbxBusquedaZona.ValueMember = "id";
            // 
            // txtBuscarZona
            // 
            this.txtBuscarZona.Location = new System.Drawing.Point(237, 23);
            this.txtBuscarZona.Name = "txtBuscarZona";
            this.txtBuscarZona.Size = new System.Drawing.Size(177, 22);
            this.txtBuscarZona.TabIndex = 1;
            // 
            // btnListarZona
            // 
            this.btnListarZona.Image = ((System.Drawing.Image)(resources.GetObject("btnListarZona.Image")));
            this.btnListarZona.Location = new System.Drawing.Point(461, 18);
            this.btnListarZona.Name = "btnListarZona";
            this.btnListarZona.Size = new System.Drawing.Size(38, 33);
            this.btnListarZona.TabIndex = 0;
            this.btnListarZona.UseVisualStyleBackColor = true;
            this.btnListarZona.Click += new System.EventHandler(this.btnListarZonaNombre_Click);
            // 
            // dgbZona
            // 
            this.dgbZona.AllowUserToAddRows = false;
            this.dgbZona.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgbZona.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgbZona.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgbZona.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column5,
            this.Column4,
            this.Column3,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dgbZona.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgbZona.Location = new System.Drawing.Point(8, 127);
            this.dgbZona.Name = "dgbZona";
            this.dgbZona.Size = new System.Drawing.Size(526, 156);
            this.dgbZona.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "IdZona";
            this.Column1.HeaderText = "Idzona";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "NombreZona";
            this.Column5.HeaderText = "Nombre";
            this.Column5.Name = "Column5";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "NumeroZona";
            this.Column4.HeaderText = "Numero";
            this.Column4.Name = "Column4";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Capacidad";
            this.Column3.HeaderText = "Capacidad";
            this.Column3.Name = "Column3";
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TextoDisponibleZona";
            this.Column6.HeaderText = "Disponible";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "NombreBodega";
            this.Column7.HeaderText = "Bodega";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "LugarBodega";
            this.Column8.HeaderText = "Lugar de Bodega";
            this.Column8.Name = "Column8";
            // 
            // toolStrip3
            // 
            this.toolStrip3.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbbtnListarZona,
            this.tsbEditarZona,
            this.tsbEliminarZona,
            this.tsbSalirConsultarZona});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(539, 25);
            this.toolStrip3.TabIndex = 1;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // tsbbtnListarZona
            // 
            this.tsbbtnListarZona.Image = ((System.Drawing.Image)(resources.GetObject("tsbbtnListarZona.Image")));
            this.tsbbtnListarZona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbbtnListarZona.Name = "tsbbtnListarZona";
            this.tsbbtnListarZona.Size = new System.Drawing.Size(59, 22);
            this.tsbbtnListarZona.Text = "Listar";
            this.tsbbtnListarZona.Click += new System.EventHandler(this.tsbListarTodas_Click);
            // 
            // tsbEditarZona
            // 
            this.tsbEditarZona.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditarZona.Image")));
            this.tsbEditarZona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditarZona.Name = "tsbEditarZona";
            this.tsbEditarZona.Size = new System.Drawing.Size(61, 22);
            this.tsbEditarZona.Text = "Editar";
            this.tsbEditarZona.Click += new System.EventHandler(this.tsbEditarZona_Click);
            // 
            // tsbEliminarZona
            // 
            this.tsbEliminarZona.Image = ((System.Drawing.Image)(resources.GetObject("tsbEliminarZona.Image")));
            this.tsbEliminarZona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEliminarZona.Name = "tsbEliminarZona";
            this.tsbEliminarZona.Size = new System.Drawing.Size(74, 22);
            this.tsbEliminarZona.Text = "Eliminar";
            this.tsbEliminarZona.Click += new System.EventHandler(this.tsbEliminarZona_Click);
            // 
            // tsbSalirConsultarZona
            // 
            this.tsbSalirConsultarZona.Image = ((System.Drawing.Image)(resources.GetObject("tsbSalirConsultarZona.Image")));
            this.tsbSalirConsultarZona.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSalirConsultarZona.Name = "tsbSalirConsultarZona";
            this.tsbSalirConsultarZona.Size = new System.Drawing.Size(54, 22);
            this.tsbSalirConsultarZona.Text = "Salir";
            // 
            // tsbbtnsalir
            // 
            this.tsbbtnsalir.Image = ((System.Drawing.Image)(resources.GetObject("tsbbtnsalir.Image")));
            this.tsbbtnsalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbbtnsalir.Name = "tsbbtnsalir";
            this.tsbbtnsalir.Size = new System.Drawing.Size(49, 22);
            this.tsbbtnsalir.Text = "Salir";
            this.tsbbtnsalir.Click += new System.EventHandler(this.tsbbtnsalir_Click);
            // 
            // frmZona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 324);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmZona";
            this.Text = "Zona";
            this.Load += new System.EventHandler(this.frmZona_Load);
            this.tabControl1.ResumeLayout(false);
            this.tpIngresarZona.ResumeLayout(false);
            this.tpIngresarZona.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbInfoZona.ResumeLayout(false);
            this.gbInfoZona.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tpConsultarZona.ResumeLayout(false);
            this.tpConsultarZona.PerformLayout();
            this.gbBuscarZonaNombre.ResumeLayout(false);
            this.gbBuscarZonaNombre.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgbZona)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpIngresarZona;
        private System.Windows.Forms.TabPage tpConsultarZona;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbGuardarZona;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton tsbEditarZona;
        private System.Windows.Forms.ToolStripButton tsbEliminarZona;
        private System.Windows.Forms.ToolStripButton tsbSalirConsultarZona;
        private System.Windows.Forms.GroupBox gbInfoZona;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtCapacidadZona;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNumeroZona;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreZona;
        private System.Windows.Forms.TextBox txtUbicacionBodega;
        private System.Windows.Forms.TextBox txtNombreBodega;
        private System.Windows.Forms.Button btnAgregarBodegaZona;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgbZona;
        private System.Windows.Forms.GroupBox gbBuscarZonaNombre;
        private System.Windows.Forms.TextBox txtBuscarZona;
        private System.Windows.Forms.Button btnListarZona;
        private System.Windows.Forms.ComboBox cbxBusquedaZona;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.ToolStripButton tsbbtnListarZona;
        private System.Windows.Forms.ToolStripButton tsbbtnsalir;
    }
}