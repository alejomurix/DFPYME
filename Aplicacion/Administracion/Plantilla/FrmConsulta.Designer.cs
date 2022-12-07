namespace Aplicacion.Administracion.Plantilla
{
    partial class FrmConsulta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConsulta));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.btnSalir = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgPlantillas = new System.Windows.Forms.DataGridView();
            this.btnNuevoPlantilla = new System.Windows.Forms.ToolStripButton();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Concepto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsMenu.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlantillas)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSalir,
            this.btnNuevoPlantilla});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(588, 25);
            this.tsMenu.TabIndex = 3;
            this.tsMenu.Text = "Menu";
            // 
            // btnSalir
            // 
            this.btnSalir.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSalir.Image = ((System.Drawing.Image)(resources.GetObject("btnSalir.Image")));
            this.btnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(87, 22);
            this.btnSalir.Text = "Salir [ESC]";
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgPlantillas);
            this.groupBox1.Location = new System.Drawing.Point(16, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(556, 405);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            // 
            // dgPlantillas
            // 
            this.dgPlantillas.AllowUserToAddRows = false;
            this.dgPlantillas.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgPlantillas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlantillas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.Codigo,
            this.Concepto});
            this.dgPlantillas.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgPlantillas.Location = new System.Drawing.Point(13, 19);
            this.dgPlantillas.Name = "dgPlantillas";
            this.dgPlantillas.RowHeadersVisible = false;
            this.dgPlantillas.Size = new System.Drawing.Size(528, 370);
            this.dgPlantillas.TabIndex = 1;
            // 
            // btnNuevoPlantilla
            // 
            this.btnNuevoPlantilla.Font = new System.Drawing.Font("Tahoma", 8.5F);
            this.btnNuevoPlantilla.Image = ((System.Drawing.Image)(resources.GetObject("btnNuevoPlantilla.Image")));
            this.btnNuevoPlantilla.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevoPlantilla.Name = "btnNuevoPlantilla";
            this.btnNuevoPlantilla.Size = new System.Drawing.Size(89, 22);
            this.btnNuevoPlantilla.Text = "Nuevo [F3]";
            this.btnNuevoPlantilla.ToolTipText = "Nuevo [F3]";
            this.btnNuevoPlantilla.Click += new System.EventHandler(this.btnNuevoPlantilla_Click);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "Código";
            this.Codigo.Name = "Codigo";
            this.Codigo.Width = 70;
            // 
            // Concepto
            // 
            this.Concepto.DataPropertyName = "concepto";
            this.Concepto.HeaderText = "Concepto";
            this.Concepto.Name = "Concepto";
            this.Concepto.Width = 450;
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(588, 449);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tsMenu);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConsulta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plantillas";
            this.Load += new System.EventHandler(this.FrmConsulta_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmConsulta_KeyDown);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPlantillas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgPlantillas;
        private System.Windows.Forms.ToolStripButton btnNuevoPlantilla;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Concepto;
    }
}