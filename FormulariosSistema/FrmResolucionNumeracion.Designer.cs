namespace FormulariosSistema
{
    partial class FrmResolucionNumeracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResolucionNumeracion));
            this.lblNit = new System.Windows.Forms.Label();
            this.txtNumeroFormulario = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.nudVigencia = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTipoSolicitud = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNumeroFinal = new System.Windows.Forms.TextBox();
            this.txtNumeroInicial = new System.Windows.Forms.TextBox();
            this.txtVigencia = new System.Windows.Forms.TextBox();
            this.txtPrefijo = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvFormularios = new System.Windows.Forms.DataGridView();
            this.Codigo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Name_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricpcion_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVigencia)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormularios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNit
            // 
            this.lblNit.AutoSize = true;
            this.lblNit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNit.Location = new System.Drawing.Point(7, 24);
            this.lblNit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNit.Name = "lblNit";
            this.lblNit.Size = new System.Drawing.Size(137, 16);
            this.lblNit.TabIndex = 3;
            this.lblNit.Text = "Número de formulario";
            // 
            // txtNumeroFormulario
            // 
            this.txtNumeroFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNumeroFormulario.Location = new System.Drawing.Point(8, 42);
            this.txtNumeroFormulario.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroFormulario.MaxLength = 50;
            this.txtNumeroFormulario.Name = "txtNumeroFormulario";
            this.txtNumeroFormulario.Size = new System.Drawing.Size(161, 22);
            this.txtNumeroFormulario.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox2.Controls.Add(this.btnGuardar);
            this.groupBox2.Controls.Add(this.nudVigencia);
            this.groupBox2.Controls.Add(this.dtpFecha);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cbTipoSolicitud);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lblNit);
            this.groupBox2.Controls.Add(this.txtNumeroFinal);
            this.groupBox2.Controls.Add(this.txtNumeroInicial);
            this.groupBox2.Controls.Add(this.txtVigencia);
            this.groupBox2.Controls.Add(this.txtPrefijo);
            this.groupBox2.Controls.Add(this.txtNumeroFormulario);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(745, 170);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FACTURACION ELECTRONICA DE VENTA";
            // 
            // btnGuardar
            // 
            this.btnGuardar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardar.Location = new System.Drawing.Point(664, 125);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(73, 38);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // nudVigencia
            // 
            this.nudVigencia.Location = new System.Drawing.Point(398, 95);
            this.nudVigencia.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudVigencia.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudVigencia.Name = "nudVigencia";
            this.nudVigencia.Size = new System.Drawing.Size(59, 22);
            this.nudVigencia.TabIndex = 5;
            this.nudVigencia.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(179, 42);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(125, 22);
            this.dtpFecha.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(396, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vigencia";
            // 
            // cbTipoSolicitud
            // 
            this.cbTipoSolicitud.DisplayMember = "descripcion";
            this.cbTipoSolicitud.FormattingEnabled = true;
            this.cbTipoSolicitud.Location = new System.Drawing.Point(561, 94);
            this.cbTipoSolicitud.Margin = new System.Windows.Forms.Padding(4);
            this.cbTipoSolicitud.Name = "cbTipoSolicitud";
            this.cbTipoSolicitud.Size = new System.Drawing.Size(176, 24);
            this.cbTipoSolicitud.TabIndex = 6;
            this.cbTipoSolicitud.ValueMember = "code";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(558, 77);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tipo solicitud";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(250, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Hasta número";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(102, 77);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(97, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Desde número";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(7, 76);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(46, 16);
            this.label13.TabIndex = 3;
            this.label13.Text = "Prefijo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(177, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fecha";
            // 
            // txtNumeroFinal
            // 
            this.txtNumeroFinal.Location = new System.Drawing.Point(251, 95);
            this.txtNumeroFinal.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroFinal.MaxLength = 250;
            this.txtNumeroFinal.Name = "txtNumeroFinal";
            this.txtNumeroFinal.Size = new System.Drawing.Size(140, 22);
            this.txtNumeroFinal.TabIndex = 4;
            // 
            // txtNumeroInicial
            // 
            this.txtNumeroInicial.Location = new System.Drawing.Point(103, 95);
            this.txtNumeroInicial.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroInicial.MaxLength = 250;
            this.txtNumeroInicial.Name = "txtNumeroInicial";
            this.txtNumeroInicial.Size = new System.Drawing.Size(140, 22);
            this.txtNumeroInicial.TabIndex = 3;
            // 
            // txtVigencia
            // 
            this.txtVigencia.Location = new System.Drawing.Point(464, 95);
            this.txtVigencia.Margin = new System.Windows.Forms.Padding(4);
            this.txtVigencia.MaxLength = 250;
            this.txtVigencia.Name = "txtVigencia";
            this.txtVigencia.ReadOnly = true;
            this.txtVigencia.Size = new System.Drawing.Size(87, 22);
            this.txtVigencia.TabIndex = 8;
            // 
            // txtPrefijo
            // 
            this.txtPrefijo.Location = new System.Drawing.Point(8, 95);
            this.txtPrefijo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrefijo.MaxLength = 250;
            this.txtPrefijo.Name = "txtPrefijo";
            this.txtPrefijo.Size = new System.Drawing.Size(87, 22);
            this.txtPrefijo.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox4.Controls.Add(this.btnEliminar);
            this.groupBox4.Controls.Add(this.dgvFormularios);
            this.groupBox4.ForeColor = System.Drawing.Color.Blue;
            this.groupBox4.Location = new System.Drawing.Point(3, 180);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(745, 354);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "LISTADO DE FORMULARIOS";
            // 
            // btnEliminar
            // 
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminar.Location = new System.Drawing.Point(664, 310);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(73, 38);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dgvFormularios
            // 
            this.dgvFormularios.AllowUserToAddRows = false;
            this.dgvFormularios.BackgroundColor = System.Drawing.Color.MintCream;
            this.dgvFormularios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormularios.ColumnHeadersVisible = false;
            this.dgvFormularios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo_,
            this.Name_,
            this.Descricpcion_});
            this.dgvFormularios.Location = new System.Drawing.Point(6, 21);
            this.dgvFormularios.Name = "dgvFormularios";
            this.dgvFormularios.RowHeadersVisible = false;
            this.dgvFormularios.Size = new System.Drawing.Size(731, 283);
            this.dgvFormularios.TabIndex = 0;
            // 
            // Codigo_
            // 
            this.Codigo_.DataPropertyName = "codigo";
            this.Codigo_.HeaderText = "";
            this.Codigo_.Name = "Codigo_";
            this.Codigo_.Width = 34;
            // 
            // Name_
            // 
            this.Name_.DataPropertyName = "nombre";
            this.Name_.HeaderText = "";
            this.Name_.Name = "Name_";
            this.Name_.Width = 74;
            // 
            // Descricpcion_
            // 
            this.Descricpcion_.DataPropertyName = "descripcion";
            this.Descricpcion_.HeaderText = "";
            this.Descricpcion_.Name = "Descricpcion_";
            this.Descricpcion_.Width = 226;
            // 
            // FrmResolucionNumeracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(791, 546);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmResolucionNumeracion";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RESOLUCION NÚMERACION";
            this.Load += new System.EventHandler(this.FrmResolucionNumeracion_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVigencia)).EndInit();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormularios)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblNit;
        public System.Windows.Forms.TextBox txtNumeroFormulario;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtPrefijo;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtNumeroInicial;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbTipoSolicitud;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvFormularios;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricpcion_;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox txtNumeroFinal;
        private System.Windows.Forms.NumericUpDown nudVigencia;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtVigencia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEliminar;
    }
}