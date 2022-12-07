namespace Aplicacion.Compras.IngresarCompra
{
    partial class frmMedidaColor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedidaColor));
            this.tsMenu = new System.Windows.Forms.ToolStrip();
            this.tsBtnAceptar = new System.Windows.Forms.ToolStripButton();
            this.gbTalla = new System.Windows.Forms.GroupBox();
            this.dgvTalla = new System.Windows.Forms.DataGridView();
            this.IdMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Talla = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbColor = new System.Windows.Forms.GroupBox();
            this.dgvColor = new System.Windows.Forms.DataGridView();
            this.IdColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Color = new System.Windows.Forms.DataGridViewImageColumn();
            this.tsMenu.SuspendLayout();
            this.gbTalla.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalla)).BeginInit();
            this.gbColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).BeginInit();
            this.SuspendLayout();
            // 
            // tsMenu
            // 
            this.tsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsBtnAceptar});
            this.tsMenu.Location = new System.Drawing.Point(0, 0);
            this.tsMenu.Name = "tsMenu";
            this.tsMenu.Size = new System.Drawing.Size(358, 25);
            this.tsMenu.TabIndex = 0;
            this.tsMenu.Text = "Menu";
            // 
            // tsBtnAceptar
            // 
            this.tsBtnAceptar.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.tsBtnAceptar.Image = ((System.Drawing.Image)(resources.GetObject("tsBtnAceptar.Image")));
            this.tsBtnAceptar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsBtnAceptar.Name = "tsBtnAceptar";
            this.tsBtnAceptar.Size = new System.Drawing.Size(105, 22);
            this.tsBtnAceptar.Text = "Aceptar [F12]";
            this.tsBtnAceptar.Click += new System.EventHandler(this.tsBtnAceptar_Click);
            // 
            // gbTalla
            // 
            this.gbTalla.Controls.Add(this.dgvTalla);
            this.gbTalla.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.gbTalla.Location = new System.Drawing.Point(18, 32);
            this.gbTalla.Name = "gbTalla";
            this.gbTalla.Size = new System.Drawing.Size(150, 270);
            this.gbTalla.TabIndex = 1;
            this.gbTalla.TabStop = false;
            this.gbTalla.Text = "Talla";
            // 
            // dgvTalla
            // 
            this.dgvTalla.AllowUserToAddRows = false;
            this.dgvTalla.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTalla.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvTalla.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTalla.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdMedida,
            this.Talla});
            this.dgvTalla.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTalla.Location = new System.Drawing.Point(6, 20);
            this.dgvTalla.Name = "dgvTalla";
            this.dgvTalla.Size = new System.Drawing.Size(138, 244);
            this.dgvTalla.TabIndex = 0;
            this.dgvTalla.Click += new System.EventHandler(this.dgvTalla_Click);
            // 
            // IdMedida
            // 
            this.IdMedida.DataPropertyName = "idvalor_unidad_medida";
            this.IdMedida.HeaderText = "Id";
            this.IdMedida.Name = "IdMedida";
            this.IdMedida.Visible = false;
            // 
            // Talla
            // 
            this.Talla.DataPropertyName = "descripcionvalor_unidad_medida";
            this.Talla.HeaderText = "Talla";
            this.Talla.Name = "Talla";
            // 
            // gbColor
            // 
            this.gbColor.Controls.Add(this.dgvColor);
            this.gbColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F);
            this.gbColor.Location = new System.Drawing.Point(188, 32);
            this.gbColor.Name = "gbColor";
            this.gbColor.Size = new System.Drawing.Size(150, 270);
            this.gbColor.TabIndex = 2;
            this.gbColor.TabStop = false;
            this.gbColor.Text = "Color";
            // 
            // dgvColor
            // 
            this.dgvColor.AllowUserToAddRows = false;
            this.dgvColor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvColor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvColor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvColor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdColor,
            this.Color});
            this.dgvColor.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvColor.Location = new System.Drawing.Point(6, 20);
            this.dgvColor.Name = "dgvColor";
            this.dgvColor.Size = new System.Drawing.Size(138, 244);
            this.dgvColor.TabIndex = 1;
            // 
            // IdColor
            // 
            this.IdColor.DataPropertyName = "IdColor";
            this.IdColor.HeaderText = "Id";
            this.IdColor.Name = "IdColor";
            this.IdColor.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IdColor.Visible = false;
            // 
            // Color
            // 
            this.Color.DataPropertyName = "ImagenBit";
            this.Color.HeaderText = "Color";
            this.Color.Name = "Color";
            this.Color.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Color.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // frmMedidaColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(358, 324);
            this.Controls.Add(this.tsMenu);
            this.Controls.Add(this.gbTalla);
            this.Controls.Add(this.gbColor);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMedidaColor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMedidaColor_FormClosing);
            this.Load += new System.EventHandler(this.frmMedidaColor_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMedidaColor_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.frmMedidaColor_KeyUp);
            this.tsMenu.ResumeLayout(false);
            this.tsMenu.PerformLayout();
            this.gbTalla.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTalla)).EndInit();
            this.gbColor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsMenu;
        private System.Windows.Forms.ToolStripButton tsBtnAceptar;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Talla;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdColor;
        private System.Windows.Forms.DataGridViewImageColumn Color;
        private System.Windows.Forms.GroupBox gbTalla;
        private System.Windows.Forms.GroupBox gbColor;
        private System.Windows.Forms.DataGridView dgvTalla;
        private System.Windows.Forms.DataGridView dgvColor;
    }
}