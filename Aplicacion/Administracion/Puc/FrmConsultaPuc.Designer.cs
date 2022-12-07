namespace Aplicacion.Administracion.Puc
{
    partial class FrmConsultaPuc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsultaPuc));
            this.gbGrupos = new System.Windows.Forms.GroupBox();
            this.rBtnTodos = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo1 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo2 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo3 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo4 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo5 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo6 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo7 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo8 = new System.Windows.Forms.RadioButton();
            this.rBtnGrupo9 = new System.Windows.Forms.RadioButton();
            this.gbConsultas = new System.Windows.Forms.GroupBox();
            this.dgvCuentas = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Estado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Aplica = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.tsBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.tsSalir = new System.Windows.Forms.ToolStripButton();
            this.gbGrupos.SuspendLayout();
            this.gbConsultas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).BeginInit();
            this.tsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbGrupos
            // 
            this.gbGrupos.Controls.Add(this.rBtnTodos);
            this.gbGrupos.Controls.Add(this.rBtnGrupo1);
            this.gbGrupos.Controls.Add(this.rBtnGrupo2);
            this.gbGrupos.Controls.Add(this.rBtnGrupo3);
            this.gbGrupos.Controls.Add(this.rBtnGrupo4);
            this.gbGrupos.Controls.Add(this.rBtnGrupo5);
            this.gbGrupos.Controls.Add(this.rBtnGrupo6);
            this.gbGrupos.Controls.Add(this.rBtnGrupo7);
            this.gbGrupos.Controls.Add(this.rBtnGrupo8);
            this.gbGrupos.Controls.Add(this.rBtnGrupo9);
            this.gbGrupos.Location = new System.Drawing.Point(11, 33);
            this.gbGrupos.Name = "gbGrupos";
            this.gbGrupos.Size = new System.Drawing.Size(178, 372);
            this.gbGrupos.TabIndex = 2;
            this.gbGrupos.TabStop = false;
            // 
            // rBtnTodos
            // 
            this.rBtnTodos.AutoSize = true;
            this.rBtnTodos.Checked = true;
            this.rBtnTodos.Location = new System.Drawing.Point(18, 33);
            this.rBtnTodos.Name = "rBtnTodos";
            this.rBtnTodos.Size = new System.Drawing.Size(132, 20);
            this.rBtnTodos.TabIndex = 0;
            this.rBtnTodos.TabStop = true;
            this.rBtnTodos.Text = "Todos los grupos";
            this.rBtnTodos.UseVisualStyleBackColor = true;
            this.rBtnTodos.Click += new System.EventHandler(this.rBtnTodos_Click);
            // 
            // rBtnGrupo1
            // 
            this.rBtnGrupo1.AutoSize = true;
            this.rBtnGrupo1.Location = new System.Drawing.Point(18, 64);
            this.rBtnGrupo1.Name = "rBtnGrupo1";
            this.rBtnGrupo1.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo1.TabIndex = 1;
            this.rBtnGrupo1.TabStop = true;
            this.rBtnGrupo1.Text = "Mostrar grupo 1";
            this.rBtnGrupo1.UseVisualStyleBackColor = true;
            this.rBtnGrupo1.Click += new System.EventHandler(this.rBtnGrupo1_Click);
            // 
            // rBtnGrupo2
            // 
            this.rBtnGrupo2.AutoSize = true;
            this.rBtnGrupo2.Location = new System.Drawing.Point(18, 97);
            this.rBtnGrupo2.Name = "rBtnGrupo2";
            this.rBtnGrupo2.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo2.TabIndex = 1;
            this.rBtnGrupo2.TabStop = true;
            this.rBtnGrupo2.Text = "Mostrar grupo 2";
            this.rBtnGrupo2.UseVisualStyleBackColor = true;
            this.rBtnGrupo2.Click += new System.EventHandler(this.rBtnGrupo2_Click);
            // 
            // rBtnGrupo3
            // 
            this.rBtnGrupo3.AutoSize = true;
            this.rBtnGrupo3.Location = new System.Drawing.Point(18, 130);
            this.rBtnGrupo3.Name = "rBtnGrupo3";
            this.rBtnGrupo3.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo3.TabIndex = 1;
            this.rBtnGrupo3.TabStop = true;
            this.rBtnGrupo3.Text = "Mostrar grupo 3";
            this.rBtnGrupo3.UseVisualStyleBackColor = true;
            this.rBtnGrupo3.Click += new System.EventHandler(this.rBtnGrupo3_Click);
            // 
            // rBtnGrupo4
            // 
            this.rBtnGrupo4.AutoSize = true;
            this.rBtnGrupo4.Location = new System.Drawing.Point(18, 159);
            this.rBtnGrupo4.Name = "rBtnGrupo4";
            this.rBtnGrupo4.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo4.TabIndex = 1;
            this.rBtnGrupo4.TabStop = true;
            this.rBtnGrupo4.Text = "Mostrar grupo 4";
            this.rBtnGrupo4.UseVisualStyleBackColor = true;
            this.rBtnGrupo4.Click += new System.EventHandler(this.rBtnGrupo4_Click);
            // 
            // rBtnGrupo5
            // 
            this.rBtnGrupo5.AutoSize = true;
            this.rBtnGrupo5.Location = new System.Drawing.Point(18, 190);
            this.rBtnGrupo5.Name = "rBtnGrupo5";
            this.rBtnGrupo5.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo5.TabIndex = 1;
            this.rBtnGrupo5.TabStop = true;
            this.rBtnGrupo5.Text = "Mostrar grupo 5";
            this.rBtnGrupo5.UseVisualStyleBackColor = true;
            this.rBtnGrupo5.Click += new System.EventHandler(this.rBtnGrupo5_Click);
            // 
            // rBtnGrupo6
            // 
            this.rBtnGrupo6.AutoSize = true;
            this.rBtnGrupo6.Location = new System.Drawing.Point(18, 221);
            this.rBtnGrupo6.Name = "rBtnGrupo6";
            this.rBtnGrupo6.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo6.TabIndex = 1;
            this.rBtnGrupo6.TabStop = true;
            this.rBtnGrupo6.Text = "Mostrar grupo 6";
            this.rBtnGrupo6.UseVisualStyleBackColor = true;
            this.rBtnGrupo6.Click += new System.EventHandler(this.rBtnGrupo6_Click);
            // 
            // rBtnGrupo7
            // 
            this.rBtnGrupo7.AutoSize = true;
            this.rBtnGrupo7.Location = new System.Drawing.Point(18, 251);
            this.rBtnGrupo7.Name = "rBtnGrupo7";
            this.rBtnGrupo7.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo7.TabIndex = 2;
            this.rBtnGrupo7.TabStop = true;
            this.rBtnGrupo7.Text = "Mostrar grupo 7";
            this.rBtnGrupo7.UseVisualStyleBackColor = true;
            this.rBtnGrupo7.Click += new System.EventHandler(this.rBtnGrupo7_Click);
            // 
            // rBtnGrupo8
            // 
            this.rBtnGrupo8.AutoSize = true;
            this.rBtnGrupo8.Location = new System.Drawing.Point(18, 283);
            this.rBtnGrupo8.Name = "rBtnGrupo8";
            this.rBtnGrupo8.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo8.TabIndex = 3;
            this.rBtnGrupo8.TabStop = true;
            this.rBtnGrupo8.Text = "Mostrar grupo 8";
            this.rBtnGrupo8.UseVisualStyleBackColor = true;
            this.rBtnGrupo8.Click += new System.EventHandler(this.rBtnGrupo8_Click);
            // 
            // rBtnGrupo9
            // 
            this.rBtnGrupo9.AutoSize = true;
            this.rBtnGrupo9.Location = new System.Drawing.Point(18, 315);
            this.rBtnGrupo9.Name = "rBtnGrupo9";
            this.rBtnGrupo9.Size = new System.Drawing.Size(119, 20);
            this.rBtnGrupo9.TabIndex = 4;
            this.rBtnGrupo9.TabStop = true;
            this.rBtnGrupo9.Text = "Mostrar grupo 9";
            this.rBtnGrupo9.UseVisualStyleBackColor = true;
            this.rBtnGrupo9.Click += new System.EventHandler(this.rBtnGrupo9_Click);
            // 
            // gbConsultas
            // 
            this.gbConsultas.Controls.Add(this.dgvCuentas);
            this.gbConsultas.Location = new System.Drawing.Point(195, 33);
            this.gbConsultas.Name = "gbConsultas";
            this.gbConsultas.Size = new System.Drawing.Size(540, 372);
            this.gbConsultas.TabIndex = 3;
            this.gbConsultas.TabStop = false;
            // 
            // dgvCuentas
            // 
            this.dgvCuentas.AllowUserToAddRows = false;
            this.dgvCuentas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Numero,
            this.Nombre,
            this.Estado,
            this.Aplica});
            this.dgvCuentas.Location = new System.Drawing.Point(6, 13);
            this.dgvCuentas.Name = "dgvCuentas";
            this.dgvCuentas.RowHeadersVisible = false;
            this.dgvCuentas.Size = new System.Drawing.Size(528, 353);
            this.dgvCuentas.TabIndex = 1;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Cuenta";
            this.Numero.Name = "Numero";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 307;
            // 
            // Estado
            // 
            this.Estado.DataPropertyName = "Estado";
            this.Estado.HeaderText = "Estado";
            this.Estado.Name = "Estado";
            // 
            // Aplica
            // 
            this.Aplica.DataPropertyName = "Aplica";
            this.Aplica.HeaderText = "Aplica";
            this.Aplica.Name = "Aplica";
            this.Aplica.Visible = false;
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnGuardar,
            this.tsBtnNuevo,
            this.tsSalir});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(751, 25);
            this.tsMenu.TabIndex = 4;
            this.tsMenu.Text = "toolStrip1";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(102, 22);
            this.btnGuardar.Text = "Guardar [F2]";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // tsBtnNuevo
            // 
            this.tsBtnNuevo.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnNuevo.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnNuevo.Image")));
            this.tsBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnNuevo.Name = "tsBtnNuevo";
            this.tsBtnNuevo.Size = new System.Drawing.Size(132, 22);
            this.tsBtnNuevo.Text = "Nueva cuenta [F3]";
            this.tsBtnNuevo.Click += new System.EventHandler(this.tsBtnNuevo_Click);
            // 
            // tsSalir
            // 
            this.tsSalir.Font = new System.Drawing.Font("Tahoma", 9.5F);
            this.tsSalir.Image = ((System.Drawing.Image)(resources.GetObject("tsSalir.Image")));
            this.tsSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsSalir.Name = "tsSalir";
            this.tsSalir.Size = new System.Drawing.Size(91, 22);
            this.tsSalir.Text = "Salir [ESC]";
            this.tsSalir.Click += new System.EventHandler(this.tsSalir_Click);
            // 
            // FrmConsultaPuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(751, 416);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbGrupos);
            this.Controls.Add(this.gbConsultas);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsultaPuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plan Contable";
            this.Load += new System.EventHandler(this.FrmConsultaPuc_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsultaPuc_KeyDown);
            this.gbGrupos.ResumeLayout(false);
            this.gbGrupos.PerformLayout();
            this.gbConsultas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuentas)).EndInit();
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbGrupos;
        private System.Windows.Forms.RadioButton rBtnGrupo1;
        private System.Windows.Forms.RadioButton rBtnTodos;
        private System.Windows.Forms.RadioButton rBtnGrupo8;
        private System.Windows.Forms.RadioButton rBtnGrupo7;
        private System.Windows.Forms.RadioButton rBtnGrupo5;
        private System.Windows.Forms.RadioButton rBtnGrupo6;
        private System.Windows.Forms.RadioButton rBtnGrupo4;
        private System.Windows.Forms.RadioButton rBtnGrupo3;
        private System.Windows.Forms.GroupBox gbConsultas;
        private System.Windows.Forms.RadioButton rBtnGrupo9;
        private System.Windows.Forms.RadioButton rBtnGrupo2;
        private System.Windows.Forms.DataGridView dgvCuentas;
        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnGuardar;
        private System.Windows.Forms.ToolStripButton tsSalir;
        private System.Windows.Forms.ToolStripButton tsBtnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplica;
    }
}