namespace Aplicacion.Inventario.Cruce
{
    partial class FrmCorte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCorte));
            this.dgvCorte = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbCorte = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorte)).BeginInit();
            this.gbCorte.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCorte
            // 
            this.dgvCorte.AllowUserToAddRows = false;
            this.dgvCorte.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvCorte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCorte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Fecha});
            this.dgvCorte.Location = new System.Drawing.Point(6, 12);
            this.dgvCorte.Name = "dgvCorte";
            this.dgvCorte.Size = new System.Drawing.Size(247, 268);
            this.dgvCorte.TabIndex = 0;
            this.dgvCorte.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCorte_CellDoubleClick);
            // 
            // Numero
            // 
            this.Numero.DataPropertyName = "numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            // 
            // Fecha
            // 
            this.Fecha.DataPropertyName = "fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            // 
            // gbCorte
            // 
            this.gbCorte.Controls.Add(this.dgvCorte);
            this.gbCorte.Location = new System.Drawing.Point(12, 2);
            this.gbCorte.Name = "gbCorte";
            this.gbCorte.Size = new System.Drawing.Size(260, 288);
            this.gbCorte.TabIndex = 1;
            this.gbCorte.TabStop = false;
            // 
            // FrmCorte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(287, 299);
            this.Controls.Add(this.gbCorte);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmCorte";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cortes y fecha";
            this.Load += new System.EventHandler(this.FrmCorte_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCorte_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCorte)).EndInit();
            this.gbCorte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCorte;
        private System.Windows.Forms.GroupBox gbCorte;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
    }
}